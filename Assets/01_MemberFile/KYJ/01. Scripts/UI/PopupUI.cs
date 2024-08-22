using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupUI : MonoBehaviour
{
    [SerializeField] private GameObject popupUI;

    private float _timer;
    private float _timerMax = 10;

    private bool isTrue;

    private Vector2 pos;

    private void Awake()
    {
        popupUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        EnablingHelp();
    }

    private void EnablingHelp()
    {
        _timer += Time.deltaTime;
        if (_timer > _timerMax)
        {
            popupUI.gameObject.SetActive(true);
        }

        if (_timer > (_timerMax + 5) && !isTrue)
        {
            float randX = Random.Range(-6, 6);
            float randY = Random.Range(-2.4f, 2.4f);
            pos = new Vector2(randX, randY);
            Instantiate(popupUI, pos, Quaternion.identity, GameObject.Find("PopupManager").transform);
            StartCoroutine(PopupSpawnCool());
        }
    }

    private IEnumerator PopupSpawnCool()
    {
        isTrue = true;
        yield return new WaitForSeconds(5f);
        isTrue = false;
    }
}
