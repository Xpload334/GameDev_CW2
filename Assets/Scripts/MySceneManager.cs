using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour
{
    private static MySceneManager _instance;
    public ScreenFade screenFade;

    // public string currentScene;
    public int currentSceneIndex;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // currentScene = SceneManager.GetActiveScene().name;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        screenFade = GetComponent<ScreenFade>();
        if (!screenFade.isLoading)
        {
            screenFade.StartFadeFromBlack();
        }
    }

    public void FadeFromBlack()
    {
        screenFade.StartFadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TitleScreen()
    {
        Debug.Log("Switching to title screen");
        FindObjectOfType<PlayerPathManager>().ResetPrefs();
        screenFade.StartFadeToBlack(() => LoadScene(0));
        
    }
    public void WolfBattle()
    {
        Debug.Log("Loading wolf battle");
        screenFade.StartFadeToBlack(() => LoadScene(1));
    }
    
    public void GoblinBattle()
    {
        Debug.Log("Loading goblin battle");
        screenFade.StartFadeToBlack(() => LoadScene(2));
    }
    
    public void WizardBattle()
    {
        Debug.Log("Loading wizard battle");
        screenFade.StartFadeToBlack(() => LoadScene(3));
    }

    public void RestartCurrentScene()
    {
        Debug.Log("Restarting scene");
        screenFade.StartFadeToBlack(() => LoadScene(currentSceneIndex));
        // throw new NotImplementedException();
    }

    // public void LoadScene(string sceneName)
    // {
    //     currentScene = sceneName;
    //     SceneManager.LoadScene(currentScene);
    // }

    public void LoadScene(int sceneIndex)
    {
        currentSceneIndex = sceneIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
