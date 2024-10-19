using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Outline outline;
    private Color outlineColor;
    [SerializeField] private Color selectedOutlineColor = new Color(0,255,0);
    private float outilineWidth;
    [SerializeField] private float selectedOutilineWidth = 15f;

    [SerializeField] private TextAsset dialogue;
    [SerializeField] private bool isPermanent = false;

    public bool isActive = false;

    void Start()
    {
        outline = GetComponent<Outline>();

        outlineColor = outline.outlineColor;
        outilineWidth = outline.outlineWidth;

        Deactive();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isActive)
        {
            outline.ChangeOutline(selectedOutilineWidth, selectedOutlineColor);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isActive)
        {
            outline.ChangeOutline(outilineWidth, outlineColor);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive)
        {
            if (!isPermanent)
            {
                Deactive();
                DialogueManager.Instance.EnterDialogueMode(dialogue);
            }
            else
            {
                DialogueManager.Instance.EnterDialogueMode(dialogue);
            }
        }
    }

    public void Active()
    {
        isActive = true;
        outline.enabled = true;
    }

    public void Deactive()
    {
        isActive = false;
        outline.enabled = false;
    }
}
