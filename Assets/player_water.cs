using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
