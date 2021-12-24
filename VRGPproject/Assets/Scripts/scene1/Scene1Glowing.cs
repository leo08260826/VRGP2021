using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Glowing : MonoBehaviour
{
    public Glow [] glowObjs;

    void Update()
    {
        float timeArg = Mathf.Abs(Mathf.Sin(Time.deltaTime));
        for(int i=0; i<glowObjs.Length; i++)
        {
            glowObjs[i].glowStr = timeArg;
        }
    }
}
