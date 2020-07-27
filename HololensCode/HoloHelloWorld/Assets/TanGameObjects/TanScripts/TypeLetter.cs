using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

#if WINDOWS_UWP
using Windows.Storage;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using System;
#endif

public class TypeLetter : MonoBehaviour
{
    private TextMesh debugMessage;
    private float stopwatch;

    public string symbol;
    public GameObject KeyboardSegment;
    public GameObject BoardPlane;

    public Collider TRbumper;
    public Collider BRbumper;
    public Collider TLbumper;
    public Collider BLbumper;

    private float[] xs = { -0.05f, 0.05f, 0.0f };
    private float[] ys = { -0.05f, 0.05f, 0.0f };


    // Start is called before the first frame update
    void Start()
    {
        debugMessage = GameObject.Find("DebugText").GetComponent<TextMesh>();
        stopwatch = 0;

        debugMessage.text = "";

        String path = Path.Combine(Application.persistentDataPath, "LocalText.txt");
        using (var file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
            using (var writer = new StreamWriter(file, Encoding.UTF8))
            {
                writer.Write("Hello");
            }
        }
    }

    //timer starts when first character is entered and resets after newline 
    public void print()
    {
        debugMessage.text += symbol;
        Shift(); 
        if (symbol.Equals("newline"))
        {
            debugMessage.text = "";
            stopwatch = 0; //resets the stopwatch for next string
        }
    }
        

    //moves the keyboard segment 0.05 positive or negative on x or y
    void Shift()
    { 

        //get random seed from time in milliseconds
        System.Random randx = new System.Random(System.DateTime.Now.Millisecond);
        //pick the index from that random
        int indexx = randx.Next(xs.Length);
        //adjust index if out of bounds
        float xval = xs[indexx];
        float newXpos = KeyboardSegment.transform.localPosition.x + xval;

        //if a bumper does not have the "trigger" property, it is out of bounds per the "Bounding" script
        if (!BRbumper.isTrigger && !TRbumper.isTrigger)
        {
            indexx = 0;
            xval = xs[indexx];
            newXpos = KeyboardSegment.transform.localPosition.x + xval;
        }
        if (!BLbumper.isTrigger && !TLbumper.isTrigger)
        {
            indexx = 1;
            xval = xs[indexx];
            newXpos = KeyboardSegment.transform.localPosition.x + xval;
        }

        System.Random randy = new System.Random(System.DateTime.Now.Millisecond + System.DateTime.Now.Millisecond);
        int indexy = randy.Next(ys.Length);
        float yval = ys[indexy];
        float newYpos = KeyboardSegment.transform.localPosition.y + yval;
        
        if (!TLbumper.isTrigger && !TRbumper.isTrigger)
        {
            indexy = 0;
            yval = ys[indexy];
            newYpos = KeyboardSegment.transform.localPosition.y + yval;
        }
        if (!BLbumper.isTrigger && !BRbumper.isTrigger)
        {
            indexy = 1;
            yval = ys[indexy];
            newYpos = KeyboardSegment.transform.localPosition.y + yval;
        }

        Vector3 shiftPos = new Vector3(newXpos, newYpos, KeyboardSegment.transform.position.z);
        KeyboardSegment.transform.position = shiftPos;
        //if they shouldn't be alive, they aren't
        BLbumper.isTrigger = false;
        BRbumper.isTrigger = false;
        TLbumper.isTrigger = false;
        TRbumper.isTrigger = false;
    }
}
