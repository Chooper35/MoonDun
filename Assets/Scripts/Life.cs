using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour

    
{   
    public int Health;
    public UIManager _uiManager;
    public AudioClip _clip;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Player player = collision.GetComponent<Player>();

        if (collision.tag == "Player")
        {

            if (player.playerHealth < 100)
            {
                player.playerHealth += Health;
                AudioSource.PlayClipAtPoint(_clip, transform.position,0.3f);
                Destroy(this.gameObject);
            }
            _uiManager.UpdateLives(player.playerHealth / 10);
        }

    }
}
