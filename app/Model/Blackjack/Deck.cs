﻿using System;
using System.Collections.Generic;

/// <summary>
/// Defines the collection of cards 
/// (Requirement 1.2.2)
/// </summary>
namespace CasinoSimulation.Model.Blackjack
{
    public class Deck
    {
        private List<Card> _cards;
        private int _top;
        private int _numDecks;

        public Deck(int numDecks)
        {
            _cards = new List<Card>();
            _numDecks = numDecks;
            for (int i = 0; i < numDecks; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        Card NewCard = new Card((cardRank)j, (cardSuit)k);
                        _cards.Add(NewCard);
                    }
                }
            }
            _top = 0;
            Shuffle();
        }

        //Shuffles careds
        //(Requirement 3.2.2.1)
        public void Shuffle()
        {
            if (_top < _numDecks * 13)
            {
                Random r = new Random();
                for (int i = _numDecks * 52 - 1; i > 0; i--)
                {
                    int RandomIndex = r.Next(i);
                    Card TempCard = _cards[i];
                    _cards[i] = _cards[RandomIndex];
                    _cards[RandomIndex] = TempCard;
                }
                _top = _cards.Count - 1;
            }
            /********************************************************************
             * 
             * Testing mode:
             *
            for(int i = 0; i < _cards.Count; i++)
            {
               _cards[i] = new Card(cardRank.Ace, cardSuit.Spades);
            }
             * 
             * Known Bugs:
             * 
             * Test cases:
             * 
             * 1. both have blackjack:
             *
             _cards[_cards.Count - 1] = new Card(cardRank.Ace, cardSuit.Spades);
             _cards[_cards.Count - 2] = new Card(cardRank.Ace, cardSuit.Spades);
             _cards[_cards.Count - 3] = new Card(cardRank.Ten, cardSuit.Spades);
             _cards[_cards.Count - 4] = new Card(cardRank.Ten, cardSuit.Spades);
             * 
             * 2. player has blackjack, dealer does not:
             *
            _cards[_cards.Count - 1] = new Card(cardRank.Ace, cardSuit.Spades);
            _cards[_cards.Count - 2] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 3] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 4] = new Card(cardRank.Ten, cardSuit.Spades);
             *
             * 3. Split Aces and first one gets blackjack
             *       
            _cards[_cards.Count - 1] = new Card(cardRank.Ace, cardSuit.Spades);
            _cards[_cards.Count - 2] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 3] = new Card(cardRank.Ace, cardSuit.Spades);
            _cards[_cards.Count - 4] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 5] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 6] = new Card(cardRank.Ten, cardSuit.Spades);
            * 
            * 4. Dealer hitting on soft 17
            *
            _cards[_cards.Count - 1] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 2] = new Card(cardRank.Ace, cardSuit.Spades);
            _cards[_cards.Count - 3] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 4] = new Card(cardRank.Six, cardSuit.Spades);
            *
            * 5. Dealer standing on hard 17
            *
            _cards[_cards.Count - 1] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 2] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 3] = new Card(cardRank.Ten, cardSuit.Spades);
            _cards[_cards.Count - 4] = new Card(cardRank.Six, cardSuit.Spades);
            _cards[_cards.Count - 5] = new Card(cardRank.Ace, cardSuit.Spades);
            * 
            *******************************************************************/
        }
        //Distributes one card from the top
        //(Requirement 1.2.2)
        public Card DealTopCard()
        {
            return _cards[_top--];
        }
    }
}
