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
    public PriorityQueue<CombatState, int> stateQueue = new PriorityQueue<CombatState, int>();
    // public Stack<CombatState> stateStack = new Stack<CombatState>();

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
    
    


}
