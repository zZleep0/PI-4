using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuMouseHoverOption : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private string explanation = "";
    [SerializeField] private string defaultKey = "";
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private TextMeshProUGUI textDefault;

    public void OnPointerEnter(PointerEventData eventData)
    {
        textUI.text = explanation;
        textDefault.text = defaultKey;
    }
}
