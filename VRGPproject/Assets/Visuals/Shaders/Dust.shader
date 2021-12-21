Shader "Custom/Dust"
{
    Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _TintColor("Tint Color", Color) = (1,1,1,1)
	}
	SubShader
	{
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        Lighting Off
        Blend SrcAlpha OneMinusSrcAlpha 
		ZWrite Off 
        ZTest Always

		HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
		CBUFFER_START(UnityPerMaterial)
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
            float4 _TintColor;
		CBUFFER_END
        ENDHLSL

		// Horizontal
		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct appdata
			{
				float4 vertex : POSITION;
                float4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
                float4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.color = v.color;
				o.uv = v.uv;
				return o;
			}

			float4 frag (v2f i) : SV_Target
			{
                float4 col = _MainTex.Sample(sampler_MainTex, i.uv);
				return col * i.color * _TintColor;
			}
			ENDHLSL
		}
	}
}
