using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPaintColorChange : MonoBehaviour
{    
    public string handObjName;
    public string colorObjName;
    public Color defaultColor;

    private GameObject colorObj = null;

    void Update()
    {
        if(colorObj==null)
        {
            colorObj = transform.Find(handObjName).gameObject.transform.Find(colorObjName).gameObject;
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
