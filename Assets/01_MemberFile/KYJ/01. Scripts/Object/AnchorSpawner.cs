using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject anchorPrefab;
    public Stack<GameObject> AnchorPool = new Stack<GameObject>();
    private GameObject anchor;

    public bool isSpawn;

    [SerializeField] private Transform[] spawnPoint;

    private void Awake()
    {
        CreatAnchorPool();
    }

    private void Update()
    {
        if (!isSpawn)
        {
            StartCoroutine(SpawnRoutine(7f));
            StartCoroutine(DropRoutine(3f));
        }
    }

    private void GetAnchorInPool()
    {
        if (AnchorPool.Count > 0)
        {
            anchor = AnchorPool.Pop(); 
            anchor.SetActive(true); 
        }
    }

    private void DestroyAnchor()
    {
        if (anchor != null)
        {
            anchor.SetActive(false);
        }
    }

    private void CreatAnchorPool()
    {
        int rand = Random.Range(0, 2);
        GameObject anchorObj;

        for (int i = 0; i < 10; i++)
        {
            anchorObj = Instantiate(anchorPrefab, gameObject.transform, spawnPoint[rand]);
            AnchorPool.Push(anchorObj);
            anchorObj.SetActive(false);
        }
    }

    private IEnumerator SpawnRoutine(float time)
    {
        isSpawn = true;
        GetAnchorInPool();
        yield return new WaitForSeconds(time);
        DestroyAnchor();
        isSpawn = false;
    }

    private IEnumerator DropRoutine(float time)
    {
        isSpawn = true;
        yield return new WaitForSeconds(time);
        isSpawn = false;
    }
}
