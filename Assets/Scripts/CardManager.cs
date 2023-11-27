using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 * Class to keep track of cards per player.
 * Relay all card effects to the combat manager.
 */
public class CardManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>(); //List of all cards
    public List<Card> cardsInHand = new List<Card>(); //Cards in the entity's hand
    public List<Card> discardPile = new List<Card>(); //Cards go here after they are played
    /*
     * All cards waiting to be drawn.
     * When empty, shuffle all cards from discard pile into draw pile
     */
    public List<Card> drawPile = new List<Card>();
    
    // private void Start()
    // {
    //     throw new NotImplementedException();
    // }

    /*
     * Draw a random card from your draw pile.
     * If there are no cards in the draw pile, reset it.
     *
     * Returns card, should there be any effects from the card being drawn
     */
    public Card DrawCard()
    {
        Card card = null;
        //Check if there are cards in draw pile
        int cardsInDrawPile = drawPile.Count;
        if (cardsInDrawPile <= 0)
        {
            ResetCardPiles();
        }

        //Get random card from your draw pile (simulating shuffle)
        int i = Random.Range(0, cardsInDrawPile - 1);
        card = drawPile[i];
        Debug.Log("Card drawn: "+card.ToString());
        
        //Add card to hand
        cardsInHand.Add(card);
        return card;
    }

    public void PlayCard(Card card, bool isBackSide)
    {
        //Check if card exists in hand
        if (cardsInHand.Contains(card))
        {
            //Play card effect
            PlayCardEffects(card, isBackSide);

            //Remove card from hand
            cardsInHand.Remove(card);
            
            //Add card to discard pile
            discardPile.Add(card);
        }
        else
        {
            throw new NullReferenceException("Card "+card.ToString()+" not found in hand.");
        }
    }

    /*
     * Put all cards from discard pile into draw pile
     */
    void ResetCardPiles()
    {
        drawPile = discardPile;
        discardPile = new List<Card>();
    }


    /**
     * Play the effects of a given card
     */
    void PlayCardEffects(Card card, bool isBackSide)
    {
        //Access combat manager
        //Remove card energy
        int energy = card.energyCost;
        
        //Select correct card side
        var effects = isBackSide ? card.stats2 : card.stats1;
        
        //Play each card effect
        foreach (var varCardEffect in effects)
        {
            //combatManager.TargetEnemy(cardeffect)
        }
        
    }
    
    
}