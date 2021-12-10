using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Mirror : MonoBehaviour
{
    private Camera mainCam;
    private Camera mirrorCam;
    private MeshRenderer mirror;
    private MeshFilter filter;
    private RenderTexture mirrorTexture = null;

    private Vector3 mirrorNormal { get { return transform.TransformDirection(filter.mesh.normals[0]);} }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        mirrorCam = GetComponentInChildren<Camera>();
        mirror = GetComponent<MeshRenderer>();
        filter = GetComponent<MeshFilter>();

        mirrorCam.enabled = true;
    }

    void LateUpdate()
    {
        MoveMirrorCam();
        Render();
    }

    void MoveMirrorCam()
    {
        //Update position.
        Vector3 mainCamToMirror = transform.position - mainCam.transform.position;
        Vector3 reflect = Vector3.Reflect(mainCamToMirror, mirrorNormal);
        mirrorCam.transform.position = transform.position - reflect;

        //Update rotation. (From: http://www.euclideanspace.com/maths/geometry/affine/reflection/quaternion/index.htm)
        //It says that Pout = q * Pin * q
        //Pin is the input quaternion.
        //q is the reflect normal vector in quaternion form.
        //Pout is the reflected quaternion.
        //...I have absolutly no idea how this work.
        //...And this seems to fail when the normal is +Z or -Z axis.
        //Quaternion mirrorQuaternion = new Quaternion(-mirrorNormal.x, -mirrorNormal.y, -mirrorNormal.z, 0);
        //mirrorCam.transform.rotation = mirrorQuaternion * mainCam.transform.rotation * mirrorQuaternion;

        //So, here's another questionable approach.
        Vector3 forw = mainCam.transform.forward;
        Vector3 up = mainCam.transform.up;
        Vector3 mirrorForw = Vector3.Reflect(forw, mirrorNormal);
        Vector3 mirrorUp = Vector3.Reflect(up, mirrorNormal);
        mirrorCam.transform.rotation = Quaternion.LookRotation(mirrorForw, mirrorUp);
    }

    void Render()
    {
        if(!IsVisible())
        {
            mirror.material.SetInt("display", 0);
            return;
        } 
        mirror.material.SetInt("display", 1);

        SetNearClipPlane();
        CreateRenderTexture();
        //mirrorCam.targetTexture = mirrorTexture;
        //mirror.material.SetTexture ("_MainTex", mirrorTexture);
    }

    bool IsVisible()
    {
        Vector3 mainCamToMirror = transform.position - mainCam.transform.position;

        if(Vector3.Dot(mirrorNormal, mainCamToMirror) >= 0)
            return false;
        
        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(mainCam);
        return GeometryUtility.TestPlanesAABB(frustumPlanes, mirror.bounds);
    }

    void CreateRenderTexture()
    {
        if (mirrorTexture == null || mirrorTexture.width != Screen.width || mirrorTexture.height != Screen.height) {
            if (mirrorTexture != null) {
                mirrorTexture.Release ();
            }
            mirrorTexture = new RenderTexture (Screen.width, Screen.height, 0);
            mirrorCam.targetTexture = mirrorTexture;
            mirror.material.SetTexture ("_MainTex", mirrorTexture);
        }
    }

    void SetNearClipPlane()
    {
        // Use custom projection matrix to align portal camera's near clip plane with the surface of the mirror.
        // AKA oblique projection. (From: http://www.terathon.com/lengyel/Lengyel-Oblique.pdf)
        int dot = (int)Mathf.Sign(Vector3.Dot (transform.forward, transform.position - mirrorCam.transform.position));

        Vector3 camSpacePos = mirrorCam.worldToCameraMatrix.MultiplyPoint(transform.position);
        Vector3 camSpaceNormal = mirrorCam.worldToCameraMatrix.MultiplyVector(transform.forward) * dot;
        float camSpaceDst = -Vector3.Dot (camSpacePos, camSpaceNormal);

        Vector4 clipPlaneCameraSpace = new Vector4 (camSpaceNormal.x, camSpaceNormal.y, camSpaceNormal.z, camSpaceDst);

        // Update projection based on new clip plane
        mirrorCam.projectionMatrix = mirrorCam.CalculateObliqueMatrix (clipPlaneCameraSpace);
    }
}
