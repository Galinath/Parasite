using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 



public class DeathZone : MonoBehaviour

{

    private void OnTriggerEnter2D(Collider2D other)

    {

        

        if (other.CompareTag("Player") || other.CompareTag("Host")) 

        {

            Debug.Log("Player Died!");

            RestartLevel();

        }

    }



    void RestartLevel()

    {

       

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
