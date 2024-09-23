using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public static class TextExpand
{
    public static void TextUpDownMove(this TMP_Text text,float time)
    {
        while(time > 0)
        {
            Debug.Log("야야 실행");
            time -= 0.1f;
            Mesh mesh = text.mesh;
            Vector3[] vertices = mesh.vertices;
            Color[] colors = mesh.colors;

            text.ForceMeshUpdate();

            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices[i] += Mathf.Sign(Time.time * 5 + (i / 4) * 2) * 0.5f * Vector3.up;
            }

            mesh.SetVertices(vertices);
            mesh.SetColors(colors);
        }
        //TextUpDownMove(parameter, isStart);
    }
}
