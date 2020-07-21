using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLocation : MonoBehaviour
{
    public GameObject keyboard;
    public TextMesh display;

    // Update is called once per frame
    void Update()
    {
        display.text = keyboard.transform.position.ToString();
    }
}
