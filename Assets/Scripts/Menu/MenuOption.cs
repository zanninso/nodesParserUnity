using System;
using TMPro;

public abstract class MenuOption: AAction
{
    String name;
	const int labelIdx = 0;
	const int inputFieldIdx = 1;

	public MenuOption(String name, String title = "Click submit to go back")
    {
        this.name = name;
		this.title = title;
    }

    public String getName() { return name; }

	//override
	//protected void checkParams()
	//{
	//	if (parameters.Count < 2)
	//		throw new ArgumentException("");
	//	if (parameters[labelIdx] is not TextMeshProUGUI)
	//		throw new ArgumentException("param 0 should be of type TextMeshProUGUI");
	//	if (parameters[inputFieldIdx] is not TMP_InputField)
	//		throw new ArgumentException("param 1 should be of type TMP_InputField");
	//}
}