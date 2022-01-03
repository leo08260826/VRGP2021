using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketTrigger : MonoBehaviour
{
    //public static bool getPen = false;
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            TimeLineControl.BucketIsTriggered = true;
        }
    }
}
