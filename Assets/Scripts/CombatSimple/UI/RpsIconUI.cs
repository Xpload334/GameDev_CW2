using System;
using UnityEngine;
using UnityEngine.UI;

namespace CombatSimple.UI
{
    public class RpsIconUI : MonoBehaviour
    {
        public Image rpsIcon;

        public Sprite spriteBlank;
        public Sprite spriteRock;
        public Sprite spritePaper;
        public Sprite spriteScissors;

        public void ChangeDamageType(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.None:
                    rpsIcon.sprite = spriteBlank;
                    break;
                case DamageType.Rock:
                    rpsIcon.sprite = spritePaper;
                    break;
                case DamageType.Paper:
                    rpsIcon.sprite = spritePaper;
                    break;
                case DamageType.Scissors:
                    rpsIcon.sprite = spriteScissors;
                    break;
            }
        }
    }
}