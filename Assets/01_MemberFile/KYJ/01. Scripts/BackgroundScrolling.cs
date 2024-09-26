using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int startIndex;
    [SerializeField] private int endIndex;

    [SerializeField] private Transform[] sprites;

    [SerializeField] private Transform _player;

    private float viewHeight;

    [SerializeField] private InputReader inputReader;


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

            Scrolling();
        }
        else if (inputReader.Movement.x < 0)
        {
            Vector3 nextPos = Vector3.right * speed * Time.deltaTime;
            transform.position += nextPos;

            Scrolling();
        }
    }

    private void Scrolling()
    {
        if (sprites[startIndex].position.x < _player.position.x - 20f)
        {
            sprites[startIndex].position = sprites[endIndex].position + Vector3.right * 30;

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = startIndexSave;
        }

        else if (sprites[startIndex].position.x > _player.position.x - 20f)
        {
            sprites[startIndex].position = sprites[endIndex].position + Vector3.left * 30;

            //int startIndexSave = startIndex;
            //startIndex = endIndex;
            //endIndex = startIndexSave;
        }
    }
}
