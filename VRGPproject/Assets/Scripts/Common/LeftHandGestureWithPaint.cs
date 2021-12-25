using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandGestureWithPaint : MonoBehaviour
{
    public Animator aniHand;
    public Animator aniPaint;

    // Gestures for holding stuff
    public void LeftGestureStart(float index, float three, float thumb)
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

    public void LeftGestureEnd()
    {
        aniHand.SetBool("isGesture", false);
        aniPaint.SetBool("isGesture", false);
    }

    // Gesture for hand painting
    public void LeftGestureStampStart()
    {
        aniHand.SetBool("isGestureStamp", true);
        aniPaint.SetBool("isGestureStamp", true);
    }

    public void LeftGestureStampEnd()
    {
        aniHand.SetBool("isGestureStamp", false);
        aniPaint.SetBool("isGestureStamp", false);
    }
}
