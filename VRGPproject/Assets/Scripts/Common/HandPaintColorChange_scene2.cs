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
        Debug.Log("hand paint trigger object : " + other+"\n tag : " + other.tag);
        if(other.tag == "DrawingMaterial_onFloor")
        {
            Debug.Log("Change Hand Color_onFloor");
            ChangeColor(Color_onFloor);
            defaultColor = Color_onFloor;
        }
        else if(other.tag == "DrawingMaterial")
        {
            Debug.Log("Change Hand Color");
            Material_Color = other.gameObject.GetComponent<MeshRenderer>().material.color;
            ChangeColor(Material_Color);
            defaultColor = Material_Color;
        }
        
    }
}
