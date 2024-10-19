using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public static GameStates Instance;

    private InputManager inputManager;

    [SerializeField] private GameObject cameraDialogue;
    
    public enum GameState
    {
        Exploring,
        Dialogue,
        Pause,
        Jornal,
        Menu,
        Boss,
        Transitioning,
        Tutorial,
        Null
    }

    [SerializeField] public GameState gameState; //{ get; private set; }
    private GameState previousGameState;
    private GameState firstPreviousGameState = GameState.Null;

    [SerializeField] private GameState inicialGameState;

    //Corrigir bug de estado agir corretamente quando ambos o jornal esta aberto e o jogo entra em pausa
    private bool isJornalOpen = false;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Found more than one GameStates in the scene");
            Destroy(this);
        }

        Instance = this;

        gameState = inicialGameState;

        if (cameraDialogue != null)
        {
            cameraDialogue.SetActive(false);
        }
    }

    private void Start()
    {
        if (InputManager.Instance != null)
        {
            inputManager = InputManager.Instance;
        }
        else
        {
            Debug.LogError("GameStates could not find InputManager Instance");
        }

        OnChangeState();
    }

    public void SetStateExploring()
    {
        gameState = GameState.Exploring;

        OnChangeState();
    }

    public void SetStateDialogue()
    {
        firstPreviousGameState = gameState;
        previousGameState = gameState;
        gameState = GameState.Dialogue;

        OnChangeState();
    }

    public void SetStatePause()
    {
        if (gameState != GameState.Jornal)
        {
            previousGameState = gameState;
        }

        gameState = GameState.Pause;

        OnChangeState();
    }

    public void SetStateJornal()
    {
        previousGameState = gameState;

        gameState = GameState.Jornal;
        isJornalOpen = true;

        OnChangeState();
    }

    public void SetStateBoss()
    {
        //Ainda nao pronto
        gameState = GameState.Boss;

        OnChangeState();
    }

    public void SetStateTransitioning()
    {
        gameState = GameState.Transitioning;

        OnChangeState();
    }

    public void SetStateTutorial()
    {
        gameState = GameState.Tutorial;

        OnChangeState();
    }

    public void SetStatePrevious()
    {
        if(isJornalOpen)
        {
            gameState = GameState.Jornal;
        }
        else
        {
            if (previousGameState == gameState && firstPreviousGameState != GameState.Null)
            {
                gameState = firstPreviousGameState;
                firstPreviousGameState = GameState.Null;
            }
            else
            {
                gameState = previousGameState;
            }
        }

        OnChangeState();
    }

    private void OnChangeState()
    {
        switch(gameState)
        {
            case GameState.Exploring:
                Time.timeScale = 1f;
                cameraDialogue.SetActive(false);
                inputManager.SwitchToExploringMap();
                break;

            case GameState.Dialogue:
                Time.timeScale = 1f;
                cameraDialogue.SetActive(true);
                inputManager.SwitchToDialogueMap();
                break;

            case GameState.Pause:
                Time.timeScale = 0f;
                inputManager.SwitchToUIMap();
                break;

            case GameState.Jornal:
                Time.timeScale = 0f;
                inputManager.SwitchToJornalMap();
                break;

            case GameState.Menu:
                inputManager.SwitchToUIMap();
                break;

            case GameState.Boss:
                Time.timeScale = 1f;
                //Ainda nao feito
                break;

            case GameState.Transitioning:
                Time.timeScale = 1f;
                inputManager.SwitchOffAll();
                break;

            case GameState.Tutorial:
                Time.timeScale = 0f;
                inputManager.SwitchToUIMap();
                break;
        }
    }

    public void SetStateCloseJornal()
    {
        isJornalOpen = false;
        SetStatePrevious();
    }

    public void SetStateMenu()
    {
        gameState = GameState.Menu;
    }

    public GameState GetState()
    {
        return gameState;
    }
}
