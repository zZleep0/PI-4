using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelButtons : MonoBehaviour
{
    [Header("Panels HUD")]
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject panelJornal;

    [Header("Panels inside Pause")]
    [SerializeField] private GameObject panelElements;
    [SerializeField] private GameObject panelOptions;

    [Header("Scripts Reference")]
    [SerializeField] private LevelLoader levelLoader;

    [Header("Scene Management")]
    [SerializeField] private bool deactivateJornal = false;

    private void Start()
    {
        panelPausa.SetActive(false);
        panelJornal.SetActive(false);
        panelElements.SetActive(true);
        panelOptions.SetActive(false);
    }

    private void Update()
    {
        if(InputManager.Instance.GetPausePressed())
        {
            if (!panelPausa.activeInHierarchy)
            {
                BtnPausa();
            }
            else
            {
                BtnPausaBack();
            }
        }

        if(InputManager.Instance.GetJornalPressed())
        {
            if(deactivateJornal)
            {
                return;
            }

            if (!panelJornal.activeInHierarchy)
            {
                BtnJornal();
            }
            else
            {
                BtnJornalBack();
            }
        }
    }

    public void BtnPausa()
    {
        GameStates.GameState _gameState = GameStates.Instance.GetState();

        if(_gameState == GameStates.GameState.Transitioning)
        {
            return;
        }

        panelPausa.SetActive(true);
        GameStates.Instance.SetStatePause();
    }

    public void BtnJornal()
    {
        GameStates.GameState _gameState = GameStates.Instance.GetState();

        if (_gameState == GameStates.GameState.Transitioning || _gameState == GameStates.GameState.Pause)
        {
            return;
        }

        JornalController.Instance.LoadJornalPage();
        panelJornal.SetActive(true);
        GameStates.Instance.SetStateJornal();
    }

    public void BtnPausaBack()
    {
        GameStates.GameState _gameState = GameStates.Instance.GetState();

        if (_gameState == GameStates.GameState.Transitioning)
        {
            return;
        }

        panelPausa.SetActive(false);
        GameStates.Instance.SetStatePrevious();
    }

    public void BtnJornalBack()
    {
        GameStates.GameState _gameState = GameStates.Instance.GetState();

        if (_gameState == GameStates.GameState.Transitioning || _gameState == GameStates.GameState.Pause)
        {
            return;
        }

        if (JornalController.Instance == null)
        {
            Debug.LogError("Instance of JornalController not found, necessary for jornal control");
        }
        JornalController.Instance.SavePageTexts();
        panelJornal.SetActive(false);
        GameStates.Instance.SetStateCloseJornal();
    }

    public void BtnMenu()
    {
        levelLoader.LoadLevel("Menu");
    }

    public void BtnOptions()
    {
        panelElements.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void BtnOptionsBack()
    {
        panelOptions.SetActive(false);
        panelElements.SetActive(true);
    }
}
