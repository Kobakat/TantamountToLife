using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameService : MonoBehaviour
{
    [SerializeField] float reloadSceneTime;
    [SerializeField] Canvas canvas;
    
    Color color;
    float startTime;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        color = canvas.transform.Find("FadePanel").GetComponent<Image>().color;
    }

    void OnEnable()
    {
        Player.PlayerDeath += OnPlayerDeath;
    }
    void OnDisable()
    {
        Player.PlayerDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        startTime = Time.time;
        StartCoroutine(LoadSceneAfterDelay(reloadSceneTime));
        StartCoroutine(FadeScreenToBlack(reloadSceneTime));
    }

    /// <summary>
    /// Reload the scene after <param name="time"> seconds
    /// </summary>
    IEnumerator LoadSceneAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Lerp screen black over <param name="time"> seconds
    /// </summary>
    IEnumerator FadeScreenToBlack(float time)
    {
        float frac = (Time.time - startTime) / time;

        color.a = Mathf.Lerp(0, 255, frac);

        yield return new WaitForSeconds(.25f);
    }
}
