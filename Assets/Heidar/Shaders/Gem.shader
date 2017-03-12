// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:14,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.007843138,fgcg:0.03921569,fgcb:0.03137255,fgca:0.01960784,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33542,y:32647,varname:node_4013,prsc:2|custl-6716-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:4092,x:32703,y:33126,varname:node_4092,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6716,x:33182,y:32923,varname:node_6716,prsc:2|A-3438-RGB,B-9106-RGB,C-4092-OUT,D-5060-OUT;n:type:ShaderForge.SFN_NormalVector,id:5592,x:31558,y:32474,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:2247,x:31558,y:32655,varname:node_2247,prsc:2;n:type:ShaderForge.SFN_Dot,id:3196,x:31796,y:32500,varname:node_3196,prsc:2,dt:0|A-5592-OUT,B-2247-OUT;n:type:ShaderForge.SFN_ViewVector,id:8351,x:31558,y:32840,varname:node_8351,prsc:2;n:type:ShaderForge.SFN_Dot,id:4188,x:31796,y:32746,varname:node_4188,prsc:2,dt:0|A-2247-OUT,B-8351-OUT;n:type:ShaderForge.SFN_Multiply,id:8458,x:32060,y:32565,varname:node_8458,prsc:2|A-3196-OUT,B-3209-OUT;n:type:ShaderForge.SFN_Vector1,id:3209,x:31796,y:32655,varname:node_3209,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Vector1,id:8624,x:31796,y:32907,varname:node_8624,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Multiply,id:569,x:32060,y:32792,varname:node_569,prsc:2|A-4188-OUT,B-8624-OUT;n:type:ShaderForge.SFN_Append,id:2411,x:32543,y:32600,varname:node_2411,prsc:2|A-569-OUT,B-3665-OUT;n:type:ShaderForge.SFN_Add,id:3665,x:32281,y:32534,varname:node_3665,prsc:2|A-6242-OUT,B-8458-OUT;n:type:ShaderForge.SFN_Vector1,id:6242,x:32060,y:32453,varname:node_6242,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2dAsset,id:2497,x:32544,y:32856,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:_Ramp,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e925d89b2f09d466aaaf4fc8a6dc9c99,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3438,x:32819,y:32675,varname:_node_3438,prsc:2,tex:e925d89b2f09d466aaaf4fc8a6dc9c99,ntxv:0,isnm:False|UVIN-2411-OUT,TEX-2497-TEX;n:type:ShaderForge.SFN_LightColor,id:9106,x:32703,y:32928,varname:node_9106,prsc:2;n:type:ShaderForge.SFN_Slider,id:5060,x:32818,y:33243,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:_Brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;proporder:2497-5060;pass:END;sub:END;*/

Shader "Shader Forge/Gem" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 1)) = 1
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
                float2 node_2411 = float2((dot(lightDirection,viewDirection)*0.8),(0.5+(dot(i.normalDir,lightDirection)*0.3)));
                float4 _node_3438 = tex2D(_Ramp,TRANSFORM_TEX(node_2411, _Ramp));
                float3 finalColor = (_node_3438.rgb*_LightColor0.rgb*attenuation*_Brightness);
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
