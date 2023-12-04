using Unity.VisualScripting;

/*
 * Give player cards
 * Give enemy cards
 *
 * Run animations for giving cards
 */
public class StartState : CombatState, ICombatState
{
    public StartState()
    {
        shouldRequeue = true;
    }
    public void EnterState()
    {
        isRunning = true;
        combatManager.SetupDecks();
        
        //if current battle is a tutorial, enqueue tutorial states
    }

    public void StateUpdate()
    {
        // Wait for animations to finish
        if (true)
        {
            NextState(); //Note: StateUpdate() will not fire again once NextState() is triggered 
        }
    }

    public void ExitState()
    {
        isRunning = false;
    }
}
