using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomFlow : MonoBehaviour
{
    public Animator mom_ac;
    public GameObject mom_face;
    public GameObject player_face;
    int face_No = 0;

    private void Start()
    {
        Invoke("EnterRoom", 2f);
    }
    // Update is called once per frame
    void Update()
    {

    }



    public void FacePlayer()
    {
        mom_face.transform.LookAt(player_face.transform);
        switch (face_No)
        {
            case 0:
                Invoke("GetColor", 2f);
                face_No += 1;
                break;
            case 1:
                Invoke("LeaveRoom", 5f);
                face_No += 1;
                break;
            case 2:
                Invoke("GiveGift", 2f);
                face_No += 1;
                break;
        }
    }
    public void EnterRoom()
    {
        mom_ac.SetBool("EnterRoom", true);
    }

    public void GetColor(){
        mom_ac.SetBool("GetColor", true);
    }

    public void LeaveRoom()
    {
        mom_ac.SetBool("LeaveRoom", true);
    }
    public void GiveGift()
    {
        mom_ac.SetBool("GiveGift", true);
    }
    public void Faint()
    {
        mom_ac.SetBool("Faint", true);
    }
}
