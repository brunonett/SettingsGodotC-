using Godot;
using System;

public partial class WorldEnvironment : Godot.WorldEnvironment
{

	public override void _Ready()
	{
	
	
	Environment.SsaoEnabled = GM.istantiate._Graphics.ssao;
	Environment.SsaoRadius = GM.istantiate._Graphics.ssaoStrength;

	Environment.VolumetricFogEnabled = GM.istantiate._Graphics.fog;
	Environment.VolumetricFogDensity = GM.istantiate._Graphics.fogStrengt;
	
	Environment.GlowEnabled  = GM.istantiate._Graphics.bloom;
	Environment.GlowNormalized  = GM.istantiate._Graphics.bloom;
	Environment.GlowStrength  = GM.istantiate._Graphics.blooStrength;
	
	Environment.SsrEnabled =  GM.istantiate._Graphics.reflection;
	Environment.SsrMaxSteps =  GM.istantiate._Graphics.reflectionStrength;
	

	}


}
