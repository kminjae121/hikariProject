using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float speed;
    [SerializeField] private InputReader inputReader;

    [Header("Index Number")]
    [SerializeField] private int startIndex;
    [SerializeField] private int endIndex;

    [Header("Background Sprite List")]
    [SerializeField] private Transform[] sprites;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (inputReader.Movement.x > 0)
        {
            Vector3 nextPos = Vector3.left * speed * Time.deltaTime;
            transform.position += nextPos;
        }

        else if (inputReader.Movement.x < 0)
        {
            Vector3 nextPos = Vector3.right * speed * Time.deltaTime;
            transform.position += nextPos;
        }

        Scrolling();
    }

    private void Scrolling()
    {
        if (sprites[startIndex].position.x < _player.position.x - 30)
        {
            sprites[startIndex].position = sprites[endIndex].position + Vector3.right * 30;

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = startIndexSave;

            print("right");
        }

        else if (sprites[endIndex].position.x - 30f > _player.position.x)
        {
            print("left");
            sprites[endIndex].position = sprites[startIndex].position + Vector3.left * 30;


            int endIndexSave = endIndex;
            endIndex = startIndex;
            startIndex = endIndexSave;
        }
    }
}
