using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    [SerializeField] private GameObject cardPos;
    [SerializeField] private Image cardImage;
    [SerializeField] private TMP_Text cardName;

    public Card card;

    public void SetUp(Card card)
    {
        this.card = card;

        cardImage.sprite = this.card.cardImage;
        cardName.text = this.card.cardName;
    }
}
