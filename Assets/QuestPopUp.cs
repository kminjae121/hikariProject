using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestPopUp : MonoBehaviour, IDragHandler
{
    public GameObject questText;
    public bool isOnQuestText;

    public void OnDrag(PointerEventData eventData)
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Vector2 mouseDir = new Vector2(Mathf.Clamp(Input.mousePosition.x,0, screenWidth), Mathf.Clamp(Input.mousePosition.y, 0, screenHeight));
        transform.position = mouseDir;
    }

    public void OnQuestScreen()
    {
        if(!isOnQuestText)
        {
            questText.SetActive(true);
            isOnQuestText = true;
        }
        else
        {
            questText.SetActive(false);
            isOnQuestText = false;
        }
    }
}
