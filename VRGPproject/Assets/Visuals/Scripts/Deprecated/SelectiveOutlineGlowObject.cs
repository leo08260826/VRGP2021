using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SelectiveOutlineGlowObject : MonoBehaviour
{
    [HideInInspector]
    public Renderer render;
    public Color glowColor;
    [SerializeField]
    public bool glow = true;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        if(glow)
            SelectiveOutlineGlowRenderer.instance.AddGlowObject(this);
    }

    void FixedUpdate() 
    {
        if(glow)
            SelectiveOutlineGlowRenderer.instance.AddGlowObject(this);
        else
            SelectiveOutlineGlowRenderer.instance.RemoveGlowObject(this); 
    }

    void OnDisable() 
    {
        if(glow)
            SelectiveOutlineGlowRenderer.instance.RemoveGlowObject(this);
    }
}
