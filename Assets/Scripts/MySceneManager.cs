using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour
{
    private static MySceneManager _instance;
    public ScreenFade screenFade;

    public string currentScene;

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
        currentScene = SceneManager.GetActiveScene().name;
        
        screenFade = GetComponent<ScreenFade>();
        screenFade.StartFadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TitleScreen()
    {
        Debug.Log("Switching to title screen");
        screenFade.StartFadeToBlack(() => SceneManager.LoadScene("Scenes/Title"));
        
    }
    public void WolfBattle()
    {
        Debug.Log("Loading wolf battle");
        screenFade.StartFadeToBlack(() => SceneManager.LoadScene("Scenes/Combat 1"));
    }
    
    public void GoblinBattle()
    {
        Debug.Log("Loading goblin battle");
        screenFade.StartFadeToBlack(() => SceneManager.LoadScene("Scenes/Combat 2"));
    }
    
    public void WizardBattle()
    {
        Debug.Log("Loading wizard battle");
        screenFade.StartFadeToBlack(() => SceneManager.LoadScene("Scenes/Combat 3"));
    }

    public void RestartCurrentScene()
    {
        Debug.Log("Restarting scene");
        screenFade.StartFadeToBlack(() => SceneManager.LoadScene(currentScene));
        // throw new NotImplementedException();
    }
}
