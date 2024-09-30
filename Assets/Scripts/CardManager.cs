using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    private GameManager GM;

    [SerializeField] private CardSO cardSO;
    [SerializeField] private GameObject rightHandCard;
    [SerializeField] private GameObject leftHandCard;
    [SerializeField] private GameObject cardDeck_1;
    [SerializeField] private GameObject cardDeck_2;
    [SerializeField] private GameObject cardDeck_3;
    
    private List<Card> cardBuffer;
    
    void Start()
    {
        GM = GameManager.Instance;

        SetUpCardBuffer();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            showCard();
        }
    }

    private void SetUpCardBuffer()
    {
        cardBuffer = new List<Card>();

        for (int i = 0; i < cardSO.cards.Length; i++)
        {
            Card card = cardSO.cards[i];

            for (int j = 0; j < card.probability; j++)
            {
                cardBuffer.Add(card);
            }
        }

        for (int i = 0; i < cardBuffer.Count; i++)
        {
            int rand = Random.Range(i, cardBuffer.Count);
            Card tempCard = cardBuffer[i];
            cardBuffer[i] = cardBuffer[rand];
            cardBuffer[rand] = tempCard;
        }
    }

    private Card PopCard()
    {
        if (cardBuffer.Count == 0)
        {
            SetUpCardBuffer();
        }

        Card card = cardBuffer[0];
        cardBuffer.RemoveAt(0);
        return card;
    }

    private void showCard()
    {
        var rightCard = rightHandCard.GetComponent<CardInfo>();
        rightCard.SetUp(PopCard());

        var leftCard = leftHandCard.GetComponent<CardInfo>();
        leftCard.SetUp(PopCard());
        
        var deckNum1 = cardDeck_1.GetComponent<CardInfo>();
        deckNum1.SetUp(PopCard());
        
        var deckNum2 = cardDeck_2.GetComponent<CardInfo>();
        deckNum2.SetUp(PopCard());
        
        var deckNum3 = cardDeck_3.GetComponent<CardInfo>();
        deckNum3.SetUp(PopCard());
    }
}
