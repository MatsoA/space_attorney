Shader "Unlit/Space"
{
    Properties
    {
        _BackgroundColor ("Background Color", Color) = (0,0,0,1)
        _NebulaColor ("Nebula Color", Color) = (0,0,0,1)
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
                float3 pos : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            inline float unity_noise_randomValue (float2 uv) {
                return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453);
            }

            inline float unity_noise_interpolate (float a, float b, float t) {
                return (1.0-t)*a + (t*b);
            }

            inline float unity_valueNoise (float2 uv) {
                float2 i = floor(uv);
                float2 f = frac(uv);
                f = f * f * (3.0 - 2.0 * f);

                uv = abs(frac(uv) - 0.5);
                float2 c0 = i + float2(0.0, 0.0);
                float2 c1 = i + float2(1.0, 0.0);
                float2 c2 = i + float2(0.0, 1.0);
                float2 c3 = i + float2(1.0, 1.0);
                float r0 = unity_noise_randomValue(c0);
                float r1 = unity_noise_randomValue(c1);
                float r2 = unity_noise_randomValue(c2);
                float r3 = unity_noise_randomValue(c3);

                float bottomOfGrid = unity_noise_interpolate(r0, r1, f.x);
                float topOfGrid = unity_noise_interpolate(r2, r3, f.x);
                float t = unity_noise_interpolate(bottomOfGrid, topOfGrid, f.y);
                return t;
            }

            float Unity_SimpleNoise_float(float2 UV, float Scale)
            {
                float t = 0.0;

                float freq = pow(2.0, float(0));
                float amp = pow(0.5, float(3-0));
                t += unity_valueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;

                freq = pow(2.0, float(1));
                amp = pow(0.5, float(3-1));
                t += unity_valueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;

                freq = pow(2.0, float(2));
                amp = pow(0.5, float(3-2));
                t += unity_valueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;

                return t;
            }

            float invLerp(float from, float to, float value){
                return (value - from) / (to - from);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.pos = v.vertex.xyz;
                o.uv = v.uv;
                return o;
            }

            fixed4 _BackgroundColor;
            fixed4 _NebulaColor;

            fixed4 frag (v2f i) : SV_Target
            {
                //fixed4 col = lerp(fixed4(0,0,0,1), fixed4(1,1,1,1), invLerp(0.73, 0.76, Unity_SimpleNoise_float(i.uv, 500)));

                i.uv = float2(atan2(i.pos.z, i.pos.x)/3.14, asin(i.pos.y)/1.57);

                float size = 0.015;

                fixed4 col = Unity_SimpleNoise_float(i.uv, 100) * _BackgroundColor;
                col += Unity_SimpleNoise_float(i.uv, 10) * _NebulaColor;

                float2 pos = floor((1.0 / size) * i.uv);
                float star = unity_noise_randomValue(pos);
                if (star > 0.8) {
                    float2 center = size * pos + float2(size * unity_noise_randomValue(pos + float2(0.1, 0.2)), size * unity_noise_randomValue(pos + float2(0.2, 0.1)));
                    float dist = saturate(distance(i.uv, center)/(0.5*size));
                    col = lerp(col, fixed4(1,1,1,1), pow(saturate(1. - dist), 15));
                }
                return col;
            }
            ENDCG
        }
    }
}
