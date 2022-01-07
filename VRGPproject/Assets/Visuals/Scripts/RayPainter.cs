using UnityEngine;

public class RayPainter : MonoBehaviour
{
    public LayerMask checkMask;
    public float checkLength;
    [SerializeField]
    private bool debug = false;

    [Space(10)]
    public Color paintColor;    
    public float radius = 1;
    [Range(0f,1f)]
    public float strength = 1;
    [Range(0f,1f)]
    public float hardness = 1;

    private bool castRay = false;

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Mouse0))
        //     castRay = true;
        // if(Input.GetKeyUp(KeyCode.Mouse0))
        //     castRay = false;
        if(castRay)
            CastPaintingRay();
    }

    public void StartCastRay() { castRay = true; }
    
    public void StopCastRay() { castRay = false; }

    public void CastPaintingRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,checkLength,checkMask))
        {
            if(debug)
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
            Paintable p = null;
            if(hit.collider.gameObject.TryGetComponent(out p)) {
                PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
            }
        }
    }
}
