using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_UI : MonoBehaviour
{

    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerEnter (Collider Player)
    {
        if (Player.gameObject.tag == "Player")


        {
            uiObject.SetActive(true);
            StartCoroutine("WaitforSec");
        }
    }
    IEnumerator WaitforSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}

