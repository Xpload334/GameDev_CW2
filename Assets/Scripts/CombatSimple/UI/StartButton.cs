using UnityEngine;
using UnityEngine.SceneManagement;

namespace CombatSimple.UI
{
    public class StartButton : MonoBehaviour
    {
        public void StartGame()
        {
            FindObjectOfType<MySceneManager>().WolfBattle();
        }
    }
}