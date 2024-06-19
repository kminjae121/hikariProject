using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PriviewWindow : MonoBehaviour
{
    [SerializeField] public bool isContactingPreview; // 미리보기 화면에 접촉 여부 bool
    
    public bool IsContactingPreview
    {
        get
        {
            return isContactingPreview;
        }
        set
        {
            isContactingPreview = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어가 미리보기 화면에 닿았을 경우
        {
            isContactingPreview = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어가 미리보기 화면에 닿았다가 떨어졌을 경우
        {
            isContactingPreview = false;
        }
    }
}
