Shader "Shader Graphs/shader_heeldesigner_itemcard" {
	Properties {
		[NoScaleOffset] _ItemIcon ("ItemIcon", 2D) = "white" {}
		Color_F0E5C1AD ("ColorOutline1", Vector) = (0,0.459223,1,0)
		Color_401281A7 ("ColorOutline2", Vector) = (1,0,0,0)
		Color_34E45C28 ("BackgroundColor", Vector) = (0.05327868,1,0,0)
		[NoScaleOffset] Texture2D_A3DF8520 ("EffectTexture", 2D) = "white" {}
		Vector1_98754971 ("EffectOffset", Float) = 0.2
		Vector2_ABAAFEC2 ("Vector2", Vector) = (-0.3,-0.4,0,0)
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