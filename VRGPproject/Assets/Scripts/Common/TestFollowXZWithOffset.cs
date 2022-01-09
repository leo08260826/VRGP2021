using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollowXZWithOffset : MonoBehaviour
{
    public GameObject followed;
    public GameObject follower;
    public float offsetX = 0;
    public float offsetZ = 0;

    void Update()
    {
        float newX = followed.transform.position.x + offsetX;
        float newZ = followed.transform.position.z + offsetZ;
        follower.transform.position = new Vector3(newX, follower.transform.position.y, newZ);
    }
}
