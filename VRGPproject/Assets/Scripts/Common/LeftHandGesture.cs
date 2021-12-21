using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandGesture : MonoBehaviour
{
    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Gestures for holding stuff
    public void LeftGestureStart(float index, float three, float thumb)
    {
        ani.SetFloat("Index",index);
        ani.SetFloat("Three",three);
        ani.SetFloat("Thumb",thumb);
        ani.SetBool("isGesture", true);
    }

    public void LeftGestureEnd()
    {
        ani.SetBool("isGesture", false);
    }

    // Gesture for hand painting
    public void LeftGestureStampStart()
    {
        ani.SetBool("isGestureStamp", true);
    }

    public void LeftGestureStampEnd()
    {
        ani.SetBool("isGestureStamp", false);
    }
}
