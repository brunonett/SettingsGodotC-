using Godot;
using System;

public partial class GM : Node
{

	public static GM istantiate;
	public Label FPS;
	public CM _CM;
	public Node3D _Player;
	public Node _SM;
	public Graphics _Graphics;
	public SaveSettings _SaveSettings;
	

    public override void _EnterTree()
    {
		base._EnterTree();

        if(GM.istantiate ==  null){
			GM.istantiate = this;
		}else{
			GetTree().QueueDelete(GM.istantiate);
		}
		

		_SM = GetNode("%SM") as Node;
		_CM = GetNode("%CM") as CM;
		_SaveSettings = GetNode("%SaveSettings") as  SaveSettings;
		_Graphics = GetNode("%Graphics") as  Graphics;

		_Player = GetNode<Node3D>("/root/Splayer");
		FPS = GetNode<Label>("FPS/%FPS");
    }
	

	public override void _Ready()
	{
      	base._Ready();
    }


	public override void _Process(double delta)
	{
		_FPS();
	}

	public void _FPS()
	{
		var _fps = Engine.GetFramesPerSecond();
		var Vec = DisplayServer.WindowGetSize();
		FPS.Text = "C# FPS : " + _fps + "    Resolution : "+ Vec+ "   Render : ("+ (int)(Vec.X*GetViewport().Scaling3DScale) +", "+ (int)(Vec.Y*GetViewport().Scaling3DScale)+ ")   Scene : " +GetTree().CurrentScene.Name;
	}
	


}
