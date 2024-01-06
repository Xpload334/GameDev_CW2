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
        screenFade = GetComponent<ScreenFade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TitleScreen()
    {
        
        SceneManager.LoadScene("Scenes/Title");
    }
    public void WolfBattle()
    {
        SceneManager.LoadScene("Scenes/");
    }
}
