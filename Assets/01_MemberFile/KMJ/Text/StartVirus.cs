using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVirus : MonoBehaviour
{
    private FeedbackPlayer _feedBack;


    private void Awake()
    {
        _feedBack = GetComponent<FeedbackPlayer>();
    }
    private void Update()
    {
        //_feedBack.PlayFeedback();
    }

    private void Start()
    {
        _feedBack.PlayFeedback();
    }
}
