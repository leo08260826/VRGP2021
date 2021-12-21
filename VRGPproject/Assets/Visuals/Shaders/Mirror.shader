Shader "Custom/Mirror"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        ENDHLSL

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase

            struct VertexInput
            {
                float4 vertex : POSITION;
            };

            struct VertexOutput
            {
                float4 pos : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };

            sampler2D _MainTex;
            static const float4 WHITE_COLOR = float4(1, 1, 1, 1);
            int display; // set to 1 to display texture, otherwise will draw white

            VertexOutput vert (VertexInput i)
            {
                VertexOutput o;
                o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
                o.screenPos = ComputeScreenPos(o.pos);
                // compute shadows data
                //TRANSFER_SHADOW(o)
                return o;
            }

            float4 frag (VertexOutput i) : SV_Target
            {
                float2 uv = float2(i.screenPos.x, i.screenPos.y) / i.screenPos.w;
                float4 mirrorCol = tex2D(_MainTex, float2(1 - uv.x, uv.y));

                // compute shadow attenuation (1.0 = fully lit, 0.0 = fully shadowed)
                //fixed shadow = SHADOW_ATTENUATION(i);
                return (mirrorCol * display + WHITE_COLOR * (1 - display)); //* max(shadow, 1);
            }
            ENDHLSL
        }
    }
    Fallback "VertexLit"
}