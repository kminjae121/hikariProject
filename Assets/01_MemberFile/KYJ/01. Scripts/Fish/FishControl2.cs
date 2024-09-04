using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl2 : MonoBehaviour
{
    private float m_detectingDistance = 5f;
    public LayerMask followingLayer;

    [SerializeField] private GameObject aligningObject;
    [SerializeField] private float movementSpeed= 3f;

    [SerializeField] private float repulsionDistance = 5f;
    [SerializeField] private float attractionDistance = 5f;

    private void Update()
    {
        Heading();
    }

    private void Heading()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, m_detectingDistance, followingLayer);
        float shortestDist = Mathf.Infinity;
        Collider shortestCol = null;

        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject != gameObject)
            {
                float currentDist = Vector3.Distance(transform.position, cols[i].transform.position);
                if (shortestDist > currentDist)
                {
                    shortestDist = currentDist;
                    shortestCol = cols[i];
                }
            }
        }
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
        transform.rotation = RotateTransform(aligningObject.transform, transform, 0);

        if (shortestCol != null)
        {
            Quaternion totalRotation = transform.rotation;
            if (shortestDist < repulsionDistance)
            {
                totalRotation = RotateTransform(transform, shortestCol.transform, 0);
            }
            else if (shortestDist > attractionDistance)
            {
                totalRotation = RotateTransform(shortestCol.transform, transform, 0);
            }
            transform.rotation = totalRotation;
        }
    }

    private Quaternion RotateTransform(Transform target, Transform basis, float factor = 1f)
    {
        Quaternion rot = Quaternion.LookRotation(target.position - basis.position);
        return Quaternion.Slerp(transform.rotation, rot, factor * Time.deltaTime);
    }
}
