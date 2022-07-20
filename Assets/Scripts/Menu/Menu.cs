using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using System.Linq;
using UnityEngine;

public class Menu:AAction
{
	List<MenuOption> options = new List<MenuOption>();
	
	int step = 0;
	const int maxSteps = 3;
	const int labelIdx = 0;
	const int inputFieldIdx = 1;

	public Menu(String title = "Chose option from the console")
	{
		this.title = title;
	}

	public void show()
	{
		int i = 1;
		StringBuilder sb = new StringBuilder();
		sb.Append(Environment.NewLine);

		sb.Append("Menu:").Append(Environment.NewLine);
		foreach (MenuOption option in options)
		{
			sb.Append(i).Append(") ").Append(option.getName()).Append(Environment.NewLine);
			i++;
		}
		sb.Append(i).Append(") ").Append("Back").Append(Environment.NewLine);

		MonoBehaviour.print(sb.ToString());
		step++;
	}

	public override void start()
	{
		base.start();
		show();
	}

	public int GetChoice()
	{
		String choice = GlobalStorage.getInstace().input.text.Trim();
		int x = 0;
        bool badChoice = choice.Equals("") || !int.TryParse(choice, out x);
		badChoice = badChoice || !Enumerable.Range(1, options.Count + 1).Contains(x);
		if (badChoice)
		{
			MonoBehaviour.print("bad choice try again!");
			return 0;
		}
		step++;
		return x;
	}

	public Menu SetOption(MenuOption option)
	{
		option.setPrevAction(this);
		options.Add(option);
		return this;
	}

	override
	protected IAction runAction()
	{
		IAction nextAction = this;

		int x = GetChoice();
		if (x > 0 && x <= options.Count)
			nextAction = options[x - 1];
		if (x == options.Count + 1)
			nextAction = prevAction;
		return nextAction;
	}

	//override
	//protected void checkParams()
	//{
	//	if (parameters.Count < actionParamsCount)
	//		throw new ArgumentException("");
	//	if (parameters[labelIdx] is not TextMeshProUGUI)
	//		throw new ArgumentException("param 0 should be of type TextMeshProUGUI");
	//	if (parameters[inputFieldIdx] is not TMP_InputField)
	//		throw new ArgumentException("param 1 should be of type TMP_InputField");
	//}
}