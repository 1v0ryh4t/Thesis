using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    public GameObject BoardPlane;
    public GameObject KeyboardSegment;

    // Start is called before the first frame update
    void Start()
    {
        if (KeyboardSegment.name.Contains("Left"))//should generate a new random for each keyboard. UPDATE: Still works for the horizontal keyboard, even though both go the right path, because we generate a new randPos each time
        {
            Vector3 randPos = transform.position + new Vector3(Random.Range(-BoardPlane.transform.localScale.x/2, BoardPlane.transform.localScale.x/2),
                                                               Random.Range(-BoardPlane.transform.localScale.y/2, BoardPlane.transform.localScale.y/2),0);//random range for z shouldn't be a choice
            Instantiate(KeyboardSegment, randPos, KeyboardSegment.transform.rotation);
            if (!KeyboardSegment.activeSelf) { KeyboardSegment.SetActive(true); }
           
        }
        else
        {
            Vector3 randPos = transform.position + new Vector3(Random.Range(-BoardPlane.transform.localScale.x/2, BoardPlane.transform.localScale.x/2),
                                                               Random.Range(-BoardPlane.transform.localScale.y/2, BoardPlane.transform.localScale.y/2),0);//random range for z shouldn't be a choice
            Instantiate(KeyboardSegment, randPos, KeyboardSegment.transform.rotation);
            if (!KeyboardSegment.activeSelf) { KeyboardSegment.SetActive(true); }
            
        }
    }
}
