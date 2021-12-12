using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandGesture : MonoBehaviour
{
    Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

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
}
