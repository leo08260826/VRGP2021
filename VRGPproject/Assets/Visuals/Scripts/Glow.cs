using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Glow : MonoBehaviour
{
    [SerializeField]
    private GameObject glowPrefab;
    [SerializeField]
    private Material glowMat;

    private MeshFilter filter;
    private MeshRenderer glow;

    [ColorUsage(true, true)]
    public Color glowColor;
    [Range(0,1)]
    public float glowStr;

    // Start is called before the first frame update
    void Start()
    {
        GameObject glowObj = Instantiate(glowPrefab,transform);
        filter = glowObj.GetComponent<MeshFilter>();
        glow = glowObj.GetComponent<MeshRenderer>();

        filter.mesh = GetComponent<MeshFilter>().mesh;
        glow.material = glowMat;
    }

    void FixedUpdate() 
    {
        glow.material.SetFloat("_GlowStr", glowStr);
        glow.material.SetVector("_GlowColor", (Vector4)glowColor);    
    }
}
