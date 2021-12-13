using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGesture : MonoBehaviour
{
    private LeftHandGesture left;
    public string handObjName;
    public float index;
    public float three;
    public float thumb;

    void Update()
    {
        if(left==null)
        {
            left = transform.Find(handObjName).gameObject.GetComponent<LeftHandGesture>();
        }
    }
    public void GestureStart()
    {
        left.LeftGestureStart(1,1,1);
    }

    public void GestureEnd()
    {
        left.LeftGestureEnd();
    }
}
