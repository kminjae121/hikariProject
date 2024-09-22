using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMove : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    Color[] colors;

    private void TextUpDownMove(TMP_Text text, bool isStart)
    {
        mesh = text.mesh;
        vertices = mesh.vertices;
        colors = mesh.colors;

        text.ForceMeshUpdate();

        for (int i = 0; i < vertices.Length; ++i)
        {
            vertices[i] += Mathf.Sign(Time.time * 5 + (i / 4) * 2) * 0.5f * Vector3.up;
        }

        mesh.SetVertices(vertices);
        mesh.SetColors(colors);
    }

    private void Update()
    {
        
    }
}
