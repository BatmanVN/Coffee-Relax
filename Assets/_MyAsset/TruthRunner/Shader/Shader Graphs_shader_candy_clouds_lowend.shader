Shader "Shader Graphs/shader_candy_clouds_lowend" {
	Properties {
		Vector1_89E1EB3F ("Speed", Float) = 1
		Color_10E63E61 ("Color1", Vector) = (1,1,1,0)
		Color_3A2872DC ("Color2", Vector) = (0,0,0,0)
		Vector1_10AC5CFA ("CloudCover", Float) = 0
		Vector1_C28BCB1A ("Additional Falloff", Float) = 0
		Vector1_A40C51A3 ("Density", Float) = 0
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