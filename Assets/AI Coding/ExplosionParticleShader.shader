Shader "Custom/ExplosionParticleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Scale ("Scale", Range(0.1, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed4 _Color;
        half _Scale;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Sample the texture
            fixed4 texColor = tex2D(_MainTex, IN.uv_MainTex);

            // Apply color
            texColor *= _Color;

            // Apply scale
            texColor.a *= _Scale;

            // Output final color
            o.Albedo = texColor.rgb;
            o.Alpha = texColor.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
