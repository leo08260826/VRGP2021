using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBucketGlowController : MonoBehaviour
{
    public GameObject[] glows;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && HandPaintColorChange_scene2.CanGetColor)
        {
            foreach (var glow in glows)
            {
                glow.SetActive(false);
            }
        }
    }
}
