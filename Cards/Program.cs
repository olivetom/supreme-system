using System;
using System.Text;

namespace Cards 
{
    enum Value { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    enum Suit { Clubs, Diamonds, Hearts, Spades }   
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i=0; i < 4; i++)
            {
                


            }
            Console.WriteLine("Manos dadas:");
        }
    }
    class PlayingCard
    {
        private readonly Suit suit;
        private readonly Value value;
        public PlayingCard(Suit s, Value v)
        {
            this.suit = s;
            this.value = v;
        }
        public override string ToString()
        {
            string result = string.Format("{0} of {1}", this.value, this.suit);
            return result;
        }
        public Suit CardSuit()
        {
            return this.suit;
        }
         public Value CardValue()
        {
            return this.value;
        }
    }
    class Pack {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private PlayingCard[,] cardPack;
        private Random randomCardSelector = new Random();
        //TODO...
    }

    class Hand {
        private int NumCards;
        private PlayingCard[] hand;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i < NumCards; i++ )
                 sb.Append(hand[i].ToString());
            return sb.ToString();
        }

        public Hand(int numCards) 
        {
            NumCards = numCards;
        }
    }

    class CardPlayer 
    {
        public String Name;

        public Hand hand;
    }

    class GameOfPoker
    {
        CardPlayer A;
        CardPlayer B;
        CardPlayer C;
        CardPlayer D;


    }

}
