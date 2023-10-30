using Godot;
using System;



public partial class Settings : Control
{

	
    public OptionButton BTWResolution, BTWwindow, BTWshadow, BTWTextures, BTWAntialiasing ,BTWSSAO, BTWBloom, BTWReflection, BTWFog,BTWVsync;


	public override void _EnterTree()
    {	
        base._EnterTree();	
	}


	public override void _Ready()
	{
		base._Ready();
		
		BTWVsync = GetNode("Vsync/VsyncButton") as OptionButton;
		BTWResolution = GetNode("Resolution/ResolutionButton") as OptionButton;
		BTWwindow = GetNode("Window/WindowButton") as OptionButton;
		BTWshadow = GetNode("Shadows/ShadowsButton") as OptionButton;
		BTWTextures = GetNode("Textures/TexturesButton") as OptionButton;
		BTWAntialiasing = GetNode("Antialiasing/AntialiasingButton") as OptionButton;
		BTWSSAO = GetNode("SSAO/SSAOButton") as OptionButton;
		BTWBloom = GetNode("Bloom/BloomButton") as OptionButton;
		BTWReflection = GetNode("Reflection/ReflectionButton") as OptionButton;
		BTWFog = GetNode("Fog/FogButton") as OptionButton;


		
		_Set_Graphics_BTW();
		BTWVsync.GrabFocus();
	}


	public override void _Process(double delta)
	{
		base._Process(delta);
		
	}

	void on_vsync_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["Vsync"] = _index;
	}

	void on_window_button_item_selected(int _index)
	{	
		GM.istantiate._SaveSettings.Data["Window"] = _index;
	}

	void on_resolution_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["IDresolution"] = _index;
		var _size = BTWResolution.GetItemText(_index);
		var _res = _size.Split("x");
		GM.istantiate._SaveSettings.Data["resolution"] = new Vector2(int.Parse(_res[0]),int.Parse(_res[1]));
	}

	void on_shadows_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["shadow"] = _index;
	}

	void on_textures_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["Textures"] = _index;
	}

	void on_antialiasing_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["Antialiasing"] = _index;
	}
	void on_ssao_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["SSAO"] = _index;
	}
	void on_bloom_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["Bloom"] = _index;
	}

	void on_reflection_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["Reflection"] = _index;
	}

	void on_fog_button_item_selected(int _index)
	{
		GM.istantiate._SaveSettings.Data["Fog"] = _index;
	}




	void on_return_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Menu.tscn");
	}

	void on_save_pressed()
	{
		GM.istantiate._SaveSettings.SaveData();
		
		_Set_Graphics_BTW();
		GD.Print(GM.istantiate._SaveSettings.LoadData());
	}

	public void _Set_Graphics_BTW()
	{
	
		GM.istantiate._SaveSettings.LoadData();
		GD.Print(GM.istantiate._SaveSettings.Data["resolution"]);

		//SetAtualDataGraphics
		GM.istantiate._Graphics._SetGraphics();
		//SetAtualDataButton
		BTWVsync.Select((int)GM.istantiate._SaveSettings.Data["Vsync"]);
		BTWResolution.Select((int)GM.istantiate._SaveSettings.Data["IDresolution"]);
		BTWshadow.Select((int)GM.istantiate._SaveSettings.Data["shadow"]);
		BTWwindow.Select((int)GM.istantiate._SaveSettings.Data["Window"]);
		BTWBloom.Select((int)GM.istantiate._SaveSettings.Data["Bloom"]);
		BTWSSAO.Select((int)GM.istantiate._SaveSettings.Data["SSAO"]);
		BTWReflection.Select((int)GM.istantiate._SaveSettings.Data["Reflection"]);
		BTWAntialiasing.Select((int)GM.istantiate._SaveSettings.Data["Antialiasing"]);
		BTWTextures.Select((int)GM.istantiate._SaveSettings.Data["Textures"]);
		BTWFog.Select((int)GM.istantiate._SaveSettings.Data["Fog"]);

	}

	
}
