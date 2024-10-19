using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    [Header("Load Hlobals JSON")]
    [SerializeField] private TextAsset loadGlobaJSON;

    [Header("Parameters")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [Tooltip("Painel do dialogo no Canvas")]
    [SerializeField] private GameObject panelDialogue;
    [SerializeField] private GameObject panelBackground;
    [Tooltip("Texto do dialogo no Canvas")]
    [SerializeField] private TextMeshProUGUI txtDialogue;
    [Tooltip("Botao para continuar o dialogo no Canvas")]
    [SerializeField] private GameObject btnContinue;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] txtChoices;

    [Header("Debug Informations")]
    //Se o dialogo esta ativo ou nao, use para bloquear acoes de outros scripts, exemplo movimentacao do player
    //get; private set; para que outros scripts consigam apenas ver a informacao e nao alterar 
    public bool isDialoguePlaying { get; private set; }
    [SerializeField] private Story currentStory;
    private bool isDialogTyping = false;
    private bool isSkipPressed = false;
    private bool isAddingRichTextTag = false;
    private DialogueVariables dialogueVariables;

    //Sistema de dialogo, mostrando linha por linha e ate recebendo tags, passando as para o DialogueTags
    //Para usar basta essa linha em outros scripts: DialogueManager.Instance.EnterDialogueMode(TextAsset) TextAsset sendo o arquivo Ink do dialogo
    //Video de referencia https://www.youtube.com/watch?v=vY0Sk93YUhA

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }

        Instance = this;

        dialogueVariables = new DialogueVariables(loadGlobaJSON);
    }

    private void Start()
    {
        isDialoguePlaying = false;
        panelDialogue.SetActive(false);
        panelBackground.SetActive(false);
        btnContinue.SetActive(true);

        //Pega todos os objetos de textos do canvas de escolhas
        txtChoices = new TextMeshProUGUI[choices.Length];
        int _index = 0;
        foreach (GameObject choice in choices)
        {
            txtChoices[_index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            _index++;
        }
    }

    private void Update()
    {
        //Forma temporaria de incluir o input mas bloquear sua acao quando opcoes estao na tela
        if(InputManager.Instance.GetNextLinePressed() && btnContinue.activeInHierarchy)
        {
            ContinueStory();
        }
    }

    /// <summary>
    /// Comeca um dialogo, precisa ser passado um TextAsset que inclui todas as linhbas do texto
    /// </summary>
    /// <param name="inkJSON">Texto do dialogo</param>
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        panelDialogue.SetActive(true);
        panelBackground.SetActive(true);

        //Seta o estado do jogo como dialogo
        GameStates.Instance.SetStateDialogue();

        //Comeca a gravar as variaveis globais alteradas nesse dialogo
        dialogueVariables.StartListening(currentStory);

        //Reseta as tags no inicio de cada dialogo
        if(DialogueTags.Instance != null)
        {
            DialogueTags.Instance.ResetTags();
        }

        ContinueStory();
    }

    //Sai do dialogo, com um delay para que nao ative outras acoes com o mesmo botao usado
    //caso seja usado um botao para continuar/sair do dialogo
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.1f);

        //Para de gravar as alteracoes das variaveis globais nesse dialogo
        dialogueVariables.StopListening(currentStory);

        isDialoguePlaying = false;
        panelDialogue.SetActive(false);
        panelBackground.SetActive(false);
        btnContinue.SetActive(true);
        txtDialogue.text = "";

        //Volta o jogo para o estado anterior
        GameStates.Instance.SetStatePrevious();

        //Temporario ate uma solucao melhor
        if(FirstAndLastDialogues.Instance != null)
        {
            FirstAndLastDialogues.Instance.UniqueDialogueEnded();
        }
    }

    /// <summary>
    /// Continua a historia com o TextAsset atual, ou finaliza quando acabar o dialogo
    /// </summary>
    public void ContinueStory()
    {
        //Checa se o dialogo ainda esta na animacao de digitacao, se estivar pula para o final
        if (isDialogTyping)
        {
            isSkipPressed = true;
            return;
        }

        if (currentStory.canContinue)
        {

            //Reseta a visibilidade do botao de continuar para visivel novamente
            btnContinue.SetActive(true);

            //Seta o texto para a proxima linha do dialogo
            StartCoroutine(DisplayLine(currentStory.Continue()));


            //Manda as tags para o DialogueTags onde sera feito o processamento e agir de acordo
            if(DialogueTags.Instance != null)
            {
                DialogueTags.Instance.HandleTags(currentStory.currentTags);
            }
            else
            {
                Debug.LogWarning("DialogueTags not found, tags are not being handled");
            }

        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        isDialogTyping = true;

        //Inicializa o texto inteiro, mas seta caracteres visiveis para 0
        txtDialogue.text = line;
        txtDialogue.maxVisibleCharacters = 0;

        //Esconde objetos enquanto esta digitando
        HideChoices();

        //Mostra uma letra de cada vez
        foreach(char letter in line.ToCharArray())
        {
            if(isSkipPressed)
            {
                txtDialogue.maxVisibleCharacters = line.Length;
                break;
            }

            //Checa por Rich Text <>, se encontrado, adiciona diretamente sem animacao
            if(letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if(letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            //Nao possui Rich Text entao adiciona a letra normalmente depois de um tempo muito pequeno
            else
            {
                txtDialogue.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        //Mostra as escolhas, caso tenha alguma nessa linha de dialogo
        DisplayChoices();

        isDialogTyping = false;
        isSkipPressed = false;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices givem: "
                + currentChoices.Count);
        }

        int _index = 0;

        //Ativa os objetos de texto para as escolhas ate a quantidade necessaria para essa parte do dialogo
        foreach (Choice choice in currentChoices)
        {
            choices[_index].gameObject.SetActive(true);
            txtChoices[_index].text = choice.text;
            _index++;

            //Desativa botao de continuar, em vez disso o botao das escolhas fazem esse papel
            btnContinue.SetActive(false);
        }

        //Desativa os objetos de texto restantes que nao serao usados
        for (int i = _index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    private void HideChoices()
    {
        foreach(GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="variableName"></param>
    /// <returns></returns>
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }
}
