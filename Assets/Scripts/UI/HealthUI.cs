using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    int health;

    //TODO swap this to a list. Heart container count may become dynamic at some point
    Image[] hearts;

    [SerializeField] Sprite fullHealthSprite;
    [SerializeField] Sprite halfHealthSprite;
    [SerializeField] Sprite emptyHealthSprite;

    void Start()
    {
        PlaceHeartContainers();
    }

    void OnEnable()
    {
        Player.PlayerDamaged += OnPlayerDamaged;
    }

    void OnDisable()
    {
        Player.PlayerDamaged -= OnPlayerDamaged;
    }

    /// <summary>
    /// Instantiates an appropriate number of heart containers and places them in the UI canvas
    /// </summary>
    void PlaceHeartContainers()
    {
        health = FindObjectOfType<Player>().health;

        //Note that this expects the players full health to be divisible by 2
        hearts = new Image[Mathf.CeilToInt(health / 2.0f)];

        //Instantiate all the images for each heart container
        for(int i = 0; i < hearts.Length; i++)
        {
            //Make a new gameobject and give it all the components it needs
            GameObject newImage = new GameObject();
            newImage.transform.parent = this.transform;
            newImage.name = "Heart";
            
            newImage.AddComponent<Image>();
            newImage.AddComponent<CanvasRenderer>();
            newImage.AddComponent<RectTransform>();
            
            //References for the necessary components
            Image image = newImage.GetComponent<Image>();
            RectTransform rect = newImage.GetComponent<RectTransform>();

            //Set the sprite image and position on the canvas
            image.sprite = fullHealthSprite;
            rect.anchorMin = new Vector2(0, 1);
            rect.anchorMax = new Vector2(0, 1);
            rect.anchoredPosition = new Vector3(50 + i * 50, -50);

            //Stash it in this array for UpdateUI
            hearts[i] = image;
        }
        //Check once to ensure all sprites are proper
        UpdateUI();
    }

    /// <summary>
    /// Instead of updating the UI every frame, update it when this function is called by an event (player getting hit)
    /// </summary>
    void OnPlayerDamaged()
    {
        health = FindObjectOfType<Player>().health;
        UpdateUI();
    }

    void UpdateUI()
    {
        for(int i = hearts.Length - 1; i > -1; i--)
        {
            int check = (i + 1) * 2;

            if (check > health) 
            {
                if(check - 1 == health)
                    hearts[i].sprite = halfHealthSprite;
                else
                    hearts[i].sprite = emptyHealthSprite;
            }
        }
    }
}
