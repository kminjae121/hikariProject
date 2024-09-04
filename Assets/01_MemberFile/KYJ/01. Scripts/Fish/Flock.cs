using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public GameObject _fishPrefab;
    public GameObject _parentFish;
    public int _fishCount = 30;
    public static int _boundary = 7;
    public static GameObject[] _fishList;
    public static Vector3 _targetPosition = Vector3.zero;

    void Start()
    {
        _fishList = new GameObject[_fishCount];

        for (int i = 0; i < _fishCount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-_boundary, _boundary),
                Random.Range(-_boundary, _boundary),
                Random.Range(-_boundary, _boundary)
            );

            GameObject fish = (GameObject)Instantiate(_fishPrefab, position, Quaternion.identity);

            fish.transform.parent = _parentFish.transform;
            _fishList[i] = fish;
        }
    }

    void Update()
    {
        GetTargetPosition();
    }

    void GetTargetPosition()
    {
        if (Random.Range(1, 10000) < 50)
        {
            _targetPosition = new Vector3(
                Random.Range(-_boundary, _boundary),
                Random.Range(-_boundary, _boundary),
                Random.Range(-_boundary, _boundary)
            );
        }
    }
}
