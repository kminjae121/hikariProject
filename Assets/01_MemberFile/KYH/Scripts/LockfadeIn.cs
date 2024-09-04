using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LockfadeIn : MonoBehaviour
{
    public Vector2 size;

    public void LockFade()
    {
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        gameObject.GetComponent<SpriteRenderer>().DOFade(1, 1).WaitForCompletion();
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1).WaitForCompletion();
    }
}
