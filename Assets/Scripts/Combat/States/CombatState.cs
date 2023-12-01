using System;
using UnityEngine;

public class CombatState: MonoBehaviour
{
    protected CombatManager combatManager;
    public bool isRunning;

    protected CombatState(CombatManager combatManager)
    {
        this.combatManager = combatManager;
    }
    
    public void OnStateEnter()
    {
        isRunning = true;
    }

    public virtual void OnStateUpdate()
    {
        // throw new NotImplementedException();
    }

    public void OnStateExit()
    {
        isRunning = false;
    }
}