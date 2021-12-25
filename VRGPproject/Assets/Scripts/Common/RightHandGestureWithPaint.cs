using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandGestureWithPaint : MonoBehaviour
{
    public Animator aniHand;
    public Animator aniPaint;

    // Gestures for holding stuff
    public void RightGestureStart(float index, float three, float thumb)
    {
        aniHand.SetFloat("Index",index);
        aniHand.SetFloat("Three",three);
        aniHand.SetFloat("Thumb",thumb);
        aniHand.SetBool("isGesture", true);

        aniPaint.SetFloat("Index",index);
        aniPaint.SetFloat("Three",three);
        aniPaint.SetFloat("Thumb",thumb);
        aniPaint.SetBool("isGesture", true);
    }

    public void RightGestureEnd()
    {
        aniHand.SetBool("isGesture", false);
        aniPaint.SetBool("isGesture", false);
    }

    // Gesture for hand painting
    public void RightGestureStampStart()
    {
        aniHand.SetBool("isGestureStamp", true);
        aniPaint.SetBool("isGestureStamp", true);
    }

    public void RightGestureStampEnd()
    {
        aniHand.SetBool("isGestureStamp", false);
        aniPaint.SetBool("isGestureStamp", false);
    }
}
