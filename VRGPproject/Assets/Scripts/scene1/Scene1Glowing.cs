using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Glowing : MonoBehaviour
{
    public float speed = 1f;
    public Glow [] glowObjs;

    void Update()
    {
        float timeArg = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup*speed));
        for(int i=0; i<glowObjs.Length; i++)
        {
            glowObjs[i].glowStr = timeArg;
        }
    }
}
