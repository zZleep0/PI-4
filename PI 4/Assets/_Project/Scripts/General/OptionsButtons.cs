using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtons : MonoBehaviour
{
    [Header("Panels Inside Options")]
    [SerializeField] private GameObject panelOptGeral;
    [SerializeField] private GameObject panelOptAudio;
    [SerializeField] private GameObject panelOptVideo;
    [SerializeField] private GameObject panelOptControles;

    void Start()
    {
        //panelOptGeral e o padrao que aparece quando se abre a tela de opcoes
        panelOptGeral.SetActive(true);
        panelOptAudio.SetActive(false);
        panelOptVideo.SetActive(false);
        panelOptControles.SetActive(false);
    }

    public void BtnOptGeral()
    {
        panelOptGeral.SetActive(true);
        panelOptAudio.SetActive(false);
        panelOptVideo.SetActive(false);
        panelOptControles.SetActive(false);
    }

    public void BtnOptAudio()
    {
        panelOptGeral.SetActive(false);
        panelOptAudio.SetActive(true);
        panelOptVideo.SetActive(false);
        panelOptControles.SetActive(false);
    }

    public void BtnOptVideo()
    {
        panelOptGeral.SetActive(false);
        panelOptAudio.SetActive(false);
        panelOptVideo.SetActive(true);
        panelOptControles.SetActive(false);
    }

    public void BtnOptControles()
    {
        panelOptGeral.SetActive(false);
        panelOptAudio.SetActive(false);
        panelOptVideo.SetActive(false);
        panelOptControles.SetActive(true);
    }
}
