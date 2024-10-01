using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialObj : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    private int objNumber;

    private void Awake()
    {
        for (int i = -0; i < obj.Length; i++)
        {
            obj[i].GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ObjectRelease();
        }
    }

    private void ObjectRelease()
    {
        obj[objNumber].GetComponent<SpriteRenderer>().DOColor(Color.white, 1);
        objNumber++;
    }
}
