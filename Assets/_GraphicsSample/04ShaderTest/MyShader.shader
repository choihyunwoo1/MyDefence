Shader "Unlit/MyShader"
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
/*
Lighting의 종류

1) Ambient : 주변광 , 환경광{ex) SkyBox}에 의한 빛이 오브젝트에 반사되어 나온 반사광 = 공기중에 퍼진 빛 = Environment

2) Diffuse : 오브젝트 자신의 고유 색, 광원에 반사될때 출력되는 가장 주된 색 = Main Color = 물체의 본래 색을 비추는 빛

3) Specular : 정 반사광, 특정 방향으로만 반사되는 빛, 하이라이트 표현 = 질감 표현을 하기위한, 가장 강한 빛

4) Emissive : Mesh 표면에서 자체적으로 방출되는 색 = 자가 광원

Shader 프로그램
: 화면에 출력할 픽셀의 위치와 색상을 계산하는 함수를 작성하는 것

언어
shaderLab : 유니티에서 제공하는 셰이더 스크립트 언어
셰이더 언어

1) CG : C for graphics, MS와 엔비디아 에서 만든 언어(C Language)
이름 그대로 그래픽용 C언어예요.
Unity의 옛날 셰이더(예: Surface Shader) 들이 대부분 CG로 작성되어 있어요.
사실상 HLSL 기반이라 문법이 거의 똑같아요.

2) HLSL :  “Microsoft가 만든 DirectX 전용 셰이더 언어(Shading Language)
이름 뜻 그대로 고수준 셰이더 언어
DirectX 전용이라 Windows, Xbox 쪽에서 주로 사용돼요.
Unity에서는 기본적으로 HLSL을 사용합니다

3) GLSL : OpenGL용 셰이더 언어(Shading Language) 
Khronos Group(오픈GL을 만든 곳)에서 만든 언어
Mac, Linux, WebGL 같은 플랫폼에서 주로 쓰여요
문법은 HLSL과 비슷하지만, 함수 이름과 자료형이 약간 다름


ShaferLab 으로 작성할 수 있는 프로그램
1) 고정 함수 셰이더 - 사라짐  
2) 표면 셰이더 = Surface- 가장 최근까지 사용함
3) Vertex & Fragment 셰이더 - 가장 많이 사용함
*/