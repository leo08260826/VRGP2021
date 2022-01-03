using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineControl : MonoBehaviour
{
    [HideInInspector]
    public PlayableDirector PD;

    private bool Pause = false;
    static int anim_stage = 0;

    public static bool BucketIsTriggered = false;
    public static bool StampIsTriggered = false;
    public static bool GiftIsReceived = false;

    // Start is called before the first frame update
    void Start()
    {
        PD = GetComponent<PlayableDirector>();
    }

    public void MyPause()
    {
        if(PD != null)
        {
            //PD.Pause() will reset transform
            //PD.Stop() can't continue to play with the status of stop;
            PD.playableGraph.GetRootPlayable(0).SetSpeed(0);
            Invoke("MyContinue", 1f);
            anim_stage += 1;
            Pause = true;
            Debug.Log("Now Pause!");
        }
    }

    public void MyContinue()
    {
        if(PD != null)
        {
            PD.playableGraph.GetRootPlayable(0).SetSpeed(1);
            Pause = false;
            Debug.Log("Now Continue!");
        }
    }

    public void Stop2Talk()
    {
        if(anim_stage == 1)
        {
            MyPause(); 
            Invoke("MyContinue", 3f); // wait for talking
        }
    }

    public void CanGetColor()
    {
        MyPause();
        HandPaintColorChange_scene2.CanGetColor = true;
    }

    public void LeaveRoom()
    {   
        if(anim_stage == 2 && Pause)
        {
            MyContinue();
        }
    }

    public void Faint()
    {
        if (anim_stage == 3 && Pause)
        {
            MyContinue();
        }
    }

    public void Update()
    {
        if (BucketIsTriggered)
        {
            PD.Play();
        }
        else if (StampIsTriggered)
        {
            LeaveRoom();
        }
        else if (GiftIsReceived)
        {
            Faint();
        }
    }
}
