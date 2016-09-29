using UnityEngine;
using System;

public class ReverseMesh : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Array.Reverse(mesh.triangles);
        
        gameObject.AddComponent<MeshCollider>();
    }
}
