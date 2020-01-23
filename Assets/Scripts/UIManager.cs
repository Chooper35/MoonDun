using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image LivesImageDisplay;
    public Sprite[] Lives;
    public Image KeyDisplay;
    public Sprite[] Keys;
    public bool GameOver;
    public GameObject MenuScreen;



    public void UpdateLives(int currentLives)
    {
        Debug.Log("Player Lives " + currentLives);
        LivesImageDisplay.sprite = Lives[currentLives];
    }

    public void UpdateKeys(int PickedKey)
    {
        Debug.Log("Key" + PickedKey);
        KeyDisplay.sprite = Keys[PickedKey];
    }


    public void ShowMenuScreen()
    {
        MenuScreen.SetActive(true);
    }

    public void HideMenuScreen()
    {
        MenuScreen.SetActive(false);
    }


    private void Update()
    {
        if (GameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
                GameOver = false;
                HideMenuScreen();
            }

            else if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }
}
