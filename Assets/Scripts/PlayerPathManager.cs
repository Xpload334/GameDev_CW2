using System;
using CombatSimple;
using UnityEngine;

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
            // wolfBefriended = PlayerPrefs.GetInt(prefWolfBefriended);
            // goblinBefriended = PlayerPrefs.GetInt(prefGoblinBefriended);
        }
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

        /*
         * Call on pressing start game button
         */
        public void ResetPrefs()
        {
            // battleNum = 0;
            wolfBefriended = false;
            goblinBefriended = false;
        }

        public void SetWolfBefriended(bool state)
        {
            wolfBefriended = state;
            // PlayerPrefs.SetInt(prefWolfBefriended, 1);
        }
        public void SetGoblinBefriended(bool state)
        {
            goblinBefriended = state;
            // PlayerPrefs.SetInt(prefGoblinBefriended, 1);
        }
    }
}