Shader "Custom/GlassbreakingURP"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Break ("Enable Shattering", Float) = 0.0
        _Seed ("Random Seed", Float) = 1.0
        _Magnitude ("Shatter Magnitude", Range(0,1)) = 0.1
    }
    SubShader
    {
        Tags { "RenderPipeline" = "Universal" }
        LOD 100  // Corrected LOD value

        // Include the Universal Render Pipeline core HLSL file
        // Contents of Core.hlsl start
        #define UNITY_PASS_FORWARDBASE
        #define UNITY_PASS_PREPASSBASE
        #define UNITY_PASS_SHADOWCASTER
        #define UNITY_PASS_MOTIONVECTORS
        #define UNITY_PASS_DEPTH
        #define UNITY_PASS_OPAQUE
        #define UNITY_PASS_SKINNED
        #define UNITY_PASS_FORWARDADD
        #define UNITY_PASS_VERTEX
        // ... (copy other relevant parts of Core.hlsl here)
        // Contents of Core.hlsl end

        // Include the Universal Render Pipeline lighting HLSL file
        // Contents of Lighting.hlsl start
        #define UNITY_BRDF_PBS_BRANCH
        // ... (copy other relevant parts of Lighting.hlsl here)
        // Contents of Lighting.hlsl end

        Pass
        {
            Name "BREAKABLE"
            Tags
            {
                "LightMode" = "UniversalForward"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            #pragma target 3.5

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            float4 _Color;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 _Glossiness;
            fixed4 _Metallic;
            fixed4 _Break;
            fixed4 _Seed;
            fixed4 _Magnitude;

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                if (_Break.r > 0.0)
                {
                    // Break the glass based on the provided shattering parameters
                    float3 offset = float3(
                        sin(IN.uv_MainTex.x * _Seed.r) * _Magnitude.r,
                        cos(IN.uv_MainTex.y * _Seed.r) * _Magnitude.r,
                        tan(_Seed.r) * _Magnitude.r
                    );

                    // Apply the offset to the vertex position
                    IN.uv_MainTex.xy += offset.xy;
                }

                fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Metallic = _Metallic.r;
                o.Smoothness = _Glossiness.r;
                o.Alpha = c.a;
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}
