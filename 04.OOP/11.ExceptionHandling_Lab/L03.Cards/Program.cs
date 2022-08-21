using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L03.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] currentInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < currentInput.Length; i++)
            {
                string[] currentCardInfo = currentInput[i].Split();

                string currentFace = currentCardInfo[0];
                string currentSuit = currentCardInfo[1];

                try
                {
                    Card card = new Card(currentFace, currentSuit);
                    cards.Add(card);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            foreach (var card in cards)
            {
                Console.Write(card);
            }
        }
    }

    class Card
    {
        string face;
        string suit;

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face 
        { 
            get
            {
                return this.face;
            }
            private set
            {
                if (!IsValidFace(value))
                {
                    throw new FormatException();
                }

                this.face = value;
            }
        }

        public string Suit
        {
            get
            {
                return this.suit;
            }
            private set
            {
                if (!IsValidSuit(value))
                {
                    throw new FormatException();
                }

                this.suit = ConvertSuit(value);
            }
        }

        public static bool IsValidFace(string face)
        {
            if (face == "2" || face == "3" || face == "4" ||
                face == "5" || face == "6" || face == "7" ||
                face == "8" || face == "10" || face == "J" ||
                face == "Q" || face == "K" || face == "A")
            {
                return true;
            }

            return false;
        }

        public static bool IsValidSuit(string suit)
        {
            if (suit == "S" || suit == "H" || 
                suit == "D" || suit == "C")
            {
                return true;
            }

            return false;
        }

        public static string ConvertSuit(string suit)
        {
            string convertedSuit = string.Empty;

            switch (suit)
            {
                case "S":
                    convertedSuit = "\u2660";
                    break;
                case "H":
                    convertedSuit = "\u2665";
                    break;
                case "D":
                    convertedSuit = "\u2666";
                    break;
                case "C":
                    convertedSuit = "\u2663";
                    break;
            }

            return convertedSuit;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"[{this.face}{this.suit}] ");

            return sb.ToString();
        }
    }
}
