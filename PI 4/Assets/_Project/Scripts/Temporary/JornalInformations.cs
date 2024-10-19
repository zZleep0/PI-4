using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JornalInformations : MonoBehaviour
{
    public static JornalInformations Instance;

    //Uma forma temporaria de salvar as escritas enquanto ainda nao e usado JSON para isso
    [System.Serializable]
    public struct Pages
    {
        public string word;
        public string firstField;
        public string secondField;
        public string thirdField;
        public bool discovered;
    };

    [Header("Debug Info")]
    public Pages[] pages;
    public int pageIndex = 0;
    public bool hasOnePageDiscovered = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
