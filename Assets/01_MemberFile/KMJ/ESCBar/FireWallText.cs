using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class FireWallText : MonoBehaviour
{
    [SerializeField] private ButtonManager _buttonManager;

    [SerializeField] private TextMeshPro _fireWallText;


    private Sequence _textSequence;


    private void Start()
    {
        _textSequence = DOTween.Sequence()
            .Append(_fireWallText.DOFade(0, 2))
            .AppendInterval(0.5f)
            .Append(_fireWallText.DOFade(255, 2))
            .SetLoops(-1)
            .SetAutoKill(false);
    }

    private void Update()
    {
        if(ButtonManager.IsFireWallTrue == false)
        {
            _fireWallText.enabled = true;
            _textSequence.Play();
        }
        else
        {
            _fireWallText.enabled = false;
            _textSequence.Pause();
        }    
            
    }

}
