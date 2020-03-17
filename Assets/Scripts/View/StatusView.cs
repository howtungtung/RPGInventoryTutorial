using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusView : MonoBehaviour
{
    private CanvasRenderer canvasRenderer;
    public Material chartMaterial;
    public float maxValue = 100f;

    private void Awake()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
    }

    public void UpdateStatusMesh(float[] normalizedValues)
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[normalizedValues.Length + 1];
        int[] triangles = new int[3 * normalizedValues.Length];
        float deltaAngle = 360f / normalizedValues.Length;

        vertices[0] = Vector3.zero;
        for (int i = 1; i < vertices.Length; i++)
        {
            vertices[i] = Quaternion.Euler(0, 0, -deltaAngle * (i - 1)) * Vector3.up * maxValue * normalizedValues[i - 1];
        }
        //vertices[1] = Quaternion.Euler(0, 0, -deltaAngle * 0) * Vector3.up * maxValue * normalizedValues[0];
        //vertices[2] = Quaternion.Euler(0, 0, -deltaAngle * 1) * Vector3.up * maxValue * normalizedValues[1];
        //vertices[3] = Quaternion.Euler(0, 0, -deltaAngle * 2) * Vector3.up * maxValue * normalizedValues[2];
        //vertices[4] = Quaternion.Euler(0, 0, -deltaAngle * 3) * Vector3.up * maxValue * normalizedValues[3];
        //vertices[5] = Quaternion.Euler(0, 0, -deltaAngle * 4) * Vector3.up * maxValue * normalizedValues[4];
        //vertices[6] = Quaternion.Euler(0, 0, -deltaAngle * 5) * Vector3.up * maxValue * normalizedValues[5];

        for (int i = 0; i < normalizedValues.Length; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2 >= normalizedValues.Length + 1 ? 1 : i + 2;
        }
        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;

        //triangles[3] = 0;
        //triangles[4] = 2;
        //triangles[5] = 3;

        //triangles[6] = 0;
        //triangles[7] = 3;
        //triangles[8] = 4;

        //triangles[9] = 0;
        //triangles[10] = 4;
        //triangles[11] = 5;

        //triangles[12] = 0;
        //triangles[13] = 5;
        //triangles[14] = 6;

        //triangles[15] = 0;
        //triangles[16] = 6;
        //triangles[17] = 1;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        canvasRenderer.SetMesh(mesh);
        canvasRenderer.SetMaterial(chartMaterial, null);
    }
}
