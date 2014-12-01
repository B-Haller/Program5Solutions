using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    //enums of card types
     public enum Ranks
     {
        Two=2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
     }
    //enums of suits
    public enum Suits
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    class Program
    {
        static void Main(string[] args)
        {
            Deck aDeck = new Deck();
            foreach (Card thisCard in aDeck.TheCards)
            {
                thisCard.PrintCard();
            }
            Console.ReadKey();
        }

    }
    //class called deck
    class Deck
    {

        private List<Card> _theCards;

        public List<Card> TheCards
        {
            get { return _theCards; }
            set { _theCards = value; }
        }

        private List<Card> _cardsDealt;

        public List<Card> CardsDealt
        {
            get { return _cardsDealt; }
            set { _cardsDealt = value; }
        }

        Random rng = new Random();


        public List<Card> ShuffleCards(List<Card> unshuffledCards)
        {
            List<Card> shuffledCards = new List<Card>();

            while (unshuffledCards.Count > 0)
            {
                //int randomIndex = rng.Next(0,unshuffledCards.Count())
                //shuffledCards.Add(unshuffledCards[randomIndex])
                //unshuffledCards.RemoveAt(randomIndex)
                Card thisCard = unshuffledCards[rng.Next(0, unshuffledCards.Count())];
                shuffledCards.Add(thisCard);
                unshuffledCards.Remove(thisCard);
            }

            return shuffledCards;
        }

        public Card DealACard()
        {
            Card theCard = this.TheCards[0];
            this.CardsDealt.Add(theCard);
            this.TheCards.Remove(theCard);
            return theCard;
        }


        public void ReturnCardToDeck(Card returnedCard)
        {

            if (CardsDealt.Contains(returnedCard))
            {
                this.CardsDealt.Remove(returnedCard);
            }

            if (!TheCards.Contains(returnedCard))
            {
                this.TheCards.Add(returnedCard);
            }
        }




        public Deck()
        {
            this.TheCards = new List<Card>();
            foreach (Suits thisSuit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks thisRank in Enum.GetValues(typeof(Ranks)))
                {
                    this.TheCards.Add(new Card(thisRank, thisSuit));
                }
            }

            TheCards = this.ShuffleCards(TheCards);


            CardsDealt = new List<Card>();

        }
        





    }

    class Card
    {
        private Ranks _theCardsRank;

        public Ranks TheCardsRank
        {
            get { return _theCardsRank; }
            set { _theCardsRank = value; }
        }
        


        private Suits _theCardsSuit;

        public Suits TheCardsSuit
        {
            get { return _theCardsSuit; }
            set { _theCardsSuit = value; }
        }

        public void PrintCard()
        {
            Console.WriteLine(TheCardsRank + " of " + TheCardsSuit);
        }


        public Card(Ranks theRank, Suits theSuit)
        {
            this.TheCardsRank = theRank;
            this.TheCardsSuit = theSuit;
        }

    }
}
    

