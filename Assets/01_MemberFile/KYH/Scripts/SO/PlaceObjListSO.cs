using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjSO/PlaceObhList")]
public class PlaceObjListSO : ScriptableObject
{
    public List<PlaceObjSO> placeObjSO = new();
}
