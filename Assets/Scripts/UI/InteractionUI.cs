using UnityEngine.UI;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    Image image;
    void OnEnable()
    {
        image = this.GetComponent<Image>();
        Player.InteractionPrompt += OnInteraction;
    }

    void OnDisable()
    {
        Player.InteractionPrompt -= OnInteraction;
    }

    void OnInteraction(bool active) 
    {
        this.image.enabled = active; 
    }

}
