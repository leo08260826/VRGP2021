using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintHand_moving : MonoBehaviour
{
    private Vector3 origin = new Vector3(0.35f, 1f, 1.25f);
    public int which_hint = 0;

    void FixedUpdate()
    {
        switch (which_hint){
            case 0 :
                if (this.gameObject.transform.position.y <= 0.25f)
                {
                    this.gameObject.transform.position = origin;
                }
                this.gameObject.transform.position += Vector3.down * Time.deltaTime * 0.3f;
                break;
            case 1 :
                if (this.gameObject.transform.position.z >= 1.95f)
                {
                    this.gameObject.transform.position = origin;
                }
                this.gameObject.transform.position += Vector3.forward * Time.deltaTime * 0.3f;
                break;
        }
        
        
    }
}
