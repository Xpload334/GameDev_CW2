using System;
using UnityEngine;

public abstract class CombatState: MonoBehaviour
{
    protected CombatManager combatManager;
    public bool isEnded;

    protected CombatState(CombatManager combatManager)
    {
        this.combatManager = combatManager;
    }


    public abstract void OnStateEnter();

    public abstract void OnStateUpdate();
    
    public abstract void OnStateExit();
}