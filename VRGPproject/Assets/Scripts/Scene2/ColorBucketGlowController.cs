using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBucketGlowController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && HandPaintColorChange_scene2.CanGetColor)
        {
            this.gameObject.SetActive(false);
        }
    }
}
