using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public GameObject Gates;
    public UIManager _uiManager;
    public GameObject player;
    public AudioClip _dooropen;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player.keyIsTaken==true)
            {
                    AudioSource.PlayClipAtPoint(_dooropen, transform.position, 0.5f);                   
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }          
        }
    }
}
