using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gate : MonoBehaviour
{
    public GameObject Gates;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player.keyIsTaken==true)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }          
        }
    }
}
