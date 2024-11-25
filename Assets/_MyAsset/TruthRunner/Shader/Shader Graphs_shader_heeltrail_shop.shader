Shader "Shader Graphs/shader_heeltrail_shop" {
	Properties {
		Vector1_3C930773 ("TrailSpeed", Float) = 1
		[NoScaleOffset] _TrailTexture ("TrailTexture", 2D) = "white" {}
		Vector1_82F33F6A ("WaveSpeed", Float) = 1
		Vector1_AB98B78 ("WaveSize", Float) = 0.2
		Vector1_96CDF05C ("xWaveSize", Float) = 0.2
		Vector1_4F3B49A6 ("xWaveSpeed", Float) = 1
		Vector1_49BC2095 ("xWaveDensity", Float) = 1
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