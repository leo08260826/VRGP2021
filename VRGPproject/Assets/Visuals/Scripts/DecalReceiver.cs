using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalReceiver : MonoBehaviour
{
    [SerializeField]
    private GameObject decalPrefab;
    [SerializeField]
    private int maxDecalCount = 50;
    private List<GameObject> decals = new List<GameObject>();
    private const float maxDecalHoverOffset = 0.02f;

    public void AddDecal(DecalCaster caster, RaycastHit hitInfo)
    {
        GameObject newDecal = Instantiate(decalPrefab, hitInfo.point + hitInfo.normal * 0.01f, Quaternion.LookRotation(-hitInfo.normal, caster.transform.up));
        newDecal.transform.localScale = new Vector3(caster.decalSize.x, caster.decalSize.y, 1);
        Renderer renderer = newDecal.GetComponent<Renderer>();
        MaterialPropertyBlock prop = new MaterialPropertyBlock();

        renderer.GetPropertyBlock(prop);
        prop.SetTexture("_BaseMap", caster.decalTexture);
        prop.SetColor("_Color", caster.decalColor);
        renderer.SetPropertyBlock(prop);

        newDecal.transform.SetParent(transform);
        decals.Add(newDecal);

        if(decals.Count > maxDecalCount)
        {
            GameObject oldDecal = decals[0];
            decals.RemoveAt(0);
            Destroy(oldDecal);
        }
    }
}
