using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{

    [SerializeField] private string LoadLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(LoadLevel);
        }



    }
}






