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
    GainCards,
    //Discord X random enemy cards
    DiscardEnemyCards,
    
    //Gain X energy next turn
    GainEnergyNextTurn,
    //Reveal X enemy cards
    SeeEnemyCards,
    //Remove X enemy energy
    
    //Dodge next attack
    Dodge,
    //Extra attack damage whenever you attack
    ExtraDamage,
    //Reduce all damage by X
    ReduceDamage
}