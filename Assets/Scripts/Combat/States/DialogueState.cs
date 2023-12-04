using Unity.VisualScripting;

/*
 * Give player cards
 * Give enemy cards
 *
 * Run animations for giving cards
 */
public class DialogueState : CombatState, ICombatState
{
    public DialogueState(string text)
    {
        //On creation
        priority = combatManager.PriorityDialogue;
    }
    public void EnterState()
    {
        isRunning = true;
        //Open dialogue box
        //Replace with text
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
