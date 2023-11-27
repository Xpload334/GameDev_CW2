public enum CardStatType
{
    //Remove enemy HP by X
    Damage,
    //Increase enemy FP by X
    Friend,
    //Increase player HP by X
    Heal,
    //Give player X shield for this turn
    Shield,
    
    //Give X player cards from pile
    DrawCards,

    //Gain X energy next turn
    GainEnergyNextTurn,
    //Reveal enemy cards
    SeeEnemyCards,
    //Remove X enemy energy
    EnergyDrain,
    //Dodge next attack
    Dodge,
    //Extra attack damage whenever you attack
    ExtraDamage,
    //Reduce all damage by X
    ReduceDamage
}