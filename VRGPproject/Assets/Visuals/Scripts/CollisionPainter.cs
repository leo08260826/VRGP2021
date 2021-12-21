using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionPainter : MonoBehaviour
{
    public Color paintColor;
    
    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    private void OnCollisionStay(Collision other) 
    {
        Paintable p = null;
        if(!other.gameObject.TryGetComponent(out p))
            return;
        PaintManager.instance.paint(p, other.GetContact(0).point, radius, hardness, strength, paintColor);    
    }
}
