using System;
using UnityEngine;

namespace CombatSimple.UI
{
    public class PlayerMenuUI : MonoBehaviour
    {
        public CombatManagerSimple combatManagerSimple;
        private void Start()
        {
            combatManagerSimple = FindObjectOfType<CombatManagerSimple>();
        }


        public void EnableUI()
        {
            gameObject.SetActive(true);
        }

        public void DisableUI()
        {
            gameObject.SetActive(false);
        }


        public void PlayerAttack(Attack attack)
        {
            combatManagerSimple.PlayerAttacksEnemy(attack);
        }

        public void ActCheck()
        {
            PlayerAction(ActType.Check);
        }

        public void ActOffer()
        {
            PlayerAction(ActType.Offer);
        }
        
        public void ActConversation()
        {
            PlayerAction(ActType.Conversation);
        }
        
        public void ActFlatter()
        {
            PlayerAction(ActType.Flatter);
        }
        
        public void ActTouch()
        {
            PlayerAction(ActType.Touch);
        }

        public void PlayerAction(ActType actType)
        {
            combatManagerSimple.ActPlayer(actType);
        }
    }
}