using System;
using Unity.VisualScripting;
using UnityEngine;

public class CombatState: MonoBehaviour
{
    protected CombatManager combatManager;
    public bool isRunning; //If the state is currently running
    public bool shouldRequeue; //If the state should be queued at the end of the loop once it finishes
    
    public CombatState(CombatManager combatManager)
    {
        this.combatManager = combatManager;
    }
    protected CombatState()
    {
        combatManager = FindObjectOfType<CombatManager>();
    }

    public void NextState()
    {
        combatManager.NextState(shouldRequeue);
    }
}