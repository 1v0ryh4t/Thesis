using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounding : MonoBehaviour
{
    //All of these are called automatically
    private void OnTriggerExit(Collider other)
    {
        other.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if this is the correct box, assign true
        if ((other.name.Contains("Top") && gameObject.name.Contains("Top"))
         || (other.name.Contains("Bot") && gameObject.name.Contains("Bot")))
            other.isTrigger = true;
        else
            other.isTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.name.Contains("Top") && gameObject.name.Contains("Top")) 
         || (other.name.Contains("Bot") && gameObject.name.Contains("Bot")))
            other.isTrigger = true;
        else
            other.isTrigger = false;
    }
}
