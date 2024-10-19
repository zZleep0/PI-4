using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockInputsWhileWriting : MonoBehaviour
{
    //REQUERIMENTOS PARA O CODIGO FUNCIONAR
    private InputManager inputManager;
    private JornalController jornalController;

    void Start()
    {
        inputManager = InputManager.Instance;
        jornalController = JornalController.Instance;
    }

    void Update()
    {
        if(GameStates.Instance.GetState() != GameStates.GameState.Jornal)
        {
            return;
        }

        if(jornalController.txtFieldDefinition.isFocused ||
            jornalController.txtFieldObservation.isFocused ||
            jornalController.txtFieldObservation2.isFocused)
        {
            inputManager.blockInputWhileWriting = true;
        }
        else
        {
            inputManager.blockInputWhileWriting = false;
        }
    }
}
