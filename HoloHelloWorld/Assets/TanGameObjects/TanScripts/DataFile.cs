using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Text;


public class DataFile : MonoBehaviour
{

    private float stopwatch;
    private TextMesh debugMessage;
    private TextMesh prompt;

    //Start is called when the scene starts
    void Start()
    {
        debugMessage = GameObject.Find("DebugText").GetComponent<TextMesh>();
        prompt = GameObject.Find("Prompt").GetComponent<TextMesh>();
        stopwatch = 0;

        String path = Path.Combine(Application.persistentDataPath, "Entries.txt");
        using (var file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
            using (var writer = new StreamWriter(file, Encoding.UTF8))
            {
                writer.Write("start");
                writer.WriteLine("");
            }
        }
    }

    // Write is called every time the Newline key is pressed
    public void Write()
    {
        String path = Path.Combine(Application.persistentDataPath, "Entries.txt");
        using (var file = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write))
        {
            using (var writer = new StreamWriter(file, Encoding.UTF8))
            {
                writer.Write("expected: " + prompt.text);
                writer.WriteLine("");
                writer.Write("actual:   " + debugMessage.text + " time: " + stopwatch);
                writer.WriteLine("");
                stopwatch = 0.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMessage.text != "") { stopwatch += Time.deltaTime; }
    }
}
