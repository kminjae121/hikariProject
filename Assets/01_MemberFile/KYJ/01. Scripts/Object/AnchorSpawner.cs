using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnchorSpawner : MonoBehaviour
{
    private PlayerMove _agentMove;

    [SerializeField] private GameObject anchorPrefab;
    public Stack<GameObject> AnchorPool = new Stack<GameObject>();
    
    private GameObject anchorObj;
    private GameObject anchor;

    [SerializeField] private Transform[] spawnPoints;

    private bool test;
    private bool tTest;

    private void Awake()
    {
        _agentMove = GameObject.Find("PlayerPrefab").GetComponent<PlayerMove>();

        CreatAnchorPool();
    }

    private void Update()
    {
        if (!test)
            AnchorSpawn();

        if(!tTest)
            StartCoroutine(JumpRoutine());
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
        int coolTime = UnityEngine.Random.Range(4, 6);
        test = true;
        yield return new WaitForSeconds(coolTime);
        DestroyAnchor();
        test = false;
    }

    private void KnockbackCoroutine()
    {
        if (_agentMove._isForce)
        {
            _agentMove._isForce = false;
        }
    }

    public IEnumerator JumpRoutine() //코루틴 뒤에 무조건 Routine 붙이기!
    {
        tTest = true;
         yield return new WaitForSeconds(1);
        _agentMove._isForce = false;
        tTest = false;
    }
}
