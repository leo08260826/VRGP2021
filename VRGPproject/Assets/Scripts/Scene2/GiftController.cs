using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftController : MonoBehaviour
{
    public GameObject GlobalGift;

    private void Start()
    {
        GlobalGift.SetActive(false);
    }
    public void GiftDetach(){
        GlobalGift.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !TimeLineControl.GiftIsReceived)
        {
            TimeLineControl.GiftIsReceived = true;
        }
    }
}
