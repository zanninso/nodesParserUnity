using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JsonLoader: AAction
{
	public JsonLoader(String title = "Path to json file:")
	{
		this.title = title;
	}

	override
	protected IAction runAction()
	{
		IAction nextAction = this;
		String path = GlobalStorage.getInstace().input.text;

		try
		{
			//MonoBehaviour.print("start parsing");
			String jsonText = System.IO.File.ReadAllText(path);
			//MonoBehaviour.print("file readed");
			JObject obj = JObject.Parse(jsonText);
			//MonoBehaviour.print("data parsed");
			GlobalStorage.getInstace().rootNode = new Root(obj);
			//MonoBehaviour.print("object created");
            GlobalStorage.getInstace().selectedNodes.Clear();
            GlobalStorage.getInstace().selectedNodes.Push(GlobalStorage.getInstace().rootNode);
            //MonoBehaviour.print("File well parsed");
			nextAction = this.nextAction;
		}
		catch (Exception e)
		{
			MonoBehaviour.print(e.Message);
			MonoBehaviour.print("Try with another file");
		}

		return nextAction;
	}
}

