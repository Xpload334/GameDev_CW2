using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CombatSimple.UI
{
    public class QuitButton : MonoBehaviour
    {

        public void QuitGame()
        {
            FindObjectOfType<MySceneManager>().QuitGame();
        }
    }
}