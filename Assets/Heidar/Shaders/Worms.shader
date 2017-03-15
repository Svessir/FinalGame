// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:14,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.007843138,fgcg:0.03921569,fgcb:0.03137255,fgca:0.01960784,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:34328,y:32213,varname:node_4013,prsc:2|emission-9034-OUT,custl-6716-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:4092,x:32819,y:33017,varname:node_4092,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6716,x:33182,y:32923,varname:node_6716,prsc:2|A-3438-RGB,B-9106-RGB,C-4092-OUT,D-5060-OUT;n:type:ShaderForge.SFN_NormalVector,id:5592,x:31558,y:32474,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:2247,x:31558,y:32655,varname:node_2247,prsc:2;n:type:ShaderForge.SFN_Dot,id:3196,x:31796,y:32500,varname:node_3196,prsc:2,dt:0|A-5592-OUT,B-2247-OUT;n:type:ShaderForge.SFN_ViewVector,id:8351,x:31558,y:32840,varname:node_8351,prsc:2;n:type:ShaderForge.SFN_Dot,id:4188,x:31796,y:32746,varname:node_4188,prsc:2,dt:0|A-2247-OUT,B-8351-OUT;n:type:ShaderForge.SFN_Multiply,id:8458,x:32060,y:32565,varname:node_8458,prsc:2|A-3196-OUT,B-3209-OUT;n:type:ShaderForge.SFN_Vector1,id:3209,x:31796,y:32655,varname:node_3209,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Vector1,id:8624,x:31796,y:32907,varname:node_8624,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Multiply,id:569,x:32060,y:32792,varname:node_569,prsc:2|A-4188-OUT,B-8624-OUT;n:type:ShaderForge.SFN_Append,id:2411,x:32543,y:32600,varname:node_2411,prsc:2|A-569-OUT,B-3665-OUT;n:type:ShaderForge.SFN_Add,id:3665,x:32281,y:32534,varname:node_3665,prsc:2|A-6242-OUT,B-8458-OUT;n:type:ShaderForge.SFN_Vector1,id:6242,x:32060,y:32453,varname:node_6242,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2dAsset,id:2497,x:32544,y:32856,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:_Ramp,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e925d89b2f09d466aaaf4fc8a6dc9c99,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3438,x:32819,y:32675,varname:_node_3438,prsc:2,tex:e925d89b2f09d466aaaf4fc8a6dc9c99,ntxv:0,isnm:False|UVIN-2411-OUT,TEX-2497-TEX;n:type:ShaderForge.SFN_LightColor,id:9106,x:32819,y:32870,varname:node_9106,prsc:2;n:type:ShaderForge.SFN_Slider,id:5060,x:32662,y:33185,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:_Brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_If,id:9034,x:33640,y:31910,varname:node_9034,prsc:2|A-4862-OUT,B-5484-OUT,GT-4544-OUT,EQ-4544-OUT,LT-6168-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6001,x:31637,y:31798,ptovrint:False,ptlb:Radius,ptin:_Radius,varname:_Radius,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Vector4Property,id:9240,x:31309,y:31873,ptovrint:False,ptlb:Origin,ptin:_Origin,varname:_Origin,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:1,v4:0;n:type:ShaderForge.SFN_FragmentPosition,id:3167,x:31309,y:32096,varname:node_3167,prsc:2;n:type:ShaderForge.SFN_Distance,id:2920,x:31637,y:31987,varname:node_2920,prsc:2|A-9240-XYZ,B-3167-XYZ;n:type:ShaderForge.SFN_Subtract,id:365,x:31935,y:31866,varname:node_365,prsc:2|A-6001-OUT,B-2920-OUT;n:type:ShaderForge.SFN_Max,id:5484,x:32224,y:31949,varname:node_5484,prsc:2|A-365-OUT,B-9555-OUT;n:type:ShaderForge.SFN_Vector1,id:9555,x:31918,y:32069,varname:node_9555,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:4862,x:32634,y:32226,varname:node_4862,prsc:2,v1:2;n:type:ShaderForge.SFN_Color,id:90,x:32303,y:31257,ptovrint:False,ptlb:node_90,ptin:_node_90,varname:_node_90,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:4433,x:32679,y:31464,varname:node_4433,prsc:2|A-90-RGB,B-4544-OUT,T-8855-OUT;n:type:ShaderForge.SFN_Vector3,id:4544,x:32303,y:31504,varname:node_4544,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Divide,id:8855,x:32303,y:31650,varname:node_8855,prsc:2|A-6001-OUT,B-6068-OUT;n:type:ShaderForge.SFN_Vector1,id:6068,x:32031,y:31788,varname:node_6068,prsc:2,v1:500;n:type:ShaderForge.SFN_Fresnel,id:422,x:32286,y:32199,varname:node_422,prsc:2|NRM-5592-OUT,EXP-5468-OUT;n:type:ShaderForge.SFN_Multiply,id:6168,x:33193,y:31717,varname:node_6168,prsc:2|A-2576-OUT,B-4433-OUT;n:type:ShaderForge.SFN_Vector1,id:5468,x:32060,y:32333,varname:node_5468,prsc:2,v1:1;n:type:ShaderForge.SFN_Posterize,id:2576,x:32877,y:32049,varname:node_2576,prsc:2|IN-422-OUT,STPS-4862-OUT;proporder:2497-5060-6001-9240-90;pass:END;sub:END;*/

Shader "Shader Forge/Worm" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 1)) = 1
        _Radius ("Radius", Float ) = 0
        _Origin ("Origin", Vector) = (0,0,1,0)
        _node_90 ("node_90", Color) = (1,0,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _Brightness;
            uniform float _Radius;
            uniform float4 _Origin;
            uniform float4 _node_90;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float node_4862 = 2.0;
                float node_9034_if_leA = step(node_4862,max((_Radius-distance(_Origin.rgb,i.posWorld.rgb)),2.0));
                float node_9034_if_leB = step(max((_Radius-distance(_Origin.rgb,i.posWorld.rgb)),2.0),node_4862);
                float3 node_4544 = float3(0,0,0);
                float3 emissive = lerp((node_9034_if_leA*(floor(pow(1.0-max(0,dot(i.normalDir, viewDirection)),1.0) * node_4862) / (node_4862 - 1)*lerp(_node_90.rgb,node_4544,(_Radius/500.0))))+(node_9034_if_leB*node_4544),node_4544,node_9034_if_leA*node_9034_if_leB);
                float2 node_2411 = float2((dot(lightDirection,viewDirection)*0.8),(0.5+(dot(i.normalDir,lightDirection)*0.3)));
                float4 _node_3438 = tex2D(_Ramp,TRANSFORM_TEX(node_2411, _Ramp));
                float3 finalColor = emissive + (_node_3438.rgb*_LightColor0.rgb*attenuation*_Brightness);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _Brightness;
            uniform float _Radius;
            uniform float4 _Origin;
            uniform float4 _node_90;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float2 node_2411 = float2((dot(lightDirection,viewDirection)*0.8),(0.5+(dot(i.normalDir,lightDirection)*0.3)));
                float4 _node_3438 = tex2D(_Ramp,TRANSFORM_TEX(node_2411, _Ramp));
                float3 finalColor = (_node_3438.rgb*_LightColor0.rgb*attenuation*_Brightness);
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
