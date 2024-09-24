using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackGroundScroll : MonoBehaviour
{
    [SerializeField] private  float speed;
    [SerializeField] private Transform[] backgrounds;

    [SerializeField] private float leftPosX = 0f;
    [SerializeField] private float rightPosX = 0f;
    [SerializeField] private float xScreenHalfSize;
    [SerializeField] private float yScreenHalfSize;

    private void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }

   private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if (backgrounds[i].position.x < leftPosX)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }
}
