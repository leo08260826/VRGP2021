using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPaintColorChange : MonoBehaviour
{    
    public string [] pathTohandObj;
    public Color defaultColor;

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
    
}
