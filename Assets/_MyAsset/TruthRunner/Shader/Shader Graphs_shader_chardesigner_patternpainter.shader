Shader "Shader Graphs/shader_chardesigner_patternpainter" {
	Properties {
		_OutfitGradientColor1 ("OutfitGradientColor1", Vector) = (0.8588235,0.6588235,0.8980392,0)
		_OutfitGradientColor2 ("OutfitGradientColor2", Vector) = (0.7668079,0.4916785,0.8207547,0)
		[NoScaleOffset] _BasePatternTexture ("BasePatternTexture", 2D) = "white" {}
		[NoScaleOffset] _GeneralColorPattern ("GeneralColorPattern", 2D) = "white" {}
		_HairGradientColor1 ("HairGradientColor1", Vector) = (0.5960785,0.2862745,0,0)
		_HairGradientColor2 ("HairGradientColor2", Vector) = (0.3773585,0.1914078,0.01957992,0)
		_SkinColor ("SkinColor", Vector) = (1,0.84156,0.5330188,0)
		_OutfitSubColor ("OutfitSubColor", Vector) = (0.8588235,0.6588235,0.8980392,0)
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