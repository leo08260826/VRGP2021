using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SCene1OnTrigger : MonoBehaviour
{
    public string triggerObjTag= "";
    public UnityEvent triggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == triggerObjTag)
        {
            triggerEvent.Invoke();
        }
    }
}
