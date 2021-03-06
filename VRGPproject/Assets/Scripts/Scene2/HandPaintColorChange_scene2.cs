using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPaintColorChange_scene2 : MonoBehaviour
{    
    public string [] pathTohandObj;
    public Color defaultColor;
    public static bool CanGetColor = false;
    public Color Material_Color;
    public Color Color_onFloor;

    public GameObject Wall_interaction;
    public GameObject Hint_getColor;
    public GameObject Hint_Stamp;
    private GameObject colorObj = null;

    void Update()
    {
        if(colorObj==null)
        {
            colorObj = gameObject;
            for(int i=0; i<pathTohandObj.Length; i++)
            {
                colorObj = colorObj.transform.Find(pathTohandObj[i]).gameObject;
            }
            ChangeColor(defaultColor);
        }
    }

    public void ChangeColor(Color c)
    {
        if(colorObj==null) return;

        Material m_Material = colorObj.GetComponent<Renderer>().material;
        m_Material.color = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DrawingMaterial_onFloor" &&　CanGetColor)
        {
            //Debug.Log("Change Hand Color_onFloor");
            ChangeColor(Color_onFloor);
            defaultColor = Color_onFloor;
            if (!TimeLineControl.showHintOnce)
            {
                Hint_getColor.SetActive(false);
                Hint_Stamp.SetActive(true);
                TimeLineControl.showHintOnce = true;
            }
        }
        else if(other.tag == "DrawingMaterial" && CanGetColor)
        {
            //Debug.Log("Change Hand Color");
            Material_Color = other.gameObject.GetComponent<MeshRenderer>().material.color;
            ChangeColor(Material_Color);
            defaultColor = Material_Color;
            if (!TimeLineControl.showHintOnce)
            {
                Hint_getColor.SetActive(false);
                Hint_Stamp.SetActive(true);
                Wall_interaction.SetActive(true);
                TimeLineControl.showHintOnce = true;
            }
        }
    }
}
