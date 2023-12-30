using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour
{
    public GameObject cardUIInstance;
    public List<CardUI> cards;
    public CombatManager combatManager;
    
    // Start is called before the first frame update
    void Start()
    {
        combatManager = FindObjectOfType<CombatManager>();
        AddAllChildren(); //test
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAllChildren()
    {
        foreach (Transform child in this.transform)
        {
            if (child.TryGetComponent(out CardUI cardUI))
            {
                cards.Add(cardUI);
                cardUI.combatManager = this.combatManager;
            }
        }
    }

    public void FlipAll()
    {
        Debug.Log("Flipping all");
        foreach (var cardUI in cards)
        {
            cardUI.FlipCard();
        }
    }

    public void AddCard(Card card)
    {
        
    }

    public void PlayCard(CardUI cardUI)
    {
        
    }
}
