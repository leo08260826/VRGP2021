using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGesture_Scene2 : MonoBehaviour
{
    private LeftHandGestureWithPaint left;
    public string handObjName;
    public float index;
    public float three;
    public float thumb;

    void Update()
    {
        if (left == null)
        {
            left = transform.Find(handObjName).gameObject.GetComponent<LeftHandGestureWithPaint>();
        }
    }
    public void GestureStart()
    {
        left.LeftGestureStampStart();
    }

    public void GestureEnd()
    {
        left.LeftGestureStampEnd();
    }
}
