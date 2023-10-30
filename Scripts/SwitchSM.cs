using Godot;
using System;

public partial class SwitchSM : Node
{
	public override void _EnterTree()
    {
        base._EnterTree();
		ProcessMode = ProcessModeEnum.Inherit;
		GM.istantiate._SM.ProcessMode = ProcessModeEnum.Inherit;	
		ProcessMode = ProcessModeEnum.Disabled;
		
	}
}
