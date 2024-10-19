using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JornalController : MonoBehaviour
{
    public static JornalController Instance;

    //Uma forma temporaria de salvar as escritas enquanto ainda nao e usado JSON para isso
    private JornalInformations jornalInfo;

    [Header("GameObjects")]
    public TextMeshProUGUI txtWord;
    public TMP_InputField txtFieldDefinition;
    public TMP_InputField txtFieldObservation;
    public TMP_InputField txtFieldObservation2;
    public GameObject panelNothingYet;
    
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //panelNothingYet.SetActive(true);
    }

    void Start()
    {
        jornalInfo = JornalInformations.Instance;
    }

    public void LoadJornalPage()
    {
        if(!jornalInfo.hasOnePageDiscovered)
        {
            panelNothingYet.SetActive(true);
            return;
        }

        txtWord.text = jornalInfo.pages[jornalInfo.pageIndex].word;
        txtFieldDefinition.text = jornalInfo.pages[jornalInfo.pageIndex].firstField;
        txtFieldObservation.text = jornalInfo.pages[jornalInfo.pageIndex].secondField;
        txtFieldObservation2.text = jornalInfo.pages[jornalInfo.pageIndex].thirdField;
    }

    public void SavePageTexts()
    {
        jornalInfo.pages[jornalInfo.pageIndex].firstField = txtFieldDefinition.text;
        jornalInfo.pages[jornalInfo.pageIndex].secondField = txtFieldObservation.text;
        jornalInfo.pages[jornalInfo.pageIndex].thirdField = txtFieldObservation2.text;
    }

    public void BtnMovePage(bool toRight)
    {
        if(!jornalInfo.hasOnePageDiscovered)
        {
            return;
        }

        SavePageTexts();

        //Solucao que encontrei temporariamente para rodar apenas as palavras ativas com um array
        CheckPage(toRight);
    }

    private void CheckPage(bool toRight)
    {
        if (toRight)
            jornalInfo.pageIndex++;
        else
            jornalInfo.pageIndex--;

        if (jornalInfo.pageIndex < 0)
        {
            jornalInfo.pageIndex = jornalInfo.pages.Length - 1;
        }
        else if(jornalInfo.pageIndex >= jornalInfo.pages.Length)
        {
            jornalInfo.pageIndex = 0;
        }

        if (jornalInfo.pages[jornalInfo.pageIndex].discovered == false)
        {
            CheckPage(toRight);
            return;
        }
        else
        {
            LoadJornalPage();
        }
    }

    public void DiscoverWord(int intWord)
    {
        jornalInfo.pages[intWord].discovered = true;
        jornalInfo.hasOnePageDiscovered = true;
        panelNothingYet.SetActive(false);
        jornalInfo.pageIndex = intWord;
        LoadJornalPage();
    }
}
