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
    private bool CallCompleteStamping = false;
    public bool IsMain = false;
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
                if(IsMain){
                    decalColor = this.GetComponent<HandPaintColorChange_scene2>().defaultColor;
                }
                
                rayHit = true;
                receiver.AddDecal(this, hit);
                if (!CallCompleteStamping)
                {
                    Invoke("CompleteStamping", 30f);
                    CallCompleteStamping = true;
                }
            }
        }
        else
            rayHit = false;
        lastFramePos = transform.position;
    }

    private void CompleteStamping()
    {
        Debug.Log("completeStamping");
        TimeLineControl.StampIsTriggered = true;
    }
}
