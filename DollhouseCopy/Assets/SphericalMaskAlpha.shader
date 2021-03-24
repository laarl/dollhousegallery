Shader "Custom/SphericalMaskAlpha"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
_TransparencyStrength("Transparency Strength", Range(0,0.5)) = 0.25
        _MainTex ("Albedo (RGB) Alpha (A)", 2D) = "white" {}
_Hardness("Hardness", float) = 0.1
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 200

ZWrite Off
Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf NoLighting alpha:blend
//alpha:blend enables alpha blending

fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
{
return fixed4(s.Albedo, s.Alpha);
}

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
float3 worldPos;
        };

        fixed4 _Color;
float _Hardness;
half _TransparencyStrength;

//Spherical Mask
uniform float4 GLOBALmask_Position;
uniform half GLOBALmask_Radius;
//uniform half GLOBALmask_Softness;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color

//Color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

half d = distance(GLOBALmask_Position,IN.worldPos);
half sum = saturate(d - GLOBALmask_Radius);


//fixed4 lerpAlpha = lerp(fixed4(0,c.a),c * _TransparencyStrength,sum);

            o.Albedo = c.rgb;
            o.Alpha = (1.0f - pow(sum, _Hardness)) * _Color.a * c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
