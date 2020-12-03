using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    TextMeshProUGUI text;

    void OnEnable()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        Player.GoldPickup += OnGoldPickup;
    }

    void OnDisable()
    {
        Player.GoldPickup -= OnGoldPickup;
    }

    void OnGoldPickup()
    {
        this.text.text = Player.gold.ToString();
    }
}
