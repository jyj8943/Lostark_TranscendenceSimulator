using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;     // 카드 텍스트
    public Sprite cardImage;    // 카드 이미지
    public float probability;   // 드로우 될 확률
}

[CreateAssetMenu(fileName = "CardSO", menuName = "Scriptable Object/ItemSO")]
public class CardSO : ScriptableObject
{
    public Card[] cards;
}