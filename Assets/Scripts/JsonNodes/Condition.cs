using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class Condition:BaseNode
{

	public class Event:BaseNode
	{
		public int desiredEventValue;
		public String eventType;

		public Event(JObject jObj) : base(jObj)
		{
			desiredEventValue = jObj["desiredEventValue"].Value<int>();
			eventType = jObj["eventType"].Value<String>();
		}

		public override string ToString(int level = 0, int depth = 1)
		{
			StringBuilder sb = new StringBuilder();
			String tabs = String.Concat(Enumerable.Repeat("\t", level));

			sb.Append(tabs)
			  .Append("desiredEventValue: ").Append(desiredEventValue)
			  .Append(Environment.NewLine);

			sb.Append(tabs)
			  .Append("eventType: ").Append(eventType)
			  .Append(Environment.NewLine);

			return sb.ToString();
		}
	}

	public String conditionType;
	public Event @event;

	public Condition(JObject jObj):base(jObj)
	{
		conditionType = jObj["conditionType"].Value<String>();
		@event = new Event(jObj["event"].ToObject<JObject>());
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(tabs)
		  .Append("conditionType: ").Append(conditionType)
		  .Append(Environment.NewLine);

		sb.Append(tabs).Append("event:").Append(Environment.NewLine);
		sb.Append(@event.ToString(level + 1, depth));

		return sb.ToString();
	}
}

