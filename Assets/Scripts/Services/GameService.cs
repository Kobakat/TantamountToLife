using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameService : MonoBehaviour
{
    [SerializeField] float reloadSceneTime = 5.0f;
    Canvas canvas;
    
    Color color;
    float startTime;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        color = canvas.transform.Find("FadePanel").GetComponent<Image>().color;
    }

    void OnEnable()
    {
        DyingState.PlayerDeath += OnPlayerDeath;
    }
    void OnDisable()
    {
        DyingState.PlayerDeath -= OnPlayerDeath;
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
        float frac = 0;

        while (frac < 1)
        {
            frac = (Time.time - startTime) / (time - 1);
            color.a = Mathf.Lerp(0, 1, frac);
            canvas.transform.Find("FadePanel").GetComponent<Image>().color = color;
            yield return new WaitForEndOfFrame();
        }
       
        
       
    }
}
