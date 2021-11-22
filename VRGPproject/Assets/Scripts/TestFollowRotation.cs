using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollowRotation : MonoBehaviour
{
    public GameObject followed;
    public GameObject follower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        follower.transform.eulerAngles = new Vector3(follower.transform.eulerAngles.x, followed.transform.eulerAngles.y, follower.transform.eulerAngles.z );
    }
}
