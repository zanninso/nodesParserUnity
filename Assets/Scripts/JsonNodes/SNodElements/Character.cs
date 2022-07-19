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
    public List<CharacterElement> elements = new List<CharacterElement>();

	public Character(JObject jObj):base(jObj)
	{
        id = jObj["id"].Value<String>();
        name = jObj["name"].Value<String>();
        startTime = jObj["startTime"].Value<int>();
        endTime = jObj["endTime"].Value<int>();
        model = jObj["model"].Value<String>();

        foreach (JToken token in ((JArray)jObj["elements"]))
        {
            elements.Add(new CharacterElement(token.ToObject<JObject>()));
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
			foreach (CharacterElement nodeElement in elements)
			{
				sb.Append(tabs).Append("condition:").Append(Environment.NewLine);
				sb.Append(nodeElement.ToString(level + 1, depth - 1));
			}
		}
		else
			sb.Append(tabs)
				.Append(String.Format("condition: [{0}]", elements.Count))
				.Append(Environment.NewLine);

		return sb.ToString();
	}
}

