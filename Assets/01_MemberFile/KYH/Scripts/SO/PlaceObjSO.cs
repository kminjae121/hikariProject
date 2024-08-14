using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjSO/PlaceObj")]
public class PlaceObjSO : ScriptableObject
{
    public Sprite sprite;
    public string name;
    public GameObject prefab;
}
