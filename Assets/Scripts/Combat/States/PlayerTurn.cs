using Unity.VisualScripting;

/*
 * Wait for player to make an action
 *
 * Requeue state until turn ended
 */
public class PlayerTurn : CombatState, ICombatState
{
    public PlayerTurn()
    {
        priority = combatManager.PriorityDefault;
    }
    public void EnterState()
    {
        isRunning = true;
        //Enable card selection in UI
        combatManager.SetPlayerCardsActive(true);
    }

    /*
     * Call when a card is selected
     */
    public void CardPlayed(CardUI cardUI)
    {
        //Animate chosen card moving out
        
        //Add playercard state to queue
        // combatManager.EnqueueState(new PlayerCardState(cardUI.card, cardUI.isSide1), combatManager.PriorityCard);
        //Requeue this state, next state
        NextState(true);
    }

    /*
     * Call when end turn button pressed
     */
    public void EndTurn()
    {
        //Don't requeue this state
        NextState(false);
    }

    public void StateUpdate()
    {
        //Nothing
    }

    public void ExitState()
    {
        isRunning = false;
        combatManager.SetPlayerCardsActive(false);
    }
}
