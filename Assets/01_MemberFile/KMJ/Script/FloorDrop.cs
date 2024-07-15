using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorDrop : MonoBehaviour
{
    [SerializeField] private Slider _lightSlider;
    private int _rand;
    private WaitForSeconds _waitTime;

    private void Awake()
    {
        _waitTime = new WaitForSeconds(3f);
    }
    private void Start()
    {
        while (_rand != 6)
        {
            StartCoroutine(WaitTime(_waitTime));
        }
    }
    private void Update()
    { 

    }

    private void RandomDrop(int random, float Minvalue)
    {
        random = Random.Range(0, 10);

        if (random == 6)
        {
            _lightSlider.value = Minvalue;
        }

    }

    private IEnumerator WaitTime(WaitForSeconds WaitTime)
    {
        yield return WaitTime;

        RandomDrop(_rand, 0);
    }

}
