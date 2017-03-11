// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:Unlit/Color,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:14,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0.1176471,fgcb:0.08356997,fgca:1,fgde:0.02,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3691,x:34323,y:32090,varname:node_3691,prsc:2|emission-1049-OUT,custl-1049-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7374,x:30979,y:31793,ptovrint:False,ptlb:Radius,ptin:_Radius,varname:_Radius,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Distance,id:7377,x:31177,y:32137,varname:node_7377,prsc:2|A-950-XYZ,B-4484-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:4484,x:30864,y:32292,varname:node_4484,prsc:2;n:type:ShaderForge.SFN_Subtract,id:1626,x:31551,y:31879,cmnt:Distance to radius,varname:node_1626,prsc:2|A-7374-OUT,B-7377-OUT;n:type:ShaderForge.SFN_Vector4Property,id:950,x:30831,y:31952,ptovrint:False,ptlb:Origin,ptin:_Origin,varname:_Origin,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:1,v4:0;n:type:ShaderForge.SFN_Vector1,id:2700,x:31857,y:31968,varname:node_2700,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:6740,x:32475,y:32124,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:_Texture,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:96327048bbdc34e6da63859720b02823,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:1740,x:32097,y:32084,ptovrint:False,ptlb:node_1740,ptin:_node_1740,varname:_node_1740,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.02876297,c2:0.2794118,c3:0.1549517,c4:1;n:type:ShaderForge.SFN_Blend,id:5748,x:32910,y:32215,varname:node_5748,prsc:2,blmd:7,clmp:False|SRC-6740-RGB,DST-9717-OUT;n:type:ShaderForge.SFN_If,id:1049,x:33792,y:31673,varname:node_1049,prsc:2|A-5741-OUT,B-5981-OUT,GT-8557-OUT,EQ-8557-OUT,LT-5748-OUT;n:type:ShaderForge.SFN_Max,id:5981,x:32172,y:31714,cmnt:cut out less than 0,varname:node_5981,prsc:2|A-1626-OUT,B-2700-OUT;n:type:ShaderForge.SFN_Vector1,id:5741,x:33506,y:31628,varname:node_5741,prsc:2,v1:2;n:type:ShaderForge.SFN_Lerp,id:9717,x:32475,y:32363,varname:node_9717,prsc:2|A-1740-RGB,B-7312-RGB,T-7379-OUT;n:type:ShaderForge.SFN_Vector1,id:3203,x:31248,y:32671,varname:node_3203,prsc:2,v1:500;n:type:ShaderForge.SFN_Divide,id:6899,x:31748,y:32463,varname:node_6899,prsc:2|A-7374-OUT,B-3203-OUT;n:type:ShaderForge.SFN_Color,id:7312,x:32095,y:32372,ptovrint:False,ptlb:node_7312,ptin:_node_7312,varname:_node_7312,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Clamp01,id:7379,x:32095,y:32632,varname:node_7379,prsc:2|IN-6899-OUT;n:type:ShaderForge.SFN_Multiply,id:5996,x:32910,y:31977,varname:node_5996,prsc:2|A-5981-OUT,B-6740-RGB;n:type:ShaderForge.SFN_Blend,id:8557,x:33222,y:31828,varname:node_8557,prsc:2,blmd:14,clmp:True|SRC-5996-OUT,DST-1740-RGB;proporder:7374-950-6740-1740-7312;pass:END;sub:END;*/

Shader "Custom/EchoJustDiffuse" {
    Properties {
        _Radius ("Radius", Float ) = 2
        _Origin ("Origin", Vector) = (0,0,1,0)
        _Texture ("Texture", 2D) = "white" {}
        _node_1740 ("node_1740", Color) = (0.02876297,0.2794118,0.1549517,1)
        _node_7312 ("node_7312", Color) = (0,0,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "DEFERRED"
            Tags {
                "LightMode"="Deferred"
            }
            
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_DEFERRED
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile ___ UNITY_HDR_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Radius;
            uniform float4 _Origin;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _node_1740;
            uniform float4 _node_7312;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            void frag(
                VertexOutput i,
                out half4 outDiffuse : SV_Target0,
                out half4 outSpecSmoothness : SV_Target1,
                out half4 outNormal : SV_Target2,
                out half4 outEmission : SV_Target3 )
            {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float node_5981 = max((_Radius-distance(_Origin.rgb,i.posWorld.rgb)),0.0); // cut out less than 0
                float node_1049_if_leA = step(2.0,node_5981);
                float node_1049_if_leB = step(node_5981,2.0);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_8557 = saturate(( (node_5981*_Texture_var.rgb) > 0.5 ? (_node_1740.rgb + 2.0*(node_5981*_Texture_var.rgb) -1.0) : (_node_1740.rgb + 2.0*((node_5981*_Texture_var.rgb)-0.5))));
                float3 node_1049 = lerp((node_1049_if_leA*(lerp(_node_1740.rgb,_node_7312.rgb,saturate((_Radius/500.0)))/(1.0-_Texture_var.rgb)))+(node_1049_if_leB*node_8557),node_8557,node_1049_if_leA*node_1049_if_leB);
                float3 emissive = node_1049;
                float3 finalColor = emissive;
                outDiffuse = half4( 0, 0, 0, 1 );
                outSpecSmoothness = half4(0,0,0,0);
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( node_1049, 1 );
                #ifndef UNITY_HDR_ON
                    outEmission.rgb = exp2(-outEmission.rgb);
                #endif
            }
            ENDCG
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Radius;
            uniform float4 _Origin;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _node_1740;
            uniform float4 _node_7312;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float node_5981 = max((_Radius-distance(_Origin.rgb,i.posWorld.rgb)),0.0); // cut out less than 0
                float node_1049_if_leA = step(2.0,node_5981);
                float node_1049_if_leB = step(node_5981,2.0);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 node_8557 = saturate(( (node_5981*_Texture_var.rgb) > 0.5 ? (_node_1740.rgb + 2.0*(node_5981*_Texture_var.rgb) -1.0) : (_node_1740.rgb + 2.0*((node_5981*_Texture_var.rgb)-0.5))));
                float3 node_1049 = lerp((node_1049_if_leA*(lerp(_node_1740.rgb,_node_7312.rgb,saturate((_Radius/500.0)))/(1.0-_Texture_var.rgb)))+(node_1049_if_leB*node_8557),node_8557,node_1049_if_leA*node_1049_if_leB);
                float3 emissive = node_1049;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Unlit/Color"
    CustomEditor "ShaderForgeMaterialInspector"
}
