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
        shouldRequeue = false;
        //On creation
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
            NextState(); //Note: StateUpdate() will not fire again once NextState() is triggered 
        }
    }

    public void ExitState()
    {
        isRunning = false;
    }
}
