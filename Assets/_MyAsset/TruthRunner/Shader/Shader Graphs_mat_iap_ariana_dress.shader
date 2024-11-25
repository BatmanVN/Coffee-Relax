Shader "Shader Graphs/mat_iap_ariana_dress" {
	Properties {
		Color_DD7AC809 ("Color", Vector) = (0.8490566,0.5406728,0.5826566,0)
		[ToggleUI] Boolean_1D77AEB4 ("On/Off Glitter", Float) = 1
		Color_CCA81B44 ("Glitter Color", Vector) = (0.8254717,0.9444683,1,0)
		Vector1_19D16D51 ("Glitter Scale", Float) = 1
		Vector1_838FD7B2 ("Glitter Density", Range(0, 200)) = 0
		[ToggleUI] Boolean_7772413F ("On/Off Dynamic Background", Float) = 1
		Color_5769CA20 ("ColorLine", Vector) = (0.3867925,0.3867925,0.3867925,0)
		Vector1_71345A16 ("Speed", Range(0, 5)) = 1
		Vector1_AE68C882 ("Line Thickness", Range(1, 15)) = 5
		Vector1_F966B1DC ("Background Density", Range(0.5, 130)) = 3
		[ToggleUI] Boolean_56B3CD04 ("On/Off Background Texture", Float) = 0
		[NoScaleOffset] Texture2D_89874C56 ("Texture2D", 2D) = "white" {}
		[ToggleUI] Boolean_CAA6A357 ("On/Off Emission", Float) = 0
		Color_69D442E5 ("Emission Background Color", Vector) = (0,1,0.5415592,0)
		[NoScaleOffset] _SampleTexture2D_2831f84f302c9a87bcdf93f20412f10e_Texture_1_Texture2D ("Texture2D", 2D) = "white" {}
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