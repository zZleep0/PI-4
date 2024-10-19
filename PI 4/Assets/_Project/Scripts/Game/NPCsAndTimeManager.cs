using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCsAndTimeManager : MonoBehaviour
{
    [SerializeField] private float timeToBoss;
    [SerializeField] private float currentTime;

    //Temporario
    public GameObject panelToLoadBoss;

    [System.Serializable]
    public struct Interaction
    {
        public DetectMouseHover interactable;
        public float startTime;
        public float endTime;
    };

    public Interaction[] interaction;

    [Header("Mover barra do dia")]
    public bool sceneHasDayBar = true;
    public Slider dayBar;

    void Start()
    {
        //InvokeRepeating("CheckNPCsAndTimer", 0, 1);
    }

    public void StartTimer()
    {
        InvokeRepeating("CheckNPCsAndTimer", 0, 1);
    }

    public void CheckNPCsAndTimer()
    {
        for (int i = 0; i < interaction.Length; i++)
        {
            if (interaction[i].startTime == currentTime)
            {
                interaction[i].interactable.Active();
            }
            else if(interaction[i].endTime == currentTime)
            {
                interaction[i].interactable.Deactive();
            }
        }

        currentTime += 1;

        if(currentTime >= timeToBoss)
        {
            panelToLoadBoss.SetActive(true);
            GameStates.Instance.SetStateTransitioning();
        }

        if(sceneHasDayBar)
        {
            UpdateDayBar();
        }
    }

    public void UpdateDayBar()
    {
        dayBar.value = currentTime;
    }
}
