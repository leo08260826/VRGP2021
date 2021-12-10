Shader "Custom/Blur"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Cull Off ZWrite Off ZTest Always

		HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
		CBUFFER_START(UnityPerMaterial)
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
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
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			float2 _BlurSize;

			float4 frag (v2f i) : SV_Target
			{
				float4 s = tex2D(sampler_MainTex, i.uv) * 0.38774;
				s += tex2D(sampler_MainTex, i.uv + float2(_BlurSize.x * 2, 0)) * 0.06136;
				s += tex2D(sampler_MainTex, i.uv + float2(_BlurSize.x, 0)) * 0.24477;
				s += tex2D(sampler_MainTex, i.uv + float2(_BlurSize.x * -1, 0)) * 0.24477;
				s += tex2D(sampler_MainTex, i.uv + float2(_BlurSize.x * -2, 0)) * 0.06136;

				return s;
			}
			ENDHLSL
		}

		// Vertical
		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			float2 _BlurSize;

			float4 frag (v2f i) : SV_Target
			{
				float4 s = tex2D(sampler_MainTex, i.uv) * 0.38774;
				s += tex2D(sampler_MainTex, i.uv + float2(0, _BlurSize.y * 2)) * 0.06136;
				s += tex2D(sampler_MainTex, i.uv + float2(0, _BlurSize.y)) * 0.24477;			
				s += tex2D(sampler_MainTex, i.uv + float2(0, _BlurSize.y * -1)) * 0.24477;
				s += tex2D(sampler_MainTex, i.uv + float2(0, _BlurSize.y * -2)) * 0.06136;

				return s;
			}
			ENDHLSL
		}
	}
}