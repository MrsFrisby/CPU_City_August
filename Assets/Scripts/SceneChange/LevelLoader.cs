using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string nextSceneName;
    public Color loadToColor = Color.black;
    public int missionIdtoChangeScenes;

    public bool automaticChange;

    private bool inputFlag = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (inputFlag && Input.GetKeyDown(KeyCode.E) && !automaticChange && GameManager.Instance.currentQuestIndex == missionIdtoChangeScenes)
        {
            Initiate.Fade(nextSceneName, loadToColor, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LevelExit")
        {
            //int sceneNum = SceneManager.GetActiveScene().buildIndex + 1;

            inputFlag = true;
            if(automaticChange && GameManager.Instance.currentQuestIndex == missionIdtoChangeScenes)
            {
                Initiate.Fade(nextSceneName, loadToColor, 0.5f);
            }

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Debug.Log("Loading Next Scene");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LevelExit")
        {
            //int sceneNum = SceneManager.GetActiveScene().buildIndex + 1;

            inputFlag = false;


            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Debug.Log("Loading Next Scene");
        }
    }
}
