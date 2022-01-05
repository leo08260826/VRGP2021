using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketTrigger : MonoBehaviour
{
    public GameObject BucketGlow;
    public GameObject PenGlow;

    //public static bool getPen = false;
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            TimeLineControl.BucketIsTriggered = true;
            BucketGlow.SetActive(false);
            PenGlow.SetActive(false);
            
        }
    }

}
