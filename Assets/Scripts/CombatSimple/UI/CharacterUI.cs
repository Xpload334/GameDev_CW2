﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CombatSimple.UI
{
    public class CharacterUI : MonoBehaviour
    {
        public CombatManagerSimple combatManagerSimple;
        public Image portraitImage;
        
        public TMP_Text healthText;
        public Slider healthSlider;
        public TMP_Text actionPointsText;
        public Slider actionSlider;

        private float _currentHealth;
        public float maxHealth;

        private float _currentActionPoints;
        public float maxActionPoints;

        public void UpdateHealth(float newValue)
        {
            _currentHealth = newValue;
            healthText.text = (_currentHealth + " / " + maxHealth);
            //Normalise value
            healthSlider.value = (_currentHealth / maxHealth);
        }
        
        public void UpdateActionPoints(float newValue)
        {
            _currentActionPoints = newValue;
            actionPointsText.text = (_currentActionPoints + " / " + maxActionPoints);
            //Normalise value
            actionSlider.value = (_currentActionPoints / maxActionPoints);
        }

    }
}