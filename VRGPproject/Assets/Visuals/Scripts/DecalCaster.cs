using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalCaster : MonoBehaviour
{
    public Texture decalTexture = null;
    public Color decalColor = Color.white;
    public Vector2 decalSize = Vector2.one;
    public LayerMask decalLayer;
    private bool rayHit = false;

    private Vector3 lastFramePos;

    private void Start() 
    {
        lastFramePos = transform.position;
    }

    private void FixedUpdate() 
    {
        Ray ray = new Ray(lastFramePos, transform.position - lastFramePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, (transform.position - lastFramePos).magnitude, decalLayer))
        {
            DecalReceiver receiver = null;
            //Simulate OnCollisionEnter without actually collides with each other.
            if(hit.collider.gameObject.TryGetComponent(out receiver) && !rayHit)
            {
                rayHit = true;
                receiver.AddDecal(this, hit);
            }
        }
        else
            rayHit = false;
        lastFramePos = transform.position;
    }
}
