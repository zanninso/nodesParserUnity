using System;
using TMPro;
using System.Collections.Generic;

public class GlobalStorage
{
	private static GlobalStorage instance;

	public TextMeshProUGUI title;
	public TMP_InputField input;
	public Stack<BaseNode> selectedNodes = new Stack<BaseNode>();
	public Root rootNode;

	private GlobalStorage() {}

	public static GlobalStorage getInstace()
	{
		if (instance == null)
			instance = new GlobalStorage();
		return instance;
	}

}

