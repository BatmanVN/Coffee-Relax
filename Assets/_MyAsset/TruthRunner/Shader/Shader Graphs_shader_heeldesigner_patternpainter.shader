Shader "Shader Graphs/shader_heeldesigner_patternpainter" {
	Properties {
		_PrimaryColor ("PrimaryColor", Vector) = (0.8588235,0.6588235,0.8980392,0)
		_SecondryColor ("SecondryColor", Vector) = (0,0.6349897,1,0)
		[NoScaleOffset] _BasePatternTexture ("BasePatternTexture", 2D) = "white" {}
		[NoScaleOffset] _GeneralColorPattern ("GeneralColorPattern", 2D) = "white" {}
		_PrimaryGradientColor1 ("PrimaryGradientColor1", Vector) = (0,0.9703219,1,0)
		_PrimaryGradientColor2 ("PrimaryGradientColor2", Vector) = (0.01435959,1,0,0)
		_SecondaryGradientColor1 ("SecondaryGradientColor1", Vector) = (0,0.3786387,1,0)
		_SecondaryGradientColor2 ("SecondaryGradientColor2", Vector) = (1,0.3245524,0,0)
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