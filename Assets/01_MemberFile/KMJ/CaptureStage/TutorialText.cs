using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public List<string> tutorialText = new List<string>();
    private static int _textNumber;
    private bool _isEndCurrentText;

    private void Start()
    {
        _isEndCurrentText = false;
        _textNumber = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isEndCurrentText == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            { 
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                PlayerChatBoxManager.Instance.Show(tutorialText[_textNumber], 4, true);
                PlayerChatBoxManager.Instance.End();
                _textNumber++;
            }
            else
                return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _isEndCurrentText = true;
        }
    }
}
