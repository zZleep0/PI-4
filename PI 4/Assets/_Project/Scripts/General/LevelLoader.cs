using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animTransition;

    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private GameObject panelStopClicks;

    private void Start()
    {
        panelStopClicks.SetActive(false);
    }

    public void LoadLevel(string sceneName)
    {
        Time.timeScale = 1f;
        GameStates.Instance.SetStateTransitioning();
        panelStopClicks.SetActive(true);
        StartCoroutine(LoadLevelCoroutine(sceneName));
    }

    IEnumerator LoadLevelCoroutine(string sceneName)
    {
        animTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
