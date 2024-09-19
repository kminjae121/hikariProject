using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnchorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject anchorPrefab;
    public Stack<GameObject> AnchorPool = new Stack<GameObject>();
    
    private GameObject anchorObj;
    private GameObject anchor;

    [SerializeField] private Transform[] spawnPoints;

    public event Action OnSpawn;

    private bool test;

    private void Awake()
    {
        CreatAnchorPool();
    }

    private void Update()
    {
        if (!test)
            AnchorSpawn();  
    }

    private void DestroyAnchor()
    {
        Destroy(anchorObj);
    }

    private void CreatAnchorPool()
    {
        for (int i = 0; i < 10; i++)
        {
            anchor = Instantiate(anchorPrefab, transform);
            AnchorPool.Push(anchor);
            anchor.SetActive(false);
        }
    }

    private void AnchorSpawn()
    {
        Vector2 spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position;
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle;

        if (AnchorPool.Count > 0)
        {
            anchorObj = AnchorPool.Pop();
            anchorObj.transform.position = spawnPoint + randomOffset;
            anchorObj.SetActive(true);
        }
        else
        {
            anchorObj = Instantiate(anchorPrefab, transform);
            anchorObj.transform.position = spawnPoint + randomOffset;
        }

        StartCoroutine(SpawnCoroutaine());
    }

    private IEnumerator SpawnCoroutaine()
    {
        test = true;
        yield return new WaitForSeconds(5f);
        DestroyAnchor();
        test = false;
    }
}
