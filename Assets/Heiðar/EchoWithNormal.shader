// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:Unlit/Color,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0.1176471,fgcb:0.08356997,fgca:1,fgde:0.02,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3691,x:34431,y:32241,varname:node_3691,prsc:2|diff-6740-RGB,spec-6912-OUT,gloss-7888-OUT,normal-6048-OUT,emission-1049-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7374,x:30979,y:31793,ptovrint:False,ptlb:Radius,ptin:_Radius,varname:_Radius,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Distance,id:7377,x:31177,y:32137,varname:node_7377,prsc:2|A-950-XYZ,B-4484-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:4484,x:30864,y:32292,varname:node_4484,prsc:2;n:type:ShaderForge.SFN_Subtract,id:1626,x:31551,y:31879,cmnt:Distance to radius,varname:node_1626,prsc:2|A-7374-OUT,B-7377-OUT;n:type:ShaderForge.SFN_Vector4Property,id:950,x:30831,y:31952,ptovrint:False,ptlb:Origin,ptin:_Origin,varname:_Origin,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:1,v4:0;n:type:ShaderForge.SFN_Vector1,id:2700,x:31857,y:31968,varname:node_2700,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:6740,x:32475,y:32124,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:_Texture,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:96327048bbdc34e6da63859720b02823,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3717,x:33483,y:32473,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:_NormalMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ad1467064305949ecb9471e963ea50f5,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:6912,x:33304,y:32316,ptovrint:False,ptlb:Metalic,ptin:_Metalic,varname:_Metalic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3669454,max:1;n:type:ShaderForge.SFN_Color,id:1740,x:32112,y:32084,ptovrint:False,ptlb:node_1740,ptin:_node_1740,varname:_node_1740,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.02876297,c2:0.2794118,c3:0.1549517,c4:1;n:type:ShaderForge.SFN_Blend,id:5748,x:32910,y:32212,varname:node_5748,prsc:2,blmd:7,clmp:False|SRC-6740-RGB,DST-9717-OUT;n:type:ShaderForge.SFN_Slider,id:7888,x:33053,y:32425,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.65235,max:1;n:type:ShaderForge.SFN_If,id:1049,x:33681,y:31877,varname:node_1049,prsc:2|A-5741-OUT,B-5981-OUT,GT-8557-OUT,EQ-8557-OUT,LT-5748-OUT;n:type:ShaderForge.SFN_Max,id:5981,x:32172,y:31714,cmnt:cut out less than 0,varname:node_5981,prsc:2|A-1626-OUT,B-2700-OUT;n:type:ShaderForge.SFN_Vector1,id:5741,x:32183,y:31912,varname:node_5741,prsc:2,v1:2;n:type:ShaderForge.SFN_Lerp,id:9717,x:32475,y:32363,varname:node_9717,prsc:2|A-1740-RGB,B-7312-RGB,T-7379-OUT;n:type:ShaderForge.SFN_Vector1,id:3203,x:31248,y:32671,varname:node_3203,prsc:2,v1:500;n:type:ShaderForge.SFN_Divide,id:6899,x:31748,y:32463,varname:node_6899,prsc:2|A-7374-OUT,B-3203-OUT;n:type:ShaderForge.SFN_Color,id:7312,x:32097,y:32335,ptovrint:False,ptlb:node_7312,ptin:_node_7312,varname:_node_7312,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Clamp01,id:7379,x:32095,y:32602,varname:node_7379,prsc:2|IN-6899-OUT;n:type:ShaderForge.SFN_Multiply,id:5996,x:32930,y:31972,varname:node_5996,prsc:2|A-5981-OUT,B-6740-RGB;n:type:ShaderForge.SFN_Blend,id:8557,x:33336,y:31702,varname:node_8557,prsc:2,blmd:14,clmp:True|SRC-5996-OUT,DST-1740-RGB;n:type:ShaderForge.SFN_Slider,id:1594,x:33458,y:32783,ptovrint:False,ptlb:Normal Map Strenght,ptin:_NormalMapStrenght,varname:_NormalMapStrenght,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4743592,max:1;n:type:ShaderForge.SFN_Vector3,id:5720,x:33661,y:32585,varname:node_5720,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Lerp,id:6048,x:34049,y:32567,varname:node_6048,prsc:2|A-3717-RGB,B-5720-OUT,T-4717-OUT;n:type:ShaderForge.SFN_OneMinus,id:4717,x:33840,y:32705,varname:node_4717,prsc:2|IN-1594-OUT;proporder:7374-950-6740-3717-6912-1740-7888-7312-1594;pass:END;sub:END;*/

Shader "Custom/EchoWithNormal" {
    Properties {
        _Radius ("Radius", Float ) = 2
        _Origin ("Origin", Vector) = (0,0,1,0)
        _Texture ("Texture", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Metalic ("Metalic", Range(0, 1)) = 0.3669454
        _node_1740 ("node_1740", Color) = (0.02876297,0.2794118,0.1549517,1)
        _Gloss ("Gloss", Range(0, 1)) = 0.65235
        _node_7312 ("node_7312", Color) = (0,0,0,1)
        _NormalMapStrenght ("Normal Map Strenght", Range(0, 1)) = 0.4743592
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
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Metalic;
            uniform float4 _node_1740;
            uniform float _Gloss;
            uniform float4 _node_7312;
            uniform float _NormalMapStrenght;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = lerp(_NormalMap_var.rgb,float3(0,0,1),(1.0 - _NormalMapStrenght));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
/////// GI Data:
                UnityLight light; // Dummy light
                light.color = 0;
                light.dir = half3(0,1,0);
                light.ndotl = max(0,dot(normalDirection,light.dir));
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = 1;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
////// Specular:
                float3 specularColor = _Metalic;
                float specularMonochrome;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 diffuseColor = _Texture_var.rgb; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
/////// Diffuse:
////// Emissive:
                float node_5981 = max((_Radius-distance(_Origin.rgb,i.posWorld.rgb)),0.0); // cut out less than 0
                float node_1049_if_leA = step(2.0,node_5981);
                float node_1049_if_leB = step(node_5981,2.0);
                float3 node_8557 = saturate(( (node_5981*_Texture_var.rgb) > 0.5 ? (_node_1740.rgb + 2.0*(node_5981*_Texture_var.rgb) -1.0) : (_node_1740.rgb + 2.0*((node_5981*_Texture_var.rgb)-0.5))));
                float3 emissive = lerp((node_1049_if_leA*(lerp(_node_1740.rgb,_node_7312.rgb,saturate((_Radius/500.0)))/(1.0-_Texture_var.rgb)))+(node_1049_if_leB*node_8557),node_8557,node_1049_if_leA*node_1049_if_leB);
/// Final Color:
                outDiffuse = half4( diffuseColor, 1 );
                outSpecSmoothness = half4( specularColor, gloss );
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( lerp((node_1049_if_leA*(lerp(_node_1740.rgb,_node_7312.rgb,saturate((_Radius/500.0)))/(1.0-_Texture_var.rgb)))+(node_1049_if_leB*node_8557),node_8557,node_1049_if_leA*node_1049_if_leB), 1 );
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Radius;
            uniform float4 _Origin;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Metalic;
            uniform float4 _node_1740;
            uniform float _Gloss;
            uniform float4 _node_7312;
            uniform float _NormalMapStrenght;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = lerp(_NormalMap_var.rgb,float3(0,0,1),(1.0 - _NormalMapStrenght));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metalic;
                float specularMonochrome;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 diffuseColor = _Texture_var.rgb; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz)*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_5981 = max((_Radius-distance(_Origin.rgb,i.posWorld.rgb)),0.0); // cut out less than 0
                float node_1049_if_leA = step(2.0,node_5981);
                float node_1049_if_leB = step(node_5981,2.0);
                float3 node_8557 = saturate(( (node_5981*_Texture_var.rgb) > 0.5 ? (_node_1740.rgb + 2.0*(node_5981*_Texture_var.rgb) -1.0) : (_node_1740.rgb + 2.0*((node_5981*_Texture_var.rgb)-0.5))));
                float3 emissive = lerp((node_1049_if_leA*(lerp(_node_1740.rgb,_node_7312.rgb,saturate((_Radius/500.0)))/(1.0-_Texture_var.rgb)))+(node_1049_if_leB*node_8557),node_8557,node_1049_if_leA*node_1049_if_leB);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Radius;
            uniform float4 _Origin;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Metalic;
            uniform float4 _node_1740;
            uniform float _Gloss;
            uniform float4 _node_7312;
            uniform float _NormalMapStrenght;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = lerp(_NormalMap_var.rgb,float3(0,0,1),(1.0 - _NormalMapStrenght));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metalic;
                float specularMonochrome;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 diffuseColor = _Texture_var.rgb; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Unlit/Color"
    CustomEditor "ShaderForgeMaterialInspector"
}
