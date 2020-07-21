using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordGen : MonoBehaviour
{
    private string psswd = "";
    public int length;
    private TextMesh prompt;
    private string list = "1234567890abcdefghijklmnopqrstuvwxyz";
    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Prompt").GetComponent<TextMesh>();
        GenPassword();
    }

    public void GenPassword()
    {
        //generate string
        
        if (prompt.text != "") { prompt.text = ""; psswd = ""; } // clear textbox before generation

        for (int i = 0; i < length; i++)
        {
            char rand = list[Random.Range(0, list.Length)];
            psswd += rand;
        }

        //display string
        prompt.text = psswd;
    }
   
}
