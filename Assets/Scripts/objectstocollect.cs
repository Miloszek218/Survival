using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectstocollect : MonoBehaviour {
    public static int objects = 0;
  
    void Awake()
    {
        objects++;
    }

   
    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "FPSController")
            objects++;
        gameObject.SetActive(false);
    }
}
