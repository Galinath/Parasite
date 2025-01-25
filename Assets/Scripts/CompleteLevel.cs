using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 



public class LevelComplete : MonoBehaviour

{

    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player") || other.CompareTag("Host")) 

        {

            Debug.Log("Level Completed!");

            CompleteLevel();

        }

    }



    void CompleteLevel()

    {

        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
