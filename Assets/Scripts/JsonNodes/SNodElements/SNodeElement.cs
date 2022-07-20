using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

//[System.Serializable]
public class SNodeElement : BaseNode
{
	public String elementType;

	[BaseNode.Optional]
	public Sound sound;

	[BaseNode.Optional]
	public Character character;

	[BaseNode.Ignore]
	public string id;

	public SNodeElement(JObject jObj):base(jObj)
	{
		elementType = jObj["elementType"].Value<String>();

		switch (elementType)
		{
			case "Sound":
				if (!jObj.ContainsKey("sound"))
					throw new FormatException("Messing sound object");
				sound = new Sound(jObj["sound"].ToObject<JObject>());
				id = sound.objectId;
					break;
			case "Character":
				if (!jObj.ContainsKey("character"))
					throw new FormatException("Messing character object");
				character = new Character(jObj["character"].ToObject<JObject>());
				id = character.id;
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

		switch (elementType)
		{
			case "Sound":
				sb.Append(tabs).Append("sound:").Append(Environment.NewLine);
				sb.Append(sound.ToString(level + 1, depth));
				break;

			case "Character":
				sb.Append(tabs).Append("character:").Append(Environment.NewLine);
				sb.Append(character.ToString(level + 1, depth));
				break;
		}
		return sb.ToString();
	}

	public override BaseNode findById(string key)
	{
		switch (elementType)
		{
			case "Sound":
				return sound.findById(key);

			case "Character":
				return character.findById(key);
		}
		return base.findById(key);
	}
}

