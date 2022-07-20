using System;
using UnityEngine;

public class OptionSelectById: MenuOption
{
	const int labelIdx = 0;
	const int inputFieldIdx = 1;

	public OptionSelectById(String name, String title): base(name, title)
	{
	}

	override
	protected IAction runAction()
	{
		String key = GlobalStorage.getInstace().input.text;
		try
		{
			GlobalStorage gs = GlobalStorage.getInstace();
			gs.selectedNodes.Push(gs.selectedNodes.Peek().findById(key));
		}
		catch (Exception e)
		{
			MonoBehaviour.print(e.Message);
		}
		return prevAction;
	}
}

