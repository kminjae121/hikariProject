using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
	public float m_MaxSpeed = 2.0f;
	public float m_MaxTurnSpeed = 0.5f;
	private float m_Speed;
	private float m_NeighborDistance = 3.0f;
	private bool m_IsTurning = false;


	void Start()
	{
		m_Speed = Random.Range(0.5f, m_MaxSpeed);
	}

	void Update()
	{
        GetIsTurning();

        if (m_IsTurning)
		{
			Vector2 direction = Vector2.zero - (Vector2)transform.position;
			transform.rotation = Quaternion.Lerp(transform.rotation,
				Quaternion.LookRotation(Vector2.zero),
				TurnSpeed() * Time.deltaTime);
			m_Speed = Random.Range(0.5f, m_MaxSpeed);
		}

        else
        {
            if (Random.Range(0, 5) < 1)
                SetRotation();
        }

        transform.Translate(Time.deltaTime * m_Speed, 0, 0);
	}

	void GetIsTurning()
	{
		if (Vector2.Distance(transform.position, Vector2.zero) >= Flock.m_Boundary)
		{
			m_IsTurning = true;
		}

		else
		{
			m_IsTurning = false;
		}
	}

	void SetRotation()
	{
		GameObject[] fishes;
		fishes = Flock.m_Fishes;

		Vector3 center = Vector2.zero;
		Vector3 avoid = Vector2.zero;
		float speed = 0.1f;

		Vector3 targetPosition = Flock.m_TargetPosition;

		float distance;
		int groupSize = 0;

		for (int i = 0; i < fishes.Length; i++)
		{
			if (fishes[i] != gameObject)
			{
				distance = Vector2.Distance(fishes[i].transform.position, transform.position);

				if (distance <= m_NeighborDistance)
				{
					center += fishes[i].transform.position;
					groupSize++;

					if (distance < 0.75f)
					{
						avoid += (transform.position - fishes[i].transform.position);
					}

					FishController anotherFish = fishes[i].GetComponent<FishController>();
					speed += anotherFish.m_Speed;
				}
			}
		}

		if (groupSize > 0)
		{
			center = center / groupSize + (targetPosition - transform.position);
			m_Speed = speed / groupSize;

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
		return Random.Range(0.2f, m_MaxTurnSpeed);
	}
}
