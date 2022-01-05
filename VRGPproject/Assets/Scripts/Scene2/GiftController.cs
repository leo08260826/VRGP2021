using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftController : MonoBehaviour
{
    public GameObject GlobalGift;
    public GameObject MomGiftGlowing1;
    public GameObject MomGiftGlowing2;
    

    private void Start()
    {
        GlobalGift.SetActive(false);
    }
    public void GiftDetach(){
        GlobalGift.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !TimeLineControl.GiftIsReceived && TimeLineControl.GiftIsDelivered)
        {
            MomGiftGlowing1.SetActive(false);
            MomGiftGlowing2.SetActive(false);
            TimeLineControl.GiftIsReceived = true;
        }
    }
}
