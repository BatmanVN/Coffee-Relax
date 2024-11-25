Shader "Shader Graphs/shader_vertical_fog" {
	Properties {
		_Density ("Density", Float) = 0
		Color_26A072B3 ("ColorOutside", Vector) = (0,0.4632645,1,0)
		_ColorInside ("ColorInside", Vector) = (0.01860091,0.01872446,0.01886791,0)
		Vector1_1787C873 ("PlaneSize", Range(0, 1)) = 0.12
		Vector1_4556F75D ("ColorCircleSize", Range(0, 5)) = 0.9
		[NoScaleOffset] _SampleTexture2D_8f53f5a1c8eea283a33c73fbcdd31ac1_Texture_1_Texture2D ("Texture2D", 2D) = "white" {}
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}