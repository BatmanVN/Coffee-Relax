Shader "Shader Graphs/shader_pride_waterfall" {
	Properties {
		Vector2_5BAEF20A ("RipplesSpeed", Vector) = (0,0.2,0,0)
		Vector1_1E0A4C6A ("VoronoiSpeed", Float) = 2
		Vector1_4509746A ("RipplesSize", Float) = 2
		Vector1_C902A66C ("RipplesAmount", Float) = 2
		[HDR] Color_1452ECA7 ("RipplesColor", Vector) = (1,1,1,0)
		[NoScaleOffset] Texture2D_8E4A96D3 ("Texture2D", 2D) = "white" {}
		Vector2_3E056316 ("Vector2", Vector) = (1,1,0,0)
		Vector1_F8AE9EBB ("BottomStrength", Float) = 2
		Vector1_DF439D02 ("VertexOffsetAmount", Float) = 0.2
		Vector2_16F6D202 ("BottomBrigthness", Vector) = (0,3,0,0)
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