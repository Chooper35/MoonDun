using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ates : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifetime;
    void Start()
    {
        Invoke("DestroyBall", lifetime);
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void DestroyBall()
    {
        Destroy(this.gameObject);
    }
}
