using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance;

    public GameObject panelTutorial;
    public TextMeshProUGUI txtTutorial;
    public NPCsAndTimeManager startTimer;

    private bool happenedUnknownWord = false;
    private bool happenedStartScreen = false;

    private bool timerStarterd = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        panelTutorial.SetActive(false);
    }

    public void ReceiveTutorialAction(int number)
    {
        string _text = "";

        switch(number)
        {
            case 1:
                if(happenedStartScreen)
                {
                    return;
                }
                _text = "O <color=#c9c600>tempo</color> corre enquanto voc� interage com o cl�, no fim desse <color=#c9c600>tempo</color> voc� ir� conversar com o lider do cl�, nesse caso, Kerak. Use esse momento para conseguir informa��es e aumentar a <color=#00fc00>afinidade</color> entre os cl�s com suas a��es. Algumas intera��es s� podem acontecer em <color=#c9c600>tempos</color> especficos.";
                happenedStartScreen = true;
                break;
            case 2:
                if(happenedUnknownWord)
                {
                    return;
                }
                _text = "Parece que voc� encontrou uma <color=#fc0000>palavra desconhecida</color>, tente criar um significado baseado nos contextos em que voc� a encontra, isso pode ser util para o futuro. Voc� pode anotar suas observa��es no <color=#008ffc>Jornal</color> (Bot�o J como padr�o)";
                happenedUnknownWord = true;
                break;
        }

        //GameStates.Instance.SetStateTutorial();

        txtTutorial.text = _text;
        panelTutorial.SetActive(true);
    }

    public void BtnCloseTutorial()
    {
        panelTutorial.SetActive(false);

        if(!timerStarterd)
        {
            timerStarterd = true;
            startTimer.StartTimer();
        }
    }

}
