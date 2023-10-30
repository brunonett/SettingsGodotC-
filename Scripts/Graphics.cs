using Godot;
using System;

public partial class Graphics : Node
{

	public  float  ssaoStrength, blooStrength, fogStrengt;
    public int  reflectionStrength , shadow;
	public bool	ssao, bloom, reflection, fog;
	public Vector2I Vec;


	public void _SetGraphics()
	{
		if ((int)GM.istantiate._SaveSettings.Data["Vsync"] == 0){
			DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);
		}else
		if ((int)GM.istantiate._SaveSettings.Data["Vsync"] == 1){
			DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Enabled);
		}

		//Resolution Display
		if ((int)GM.istantiate._SaveSettings.Data["Window"] == 0){
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
			GetViewport().Scaling3DScale =1;
			DisplayServer.WindowSetSize((Vector2I)GM.istantiate._SaveSettings.Data["resolution"]);
			
		}else	
		if ((int)GM.istantiate._SaveSettings.Data["Window"] == 1){
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.ExclusiveFullscreen);
			Vec = (Vector2I)GM.istantiate._SaveSettings.Data["resolution"];
        	GetViewport().Scaling3DScale = (float)Vec.Y /(float)DisplayServer.WindowGetSize().Y;
			//GD.Print("Y " + (float)Vec.Y /(float)DisplayServer.WindowGetSize().Y);
			
		}
		
		//Resolution Scaling
		GetViewport().Scaling3DMode = Viewport.Scaling3DModeEnum.Fsr;
		GetViewport().FsrSharpness = 2;


		//Antialiasing Quality	
		if ((int)GM.istantiate._SaveSettings.Data["Antialiasing"] == 0){
			GetViewport().Msaa3D = Viewport.Msaa.Disabled;
			GetViewport().UseTaa = false;
			GetViewport().ScreenSpaceAA = Viewport.ScreenSpaceAAEnum.Disabled;
		}else 
		if  ((int)GM.istantiate._SaveSettings.Data["Antialiasing"] == 1){
			GetViewport().UseTaa = false;
			GetViewport().Msaa3D = Viewport.Msaa.Disabled;
			GetViewport().ScreenSpaceAA = Viewport.ScreenSpaceAAEnum.Fxaa;
		}else
		if  ((int)GM.istantiate._SaveSettings.Data["Antialiasing"] == 2){
			GetViewport().UseTaa = false;
			GetViewport().Msaa3D = Viewport.Msaa.Msaa2X;
			GetViewport().ScreenSpaceAA = Viewport.ScreenSpaceAAEnum.Fxaa;
		}else 
		if  ((int)GM.istantiate._SaveSettings.Data["Antialiasing"] == 3){
			GetViewport().UseTaa = false;
			GetViewport().Msaa3D = Viewport.Msaa.Msaa4X;
			GetViewport().ScreenSpaceAA = Viewport.ScreenSpaceAAEnum.Fxaa;
		}else 
		if  ((int)GM.istantiate._SaveSettings.Data["Antialiasing"] == 4){
			GetViewport().UseTaa = true;
			GetViewport().Msaa3D = Viewport.Msaa.Disabled;
			GetViewport().ScreenSpaceAA = Viewport.ScreenSpaceAAEnum.Fxaa;
		}
		
		//Shadows Quality
		if ((int)GM.istantiate._SaveSettings.Data["shadow"] == 0){//VeryLow
			RenderingServer.DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.Hard);
			RenderingServer.PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.Hard);
		}
		else if ((int)GM.istantiate._SaveSettings.Data["shadow"] == 1){//Low
			RenderingServer.DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftVeryLow);
			RenderingServer.PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftVeryLow);
		}
		else if ((int)GM.istantiate._SaveSettings.Data["shadow"] == 2){ //Medium (default)
			RenderingServer.DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftLow);
			RenderingServer.PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftLow);
		}
		else if ((int)GM.istantiate._SaveSettings.Data["shadow"] == 3){ //High
			RenderingServer.DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftMedium);
			RenderingServer.PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftMedium);
		}
		else if ((int)GM.istantiate._SaveSettings.Data["shadow"] == 4){ //Very High
			RenderingServer.DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftHigh);
			RenderingServer.PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftHigh);
		}
		else if ((int)GM.istantiate._SaveSettings.Data["shadow"] == 5){ //Ultra
			RenderingServer.DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftUltra);
			RenderingServer.PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality.SoftUltra);
		}

		//SSAO Quality
		if  ((int)GM.istantiate._SaveSettings.Data["SSAO"] == 0 ) {//Disable
			ssao = false;
			ssaoStrength = 0;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["SSAO"] == 1) { //Low
			ssao = true;
			RenderingServer.EnvironmentSetSsaoQuality(RenderingServer.EnvironmentSsaoQuality.VeryLow, true, 0.2f, 0, 10, 100);
			ssaoStrength = 0.3f;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["SSAO"] == 2 ){// Medium
			ssao = true;
			RenderingServer.EnvironmentSetSsaoQuality(RenderingServer.EnvironmentSsaoQuality.Medium, true, 0.5f, 1, 50, 500);
			ssaoStrength = 0.4f;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["SSAO"] == 3){// High
			ssao = true;
			RenderingServer.EnvironmentSetSsaoQuality(RenderingServer.EnvironmentSsaoQuality.High, true, 0.5f, 1, 50, 800);
			ssaoStrength = 0.5f;
		}

		//Reflection Quality
		if ((int)GM.istantiate._SaveSettings.Data["Reflection"] == 0){ //Disabled (default)
			RenderingServer.EnvironmentSetSsrRoughnessQuality(RenderingServer.EnvironmentSsrRoughnessQuality.Disabled);
			reflection = false;
			reflectionStrength = 0;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["Reflection"] == 1){// VeryLow
			RenderingServer.EnvironmentSetSsrRoughnessQuality(RenderingServer.EnvironmentSsrRoughnessQuality.Disabled);
			reflection = true;
			reflectionStrength = 128;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["Reflection"] == 2){// Low
			RenderingServer.EnvironmentSetSsrRoughnessQuality(RenderingServer.EnvironmentSsrRoughnessQuality.Disabled);
			reflection = true;
			reflectionStrength = 256;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["Reflection"] == 3){// Medium
			RenderingServer.EnvironmentSetSsrRoughnessQuality(RenderingServer.EnvironmentSsrRoughnessQuality.Disabled);
			reflection = true;
			reflectionStrength = 512;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["Reflection"] == 4){// High
			RenderingServer.EnvironmentSetSsrRoughnessQuality(RenderingServer.EnvironmentSsrRoughnessQuality.Low);
			reflectionStrength = 512;
		}

		//Bloom Quality
		if ((int)GM.istantiate._SaveSettings.Data["Bloom"] == 0){
			bloom = false;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["Bloom"] == 1){
			bloom = true;
			blooStrength = 1.2f;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["Bloom"] == 2){
			bloom = true;
			blooStrength = 1.3f;
		}
		else if ((int)GM.istantiate._SaveSettings.Data["Bloom"] == 3){
			bloom = true;
			blooStrength = 1.3f;
		}	
		else if ((int)GM.istantiate._SaveSettings.Data["Bloom"] == 4){
			bloom = true;
			blooStrength = 1.4f;
		}

		//Fog Quality	
		if ((int)GM.istantiate._SaveSettings.Data["Fog"] == 0){
			fog = false;
			fogStrengt = 0.0f;}
		else if ((int)GM.istantiate._SaveSettings.Data["Fog"] == 1){
			fog = true;
			fogStrengt = 0.005f;}
		else if ((int)GM.istantiate._SaveSettings.Data["Fog"] == 2){
			fog = true;
			fogStrengt = 0.008f;}
		else if ((int)GM.istantiate._SaveSettings.Data["Fog"] == 3){
			fog = true;
			fogStrengt = 0.01f;}
		else if ((int)GM.istantiate._SaveSettings.Data["Fog"] == 4){
			fog = true;
			fogStrengt = 0.015f;}

		//Texture Quality
		if((int)GM.istantiate._SaveSettings.Data["Textures"] == 0){// # low
			GetViewport().TextureMipmapBias = 2;}
			
		else if((int)GM.istantiate._SaveSettings.Data["Textures"] == 1){// # low
			GetViewport().TextureMipmapBias = 0;}
		
		else if((int)GM.istantiate._SaveSettings.Data["Textures"] == 2){// # low
			GetViewport().TextureMipmapBias = -2;}
			
		else if((int)GM.istantiate._SaveSettings.Data["Textures"] == 3){// # low
			GetViewport().TextureMipmapBias = -4;}
		
	
		shadow = (int)GM.istantiate._SaveSettings.Data["shadow"];
		bloom = (bool)GM.istantiate._SaveSettings.Data["Bloom"];
		reflection = (bool)GM.istantiate._SaveSettings.Data["Reflection"];
		
		ssao = (bool)GM.istantiate._SaveSettings.Data["SSAO"];
		fog = (bool)GM.istantiate._SaveSettings.Data["Fog"];



	}
}