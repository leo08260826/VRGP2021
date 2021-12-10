using UnityEngine;

public class MousePainter : MonoBehaviour
{
    private Camera cam;
    [Space]
    public Color paintColor;
    
    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    private void Awake() 
    {
        cam = Camera.main;    
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 position = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
                transform.position = hit.point;
                Paintable p = hit.collider.GetComponent<Paintable>();
                if(p != null)
                    PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
            }
        }
    }
}
