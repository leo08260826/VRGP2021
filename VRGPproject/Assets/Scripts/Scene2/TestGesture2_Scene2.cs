using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGesture2_Scene2 : MonoBehaviour
{
    private RightHandGestureWithPaint right;
    public string handObjName;
    public float index;
    public float three;
    public float thumb;

    void Update()
    {
        if (right == null)
        {
            right = transform.Find(handObjName).gameObject.GetComponent<RightHandGestureWithPaint>();
        }
    }
    public void GestureStart()
    {
        //right.RightGestureStart(index, three, thumb);
        right.RightGestureStampStart();
    }

    public void GestureEnd()
    {
        //right.RightGestureEnd();
        right.RightGestureStampEnd();
    }
}
