using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Newtonsoft.Json.Linq;

public class Main : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TMP_InputField input;
    private IAction currentAction;
    // Start is called before the first frame update
    public void RunAction() {
        Debug.ClearDeveloperConsole();
        setAction(currentAction.run());
    }

    void Start()
    {

        GlobalStorage.getInstace().title = title;
        GlobalStorage.getInstace().input = input;

        Menu menuAction = new Menu();
        menuAction.SetOption(new OptionPrint("Print Current Node"));
        menuAction.SetOption(new OptionBackSelection("Select Parent"));
        menuAction.SetOption(new OptionSelectById("Select Element By Id", "Id to select element"));

        AAction jsonLoaderAction = new JsonLoader();
        jsonLoaderAction.setNextAction(menuAction);

        setAction(jsonLoaderAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setAction(IAction action) {
        currentAction = action;
        currentAction.start();
    }
}
