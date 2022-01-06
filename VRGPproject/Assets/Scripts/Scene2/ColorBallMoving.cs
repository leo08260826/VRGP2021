using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.forward;
        Destroy(this.gameObject, 3f);
    }
}
