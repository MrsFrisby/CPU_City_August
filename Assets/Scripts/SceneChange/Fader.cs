using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [HideInInspector]
    public bool start = false;
    [HideInInspector]
    public float fadeDamp = 0.0f;
    [HideInInspector]
    public string fadeScene;
    [HideInInspector]
    public float alpha = 0.0f;
    [HideInInspector]
    public Color fadeColor;
    [HideInInspector]
    public bool isFadeIn = false;
    CanvasGroup myCanvas;
    Image bg;
    float lastTime = 0;
    bool startedLoading = false;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void InitiateFader()
    {
        DontDestroyOnLoad(gameObject);

        myCanvas = GetComponent<CanvasGroup>();
        bg = GetComponent<Image>();
        bg.color = fadeColor;

        if (myCanvas && bg)
        {
            myCanvas.alpha = 0.0f;
            StartCoroutine(FadeIt());
        }
        else
        {
            Debug.LogWarning("Something is missing. Please reimport the package.");
        }
    }

    IEnumerator FadeIt()
    {
        while (!start)
        {
            yield return null;
        }

        lastTime = Time.time;
        float coDelta;
        bool hasFadedIn = false;

        while (!hasFadedIn)
        {
            coDelta = Time.time - lastTime;

            if (!isFadeIn)
            {
                // Fade out
                alpha = newAlpha(coDelta, 1, alpha);

                if (alpha == 1 && !startedLoading)
                {
                    startedLoading = true;
                    Debug.Log("Next Scene: " + fadeScene);
                    SceneManager.LoadScene(fadeScene);
                }
            }
            else
            {
                // Fade in
                alpha = newAlpha(coDelta, 0, alpha);

                if (alpha == 0)
                {
                    hasFadedIn = true;
                }
            }

            lastTime = Time.time;
            myCanvas.alpha = alpha;
            yield return null;
        }

        // Reset the fading flag
        Initiate.DoneFading();

        // Destroy the Fader object after fading is complete
        Destroy(gameObject);
    }

    float newAlpha(float delta, int to, float currAlpha)
    {
        switch (to)
        {
            case 0:
                currAlpha -= fadeDamp * delta;
                if (currAlpha <= 0)
                    currAlpha = 0;
                break;
            case 1:
                currAlpha += fadeDamp * delta;
                if (currAlpha >= 1)
                    currAlpha = 1;
                break;
        }
        return currAlpha;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIt());
        isFadeIn = true;
    }
}
