using Godot;
using System;

public partial class CuboTest : StaticBody3D
{
	CharacterBody3D _characterBody3D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_characterBody3D = GetTree().GetNodesInGroup("Player")[0] as CharacterBody3D;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	
	
        float m_rotationDirection = new Vector2(_characterBody3D.GlobalPosition.Z, _characterBody3D.GlobalPosition.X).Angle(); //retorna em float
		var newRotation = Rotation;// armazena valores da rotacao em uma var 
		newRotation.Y = Mathf.LerpAngle(Rotation.Y, m_rotationDirection, (float)delta * 10f); 
		Rotation = newRotation;
      
	    //Cubo.LookAt(_characterBody3D.GlobalPosition);
		//GD.Print(Rotation);
		
	}

}
