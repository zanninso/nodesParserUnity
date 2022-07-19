using System;
using Newtonsoft.Json.Linq;

//[System.Serializable]
public class SNodeElement:BaseNode
{
	public String elementType;

	[BaseNode.Optional]
	public Sound sound;

	[BaseNode.Optional]
	public Character character;

	public SNodeElement(JObject jObj):base(jObj)
	{
		elementType = jObj["elementType"].Value<String>();
		switch (elementType)
		{
			case "Sound":
				if (!jObj.ContainsKey("sound"))
					throw new FormatException("Messing sound object");
				sound = new Sound(jObj["sound"].ToObject<JObject>());
					break;
			case "Character":
				if (!jObj.ContainsKey("character"))
					throw new FormatException("Messing character object");
				character = new Character(jObj["character"].ToObject<JObject>());
				break;
			default:
				throw new FormatException(String.Format("Invalide Object type {0}", elementType));
		}
	}
}

