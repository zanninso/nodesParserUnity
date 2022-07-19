using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class Node:BaseNode
{
	public String name;

	public int nodeId;

	public String nodeType;

	[BaseNode.Optional]
	public int nextNodeID = 0;

	public Node(JObject jObj) : base(jObj)
	{
		name = jObj["name"].Value<String>();
		nodeId = jObj["nodeId"].Value<int>();
		nodeType = jObj["nodeType"].Value<String>();
		if (jObj.ContainsKey("nextNodeID"))
			nextNodeID = jObj["nextNodeID"].Value<int>();
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(tabs)
		  .Append("name: ").Append(name)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("nodeId: ").Append(nodeId)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("nodeType: ").Append(nodeType)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("nextNodeID: ").Append(nextNodeID)
		  .Append(Environment.NewLine);

		return sb.ToString();
	}
}

