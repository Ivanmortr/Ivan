using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    // Start is called before the first frame update
    public float amplitude = 0.1f;
    public float speed = 1f;
    public float noisesStrenght = 1f;
    public float noiseWalk = 1f;

    private Vector3[] baseHeight;

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;

        Vector3[] vertices = new Vector3[baseHeight.Length];

        for(int i = 0; i<vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.x += Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * amplitude;
            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noisesStrenght;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();

    }
}
