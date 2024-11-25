Shader "Shader Graphs/shader_worldposition_snow" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		[NoScaleOffset] _Texture ("Texture", 2D) = "white" {}
		_Scale ("Scale", Vector) = (0.1,0.1,0,0)
		_Smoothness ("Smoothness", Range(0, 1)) = 0
		_Metallic ("Metallic", Range(0, 1)) = 0
		[NoScaleOffset] [Normal] _NormalMap ("Normal", 2D) = "bump" {}
		[NoScaleOffset] _OcclusionMap ("Occlusion", 2D) = "white" {}
		[HDR] _Emission ("Emission", Vector) = (0,0,0,0)
		Vector1_38996358 ("Texture Rotation", Float) = 90
		Vector1_9F835F78 ("U Position", Float) = 0
		Vector1_37557F3D ("V Position", Float) = 0
		Vector3_63AA8F14 ("Snow Direction", Vector) = (0,1,0,0)
		Vector1_29F61881 ("Snow Opacity", Range(0, 1)) = 0.5
		Vector1_FD7B22DD ("Snow Density", Float) = 0
		Vector1_FB7FD95D ("SnowLineThickness", Range(0, 1)) = 0.98
		Vector3_DCAB3499 ("Vector3", Vector) = (0,0,0,0)
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}