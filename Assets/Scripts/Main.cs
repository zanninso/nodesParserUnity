using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Newtonsoft.Json.Linq;

public class Main : MonoBehaviour
{
    //public TextMeshProUGUI title;
    //public TMP_InputField input;
    // Start is called before the first frame update
    public void RunAction() {
        //print(input.text);
    }

    void Start()
    {
        //title.text = "Path to json file:";
        //input.getText();
        print(typeof(int[]).ToString());
        print("mzyan a sidi");
        String jsonText = System.IO.File.ReadAllText("/Users/user/My project (1)/main.json");
        JObject obj = JObject.Parse(jsonText);
        Root root = new Root(obj);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
