Shader "Unlit/light"
{
    Properties
    {
        [HDR]_MainColor ("Color", color) = (1,1,1,1)
        _Intensity("Intensity", Range(0,1)) = 1.0
        _Pow("pow",Range(1,3)) = 1
    }
    SubShader
    {
        Tags { "RenderPipeline" = "UniversalRenderPipeline" "Queue"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            
            #include "UnityCG.cginc"

            struct appdata
            {
                fixed3 normal : NORMAL;
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float3 worldPos : TEXCOORD0;
                fixed3 worldNormal : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };
            
            float4 _MainColor;
            float _Intensity;
            fixed _Pow;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos);
                fixed4 col = _MainColor;
                float a = abs(dot(viewDir, i.worldNormal));
                col = _MainColor;
                col.a = lerp(0.08,_Intensity, dot(viewDir, i.worldNormal));
                col.a = clamp(pow(col.a, _Pow),0,1);
                return col;
            }
            ENDCG
        }
    }
}
