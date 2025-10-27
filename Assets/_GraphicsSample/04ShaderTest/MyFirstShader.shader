Shader "Custom/MyFirstShader"
{
    Properties
    {
        //_BaseColor : 셰이더 프로그램에서 사용하는 변수 이름과 동일
        //"BaseColor" 인스팩터 창에서 디스플레이 되는 이름
        //Color : 데이터 타입
        //(1,1,1,1) : 초기값(인스펙터 창에서 보이는) (R,G,B,Alpha)
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)


    }
    SubShader
    {        
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }    

        Pass
        {
            //HLSL 코드블록, HLSL 언어로 프로그래밍 한다
            HLSLPROGRAM
            //버택스 셰이더 함수 이름(vert) 정의
            #pragma vertex vert            
            //프래그먼트 셰이더 함수 이름(frag) 정의
            #pragma fragment frag
        
            //HLSL 라이브러리 가져오기(매크로, 함수)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            //버택스 셰이더에서 매개변수로 입력받아서 사용할 버택스 정보중에서 가져올 데이터 정의
            struct Attributes
            {            
                // 모델 공간의 버텍스 위치 정보
                float4 positionOS   : POSITION;
            };

            //버택스 셰이더 함수 프로그래밍의 결과로 리턴값이다
            //프래그먼트 셰이더 입력값의 매개변수로 넘겨준다
            struct Varyings
            {
                // The positions in this struct must have the SV_POSITION semantic.
                float4 positionHCS  : SV_POSITION;
            };

           CBUFFER_START(UnityPerMaterial)
           half4 _BaseColor;
           CBUFFER_END

            //버택스 프로그래밍 함수
            Varyings vert(Attributes IN)
            {
                //버택스 프로그래밍 결과의 리턴값 선언
                Varyings OUT;

                // The TransformObjectToHClip function transforms vertex positions
                // from object space to homogenous clip space.
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);

                // Returning the output.
                return OUT;
            }

            half4 frag() : SV_Target
            {
                // Defining the color variable and returning it.
                return _BaseColor;
            }
            ENDHLSL
        }
    }
}
