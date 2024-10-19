using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelsController : MonoBehaviour
{
    [Header("Panels First Screen")]
    [SerializeField] private GameObject panelMain;
    [SerializeField] private GameObject panelStart;
    [SerializeField] private GameObject panelOptions;

    [Header("Panels Inside Exit")]
    [SerializeField] private GameObject panelConfirmExit;

    [Header("Scripts References")]
    [SerializeField] private LevelLoader levelLoader;

    private void Start()
    {
        //panelMain e a primeira tela que o jogador vai ver
        panelMain.SetActive(true);
        panelStart.SetActive(false);
        panelOptions.SetActive(false);
        panelConfirmExit.SetActive(false);
    }

    public void BtnSingleplayer()
    {
        levelLoader.LoadLevel("GameDay1");
    }

    public void BtnJogar()
    {
        panelMain.SetActive(false);
        panelStart.SetActive(true);
    }

    public void BtnOpcoes()
    {
        panelMain.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void BtnSair()
    {
        panelConfirmExit.SetActive(true);
    }

    public void BtnSairSim()
    {
        Application.Quit();
    }

    public void BtnSairNao()
    {
        panelConfirmExit.SetActive(false);
    }

    public void BtnVoltar()
    {
        panelMain.SetActive(true);
        panelStart.SetActive(false);
        panelOptions.SetActive(false);
    }

    public void BtnPrologo()
    {
        levelLoader.LoadLevel("Cutscene1");
    }
}
