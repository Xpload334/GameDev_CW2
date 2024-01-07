using System;
using CombatSimple;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class PlayerPathManager : MonoBehaviour
    {
        private static PlayerPathManager _instance;
        // public int battleNum = 0;
        public bool wolfBefriended;
        public bool goblinBefriended;

        [Header("Stats Holder")] 
        public CharacterStats WolfStats;

        public CharacterStats GoblinStatsWolfAct;
        public CharacterStats GoblinStatsWolfAttack;
        
        public CharacterStats WizardStatsAllAct;
        public CharacterStats WizardStatsGoblinAct;
        public CharacterStats WizardStatsWolfAct;
        public CharacterStats WizardStatsAllAttack;
        private void Start()
        {
            wolfBefriended = PlayerPrefs.GetInt("wolf") == 1;
            goblinBefriended = PlayerPrefs.GetInt("goblin") == 1;
        }
        // private void Awake()
        // {
        //     if (_instance == null)
        //     {
        //         _instance = this;
        //         DontDestroyOnLoad(gameObject);
        //     }
        //     else
        //     {
        //         Destroy(gameObject);
        //     }
        // }

        /*
         * Call on pressing start game button
         */
        public void ResetPrefs()
        {
            // battleNum = 0;
            SetWolfBefriended(false);
            SetGoblinBefriended(false);
            // wolfBefriended = false;
            // goblinBefriended = false;
            //
            // PlayerPrefs.SetInt("wolf", 0);
            // PlayerPrefs.SetInt("goblin", 0);
        }

        public void SetWolfBefriended(bool state)
        {
            wolfBefriended = state;
            PlayerPrefs.SetInt("wolf", state ? 1 : 0);
        }
        public void SetGoblinBefriended(bool state)
        {
            goblinBefriended = state;
            PlayerPrefs.SetInt("goblin", state ? 1 : 0);
        }

        public bool GetWolfBefriended()
        {
            return PlayerPrefs.GetInt("wolf") == 1;
        }
        public bool GetGoblinBefriended()
        {
            return PlayerPrefs.GetInt("goblin") == 1;
        }
    }
}