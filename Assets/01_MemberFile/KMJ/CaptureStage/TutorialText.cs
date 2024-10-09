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

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isEndCurrentText == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (tutorialText[_textNumber] == null)
                    return;
                else
                {
                    PlayerChatBoxManager.Instance.Show(tutorialText[_textNumber], 2.5f, true)
                     .Show(tutorialText[_textNumber+=1],3,true);
                    PlayerChatBoxManager.Instance.End();
                    _textNumber++;
                }
            }
            else
                return;
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isEndCurrentText = true;
        }
    }
}
