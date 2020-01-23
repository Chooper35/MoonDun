using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Vector2 target;
    public float lifetime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Invoke("DestroyProjectile", lifetime);

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime); 
        if(transform.position.x==target.x &&transform.position.y==target.y)
        {
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player!=null)
            {
                player.PlayerDamage();
            }
            Destroy(this.gameObject);
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
