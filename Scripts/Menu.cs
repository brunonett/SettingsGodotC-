using Godot;
using System;



public partial class Menu : Control
{
	
 	[Export] public Timer wait;
	[Export] public Button BTWFocus;

    public override void _EnterTree()
    {	
        base._EnterTree();
    }

    public override void _Ready()
	{
		base._Ready();
		BTWFocus.GrabFocus();

		wait.Timeout += () =>{
		GM.istantiate._SaveSettings.LoadData();
		GM.istantiate._Graphics._SetGraphics();
		GD.Print("helo");
		wait.QueueFree();
		};
	   
	}

	
	public override void _Process(double delta)
	{
	}

	void on_iniciar_pressed(){
		
		Input.MouseMode = Input.MouseModeEnum.Captured;
		GetTree().ChangeSceneToFile("res://Scenes/TestMecanics.tscn");
	}
	void on_continiar_pressed(){

	}

	void on_opcoes_pressed(){
		GetTree().ChangeSceneToFile("res://Scenes/Option.tscn");

	}

	void on_sair_pressed(){
		GetTree().Quit();
	}

	public override void _ExitTree()
    {
        base._ExitTree();
		
    }
}

