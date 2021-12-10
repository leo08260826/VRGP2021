Shader "Unlit/Glow"
{
    Properties
    {
        [Gamma][HDR]_GlowColor ("GlowColor", Color) = (1,1,1,1)
        _GlowStr ("GlowStr", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Overlay-1" }
        Ztest Always
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        CBUFFER_START(UnityPerMaterial)
            float4 _GlowColor;
            float _GlowStr;
        CBUFFER_END
        ENDHLSL

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata 
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float3 normal : NORMAL; 
                float3 worldPos : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;

                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.normal = normalize(TransformObjectToWorldNormal(v.normal));
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                //fixed3 camNorm = mul((float3x3)unity_CameraToWorld, float3(0,0,-1));
                float3 camNorm = normalize(_WorldSpaceCameraPos - i.worldPos); 
                float dotProduct = dot(camNorm, i.normal);
                
                dotProduct = pow(dotProduct, 1.5f);
                float4 col = _GlowColor;
                col.w = clamp((1 - dotProduct) * _GlowStr,0,1);
                return col;
            }
            
            ENDHLSL
        }
    }
}
