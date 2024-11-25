Shader "Shader Graphs/Water" {
	Properties {
		Vector1_37386D30 ("WaterDepth", Float) = 5
		Color_5AB4058C ("ShallowWater", Vector) = (0.0518868,0.6949528,1,0)
		Color_220E0882 ("DepthWater", Vector) = (0,0.3045009,0.509434,0)
		Vector1_5790F137 ("Wave Speed Direction 1", Float) = 1
		Vector1_C0D0D8B9 ("Wave Speed Direction 2", Float) = 1
		Vector1_6E67AF32 ("Wave Scale", Float) = 1
		Vector1_45D12553 ("Wave Strength", Float) = 5
		Vector1_E9C20F09 ("FoamAmount", Float) = 1
		Vector1_1A6C05E6 ("FoamCutOff", Float) = 1
		Vector1_6E83A829 ("Foam Speed Direction 1", Float) = 1
		Vector1_B7F8EDB3 ("Foam Speed Direction 2", Float) = 1
		Vector1_224733B7 ("Foam Scale", Float) = 10
		Color_DE697760 ("Foam Color", Vector) = (1,1,1,1)
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