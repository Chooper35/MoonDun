using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject EnemyFire;
    public GameObject secondFire;
    public int bossHealth;
    private float timeBtwShots;   
    public float startTimeBtwShots;
    public GameObject keygameObject;
    public AudioClip screamMonster;


    void Start()
    {
        InvokeRepeating("DüşmanAteşZamanı", 2f, 0.3f);
        timeBtwShots = startTimeBtwShots;
        AudioSource.PlayClipAtPoint(screamMonster, transform.position, 1f);
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ates")
        {
            Destroy(collision.gameObject);
            BossDamage();
        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.PlayerDamage();
            }
        }
    }
    public void DüşmanAteşZamanı()
    {
        if(bossHealth>500)
        {
            Instantiate(secondFire, transform.position, transform.rotation);
            
        }
        if(bossHealth<500)
        {
            Instantiate(EnemyFire, transform.position, transform.rotation);
        }

        
    }
    public void BossDamage()
    {
        bossHealth -= 20;
        if(bossHealth<10)
        {
            Instantiate(keygameObject, transform.position, transform.rotation);
            Destroy(this.gameObject);
            
        }
    }
}