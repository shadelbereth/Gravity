// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Surf01"
{  
     Properties
     {
        _MainTex ("Sprite Texture", 2D) = "white" {}
		_IrregularityTex ("Irregularity Sprite Texture", 2D) = "white" {}
        _Color ("Color", Color) = (0,0,0,1)
		_RotationTime ("Rotation Time", float) = 5
     }
     SubShader
     {
         Tags 
         { 
             "RenderType" = "Opaque" 
             "Queue" = "Transparent+1" 
         }
 
         Pass
         {
             ZWrite Off
             Blend SrcAlpha OneMinusSrcAlpha 
  
             CGPROGRAM
             #pragma vertex vert
             #pragma fragment frag
             #pragma multi_compile DUMMY PIXELSNAP_ON
  
             sampler2D _MainTex;
			 sampler2D _IrregularityTex;
             float4 _Color;
			 float _RotationTime;
 
             struct Vertex
             {
                 float4 vertex : POSITION;
                 float2 uv_MainTex : TEXCOORD0;
                 float2 uv2 : TEXCOORD1;
             };
     
             struct Fragment
             {
                 float4 vertex : POSITION;
                 float2 uv_MainTex : TEXCOORD0;
                 float2 uv2 : TEXCOORD1;
             };
  
             Fragment vert(Vertex v)
             {
                 Fragment o;
     
                 o.vertex = UnityObjectToClipPos(v.vertex);
                 o.uv_MainTex = v.uv_MainTex / 2 + float2((_Time.y % _RotationTime) / (_RotationTime * 2), 0);
                 o.uv2 = v.uv2;
     
                 return o;
             }
                                                     
             float4 frag(Fragment IN) : COLOR
             {
                 half4 c = tex2D (_IrregularityTex, IN.uv_MainTex) * _Color;
                 return c;
             }
 
             ENDCG
         }
     }
 }