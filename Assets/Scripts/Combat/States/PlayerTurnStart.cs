using Unity.VisualScripting;

/*
 * Refill player energy
 * Draw player card
 *
 *
 * (Drain energy from energy drain effects)
 */
public class PlayerTurnStart : CombatState, ICombatState
{
    public PlayerTurnStart()
    {
        priority = combatManager.PriorityDefault;
    }
    public void EnterState()
    {
        isRunning = true;
        
        //Set max energy
        combatManager.playerMaxEnergy = combatManager.playerStartEnergy + combatManager.turnNumber;
        combatManager.playerEnergy = combatManager.playerMaxEnergy;
        
        if(combatManager.turnNumber != 0) combatManager.PlayerDrawCard();
    }

    public void StateUpdate()
    {
        // Wait for animations to finish
        if (true)
        {
            NextState(false); //Note: StateUpdate() will not fire again once NextState() is triggered 
        }
    }

    public void ExitState()
    {
        isRunning = false;
    }
}
