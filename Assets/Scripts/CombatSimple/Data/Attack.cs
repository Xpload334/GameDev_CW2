using UnityEngine;

namespace CombatSimple
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Attack", order = 0)]
    public class Attack : ScriptableObject
    {
        public DamageType damageType;
        public int damageMax = 10;
        public int damageNormal = 5;
        public int damageMin = 2;
        public Dialogue dialogue;
        [Header("Attack Conditions")] 
        public int minActionPoints = 0;
        public int maxActionPoints = 100;

        public int GetDamage(DamageType opposingDamageType)
        {
            switch (damageType)
            {
                case DamageType.Rock when opposingDamageType == DamageType.Scissors:
                    return damageMax;
                case DamageType.Scissors when opposingDamageType == DamageType.Paper:
                    return damageMax;
                case DamageType.Paper when opposingDamageType == DamageType.Rock:
                    return damageMax;
                case DamageType.Rock when opposingDamageType == DamageType.Paper:
                    return damageMin;
                case DamageType.Scissors when opposingDamageType == DamageType.Rock:
                    return damageMin;
                case DamageType.Paper when opposingDamageType == DamageType.Scissors:
                    return damageMin;
                default:
                    return damageNormal;
            }
        }

    }
}