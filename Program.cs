using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void listPrint(List<Card> lst)
        {
            Console.Write("<");
            for(int i = 0; i < lst.Count; i++)
            {
                Console.Write(lst[i]);
                if(i < lst.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(">");
        }
        static void Main(string[] args)
        {
            Deck d = new Deck();
            listPrint(d.cards);
        }
    }

    class Card
    {
        public Card(byte val, string suit)
        {
            this.val = val;
            this.suit = suit;
            switch(val)
            {
                case 1:
                    this.stringVal = "Ace";
                    break;
                case 11:
                    this.stringVal = "Jack";
                    break;
                case 12:
                    this.stringVal = "Queen";
                    break;
                case 13:
                    this.stringVal = "King";
                    break;
                default:
                    this.stringVal = val.ToString();
                    break;
            }
        }
        
        public override string ToString()
        {
            return stringVal + " of " + suit;
        }
        public byte val;
        public string suit;
        public string stringVal;
    }

    class Deck
    {

        public List<Card> cards;
        public Deck()
        {
            cards = new List<Card>();
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            for(int i = 0; i < 4; i++)
            {
                for(byte j = 1; j <= 13; j++)
                {
                    cards.Add(new Card(j, suits[i]));
                }
            }
        }
    }

    class Player
    {
        public string name;
        public List<Card> hand;
        
        public Player()
        {

        }

        public Card Draw(Deck deck)
        {
            Card c = deck.cards[0];
            deck.cards.RemoveAt(0);
            hand.Add(c);
            return c;
        }

        public Card discard(int i)
        {
            if(i >= hand.Count)
            {
                return null;
            }
            Card c = hand[i];
            hand.RemoveAt(i);
            return c;
        }
    }
}
