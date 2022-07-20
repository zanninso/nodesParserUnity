using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

[System.Serializable]
public class SNode:Node
{
	
	public class Origin:BaseNode
	{
		public int[] position = new int[3];
		public int[] rotation = new int[3];

		public Origin(JObject jObj) : base(jObj)
		{
			JArray p = (JArray)jObj["position"];
			JArray r = (JArray)jObj["rotation"];

			if (p.Count != 3)
				throw new FormatException("Bad position array size");
			if (r.Count != 3)
				throw new FormatException("Bad rotation array size");

			position[0] = p[0].Value<int>();
			position[1] = p[1].Value<int>();
			position[2] = p[2].Value<int>();

			rotation[0] = r[0].Value<int>();
			rotation[1] = r[1].Value<int>();
			rotation[2] = r[2].Value<int>();
		}

		public override string ToString(int level = 0, int depth = 1)
		{
			StringBuilder sb = new StringBuilder();
			String tabs = String.Concat(Enumerable.Repeat("\t", level));

			sb.Append(tabs)
			  .Append("position: [")
					.Append(position[0]).Append(",")
					.Append(position[1]).Append(",")
					.Append(position[2]).Append(",")
			  .Append("]").Append(Environment.NewLine);

			sb.Append(tabs)
			  .Append("rotation: [")
					.Append(rotation[0]).Append(",")
					.Append(rotation[1]).Append(",")
					.Append(rotation[2]).Append(",")
			  .Append("]").Append(Environment.NewLine);
			return sb.ToString();
		}
	}

	public int startTime;
	public int endTime;
	public Origin origin;
	public  Dictionary<String, SNodeElement> nodeElements = new Dictionary<String, SNodeElement>();


	public SNode(JObject jObj) : base(jObj)
	{
		startTime = jObj["startTime"].Value<int>();
		endTime = jObj["endTime"].Value<int>();
		origin = new Origin(jObj["origin"].ToObject<JObject>());
		foreach (JToken token in ((JArray)jObj["nodeElements"]))
		{
			SNodeElement elem = new SNodeElement(token.ToObject<JObject>());
			String key = elem.id;
			nodeElements.Add(key, elem);
		}
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(base.ToString(level, depth));

		sb.Append(tabs)
		  .Append("startTime: ").Append(startTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("endTime: ").Append(endTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs).Append("origin:").Append(Environment.NewLine);
		sb.Append(origin.ToString(level + 1, depth));

		if (depth > 0)
		{
			sb.Append(tabs).Append("nodeElements:[").Append(Environment.NewLine);
			foreach (String key in nodeElements.Keys)
			{
				sb.Append(nodeElements[key].ToString(level + 1, depth - 1))
				  .Append(tabs).Append(",").Append(Environment.NewLine);
			}
			sb.Append(tabs).Append("]").Append(Environment.NewLine);
		}
		else
			sb.Append(tabs)
				.Append(String.Format("nodeElements: [{0}]", nodeElements.Count))
				.Append(Environment.NewLine);

		return sb.ToString();
	}

	public override BaseNode findById(string key)
	{
		if (nodeElements.ContainsKey(key))
			return nodeElements[key];
		throw new Exception("key not found");
	}
}

