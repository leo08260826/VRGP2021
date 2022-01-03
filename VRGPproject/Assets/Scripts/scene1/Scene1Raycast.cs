using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scene1Raycast : MonoBehaviour
{
    public int layer;
    public string targetName;
    public UnityEvent rayEvent;

    private int layerMask; 

    void Start()
    {
        layerMask = 1 << layer;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if(hit.transform.gameObject.name == targetName)
            {
                rayEvent.Invoke();
                Debug.Log("Did Hit " + hit.transform.gameObject.name);
            }
        }
    }
}
