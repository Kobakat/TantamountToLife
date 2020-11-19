using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    #region Properties

    int health;

    //TODO swap this to a list. Heart container count may become dynamic at some point
    Image[] hearts;

    [SerializeField] Sprite fullHealthSprite = null;
    [SerializeField] Sprite halfHealthSprite = null;
    [SerializeField] Sprite emptyHealthSprite = null;

    #endregion

    #region Unity Event Functions

    void Start()
    {
        PlaceHeartContainers();
    }

    void OnEnable()
    {
        Player.PlayerDamaged += OnPlayerDamaged;
        Player.HealthPickup += OnHealthPickUp;
    }

    void OnDisable()
    {
        Player.PlayerDamaged -= OnPlayerDamaged;
        Player.HealthPickup -= OnHealthPickUp;
    }

    #endregion

    #region Events
    /// <summary>
    /// Instead of updating the UI every frame, update it when this function is called by an event (player getting hit)
    /// </summary>
    void OnPlayerDamaged()
    {
        health = FindObjectOfType<Player>().health;
        UpdateUI();
    }

    //Maybe health wants to flash differently from when player takes damage
    void OnHealthPickUp()
    {
        health = FindObjectOfType<Player>().health;
        UpdateUI();
    }

    #endregion

    #region Logic Functions
    /// <summary>
    /// Instantiates an appropriate number of heart containers and places them in the UI canvas
    /// </summary>
    void PlaceHeartContainers()
    {
        health = FindObjectOfType<Player>().health;

        hearts = new Image[Mathf.CeilToInt(health / 2.0f)];

        //Instantiate all the images for each heart container
        for(int i = 0; i < hearts.Length; i++)
        {
            //Make a new gameobject and give it all the components it needs
            GameObject newImage = new GameObject();
            newImage.transform.parent = this.transform;
            newImage.name = "Heart";
            
            newImage.AddComponent<Image>();
            
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

    void UpdateUI()
    {
        for(int i = hearts.Length - 1; i > -1; i--)
        {
            int check = (i + 1) * 2;

            if (check > health)
            {
                if (check - 1 == health)
                    hearts[i].sprite = halfHealthSprite;
                else
                    hearts[i].sprite = emptyHealthSprite;
            }

            else
                hearts[i].sprite = fullHealthSprite;
        }
    }

    #endregion
}
