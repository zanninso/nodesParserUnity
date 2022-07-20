using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class Root:BaseNode
{
	public class MainNode: BaseNode
	{
		public Dictionary<int, Node> nodes =  new Dictionary<int, Node>();

		public MainNode(JObject jObj) : base(jObj)
		{
			foreach (JToken token in ((JArray)jObj["nodes"]))
			{
				Node tmp = new Node(token.ToObject<JObject>());
				if (tmp.nodeType == "SNode")
					tmp = new SNode(token.ToObject<JObject>());
				else if (tmp.nodeType == "LNode")
					tmp = new LNode(token.ToObject<JObject>());
				else
					throw new FormatException(String.Format("Invalide Type {0}", tmp.nodeType));
				nodes.Add(tmp.nodeId, tmp);
			}
		}

		public override string ToString(int level = 0, int depth = 1)
		{
			StringBuilder sb = new StringBuilder();
			String tabs = String.Concat(Enumerable.Repeat("\t", level));

			if (depth > 0)
			{
				sb.Append(tabs).Append("nodes: [").Append(Environment.NewLine);
				foreach (int key in nodes.Keys)
					sb.Append(nodes[key].ToString(level + 1, depth - 1))
					  .Append(tabs).Append(",").Append(Environment.NewLine);
				sb.Append(tabs).Append("]").Append(Environment.NewLine);
			}
			else
				sb.Append(tabs)
				  .Append(String.Format("node: [{0}]", nodes.Count))
				  .Append(Environment.NewLine);

			return sb.ToString();
		}

		public override BaseNode findById(string key)
		{
			int ikey = int.Parse(key);
			if (nodes.ContainsKey(ikey))
				return nodes[ikey];
			throw new Exception("key not found");
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
		sb.Append(main.ToString(level + 1, depth));

		return sb.ToString();
	}

	public override BaseNode findById(string key)
	{
		return main.findById(key);
	}
}

