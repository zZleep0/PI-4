using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTags : MonoBehaviour
{
    public static DialogueTags Instance;

    [Header("Tags Ativas")]
    public bool activeSpeaker = true;

    private const string CHARACTER_TAG = "character";
    private const string NAME_TAG = "name";
    private const string WORD_TAG = "word";

    [Header("Elementos para alterar")]
    [SerializeField] private TextMeshProUGUI nameCharacter;

    //Temporario, a ideia e que instancie na hora o personagem / objeto
    [SerializeField] private GameObject characterCaixa;
    [SerializeField] private GameObject characterPerson;
    [SerializeField] private GameObject characterPlaca;

    //Script para receber tags do ink e rodar os codigos apropriados de acordo com as tags recebidas
    //Para adicionar mais tags, basta criar mais variaveis const string, e adicionar sua funcao no metodo HandleTags
    //Dentro do programa do Ink devera colocar as tags ao lado nas linhas como #nome:valor para que esse script consiga processar
    //Video de referencia https://www.youtube.com/watch?v=tVrxeUIEV9E

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Portraits in the scene");
        }

        Instance = this;
    }

    private void Start()
    {
        characterCaixa.SetActive(false);
        characterPerson.SetActive(false);
        characterPlaca.SetActive(false);
    }

    /// <summary>
    /// Procesa as tags recebidas, agindo de acordo com o requisitado pela linha de dialogo, 
    /// como mostrar imagem de quem esta falando, nome, layout, etc.
    /// </summary>
    /// <param name="currentTags"></param>
    public void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            //Separa as tags entre seu nome e seu valor contido
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropiately parsed " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            //Processa as tags, podendo adicionar mais tags nesse espaco
            switch (tagKey)
            {
                case CHARACTER_TAG:
                    //TEMPORARIO ATE SER FEITO UMA FORMA MELHOR
                    if(tagValue == "caixa")
                    {
                        characterCaixa.SetActive(true);
                        characterPerson.SetActive(false);
                        characterPlaca.SetActive(false);
                    }
                    else if(tagValue == "placa")
                    {
                        characterCaixa.SetActive(false);
                        characterPerson.SetActive(false);
                        characterPlaca.SetActive(true);
                    }
                    else if(tagValue == "character")
                    {
                        characterCaixa.SetActive(false);
                        characterPerson.SetActive(true);
                        characterPlaca.SetActive(false);
                    }
                    else
                    {
                        characterCaixa.SetActive(false);
                        characterPerson.SetActive(false);
                        characterPlaca.SetActive(false);
                    }
                    break;

                case NAME_TAG:
                    nameCharacter.text = tagValue;
                    break;

                case WORD_TAG:
                    if (JornalController.Instance == null)
                    {
                        Debug.LogError("Instance of JornalController not found, necessary for jornal control");
                    }

                    //Tutorial temporario
                    if(Tutorial.Instance != null)
                    {
                        Tutorial.Instance.ReceiveTutorialAction(2);
                    }

                    JornalController.Instance.DiscoverWord(int.Parse(tagValue));
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    /// <summary>
    /// Reseta todas as informacoes de tags, fazendo com que nao aparecam de forma errada entre dialogos diferentes
    /// </summary>
    public void ResetTags()
    {
        //CHARACTER_TAG
        characterCaixa.SetActive(false);
        characterPerson.SetActive(false);
        characterPlaca.SetActive(false);

        //NAME_TAG
        nameCharacter.text = "";
    }

    //Temporario para pegar a cor que devera ser mostrada na imagem
    private Color TempGetColor(string tagValue)
    {
        Color _color = new Color(1,1,1);

        switch(tagValue)
        {
            case "Azul":
                _color = new Color(0,0,1);
                break;
            case "Amarelo":
                _color = new Color(1,1,0);
                break;
            case "Vermelho":
                _color = new Color(1,0,0);
                break;
            case "Roxo":
                _color = new Color(0.5f,0,1);
                break;
            case "Verde":
                _color = new Color(0,1,0);
                break;
            case "Laranja":
                _color = new Color(1,0.5f,0);
                break;
            default:
                _color = new Color(1, 1, 1);
                break;
        }

        return _color;
    }
}
