using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Esse script age como um unico ponto de referencia para todos os outros scripts
//Ele pega os inputs do Unity new Input System e mapeia os metodos para seus respectivos controles
//Usnado o componente PlayerInput com Unity Events.

[RequireComponent(typeof(PlayerInput))]

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private PlayerInput playerInputs;
    private InputActionMap generalMap;
    private InputActionMap exploringMap;
    private InputActionMap dialogueMap;
    private InputActionMap jornalMap;
    private InputActionMap uiMap;

    private Vector2 moveDirection = Vector2.zero;
    private bool leftclickPressed = false;
    private bool rightclickPressed = false;
    private bool pausePressed = false;
    private bool jornalPressed = false;
    private bool nextlinePressed = false;
    private float moveoptionsPressed = 0f;
    private bool backPressed = false;

    //Bloquear input enquanto digitando, ate achar uma melhor solucao
    public bool blockInputWhileWriting = false;

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("Found more than one Input Manager in the scene");
            Destroy(this);
        }

        Instance = this;

        playerInputs = GetComponent<PlayerInput>();
        generalMap = playerInputs.actions.FindActionMap("General");
        exploringMap = playerInputs.actions.FindActionMap("Exploring");
        dialogueMap = playerInputs.actions.FindActionMap("Dialogue");
        jornalMap = playerInputs.actions.FindActionMap("Jornal");
        uiMap = playerInputs.actions.FindActionMap("UI");

        generalMap.Enable();
    }

    public void SwitchToExploringMap()
    {
        exploringMap.Enable();

        dialogueMap.Disable();
        jornalMap.Disable();
        uiMap.Disable();
    }

    public void SwitchToDialogueMap()
    {
        dialogueMap.Enable();

        exploringMap.Disable();
        jornalMap.Disable();
        uiMap.Disable();
    }

    public void SwitchToJornalMap()
    {
        jornalMap.Enable();

        dialogueMap.Disable();
        exploringMap.Disable();
        uiMap.Disable();
    }

    public void SwitchToUIMap()
    {
        uiMap.Enable();

        dialogueMap.Disable();
        jornalMap.Disable();
        exploringMap.Disable();
    }

    public void SwitchOffAll()
    {
        uiMap.Disable();
        dialogueMap.Disable();
        jornalMap.Disable();
        exploringMap.Disable();
    }

    public void LeftClickPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            leftclickPressed = true;
        }
        else if (context.canceled)
        {
            leftclickPressed = false;
        }
    }

    public void RightClickPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rightclickPressed = true;
        }
        else if (context.canceled)
        {
            rightclickPressed = false;
        }
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void PausePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pausePressed = true;
        }
        else if(context.canceled)
        {
            pausePressed = false;
        }
    }

    public void JornalPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jornalPressed = true;
        }
        else if (context.canceled)
        {
            jornalPressed = false;
        }
    }

    public void NextLinePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            nextlinePressed = true;
        }
        else if (context.canceled)
        {
            nextlinePressed = false;
        }
    }

    public void MoveOptionsPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveoptionsPressed = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            moveoptionsPressed = context.ReadValue<float>();
        }
    }

    public void BackPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            backPressed = true;
        }
        else if (context.canceled)
        {
            backPressed = false;
        }
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public float GetMoveOptionsDirection()
    {
        return moveoptionsPressed;
    }

    public bool GetLeftClickPressed()
    {
        return leftclickPressed;
    }
    public bool GetRightClickPressed()
    {
        return rightclickPressed;
    }

    //Para cada um dos metodos abaixo, se estamos referenciado eles entao tambem estamos o usando
    //Entao devemos seta-los como falsos para que nao sejam usados novamente ate serem apertados de novo

    public bool GetPausePressed()
    {
        if (blockInputWhileWriting)
        {
            return false;
        }

        bool _result = pausePressed;
        pausePressed = false;
        return _result;
    }

    public bool GetJornalPressed()
    {
        if(blockInputWhileWriting)
        {
            return false;
        }

        bool _result = jornalPressed;
        jornalPressed = false;
        return _result;
    }

    public bool GetNextLinePressed()
    {
        bool _result = nextlinePressed;
        nextlinePressed = false;
        return _result;
    }

    public bool GetBackPressed()
    {
        if (blockInputWhileWriting)
        {
            return false;
        }

        bool _result = backPressed;
        backPressed = false;
        return _result;
    }
}
