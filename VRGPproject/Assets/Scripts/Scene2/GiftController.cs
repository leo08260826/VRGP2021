using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftController : MonoBehaviour
{
    public GameObject MomGiftGlowing;
    

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void TriggerGift(){
        if (!TimeLineControl.GiftIsReceived && TimeLineControl.GiftIsDelivered)
        {
            Debug.Log("hand trigger gift");
            MomGiftGlowing.SetActive(false);
            TimeLineControl.GiftIsReceived = true;
        }
    }
}
