using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scene1TimelineController : MonoBehaviour
{
    public GameObject [] timelines;
    public GameObject [] triggerObj;
    public PlayableDirector prevTimeline;
    private bool [] havePlayeds;
    private bool canPlay = false; 

    void Start()
    {
        havePlayeds = new bool[timelines.Length];
        for(int i=0; i<havePlayeds.Length; i++)
        {
            havePlayeds[i] = false;
        }
    }
    
    public void PlayTimeline(int index)
    {
        if(!havePlayeds[index] && canPlay)
        { 
            triggerObj[index].SetActive(false);
            havePlayeds[index] = true;
            canPlay = false;
            timelines[index].GetComponent<PlayableDirector>().Play();
            prevTimeline.Stop();
        }
    }

    public void MakeCanPlay()
    {
        canPlay = true;
    }

}
