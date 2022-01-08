using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineControl : MonoBehaviour
{
    [HideInInspector]
    public PlayableDirector PD;

    public AudioClip[] audios;

    public GameObject ColorFloorInteraction;
    public GameObject GiftGlow1;
    public GameObject GiftGlow2;
    public GameObject ColorGlow_orange;
    public GameObject ColorGlow_yellow;
    public GameObject ColorGlow_purple;
    public GameObject Hint_getColor;
    public GameObject Hint_Stamp;

    public static bool BucketIsTriggered = false;
    public static bool StampIsTriggered = false;
    public static bool GiftIsDelivered = false;
    public static bool GiftIsReceived = false;
    public static bool showHintOnce = false;
    private bool StampHadTriggered = false;

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
            //Debug.Log("Now Pause!");
        }
    }

    public void MyContinue()
    {
        if(PD != null)
        {
            PD.playableGraph.GetRootPlayable(0).SetSpeed(1);
            //Debug.Log("Now Continue!");
        }
    }
    public void Asking()
    {
        Debug.Log("Asking");
        MyPause();
        Invoke("MyContinue", 2f);
        this.GetComponent<AudioSource>().clip = audios[0];
        this.GetComponent<AudioSource>().Play();
    }

    public void Stop2Talk()
    {
        Debug.Log("Stop2Talk");
        MyPause();
        Invoke("MyContinue", 3f);
        this.GetComponent<AudioSource>().clip = audios[1];
        this.GetComponent<AudioSource>().Play();
        //Invoke("MyContinue", 3f); // wait for talking
    }

    public void CanGetColor()
    {
        Debug.Log("CanGetColor");
        MyPause();
        ////// should delete
        //Invoke("MyContinue", 3f);
        //////
        this.GetComponent<AudioSource>().clip = audios[2];
        this.GetComponent<AudioSource>().Play();
        HandPaintColorChange_scene2.CanGetColor = true;
        ColorFloorInteraction.SetActive(true);
        Hint_getColor.SetActive(true);
        ColorGlow_orange.SetActive(true);
        ColorGlow_yellow.SetActive(true);
        ColorGlow_purple.SetActive(true);
    }

    public void LeaveRoom()
    {
        Debug.Log("LeaveRoom");
        ColorGlow_orange.SetActive(false);
        ColorGlow_yellow.SetActive(false);
        ColorGlow_purple.SetActive(false);
        MyContinue();
    }

    public void DeliverGift()
    {
        Debug.Log("DeliverGift");
        this.GetComponent<AudioSource>().clip = audios[3];
        this.GetComponent<AudioSource>().Play();
        MyPause();
        ////// should delete
        //Invoke("MyContinue", 3f);
        //////
        Invoke("ActivateGift", 6f);
    }

    public void ActivateGift()
    {
        GiftGlow1.SetActive(true);
        GiftGlow2.SetActive(true);
        GiftIsDelivered = true;
    }

    public void Faint()
    {
        Debug.Log("Faint");
        MyContinue();
    }

    public void Update()
    {
        if (BucketIsTriggered)
        {
            PD.Play();
            BucketIsTriggered = false;
        }
        else if (StampIsTriggered && !StampHadTriggered)
        {
            LeaveRoom();
            StampIsTriggered = false;
            StampHadTriggered = true;
        }
        else if (GiftIsReceived)
        {
            Faint();
            GiftIsReceived = false;
        }
    }
}
