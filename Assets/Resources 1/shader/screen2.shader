Shader "Unlit/screen2"
{
    Properties
    {
        _MainTex("Color", color) = (1,1,1,0)
    }
    SubShader
    {
        Stencil
        {
            Ref 2
            Comp Always
            Pass Replace    
        }
        Tags { "RenderType"="Opaque" }
        LOD 100
        ZWrite off
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
          
                float4 vertex : SV_POSITION;
            };

            fixed4 _MainTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
              
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = _MainTex;
             
                return col;
            }
            ENDCG
        }
    }
}
