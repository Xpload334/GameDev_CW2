using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
// using Utils.PriorityQueue<>;

public class CombatManager : MonoBehaviour
{
    /*
     * Basic state loop (priority 1):
     * PlayerTurnStart
     * PlayerTurn (waiting for input)
     * PlayerTurnEnd
     *
     * EnemyTurnStart
     * EnemyTurn
     * EnemyTurnEnd
     *
     * Other states: (priority 2)
     * PlayerCard (card animation)
     * EnemyCard (card animation)
     * BattleLose
     * BattleWinCombat
     * BattleWinFriendship
     */
    
    //Use ints for priorities
    public ICombatState currentState;
    public PriorityQueue<ICombatState, int> stateQueue = new PriorityQueue<ICombatState, int>();
    // public Stack<CombatState> stateStack = new Stack<CombatState>();
    public static int PRIORITY_DEFAULT = 0;
    public static int PRIORITY_DIALOGUE = 1;
    
    public CardManager playerDeck;
    public int playerStartEnergy = 2;
    public int playerStartCards = 6;
    public CardManager enemyDeck;
    public int enemyStartEnergy;
    public int enemyStartCards = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        //Queue up state loop
        // stateQueue.Enqueue();
        //Enter battle start state
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.StateUpdate();
        }
    }
    
    public void SetupDecks()
    {
        SetupDecks(6, 2, 6, 2);
    }

    public void SetupDecks(int playerStartCards, int playerStartEnergy, int enemyStartCards, int enemyStartEnergy)
    {
        this.playerStartCards = playerStartCards;
        this.playerStartEnergy = playerStartEnergy;
        this.enemyStartCards = enemyStartCards;
        this.enemyStartEnergy = enemyStartEnergy;
    }
    
    /**
     * Allow players to choose cards
     */
    public void EnablePlayerCards()
    {
        
    }

    public void DisablePlayerCards()
    {
        
    }

    public void PlayCardIndex(int i)
    {
        
    }
    
    
    public void SetupStates()
    {
        
    }

    /**
     * Exit the current state and enqueue the next state
     */
    public void NextState(bool enqueue)
    {
        //Exit current state
        currentState.ExitState();
        if (enqueue)
        {
            stateQueue.Enqueue(currentState, 1);
        }
        
        //Enter next state
        currentState = stateQueue.Dequeue();
        currentState.EnterState();
    }

    public void EnqueueState(ICombatState state, int priority)
    {
        stateQueue.Enqueue(state, priority);
    }

    public void AddDialogue(string text)
    {
        EnqueueState(new DialogueState(text), PRIORITY_DIALOGUE);
    }
    
}
