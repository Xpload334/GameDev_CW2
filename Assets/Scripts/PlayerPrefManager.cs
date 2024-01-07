using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerPrefManager : MonoBehaviour
    {
        public int wolfBefriended; //0 or 1
        public static string prefWolfBefriended = "wolfBefriended";
        public int goblinBefriended; //0 or 1
        public static string prefGoblinBefriended = "goblinBefriended";
        private void Start()
        {
            wolfBefriended = PlayerPrefs.GetInt(prefWolfBefriended);
            goblinBefriended = PlayerPrefs.GetInt(prefGoblinBefriended);
        }

        /*
         * Call on pressing start game button
         */
        public void ResetPrefs()
        {
            PlayerPrefs.SetInt(prefWolfBefriended, 0);
            PlayerPrefs.SetInt(prefGoblinBefriended, 0);
        }

        public void SetWolfBefriended()
        {
            PlayerPrefs.SetInt(prefWolfBefriended, 1);
        }
        public void SetGoblinBefriended()
        {
            PlayerPrefs.SetInt(prefGoblinBefriended, 1);
        }
    }
}