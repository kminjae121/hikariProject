using UnityEngine;

public class CaptureStartText : MonoBehaviour
{
    public static bool _isStart;
    private Color[] color;

    private void Awake()
    {
        _isStart = true;
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if(_isStart == true)
        {
            PlayerChatBoxManager.Instance.Show("대저택이 무너졌어", 3, true)
                .Show("빨리 문으로 이동하여 탈출하자!", 3.5f, true)
                .End();
        }
    }

    private void Update()
    {
    }





}
