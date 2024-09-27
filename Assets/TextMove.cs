using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMove : MonoBehaviour
{
    public TMP_Text tMP;

    public void Start()
    {
        tMP.TextUpDownMove(3f, Color.white ,2.5f, TextStyle.Moving);
        foreach(object v in new E())
        {
            Debug.Log(v);
        }

        foreach(Transform trm in transform)
        {
            if (trm == transform) continue;


        }

        IDictionary dictioanry = new Dictionary<int ,int>();
        IList ilist = new float[3];
        IReadOnlyList<int> list = new int[3];

        System.Array a = new int[3];
    }

    private void Update()
    {
    }

}
