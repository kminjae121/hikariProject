using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float _maxSpeed = 2.0f;
    public float _maxTurnSpeed = 0.5f;
    private float _moveSpeed;
    private float _neighborDistance = 3.0f;
    private bool _isTurning = false;

    [SerializeField] private GameObject _targetFish;

    private static int movementFlag = 0;

    void Start()
    {
        _moveSpeed = Random.Range(0.5f, _maxSpeed);
        StartCoroutine("ChangeMovement");

    }

    void Update()
    {
        GetIsTurning();
        Move();

        if (_isTurning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector2.zero), TurnSpeed() * Time.deltaTime);
            _moveSpeed = Random.Range(0.5f, _maxSpeed);
        }
        else
        {
            if (Random.Range(0, 5) < 1)
            {
                SetRotation();
            }
        }
        transform.Translate(Time.deltaTime * _moveSpeed, 0, 0);
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left * 0.5f;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right * 0.5f;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 3)
        {
            moveVelocity = new Vector3(0.5f, 0.4f, 0) * 0.5f;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 4)
        {
            moveVelocity = new Vector3(-0.5f, -0.4f, 0) * 0.5f;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * _moveSpeed * Time.deltaTime;
    }


    void GetIsTurning()
    {
        if (Vector2.Distance(transform.position, Vector2.zero) >= Flock._boundary) // 바운더리보다 자신의 위치 거리가 크면
        {
            _isTurning = true;
        }
        else
        {
            _isTurning = false;
        }
    }

    void SetRotation()
    {
        GameObject[] fishes;
        fishes = Flock._fishList;

        Vector3 center = Vector2.zero;
        Vector3 avoid = Vector2.zero;
        float speed = 0.1f;

        Vector3 targetPosition = Flock._targetPosition;

        float distance;
        int groupSize = 0;

        for (int i = 0; i < fishes.Length; i++)
        {
            if (fishes[i] != gameObject)
            {
                distance = Vector2.Distance(fishes[i].transform.position, transform.position); // 리스트에 있는 물고기의 위치와 나의 위치 거리를 계산

                if (distance <= _neighborDistance) // distance가 이웃거리보다 작거나 같을 떄
                {
                    center += fishes[i].transform.position;
                    groupSize++;

                    if (distance < 0.75f)
                    {
                        avoid += (transform.position - fishes[i].transform.position);
                    }

                    FishController anotherFish = fishes[i].GetComponent<FishController>();
                    speed += anotherFish._moveSpeed;
                }
            }
        }

        if (groupSize > 0)
        {
            center = center / groupSize + (targetPosition - transform.position);
            _moveSpeed = speed / groupSize;

            Vector2 direction = (center + avoid) - transform.position;
            if (direction != Vector2.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(direction),
                    TurnSpeed() * Time.deltaTime);
            }
        }
    }

    float TurnSpeed()
    {
        return Random.Range(0.2f, _maxTurnSpeed);
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = UnityEngine.Random.Range(0, 5);

        yield return new WaitForSeconds(6f);

        StartCoroutine("ChangeMovement");
    }
}
