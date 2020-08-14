using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using System;
using UnityEngine.UI;

public class CHECK : MonoBehaviour
{
    string userName;

    public WWW w;

    string filename = "faq";

    // Start is called before the first frame update
    void Start()
    {
        userName = System.Environment.UserName;
        string hlpCommand = "/k mkdir C:\\Users\\" + userName + "\\Documents\\TEST\\help & exit";
        System.Diagnostics.Process.Start("CMD.exe", hlpCommand);
        string faqCommand = "/k mkdir C:\\Users\\" + userName + "\\Documents\\TEST\\FAQ  & exit";
        System.Diagnostics.Process.Start("CMD.exe", faqCommand);
        StartCoroutine(GetFAQData(filename));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetFAQData(string name)
    {
        yield return new WaitForSeconds(3);
        w = new WWW("C:\\Users\\" + userName + "\\Documents\\TEST\\FAQ\\" + name + ".json");
        // print(w.text);
        // MyClass myObject = JsonUtility.FromJson<MyClass>(w.text);
        // print(myObject);
        RootObject obj = JsonConvert.DeserializeObject<RootObject>(w.text);
		
		foreach (KeyValuePair<string, JobCode> kvp in obj.faqs.Codes)
		{
			print("Id: \n" + kvp.Value.id);
			print("Header: \n" + kvp.Value.header);
			print("Content: \n" + kvp.Value.content);

		}
        
        
    }
}
[Serializable]
	public class RootObject
	{
		[JsonProperty("faqs")]
		public Faqs faqs { get; set; }
	}

[Serializable]
	public class Faqs
	{
		[JsonProperty("codes")]
		public Dictionary<string, JobCode> Codes { get; set; }
	}
	
[Serializable]
	public class JobCode
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("header")]
		public string header { get; set; }

        [JsonProperty("content")]
		public string content { get; set; }
	}


