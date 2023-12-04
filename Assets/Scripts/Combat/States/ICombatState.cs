public interface ICombatState
{
    /*
     * Call when a given state is entered
     */
    public void EnterState();
    /*
     * Call every tick
     */
    public void StateUpdate();
    /**
     * Call when a given state is exited
     */
    public void ExitState();
}