//UNITY_SHADER_NO_UPGRADE
#ifndef DEPTHSAMPLER_INCLUDED
#define DEPTHSAMPLER_INCLUDED

// Texture2D _CameraDepthTexture;

float DepthSampler_float(float2 UV, out float Output) {
	Output = SAMPLE_TEXTURE2D(_CameraDepthTexture, sampler_CameraDepthTexture, UV).r;

	return Output;
}

#endif