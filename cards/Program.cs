using System;
using System.Collections.Generic;

namespace cards
{
    class Card
    {
        private string stringVal;
        private string Suit;
        private int Val;

        public Card(string value, string mast, int price)
        {
            stringVal = value;
            Suit = mast;
            Val = price;
        }
        public string show_card
        {
            get
            {
                return $"{stringVal} {Suit} has value {Val}";
            }
        }

    }

    class Deck
    {
        private List<Card> cards;
        private List<Card> storage;
        public Deck()
        {   
            cards = new List<Card>();
            Random rand = new Random();
            while (cards.Count < 53)
            {
                string[] value = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"};
                string[] mast = {"Clubs", "Spades", "Hearts", "Diamonds"};
                int temp = rand.Next(0, 12);
                Card new_card = new Card(value[temp], mast[rand.Next(0,3)], temp+2);
                if (!cards.Contains(new_card))
                {
                    cards.Add(new_card);
                }
            }
            storage = cards;
        }
        public Card Deal
        {
            get
            {
                Card temp = cards[cards.Count-1];
                cards.RemoveAt(cards.Count-1);
                return temp;
            }
        }
        public void Reset()
        {
            cards = storage;
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                int card1_index = rand.Next(0,51);
                int card2_index = rand.Next(0, 51);
                Card temp = cards[card1_index];
                cards[card1_index] = cards[card2_index];
                cards[card2_index] = temp;
            }
        }
    }
    class Player
    {
        private string Name;
        private List<Card> hand = new List<Card>();
        public Player(string name)
        {
            Name = name;
        }
        public Card draw(Deck deck)
        {
            Card my_card = deck.Deal;
            hand.Add(my_card);
            return my_card;
        }
        public Card discard(int index)
        {
            if (index > hand.Count-1)
            {
                Console.WriteLine("No such card, index too high.");
                return null;
            }
            Card card_to_discard = hand[index];
            hand.RemoveAt(index);
            return card_to_discard;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Durak");
            Deck deck = new Deck();
            player.draw(deck);
            player.draw(deck);
            player.draw(deck);
            Card card = player.discard(0);
            Console.WriteLine(card.show_card);
        }
    }
}
