using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusView : MonoBehaviour
{
    private CanvasRenderer canvasRenderer;
    public Material chartMaterial;
    public float maxValue = 100f;
    private Mesh chartMesh;

    private void Awake()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
    }

    public void UpdateStatusMesh(float[] normalizedValues)
    {
        if (chartMesh)
        {
            Destroy(chartMesh);
        }
        chartMesh = new Mesh();
        Vector3[] vertices = new Vector3[normalizedValues.Length + 1];
        int[] triangles = new int[3 * normalizedValues.Length];
        float deltaAngle = 360f / normalizedValues.Length;
        vertices[0] = Vector3.zero;
        for (int i = 0; i < normalizedValues.Length; i++)
        {
            vertices[i + 1] = GetVerticesPos(normalizedValues[i], deltaAngle * i);
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2 >= normalizedValues.Length + 1 ? 1 : i + 2;
        }
        chartMesh.vertices = vertices;
        chartMesh.triangles = triangles;

        canvasRenderer.SetMesh(chartMesh);
        canvasRenderer.SetMaterial(chartMaterial, null);
    }

    public Vector2 GetVerticesPos(float value, float angle)
    {
        float x = Mathf.Sin(angle * Mathf.Deg2Rad) * maxValue * value;
        float y = Mathf.Cos(angle * Mathf.Deg2Rad) * maxValue * value;
        return new Vector2(x, y);
    }
}
