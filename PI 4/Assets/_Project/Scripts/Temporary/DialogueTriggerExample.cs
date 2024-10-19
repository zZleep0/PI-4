using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerExample : MonoBehaviour
{
    [SerializeField] private KeyCode startDialogueKey1 = KeyCode.Q;
    [SerializeField] private KeyCode startDialogueKey2 = KeyCode.E;
    [SerializeField] private TextAsset inkJSON1;
    [SerializeField] private TextAsset inkJSON2;

    //Esse codigo foi criado para testar e servir de exemplo de como usar o DialogueManager
    //Retirar quando fizer seu proprio trigger para ativar o dialogo

    void Update()
    {
        if(Input.GetKeyDown(startDialogueKey1) && !DialogueManager.Instance.isDialoguePlaying)
        {
            DialogueManager.Instance.EnterDialogueMode(inkJSON1);
        }
        else if (Input.GetKeyDown(startDialogueKey2) && !DialogueManager.Instance.isDialoguePlaying)
        {
            DialogueManager.Instance.EnterDialogueMode(inkJSON2);
        }
    }
}
