using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowControllFalse : MonoBehaviour
{
    public void Exit()
    {
        gameObject.transform.root.gameObject.SetActive(false);
    }
}
