using System;
using Unity.VisualScripting;
using UnityEngine;

public class CombatState: MonoBehaviour
{
    protected int priority;
    protected CombatManager combatManager;
    public bool isRunning; //If the state is currently running

    public CombatState(CombatManager combatManager)
    {
        this.combatManager = combatManager;
    }
    protected CombatState()
    {
        combatManager = FindObjectOfType<CombatManager>();
    }
    
    /*
     * Move to the next state.
     * Calls ExitState on this state and EnterState on the next state.
     *
     * Requeue this state into the queue if requeue = true, at the given priority
     */
    public void NextState(bool requeue)
    {
        combatManager.NextState(requeue, priority);
    }
}