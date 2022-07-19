using System;
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
		endTime = jObj["endTime"].Value<int>();
		loopCount = jObj["loopCount"].Value<int>();
		name = jObj["name"].Value<String>();
		startTime = jObj["startTime"].Value<int>();
		destination = new SNode.Origin(jObj["destination"].ToObject<JObject>());
	}
}

