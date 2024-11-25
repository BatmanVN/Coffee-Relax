Shader "Shader Graphs/shader_glow" {
	Properties {
		[HDR] Color_B6771ED2 ("ColorBase", Vector) = (0,0.6886792,0.2524458,0)
		[HDR] Color_55EAA1C2 ("ColorEmission", Vector) = (0,0.5594096,1,0)
		Vector1_B898A4EF ("EmissionDensity", Range(0, 5)) = 1
		Vector1_CFFE0A4B ("Metallic", Range(0, 1)) = 0
		Vector1_F6632CE4 ("Smoothness", Range(0, 1)) = 0
		[NoScaleOffset] Texture2D_63E5C4AC ("BaseTexture2D", 2D) = "white" {}
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