Shader "Unlit/inside"
{
    Properties
    {
        _Texture ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque"  }
        LOD 100

        Pass
        {
            
            stencil
            {
                Ref 1
                Comp NotEqual
                
            }

            Cull Front

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float2 uv : TEXCOORD0;
                float4 vertex : POSITION;
            };

            struct v2f
            {
                
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _Texture;
            float4 _Texture_ST;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _Texture);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_Texture, i.uv);
                col.a = 1;
                return col;
            }
            ENDCG
        }
    }
}
