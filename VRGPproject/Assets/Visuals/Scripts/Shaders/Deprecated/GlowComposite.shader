Shader "Custom/GlowComposite"
{
    Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
		CBUFFER_START(UnityPerMaterial)
			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);
			float2 _MainTex_TexelSize;
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
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv0 = v.uv;
				o.uv1 = v.uv;

				#if UNITY_UV_STARTS_AT_TOP
				if (_MainTex_TexelSize.y < 0)
					o.uv1.y = 1 - o.uv1.y;
				#endif

				return o;
			}
			
			sampler2D _PreBlurTex;
			sampler2D _BlurTex;
			float _Intensity;

			float4 frag (v2f i) : SV_Target
			{
				float4 col = tex2D(sampler_MainTex, i.uv0);
				float4 glow = max(0, tex2D(_BlurTex, i.uv1) - tex2D(_PreBlurTex, i.uv1));
				return col + glow * _Intensity;
			}
			ENDHLSL
		}
	}
}
