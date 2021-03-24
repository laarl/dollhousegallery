Shader "Unlit/SimpleShader"
{
    Properties
    {
        _MainTex ("Texture Image", 2D) = "white"{}
        _Color ("Color", Color) = (1,1,1,0)

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
            uniform sampler2D _MainTex;

            float4 _Color;
            float _Gloss;
            

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

                float waveAmp = (sin(shape / waveSize + _Time.y * .5) + 1) * 0.5;
                
                waveAmp *= shoreline;

                return tex2D(_MainTex, o.uv0.xy  + waveAmp);
                
            }
            ENDCG
        }
    }
}
