using Godot;
using System;

public partial class CameraControle : Node3D
{
	public float _delta;
	Marker3D _characterBody3D;
	[Export]public float Sensitive = 500;
	[Export]public float VelCan = 4;
	public Camera3D CanLook;
	public CollisionShape3D _Cubo;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Input.MouseMode = Input.MouseModeEnum.Captured;

		//Metodo para pegar  nodes em  Scena local Ex : GetNode<Camera3D>("CenterCamera/SpringArm3D/Camera3D")
		CanLook = GetNode<Camera3D>("CenterCamera/SpringArm3D/Camera3D"); 

		//Metodo "sigleton" para pegar nodes em todas as Scenas usando Grups/Tags Ex: GetTree().GetNodesInGroup("Player")[0] as CharacterBody3D; 
	    _characterBody3D = GetNode<Marker3D>("../Player/CenterPlayer");
	    _Cubo = GetTree().GetNodesInGroup("cubo")[0] as CollisionShape3D;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	    //pega a posição global da camera e iguala a posição do player 

		//CanLook.LookAt(CanLook.GlobalPosition, _characterBody3D.GlobalPosition);
		 //CanLook.LookAt(CanLook.GlobalPosition, Cubo.GlobalPosition);
	

	}

	public override void _PhysicsProcess(double delta)
	{
	        _delta = (float)delta;
	      	GlobalPosition = GlobalPosition.Lerp(_characterBody3D.GlobalPosition,VelCan*(float)delta) ;
      
	}



	

	public override void _Input(InputEvent @event)
	{

		base._Input(@event);
		if(@event is InputEventMouseMotion)
		{ 
			InputEventMouseMotion motion = (InputEventMouseMotion) @event ;
			Rotation = new Vector3(Math.Clamp(Rotation.X + motion.Relative.Y /9000* Sensitive*_delta,-1,0.25f), Rotation.Y - motion.Relative.X /9000* Sensitive*_delta,0);

		}

	}

}
