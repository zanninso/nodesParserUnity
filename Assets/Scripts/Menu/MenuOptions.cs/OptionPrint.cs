using System;
using UnityEngine;

public class OptionPrint : MenuOption
{
	public OptionPrint(String name):base(name)
	{
	}

	public override void start()
	{
		base.start();
		MonoBehaviour.print(GlobalStorage.getInstace().selectedNodes.Peek().ToString(0, 1));
	}

	protected override IAction runAction()
	{
		return prevAction;
	}
}

