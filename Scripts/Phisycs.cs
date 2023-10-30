using Godot;
using System;

public partial class Phisycs : Godot.CharacterBody3D
{
	
    public Vector3 velocity;
	public float _delta;
    public static Phisycs Instanse;

    public override void _Ready()
    {
		if (Phisycs.Instanse != null)
		{
			Instanse =  GetNode<Node3D>("/root/Phisycs") as Phisycs;
			Phisycs.Instanse = this;
		}
     
	 
    }

    public override void _PhysicsProcess(double delta)
	{
		_delta = (float)delta;

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
