using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class Sound: BaseNode
{
	public String objectName;
	public String objectId;
	public String audioType;
	public String audioUrl;
	public Boolean loop;
	public int volume;
	public int pitch;
	public String spatialMode;
	public int minDistance;
	public int maxDistance;
	public int startTime;
	public int endTime;

	public Sound(JObject jObj) :base(jObj)
	{
		objectName = jObj["objectName"].Value<String>();
		objectId = jObj["objectId"].Value<String>();
		audioType = jObj["audioType"].Value<String>();
		audioUrl = jObj["audioUrl"].Value<String>();
		loop = jObj["loop"].Value<Boolean>();
		volume = jObj["volume"].Value<int>();
		pitch = jObj["pitch"].Value<int>();
		spatialMode = jObj["spatialMode"].Value<String>();
		minDistance = jObj["minDistance"].Value<int>();
		maxDistance = jObj["maxDistance"].Value<int>();
		startTime = jObj["startTime"].Value<int>();
		endTime = jObj["endTime"].Value<int>();
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(tabs)
		  .Append("objectName: ").Append(objectName)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("objectId: ").Append(objectId)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("audioType: ").Append(audioType)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("audioUrl: ").Append(audioUrl)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("loop: ").Append(loop)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("volume: ").Append(volume)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("pitch: ").Append(pitch)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("spatialMode: ").Append(spatialMode)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("minDistance: ").Append(minDistance)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("maxDistance: ").Append(maxDistance)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("startTime: ").Append(startTime)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("endTime: ").Append(endTime)
		  .Append(Environment.NewLine);

		return sb.ToString();
	}

}

