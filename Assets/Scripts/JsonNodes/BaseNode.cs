using System;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Collections.Generic;

public abstract class BaseNode
{
	[System.AttributeUsage(System.AttributeTargets.Field | AttributeTargets.Property)]
    public class Optional : System.Attribute {}

    static Dictionary<String, String> types = new Dictionary<String, String> {
        {typeof(int).ToString(), "Integer"},
        {typeof(string).ToString(), "String"},
        {typeof(bool).ToString(), "Boolean"},
        {typeof(List<>).ToString().Substring(0, typeof(List<>).ToString().IndexOf("`")), "Array"},
        {typeof(Dictionary<,>).ToString().Substring(0, typeof(List<>).ToString().IndexOf("`")), "Array"},
        {typeof(int[]).ToString(), "Array"},
    };

    private String cleanType(String type)
    {
        int lenght = type.IndexOf("`");
        if (lenght == -1)
            lenght = type.Length;
        return type.Substring(0, lenght);
    }


    public BaseNode(JObject jObj)
	{
        // checking for bad field types 
        foreach (FieldInfo field in this.GetType().GetRuntimeFields())
        {
            String fieldType = types.GetValueOrDefault(cleanType(field.FieldType.ToString()), "Object");
            if (jObj.ContainsKey(field.Name))
            {
                if (!jObj[field.Name].Type.ToString().Equals(fieldType))
                    throw new FormatException(String.Format("Invalide type {0} for field {1} of type {2}",
                                                            jObj[field.Name].Type.ToString(),
                                                            field.Name,
                                                            fieldType));
            }
            else if (field.GetCustomAttribute(typeof(Optional), false) == null)
                throw new FormatException(String.Format("Missing field {0}", field.Name));
        }
        // dont forget to check for the objects inside arrays
    }

    public abstract string ToString(int level = 0, int depth = 1);

}

