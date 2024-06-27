using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramIcon : MonoBehaviour
{
    [SerializeField] private List<GameObject> priviewWindow = new List<GameObject>();
    public bool isContactCursor; // 커서가 미리보기 화면에 닿았는가

    private void Start()
    {
        priviewWindow[0].SetActive(false);

    }

    private void Update()
    {
        PriviewWindowOn();
    }

    private void PriviewWindowOn() // 미리보기 활성화 기능
    {
        if (isContactCursor) // 커서가 프로그램 아이콘에 닿아있는 경우
        {
            priviewWindow[0].SetActive(true);
            // 미리보기 화면을 활성화 시킨다.
            //for (int i = 0; i < priviewWindow.Count; i++)
            //{
            //    print("아이콘 닿았습니다.");
            //    priviewWindow[i].SetActive(true);
            //}
        }
        else if(isContactCursor != true)
        {
            priviewWindow[0].SetActive(false);

            //for (int i = 0; i < priviewWindow.Count; i++)
            //{
            //    priviewWindow[i].SetActive(false);
            //}
        }
    }

    public void ShowWindow()
    {
        isContactCursor = true; // isContactCursor로 접촉 여부를 참으로 만든다.
    }

    public void DownWindow()
    {
        isContactCursor = false; // isContactCursor로 접촉 여부를 참으로 만든다.
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Cursor")) // 커서가 프로그램 아이콘에 닿았을 경우
    //    {
    //        isContactCursor = true; // isContactCursor로 접촉 여부를 참으로 만든다.
    //    }
    //}

    private void OnTriggerExit2D(Collider2D other) // 커서가 프로그램 아이콘에 닿았다가 떨어졌을 경우
    {
        if (other.CompareTag("Cursor"))
        {
            isContactCursor = false;
        }
    }
}
