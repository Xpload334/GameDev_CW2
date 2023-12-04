using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Deck", order = 2)]
public class Deck : ScriptableObject
{
    public List<Card> cards;
    public int handSize = 5;
    public int energyStart = 2;
}
