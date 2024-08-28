using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public GameObject m_Prfbfish;
    public GameObject m_PrntFish;
    public int m_Fish = 30;
    public static int m_Boundary = 7;
    public static GameObject[] m_Fishes;
    public static Vector3 m_TargetPosition = Vector3.zero;

    void Start()
    {
        m_Fishes = new GameObject[m_Fish];

        for (int i = 0; i < m_Fish; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-m_Boundary, m_Boundary),
                Random.Range(-m_Boundary, m_Boundary),
                Random.Range(-m_Boundary, m_Boundary)
            );

            GameObject fish = (GameObject)Instantiate(m_Prfbfish, position, Quaternion.identity);

            fish.transform.parent = m_PrntFish.transform;
            m_Fishes[i] = fish;
        }
    }

    void Update()
    {
        GetTargetPosition();
    }

    void GetTargetPosition()
    {
        if (Random.Range(1, 10000) < 50)
        {
            m_TargetPosition = new Vector3(
                Random.Range(-m_Boundary, m_Boundary),
                Random.Range(-m_Boundary, m_Boundary),
                Random.Range(-m_Boundary, m_Boundary)
            );
        }
    }
}
