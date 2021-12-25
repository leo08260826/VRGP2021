Shader "Custom/Transition"
{
    Properties
    {
        _MainTex ("Fade Map", 2D) = "white" {}
        _Progress ("Progress", float) = 0
        _Color ("Color", Color) = (0,0,0,1)
        [HDR]_RimColor ("Rim Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Overlay" }
        ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _RimColor;
            float _Progress;

            const static fixed4 TRANSPARENT = fixed4(1,1,1,0);

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 plot = tex2D(_MainTex, i.uv);
                float trueProgress = (_Progress * 1.02f + ((plot.x - 0.5f) * 0.1f)) * _MainTex_ST.y;
                float lerpValue = 
                (
                    step(trueProgress - 0.015f, i.uv.y) + 
                    step(trueProgress - 0.01f, i.uv.y) + 
                    step(trueProgress - 0.005f, i.uv.y) + 
                    step(trueProgress, i.uv.y) + 
                    step(trueProgress + 0.005f, i.uv.y) +
                    step(trueProgress + 0.01f, i.uv.y) + 
                    step(trueProgress + 0.015f, i.uv.y)
                )/7;

                return (_Color * (1 - lerpValue) + _RimColor * lerpValue);
            }
            ENDCG
        }
    }
}
