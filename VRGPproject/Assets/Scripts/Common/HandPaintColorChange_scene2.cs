using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPaintColorChange_scene2 : MonoBehaviour
{    
    public string [] pathTohandObj;
    public Color defaultColor;
    public static bool CanGetColor = false;

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

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "DrawingMaterial" && CanGetColor)
        {
            defaultColor = other.gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }
}
