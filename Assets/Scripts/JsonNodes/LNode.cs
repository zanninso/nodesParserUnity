using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;

[System.Serializable]
public class LNode:Node
{
	public List<Condition> conditions;

	public LNode(JObject jObj) : base(jObj)
	{
		conditions = new List<Condition>();
		foreach (JToken token in ((JArray)jObj["conditions"]))
		{
			conditions.Add(new Condition(token.ToObject<JObject>()));
		}
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(base.ToString());

		if (depth > 0)
		{
			foreach (Condition condition in conditions)
			{
				sb.Append(tabs).Append("condition:").Append(Environment.NewLine);
				sb.Append(condition.ToString(level + 1, depth - 1));
			}
		}
		else
			sb.Append(tabs)
				.Append(String.Format("condition: [{0}]", conditions.Count))
				.Append(Environment.NewLine);

		return sb.ToString();
	}
}

