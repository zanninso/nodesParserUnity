using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class Character:BaseNode
{
	public String id;
    public String name;
    public int startTime;
    public int endTime;
    public String model;
    public Dictionary<String, CharacterElement> elements = new Dictionary<String, CharacterElement>();

	public Character(JObject jObj):base(jObj)
	{
        id = jObj["id"].Value<String>();
        name = jObj["name"].Value<String>();
        startTime = jObj["startTime"].Value<int>();
        endTime = jObj["endTime"].Value<int>();
        model = jObj["model"].Value<String>();

        foreach (JToken token in ((JArray)jObj["elements"]))
        {
			CharacterElement elem = new CharacterElement(token.ToObject<JObject>());
			String key = elem.id;
			elements.Add(key, elem);
        }
    }

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(tabs)
		  .Append("id: ").Append(id)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("name: ").Append(name)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("startTime: ").Append(startTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("startTime: ").Append(endTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("startTime: ").Append(model)
		  .Append(Environment.NewLine);

		if (depth > 0)
		{
			sb.Append(tabs).Append("elements:[").Append(Environment.NewLine);
			foreach (String key in elements.Keys)
			{
				sb.Append(elements[key].ToString(level + 1, depth - 1));
				sb.Append(tabs).Append(",").Append(Environment.NewLine);
			}
			sb.Append(tabs).Append("]").Append(Environment.NewLine);
		}
		else
			sb.Append(tabs)
			  .Append(String.Format("elements: [{0}]", elements.Count))
			  .Append(Environment.NewLine);

		return sb.ToString();
	}

	public override BaseNode findById(string key)
	{
		if (elements.ContainsKey(key))
			return elements[key];
		throw new Exception("key not found");
	}
}

