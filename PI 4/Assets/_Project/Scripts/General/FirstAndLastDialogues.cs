using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAndLastDialogues : MonoBehaviour
{
    public static FirstAndLastDialogues Instance;

    public TextAsset firstDialogue;
    public TextAsset lastDialogue;
    public bool hasFirstDialogue = false;
    public bool hasLastDialogue = false;
    //Se o primeiro dialogo for o unico dialogo da cena
    //Temporario ate uma solucao melhor
    public bool uniqueDialogue = false;
    public bool afterBoss = false;

    public bool tutorialHere = false;

    public GameObject panelEnd;

    public LevelLoader levelLoader;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Invoke("StartFirstDialogue", 0.1f);
    }
    
    //Temporario ate uma solucao melhor
    public void UniqueDialogueEnded()
    {
        if(tutorialHere)
        {
            tutorialHere = false;

            //Tutorial temporario
            if (Tutorial.Instance != null)
            {
                Tutorial.Instance.ReceiveTutorialAction(1);
            }
        }

        if(!uniqueDialogue)
        {
            return;
        }

        if(afterBoss)
        {
            panelEnd.SetActive(true);
        }
        else
        {
            levelLoader.LoadLevel("Menu");
        }
    }

    public void StartFirstDialogue()
    {
        if (hasFirstDialogue)
        {
            DialogueManager.Instance.EnterDialogueMode(firstDialogue);
        }
    }
}
