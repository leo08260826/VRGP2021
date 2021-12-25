using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineControl : MonoBehaviour
{
    public PlayableDirector PD;
    public bool IsPause = false;

    public GameObject mom_face;
    public GameObject player_face;

    // Start is called before the first frame update
    void Start()
    {
        PD = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    /*void Update()
    {
        //獲取播放進度
        //float normalizedTime = (float)(PD.time / PD.duration);
        if (IsPause)
        {
            
        }
    }*/

    public void MyPause()
    {
        if(PD != null)
        {
            //PD.Pause() will reset transform
            //PD.Stop() can't continue to play with the status of stop;
            PD.playableGraph.GetRootPlayable(0).SetSpeed(0);
            //IsPause = true;
            Invoke("MyContinue", 3f);
        }
    }

    public void MyContinue()
    {
        if(PD != null)
        {
            PD.playableGraph.GetRootPlayable(0).SetSpeed(1);
        }
    }

    public void FacePlayer()
    {
        mom_face.transform.LookAt(player_face.transform);
        MyPause();
        Debug.Log("FacePlayer!!!");
    }
}
