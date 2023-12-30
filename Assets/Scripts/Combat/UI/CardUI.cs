
/*
 * Attach to cardUI prefab
 */

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private CardUIAnimationController animationController;
    public CombatManager combatManager;
    
    public Card card; //Use to pull stats
    public bool isSide1 = true;
    public Button button;
    
    [Header("Side 1")]
    public TMP_Text energyCostText1;
    public Image cardImage1;
    public TMP_Text description1;
    
    [Header("Side 1")]
    public TMP_Text energyCostText2;
    public Image cardImage2;
    public TMP_Text description2;
    
    public bool FlipCard()
    {
        // if (card.isDoubleSided) return isSide1;
        
        //Flip side
        isSide1 = !isSide1;

        if (isSide1)
        {
            animationController.StartFlipSide1();
        }
        else
        {
            animationController.StartFlipSide2();
        }
        return isSide1;
    }
    
    public string ConstructDescription(List<CardEffect> cardEffects)
    {
        return "";
    }

    public void CardPressed()
    {
        Debug.Log("Card pressed");
        // if (!combatManager.playerDeck.cardsInHand.Contains(card)) return;
        
        
        // Debug.Log("Playing card");
        // combatManager.playerDeck.PlayCard(card, isSide1);
    }

    
}
