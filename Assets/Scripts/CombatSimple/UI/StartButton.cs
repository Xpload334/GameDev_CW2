using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CombatSimple.UI
{
    public class StartButton : MonoBehaviour
    {
        private void Start()
        {
            foreach (var obj in FindObjectsOfType<MySceneManager>())
            {
                try
                {
                    obj.FadeFromBlack();
                }
                catch
                {
                    //None
                }
            }
        }

        public void StartGame()
        {
            FindObjectOfType<MySceneManager>().WolfBattle();
        }
    }
}