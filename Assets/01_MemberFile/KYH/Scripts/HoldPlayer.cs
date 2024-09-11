using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayer : MonoBehaviour
{
    public GameObject riggingPlayer;
    private GameObject defaultPlayer;

    private void Start()
    {
        defaultPlayer = gameObject;
    }


}
