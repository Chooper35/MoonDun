using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject atesprefab;
    public Transform shotpoint;
    public int playerHealth = 100;
    public float fireRate = 0.3f;
    public float canFire = 0.0f;
    public bool keyIsTaken;
    public GameObject textgameObject;
    public AudioClip playerShoot;
    public AudioClip keyPickUp;
    public AudioClip playerTakeDamage;

    public UIManager _uiManager;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==0)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if(SceneManager.GetActiveScene().buildIndex==1)
        {
            transform.position = new Vector3(0.7f, -5f, 0);
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLives(playerHealth/10);
            keyIsTaken = false;
            _uiManager.UpdateKeys(0);
        }
        textgameObject.SetActive(false);

    }
    void Update()
    {
        AtesEtmek();
        Movement();
    }
    void Movement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

    }
    void AtesEtmek()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > canFire)
            {
                Instantiate(atesprefab, shotpoint.position, shotpoint.rotation);
                AudioSource.PlayClipAtPoint(playerShoot, transform.position,0.1f);
                canFire = Time.time + fireRate;
            }

        }
    }
    public void PlayerDamage()
    {
        playerHealth -= 10;
        AudioSource.PlayClipAtPoint(playerTakeDamage, transform.position, 0.3f);
        if(playerHealth<1)
        {
            _uiManager.GameOver = true;
            _uiManager.ShowMenuScreen();


            Destroy(this.gameObject);
        }
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.UpdateLives(playerHealth / 10);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Key")
        {
            keyIsTaken = true;
            AudioSource.PlayClipAtPoint(keyPickUp, transform.position, 0.5f);
            Destroy(collision.gameObject);
            textgameObject.SetActive(false);
        }
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (keyIsTaken == true)
        {
            _uiManager.UpdateKeys(1);
        }
        if(collision.tag=="Gate")
        {
            if(keyIsTaken==false)
            {
                textgameObject.SetActive(true);
            }
            
        }
    }
}
