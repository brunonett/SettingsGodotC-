using Godot;
using System;


public partial class Player : Godot.CharacterBody3D
{
	public Vector3 Montion, velocity, Rot;
	[Export]public float Speed, RotSpeed, Aceleration, _delta ;
	public Node3D _CenterCamera;
	public Marker3D _CenterPlayer;
	public MenuPause _MenuPause;
	public Variant gravity = ProjectSettings.GetSetting("physics/3d/default_gravity", default);
	
	public override void _Ready()
	{
		base._Ready();
		RotSpeed =0; Speed = 0f; Aceleration = 1.3f;
		 
		_CenterCamera = GetNode<Node3D>("../CameraControle");
		_CenterPlayer = GetNode<Marker3D>("CenterPlayer");	
		_MenuPause = GetNode("../MenuPause") as MenuPause;	
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel"))
		{
			_MenuPause.pauseON();
		}
	}
	public override void _Process(double delta)
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		_delta = (float)delta;
		 
	   if (Input.IsActionJustPressed("ui_jump") && IsOnFloor())
		{
			PlayerJump();
		}	

		PlayerMove();
	}

	public void PlayerMove()
	{
		if(GM.istantiate._CM.input.Normalized().Length() !=0 && Speed <= 350f)
		{
			Speed += 800f*_delta;
		}	

		Speed = Math.Clamp(Speed*GM.istantiate._CM.input.Normalized().Length(),0f,350f);
		Montion = -GM.istantiate._CM.input.Rotated(Vector3.Up,_CenterCamera.Rotation.Y).Normalized()*Speed*_delta;
		Montion.Y = physic_();
		Velocity = Montion;
		
		RotSpeed = Velocity.Length()<5.5f ? RotSpeed = 3 : RotSpeed = 12;

		if(GM.istantiate._CM.input != Vector3.Zero)
		{		
			Rot.Y =  Mathf.LerpAngle(Rotation.Y, new Vector2(Montion.Z, Montion.X).Angle(),RotSpeed*_delta);
			Rotation = Rot;
		}
		//GD.Print(Speed);
		//Velocity = Montion.Lerp(Montion, 0); 
		MoveAndSlide(); 
	}
			
	public void PlayerJump()
	{
		velocity.Y =  450 * _delta ;
	
	}
	
	public float physic_()
	{
		if (!IsOnFloor())
		{	
			velocity.Y -=   30 * _delta;		
		}
		return velocity.Y;
	}

}
