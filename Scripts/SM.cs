using Godot;
using System;

public partial class SM : Node
{

	public override void _EnterTree()
    {
		base._EnterTree();
	
        
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	
			
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		if(ProcessMode == ProcessModeEnum.Inherit){
			
			
			if(GetTree().CurrentScene.Name == "Menu"){
			
				GM.istantiate._Player.Visible = false;
				GM.istantiate._Player.ProcessMode = ProcessModeEnum.Disabled;

			}else
			if(GetTree().CurrentScene.Name == "TestMecanics"){
				GM.istantiate._Player.Visible = true;
				GM.istantiate._Player.ProcessMode = ProcessModeEnum.Inherit;
			}
			GD.Print(GetTree().CurrentScene.Name);
			ProcessMode = ProcessModeEnum.Disabled;
			
		}
		
	}

    public void SM_Exit()
	{
		GetTree().ReloadCurrentScene();
	}




	public override void _ExitTree()
    {
        base._ExitTree();
		//GetTree().QueueDelete(this);
		//_Splayer.Visible = true;
		//_Splayer.ProcessMode = ProcessModeEnum.Inherit;
		
    }
}
