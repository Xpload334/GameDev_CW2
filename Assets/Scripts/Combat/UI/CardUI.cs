
/*
 * Attach to cardUI prefab
 */

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    private CardUIAnimationController _animationController;
    
    public Card card; //Use to pull stats
    public bool isSide1 = true;
    
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
        if (card.isDoubleSided) return isSide1;
        
        //Flip side
        isSide1 = !isSide1;

        return isSide1;
    }
    
    public string ConstructDescription(List<CardEffect> cardEffects)
    {
        return "";
    }

    public void CardPressed()
    {
        Debug.Log("Card pressed: "+card.name1);
    }
}
