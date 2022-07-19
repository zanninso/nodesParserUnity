using System;
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
}

