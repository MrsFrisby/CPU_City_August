using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string nextSceneName;
    public Color loadToColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LevelExit")
        {
            //int sceneNum = SceneManager.GetActiveScene().buildIndex + 1;
            Initiate.Fade(nextSceneName, loadToColor, 0.5f);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Debug.Log("Loading Next Scene");
        }
    }
}
