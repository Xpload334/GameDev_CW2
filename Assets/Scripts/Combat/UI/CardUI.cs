
/*
 * Attach to cardUI prefab
 */

using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class CardUI
{
    public Card card; //Use to pull stats
    public bool isSide1 = true;
    
    public TMP_Text energyCostText;
    public Image cardImage;
    public TMP_Text description;


    public void ConstructCardUI(Card card)
    {
        this.card = card;

        //Build card UI from cardstats
        energyCostText.text = card.energyCost.ToString();
        
    }

    public bool FlipCard()
    {
        if (card.isDoubleSided) return isSide1;
        
        //Flip side
        isSide1 = !isSide1;

        return isSide1;
    }

    public void ShowCardSide()
    {
        string description = "";
        if (isSide1)
        {
            description = ConstructDescription(card.stats1);
            cardImage.sprite = card.sprite1;
        }
        else
        {
            description = ConstructDescription(card.stats2);
            cardImage.sprite = card.sprite2;
        }
    }

    public string ConstructDescription(List<CardEffect> cardEffects)
    {
        return "";
    }


}
