using Godot;
using System;

public partial class spot_light_3d : SpotLight3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ShadowBlur = GM.istantiate._Graphics.shadow+0.1f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
