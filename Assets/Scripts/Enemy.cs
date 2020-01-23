using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public int health;
    public AudioClip enemydamageclip;
    public AudioClip enemyBatsound;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AudioSource.PlayClipAtPoint(enemyBatsound, transform.position, 0.05f);
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ates")
        {
            Destroy(other.gameObject);
            TakeDamage();
        }
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.PlayerDamage();
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player!=null)
            {
                player.PlayerDamage();
            }
            Destroy(this.gameObject);
        }
    }
    void TakeDamage()
    {
        health -= 30;
        AudioSource.PlayClipAtPoint(enemydamageclip, transform.position, 0.1f);
        if (health<1)
        {           
            Destroy(this.gameObject);
        }
    }

}
