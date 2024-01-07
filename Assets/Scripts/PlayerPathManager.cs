using System;
using CombatSimple;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerPathManager : MonoBehaviour
    {
        private static PlayerPathManager _instance;
        public int battleNum = 0;
        public bool wolfBefriended;
        public bool goblinBefriended; //0 or 1

        [Header("Stats Holder")] 
        public CharacterStats WolfStats;

        public CharacterStats GoblinStats_WolfAct;
        public CharacterStats GoblinStats_WolfAttack;
        
        public CharacterStats WizardStats_AllAct;
        public CharacterStats WizardStats_Goblin;
        public CharacterStats WizardStats_Wolf;
        public CharacterStats WizardStats_AllAttack;
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
            battleNum = 0;
            wolfBefriended = false;
            goblinBefriended = false;
        }

        public void SetWolfBefriended()
        {
            wolfBefriended = true;
            // PlayerPrefs.SetInt(prefWolfBefriended, 1);
        }
        public void SetGoblinBefriended()
        {
            goblinBefriended = true;
            // PlayerPrefs.SetInt(prefGoblinBefriended, 1);
        }
    }
}