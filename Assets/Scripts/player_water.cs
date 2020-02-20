using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_water : MonoBehaviour
{

    void OnTriggerEnter(Collider Player) { 
        if (Player.gameObject.tag == "Player")
    {
     Player.GetComponent<LifeStats>().Hurt(Time.deltaTime * 100000000);
    }
}
}
