using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image LivesImageDisplay;
    public Sprite[] Lives;

    public void UpdateLives(int currentLives)
    {
        Debug.Log("Player Lives " + currentLives);
        LivesImageDisplay.sprite = Lives[currentLives];
    }
}
