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
	}

	public int startTime;
	public int endTime;
	public Origin origin;
	public List<SNodeElement> nodeElements = new List<SNodeElement>(); // dictionary


	public SNode(JObject jObj) : base(jObj)
	{
		startTime = jObj["startTime"].Value<int>();
		endTime = jObj["endTime"].Value<int>();
		origin = new Origin(jObj["origin"].ToObject<JObject>());
		foreach (JToken token in ((JArray)jObj["nodeElements"]))
		{
			nodeElements.Add(new SNodeElement(token.ToObject<JObject>()));
		}
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(base.ToString());

		sb.Append(tabs)
		  .Append("startTime: ").Append(startTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("endTime: ").Append(endTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs).Append("origin:").Append(Environment.NewLine);
		sb.Append(origin.ToString(level + 1, depth - 1));

		if (depth > 0)
		{
			foreach (SNodeElement nodeElement in nodeElements)
			{
				sb.Append(tabs).Append("condition:").Append(Environment.NewLine);
				sb.Append(nodeElement.ToString(level + 1, depth - 1));
			}
		}
		else
			sb.Append(tabs)
				.Append(String.Format("condition: [{0}]", nodeElements.Count))
				.Append(Environment.NewLine);

		return sb.ToString();
	}
}

