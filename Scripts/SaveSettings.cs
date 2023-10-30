using Godot;
using System;


public partial class SaveSettings : Node
{
	public String  SavePath = "res://save-file.cfg";
	public FileAccess File;
	//public Graphics _Graphics;
	

	public Godot.Collections.Dictionary<string, Variant> Data = new Godot.Collections.Dictionary<string, Variant>()
	{
		{"Vsync" , new int()},
		{"Window" , new int()},
		{"resolution", new Vector2I()},
		{"IDresolution", new int()},
		{"shadow", new int()},
		{"Bloom", new int()},
		{"SSAO", new int()},
		{"Reflection", new int()},
		{"Antialiasing", new int()},
		{"Textures", new int()},
		{"Fog", new int()}
	};


    public override void _EnterTree()
    {
        base._EnterTree();
		//_Graphics = GetNode("/root/Graphics") as  Graphics;

		if (!FileAccess.FileExists(SavePath))
		{
			DefaultData();
			SaveData();
			GD.Print(LoadData());
		}
		
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		base._Ready();
		if (FileAccess.FileExists(SavePath))
		{
			LoadData();
			GD.Print(LoadData());
			GM.istantiate._Graphics._SetGraphics();	
		}	
	}

	public void SaveData()
	{
		File = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
		File.StoreVar(Data);
		File.Close();
	}

	public Variant LoadData()
	{
		File = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
		Data = (Godot.Collections.Dictionary<string, Variant>)File.GetVar();
		File.Close();
		return Data;
	}
	public void DefaultData()
	{
		
		Data =  new Godot.Collections.Dictionary<string, Variant>()
		{
			{"Vsync" , new int()},
			{"Window" , new int()},
			{"resolution", new Vector2(1920,1080)},
			{"IDresolution", new int()},
			{"shadow", new int()},
			{"Bloom", new int()},
			{"SSAO", new int()},
			{"Reflection", new int()},
			{"Antialiasing", new int()},
			{"Textures", new int()},
			{"Fog", new int()}	
		};
		DisplayServer.WindowSetSize((Vector2I)Data["resolution"]);
	}

}
