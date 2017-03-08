// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/echo" {
	Properties {
		_Color ("Color", Color) = (1, 1, 1, 1)
		_ColorTwo ("ColorTwo", Color) = (1, 1, 1, 1)
		_GeneralColor ("GeneralColor", Color) = (1, 1, 1, 1)
		_Center ("CenterX", vector) = (0, 0, 0)
		_CenterTwo ("CenterXTwo", vector) = (0, 0, 0)
		_Radius ("Radius", float) = 0
		_RadiusTwo ("RadiusTwo", float) = 0
	}
	SubShader {
		Pass {
			Tags { "RenderType"="Opaque" }
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			float4 _Color;
			float4 _ColorTwo;
			float4 _GeneralColor;
			float3 _Center;
			float3 _CenterTwo;
			float _Radius;
			float _RadiusTwo;

			struct v2f {
				float4 pos : SV_POSITION;
				float3 worldPos : TEXCOORD1;
			};

			v2f vert(appdata_base v) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				return o;
			}

			fixed4 frag(v2f i) : COLOR {
				float dist = distance(_Center, i.worldPos);
				float sine = sin(dist*dist);
				float gradient = 1 - ((_Radius - dist + min(0, sine )) * 0.05);
				if (gradient < 0.9 && gradient > 0.8) { gradient = 0.0; }
				else if (gradient > 1.0) {gradient = 0.0;}
				else if (gradient < 0.0) {gradient = 0.0;}

				fixed4 echoOne = fixed4((gradient * _Color.r) + _GeneralColor.r,
				 			  (gradient * _Color.g) + _GeneralColor.g,
				 			  (gradient * _Color.b) + _GeneralColor.b, 1.0);




				dist = distance(_CenterTwo, i.worldPos);
				sine = sin(dist * 1);
				gradient = 1 - ((_RadiusTwo - dist + min(0, sine )) * 0.1);
				if (gradient > -1.0 && gradient < -0.8) { gradient = 1.0; }
				else if (gradient > 1) {gradient = 0.0;}
				else if (gradient < 0.0) {gradient = 0.0;}
 
				fixed4 echoTwo = fixed4((gradient * _ColorTwo.r) + _GeneralColor.r,
				 			  (gradient * _ColorTwo.g) + _GeneralColor.g,
				 			  (gradient * _ColorTwo.b) + _GeneralColor.b, 1.0);


				return echoOne + echoTwo;
			}



			ENDCG
		}
	} 
	FallBack "Diffuse"
}