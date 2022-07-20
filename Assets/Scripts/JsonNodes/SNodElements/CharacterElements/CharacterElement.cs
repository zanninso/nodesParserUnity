using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

public class CharacterElement:BaseNode
{
	public String elementType;
	public String id;

	[BaseNode.Optional]
	public Animation animation;

    public CharacterElement(JObject jObj):base(jObj)
	{
		elementType = jObj["elementType"].Value<String>();
		id = jObj["id"].Value<String>();
		switch (elementType)
		{
			case "Animation":
				if (!jObj.ContainsKey("animation"))
					throw new FormatException("Messing animation object");
				animation = new Animation(jObj["animation"].ToObject<JObject>());
				break;
			default:
				throw new FormatException(String.Format("Invalide Object type {0}", elementType));
		}
	}

	public override string ToString(int level = 0, int depth = 1)
	{
		StringBuilder sb = new StringBuilder();
		String tabs = String.Concat(Enumerable.Repeat("\t", level));

		sb.Append(tabs)
		  .Append("elementType: ").Append(elementType)
		  .Append(Environment.NewLine);

		sb.Append(tabs)
		  .Append("id: ").Append(id)
		  .Append(Environment.NewLine);

		switch (elementType)
		{
			case "Animation":
				sb.Append(tabs).Append("animation:").Append(Environment.NewLine);
				sb.Append(animation.ToString(level + 1, depth));
				break;
		}
		return sb.ToString();
	}
}

