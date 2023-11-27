/*
     * Serialise to make a list of card effects,
     * so you can stack multiple effects on a single side
     */
[System.Serializable]
public class CardEffect
{
    public CardStatType statType;
    public int statInt;
}