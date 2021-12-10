using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TransitionEffect : MonoBehaviour
{
    [SerializeField, Range(0,1)]
    private float progress;
    private Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();

        //Flip the sphere inside-out
        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        
        mesh.triangles = mesh.triangles.Reverse().ToArray();
        mesh.RecalculateNormals();
        filter.mesh = mesh;
    }

    private void Update() 
    {
        render.material.SetFloat("_Progress", progress);
    }
}
