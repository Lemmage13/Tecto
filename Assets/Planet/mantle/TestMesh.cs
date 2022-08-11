using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMesh : MonoBehaviour
{
    Mesh testMesh = new Mesh();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //takes 3d array of vectors that define triangles proportional to the size of the force vector
    void TestMeshBuilder(Vector3[][] tTris, Mesh mesh)
    {
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[tTris.Length * 3];
        int[] triangles = new int[tTris.Length * 3];

        for (int i = 0; i < tTris.Length; i++)
        {
            int head = i * 3;
            int left = head + 1;
            int right = head + 2;

            vertices[head] = tTris[i][0];
            vertices[left] = tTris[i][1];
            vertices[right] = tTris[i][2];

            triangles[head] = head;
            triangles[left] = left;
            triangles[right] = right;
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
