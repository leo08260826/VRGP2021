using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SelectiveOutlineGlowRenderer : MonoBehaviour
{
    private static SelectiveOutlineGlowRenderer _instance = null;
    public static SelectiveOutlineGlowRenderer instance { get { return _instance; } }
    private Dictionary<SelectiveOutlineGlowObject, bool> glowObjects = new Dictionary<SelectiveOutlineGlowObject, bool>(); 

    [SerializeField]
    private Shader preGlowShader;
    [SerializeField]
    private Shader blurShader;
    [SerializeField]
    private Shader glowCompositeShader;
    [SerializeField, Range(0,5)]
    private float intensity;

    private Material blurMat;
    private Material glowCompositeMat;

    private CommandBuffer cmb;
    private RenderTexture preBlur;
    private RenderTexture afterBlur;

    private Camera cam;

    void Awake() 
    {
        if(_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
        cam = GetComponent<Camera>();

        blurMat = new Material(blurShader);
        glowCompositeMat = new Material(glowCompositeShader);    
    }

    public void AddGlowObject(SelectiveOutlineGlowObject obj)
    {
        if(!glowObjects.ContainsKey(obj))
            glowObjects.Add(obj,true);
    }

    public void RemoveGlowObject(SelectiveOutlineGlowObject obj)
    {
        if(glowObjects.ContainsKey(obj))
            glowObjects.Remove(obj);
    }
    

    void LateUpdate()
    {
        cmb = new CommandBuffer();

        preBlur = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.Default);
        afterBlur = new RenderTexture(Screen.width, Screen.height, 0);

        cmb.SetRenderTarget(preBlur);
        cmb.ClearRenderTarget(true, true, Color.black);
        
        foreach(SelectiveOutlineGlowObject obj in glowObjects.Keys)
        {
            Material preGlowMat = new Material(preGlowShader);
            preGlowMat.SetColor("_Color", obj.glowColor);
            cmb.DrawRenderer(obj.render, preGlowMat);
        }

        cmb.Blit(preBlur, afterBlur);
        cmb.SetRenderTarget(afterBlur);

        blurMat.SetVector("_BlurSize", new Vector2(preBlur.texelSize.x * 2, preBlur.texelSize.y * 2));
        for (int i = 0; i < 10; i++)
		{
			var temp = RenderTexture.GetTemporary(afterBlur.width, afterBlur.height);
			cmb.Blit(afterBlur, temp, blurMat, 0);
			cmb.Blit(temp, afterBlur, blurMat, 1);
			RenderTexture.ReleaseTemporary(temp);
		}

        glowCompositeMat.SetTexture("_PreBlurTex", preBlur);
        glowCompositeMat.SetTexture("_BlurTex", afterBlur);
        glowCompositeMat.SetFloat("_Intensity", intensity);

        cmb.Blit
        (
            BuiltinRenderTextureType.CameraTarget, 
            BuiltinRenderTextureType.CameraTarget, 
            glowCompositeMat
        );
        //Graphics.Blit(preBlur, dest);

        Graphics.ExecuteCommandBuffer(cmb);
        preBlur.Release();
        afterBlur.Release();
    }
}
