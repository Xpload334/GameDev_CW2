using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Card", order = 2)]
public class Card : ScriptableObject
{
    public bool isDoubleSided = true;
    public int energyCost = 2; //Resource cost to play the card
    [Header("Side 1")]
    public string name1;
    public Sprite sprite1;
    public List<CardEffect> stats1;
    // public CardStatType cardType1;
    // public int stat1;
    
    [Header("Side 2")]
    public string name2;
    public Sprite sprite2;
    public List<CardEffect> stats2;
    // public CardStatType cardType2;
    // public int stat2;

    public override string ToString()
    {
        return name1 + "/" + name2;
    }
    
}
