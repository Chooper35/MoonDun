using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesliDüsman : MonoBehaviour
{
    public GameObject enemyFire;
    public int health = 60;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float speed;
    public Transform target;
    public AudioClip damage;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("DüşmanAteşZaman", 2f, 0.5f);
        timeBtwShots = startTimeBtwShots;
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Ates")
        {
            Destroy(collision.gameObject);
            enemyDamage();
        }
        else if(collision.tag=="Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player!=null)
            {
                player.PlayerDamage();
            }
        }
    }
    public void DüşmanAteşZaman()
    {
        Instantiate(enemyFire, transform.position, transform.rotation);
    }
    public void enemyDamage()
    {
        health -= 30;
        AudioSource.PlayClipAtPoint(damage, transform.position, 0.1f);
        if(health<10)
        {
            Destroy(this.gameObject);
        }

    }
}
