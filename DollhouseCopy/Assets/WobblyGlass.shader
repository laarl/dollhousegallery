Shader "Unlit/WobblyGlass"
{
    Properties
    {
       
        _Color ("Color", Color) = (1,1,1,0)
        _WaterShallow ("_WaterShallow", Color) = (1,1,1,1)
        _WaterDeep ("_WaterDeep", Color) = (1,1,1,1)
        _WaveColor ("_WaveColor", Color) = (1,1,1,1)


        _Gloss ("Gloss", Float) = 1
        _ShorelineTex ("Texture", 2D) = "black" {}

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityLightingCommon.cginc"

            // Mesh data: vertex position, vertex normal, UVs, tangents, vertex colors
            struct VertexInput
            {
                float4 vertex : POSITION;
                float4 normal : NORMAL;
                float2 uv0: TEXCOORD0;
                //float4 colors : COLOR;
                //float4 tangent : TANGENT;
                //float2 uv1 : TEXCOORD1;
               

            };

            struct VertexOutput
            {
                float4 clipSpacePos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normal : NORMAL;
                float3 worldPos : TEXCOORD2;
            };

            sampler2D _ShorelineTex;
            //float4 _MainTex_ST;

            float4 _Color;
            float _Gloss;
            uniform float3 _MousePos;

            float3 _WaterShallow;
            float3 _WaterDeep;
            float3 _WaveColor;


            //Vertex shader
            VertexOutput vert (VertexInput v)
            {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.normal = v.normal;
                o.worldPos = mul( unity_ObjectToWorld, v.vertex);
                o.clipSpacePos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            
            float InvLerp(float a, float b, float value){
                return (value-a)/(b-a);
            }

            float Posterize(float steps, float value){
                return(floor(value * steps)/steps);
            }

            float4 frag (VertexOutput o) : SV_Target
            {
                float shoreline = tex2D (_ShorelineTex, o.uv0).x;

                float waveSize = 0.04;

                //float shape = o.uv0.y;
               float shape = shoreline;

                float waveAmp = (sin(shape / waveSize + _Time.y * 8) + 1) * 0.5;
                
                waveAmp *= shoreline;

                float3 waterColor = lerp(_WaterDeep, _WaterShallow, shoreline);
                float3 waterWithWaves = lerp(waterColor, _WaveColor, waveAmp);

                return float4(waterWithWaves,0);


                float dist = distance(_MousePos, o.worldPos);
                
                float glow = saturate(1-dist);

                float2 uv = o.uv0;

                float3 colorA = float3(0.1, 0.8, 1);
                float3 colorB = float3(1, 0.1, 0.8);
                float t = uv.y;

                t = Posterize(16,t);
                
                //return t;
              
                float3 blend = lerp(colorA, colorB, t);
               //return float4(blend,0);

                float3 normal = normalize(o.normal);

                //Lighting
                float3 lightDir = _WorldSpaceLightPos0.xyz;
                float3 lightColor = _LightColor0.rgb;

                // Direct diffuse light
                float3 lightFalloff = max(0,dot(lightDir, normal));
                //lightFalloff = Posterize(3, lightFalloff);
                float3 directDiffuseLight = lightColor * lightFalloff;
                
                //Ambient light
                float3 ambientLight = float3(0.2, 0.2, 0.2);
                
                // Direct specular light
                float3 camPos = _WorldSpaceCameraPos;
                float3 fragToCam = camPos - o.worldPos;
                float3 viewDir = normalize( fragToCam);
                float3 viewReflect = reflect (-viewDir, normal);
                float specularFalloff = max(0, dot (viewReflect, lightDir));
                specularFalloff = pow(specularFalloff, _Gloss);
                //specularFalloff = Posterize(3, specularFalloff);
                float3 directSpecular = specularFalloff * lightColor;

               
                

                // composite
                float3 diffuseLight = ambientLight + directDiffuseLight;
                float3 finalSurfaceColor = diffuseLight * _Color.rgb + directSpecular + glow;


                return float4(finalSurfaceColor, 0);

            }
            ENDCG
        }
    }
}Shader "Unlit/WobblyGlass"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
