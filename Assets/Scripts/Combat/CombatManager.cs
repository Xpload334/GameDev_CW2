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
    private ICombatState currentState;
    private PriorityQueue<ICombatState, int> stateQueue = new PriorityQueue<ICombatState, int>();
    
    public readonly int PriorityDefault = 0;
    public readonly int PriorityCard = 1;
    public readonly int PriorityDialogue = 2;
    public readonly int PriorityBattleResult = 3;

    public int turnNumber = 0;          //Current turn
    public CardManager playerDeck;      //Card manager for player
    public int playerStartEnergy = 1;   //Energy on turn 1
    public int playerEnergy;            //Energy on this turn
    public int playerMaxEnergy = 1;     //Max energy, increases each turn
    public int playerStartCards = 6;    //Number of cards to draw on turn 1
    public CardManager enemyDeck;
    public int enemyStartEnergy = 1;
    public int enemyEnergy;
    public int enemyMaxEnergy = 1;
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
        /*
         * Call state update
         */
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
    public void NextState(bool enqueue, int priority)
    {
        //Exit current state
        currentState.ExitState();
        if (enqueue)
        {
            stateQueue.Enqueue(currentState, priority);
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
        EnqueueState(new DialogueState(text), PriorityDialogue);
    }

    public void PlayerDrawCard()
    {
        playerDeck.DrawCard();
    }

    public void EnemyDrawCard()
    {
        enemyDeck.DrawCard();
    }

    public void SetPlayerCardsActive(bool isActive)
    {
        
    }

    public void LogStateQueue()
    {
        Debug.Log(stateQueue.ToString());
    }
    
    
}
