using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGesture2Wall : MonoBehaviour
{
    public GameObject LeftHandController;
    public GameObject RightHandController;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Debug.Log("if triggerEnter : " + other.gameObject.name);
            if(other.gameObject.name == "LeftHand Controller"){
                LeftHandController.gameObject.GetComponent<TestGesture_Scene2>().GestureStart();
            }
            if(other.gameObject.name == "RightHand Controller"){
                RightHandController.gameObject.GetComponent<TestGesture2_Scene2>().GestureStart();
            }
        }

    }

    
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            Debug.Log("if triggerExit : " + other.gameObject.name);
            if(other.gameObject.name == "LeftHand Controller"){
                LeftHandController.gameObject.GetComponent<TestGesture_Scene2>().GestureEnd();
            }
            if(other.gameObject.name == "RightHand Controller"){
                RightHandController.gameObject.GetComponent<TestGesture2_Scene2>().GestureEnd();
            }
        }
    }
}
