using Godot;
using System;

public partial class CM : Godot.Node
{


	[Export]public Vector3 input = Vector3.Zero;


	public override void _Process(double delta)
	{
  
		input.X = Input.GetAxis("ui_left", "ui_right");
		input.Z =  Input.GetAxis("ui_up", "ui_down");

	}


}
