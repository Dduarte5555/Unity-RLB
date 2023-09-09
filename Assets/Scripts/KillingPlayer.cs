using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillingPlayer : MonoBehaviour
{

    public int Respawn;
       private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // other.gameObject.SetActive(false);
            SceneManager.LoadScene(Respawn);
        }
    }
}
