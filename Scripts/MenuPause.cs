using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class MenuPause : CanvasLayer
{
	[Export]public Button BTWFocus;
	public CanvasLayer _MenuPause;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		_MenuPause = GetNode(".") as CanvasLayer;
		pauseOFF();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void on_option_pressed()
	{

	}
	void on_return_pressed()
	{	
		pauseOFF();
	}
	void on_quit_pressed()
	{
		pauseOFF();
		GetTree().ChangeSceneToFile("res://Scenes/Menu.tscn");
	}

	
	public void pauseON()
	{
		BTWFocus.GrabFocus();
		Input.MouseMode = Input.MouseModeEnum.Visible;
		_MenuPause.Visible = true;
		GetTree().Paused = true;
	}
	public void pauseOFF()
	{	
		_MenuPause.Visible = false;
		GetTree().Paused = false;
		//Input.MouseMode = Input.MouseModeEnum.Captured;
	}
}
