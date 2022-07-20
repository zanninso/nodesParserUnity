using System;
using UnityEngine;
using System.Collections.Generic;


public class OptionBackSelection : MenuOption
{
	public OptionBackSelection(String name) : base(name)
	{
	}

	public override void start()
	{
		base.start();
		if (GlobalStorage.getInstace().selectedNodes.Count > 1)
			GlobalStorage.getInstace().selectedNodes.Pop();
	}

	protected override IAction runAction()
	{
		return prevAction;
	}
}

