using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class Root:BaseNode
{
	public class MainNode: BaseNode
	{
		//public Dictionary<int, Node> nodes;
		public List<Node> nodes =  new List<Node>();

		public MainNode(JObject jObj) : base(jObj)
		{
			foreach (JToken token in ((JArray)jObj["nodes"]))
			{
				Node tmp = new Node(token.ToObject<JObject>());
				if (tmp.nodeType == "SNode")
					nodes.Add(new SNode(token.ToObject<JObject>()));
				else if (tmp.nodeType == "LNode")
					nodes.Add(new LNode(token.ToObject<JObject>()));
			}
		}
	}

	public String mainName;
	public MainNode main;

	public Root(JObject jObj): base(jObj)
	{
		mainName = jObj["mainName"].Value<String>();
		main = new MainNode(jObj["main"].ToObject<JObject>());
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));
		sb.Append(tabs)
		  .Append("mainName: ").Append(mainName)
		  .Append(Environment.NewLine);

		sb.Append(tabs).Append("main:").Append(Environment.NewLine);
		sb.Append(main.ToString(level + 1, depth - 1));

		return sb.ToString();
	}
}

