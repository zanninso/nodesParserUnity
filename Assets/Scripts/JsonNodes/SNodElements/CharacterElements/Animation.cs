using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class Animation:BaseNode
{
	public string animationId;
	public int endTime;
	public int loopCount;
	public String name;
	public int startTime;
	public SNode.Origin destination;

	public Animation(JObject jObj):base(jObj)
	{
		animationId = jObj["animationId"].Value<String>();
		loopCount = jObj["loopCount"].Value<int>();
		name = jObj["name"].Value<String>();
		startTime = jObj["startTime"].Value<int>();
		endTime = jObj["endTime"].Value<int>();
		destination = new SNode.Origin(jObj["destination"].ToObject<JObject>());
	}

	public override string ToString(int level = 0, int depth = 1)
	{

		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(tabs)
		  .Append("animationId: ").Append(animationId)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("loopCount: ").Append(loopCount)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("name: ").Append(name)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("startTime: ").Append(startTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("endTime: ").Append(endTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs).Append("destination:").Append(Environment.NewLine);
		sb.Append(destination.ToString(level + 1, depth));

		return sb.ToString();
	}
}

