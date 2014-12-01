using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PokerPlayer
{
    //enums of card types
    public enum Ranks
    {
        Two = 2,
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
        //main function
        static void Main(string[] args)
        {
            //create new deck of deck type
            //Deck aDeck = new Deck();
            //foreach (Card thisCard in aDeck.TheCards)
            //{
            //    thisCard.PrintCard();
            //}
            //Console.WriteLine();
            do
            {
                Console.Clear();
                List<PokerPlayer> playList = new List<PokerPlayer>();
                for (int i = 0; i < 3; i++)
                {
                    playList.Add(new PokerPlayer());
                    Thread.Sleep(10);

                }
                playList.Sort();
                playList.Reverse();
                foreach (PokerPlayer player in playList)
                {
                    player.ShowHand();
                    Console.WriteLine("\nHand Value: {0}\n", player.HandStrength);
                }

                Console.WriteLine("<Press y to run again, any other key to exit>");
                
            }
            while (Console.ReadKey().KeyChar == 'y');
                
            

            Console.ReadKey();
        }

    }

    enum HandValues
    {
        HighCard = 1,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    class PokerPlayer : IComparable<PokerPlayer>
    {
        private List<Card> _cardsInHand;
        public List<Card> CardsInHand
        {
            get { return _cardsInHand; }
            set { _cardsInHand = value; }
        }

        private Card _highestCard;
        private Card HighestCard
        {
            get { return _highestCard; }
            set { _highestCard = value; }
        }

        private HandValues _handStrength;
        public HandValues HandStrength
        {
            get
            {
                if (HasRoyalFlush())
                {
                    return HandValues.RoyalFlush;
                }
                if (HasStraightFlush())
                {
                    return HandValues.StraightFlush;
                }
                if (HasFourOfAKind())
                {
                    return HandValues.FourOfAKind;
                }
                if (HasFullHouse())
                {
                    return HandValues.FullHouse;
                }
                if (HasFlush())
                {
                    return HandValues.Flush;
                }
                if (HasStraight())
                {
                    return HandValues.Straight;
                }
                if (HasThreeOfAKind())
                {
                    return HandValues.ThreeOfAKind;
                }
                if (HasTwoPair())
                {
                    return HandValues.TwoPairs;
                }
                if (HasOnePair())
                {
                    return HandValues.OnePair;
                }
                return HandValues.HighCard;
            }
        }

        public List<Card> DrawHand()
        {
            Deck cardDeck = new Deck();
            List<Card> handToReturn = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                handToReturn.Add(cardDeck.DealACard());
            }
            return handToReturn;
        }

        
        public PokerPlayer()
        {
            this.CardsInHand = DrawHand();
        }

        public void ShowHand()
        {
            foreach (Card cardChosen in CardsInHand)
            {
                cardChosen.PrintCard();
            }
        }


        public bool HasRoyalFlush()
        {
            List<Card> sortedCards = new List<Card>();
            sortedCards = CardsInHand.OrderBy(x => x.TheCardsSuit).ToList();
            if (sortedCards[0].TheCardsRank != sortedCards[sortedCards.Count()-1].TheCardsRank)
            {
                return false;
            }
            sortedCards = sortedCards.OrderByDescending(x => x.TheCardsRank).ToList();
            if (sortedCards[0].TheCardsRank == Ranks.Ace
                && sortedCards[1].TheCardsRank == Ranks.King
                && sortedCards[2].TheCardsRank == Ranks.Queen
                && sortedCards[3].TheCardsRank == Ranks.Jack
                && sortedCards[4].TheCardsRank == Ranks.Ten)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasStraightFlush()
        {
            
            if (HasStraight() && HasFlush())
            {
                this.HighestCard = CardsInHand.OrderByDescending(x => x.TheCardsRank).First();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool HasFourOfAKind()
        {
            if(CardsInHand.GroupBy(x => x.TheCardsRank).Any(x=>x.Count() == 4))
            {
                this.HighestCard = CardsInHand.GroupBy(x => x.TheCardsRank).Where(x => x.Count() == 4).First().First();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool HasFullHouse()
        {
            if (CardsInHand.GroupBy(x => x.TheCardsRank).Any(x => x.Count() == 3)
                && CardsInHand.GroupBy(x => x.TheCardsRank).Any(x => x.Count() == 2))
            {
                this.HighestCard = CardsInHand.GroupBy(x => x.TheCardsRank).OrderByDescending(x => x.Count()).First().First();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool HasFlush()
        {
            if (CardsInHand.GroupBy(x => x.TheCardsSuit).Any(x => x.Count() == 5))
            {
                this.HighestCard = CardsInHand.OrderByDescending(x => x.TheCardsRank).First();
                return true;
            }
            else
            {
                return false;
            }
            

        }

        public bool HasStraight()
        {
            if (CardsInHand.GroupBy(x => x.TheCardsRank).Any(x => x.Count() != 1))
            {
                return false;
            }

            List<Card> sortedCards = new List<Card>();
            sortedCards = CardsInHand.OrderByDescending(x => x.TheCardsRank).ToList();
            if (sortedCards[0].TheCardsRank - sortedCards[sortedCards.Count() - 1].TheCardsRank == 4)
            {
                this.HighestCard = CardsInHand.OrderByDescending(x => x.TheCardsRank).First();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool HasThreeOfAKind()
        {
            if (CardsInHand.GroupBy(x => x.TheCardsRank).Any(x => x.Count() == 3))
            {
                this.HighestCard = CardsInHand.GroupBy(x => x.TheCardsRank).OrderByDescending(x => x.Count()).First().First();
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool HasTwoPair() 
        {
            if (CardsInHand
                .GroupBy(x => x.TheCardsRank)
                .Where(x => x.Count() == 2)
                .Count() == 2)
            {
                this.HighestCard = CardsInHand
                .GroupBy(x => x.TheCardsRank)
                .OrderByDescending(x => x.Key)
                .First()
                .First();

                return true;
            }
            else
            {
                return false;
            }


        }

        public bool HasOnePair()
        {
            if (CardsInHand
                .GroupBy(x => x.TheCardsRank)
                .Any(x => x.Count() == 2))
            {
                this.HighestCard = CardsInHand.GroupBy(x => x.TheCardsRank).OrderByDescending(x => x.Count()).First().First();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Card HighCard()
        {
            return CardsInHand.OrderByDescending(x => x.TheCardsRank).First();
        }

        public int CompareTo(PokerPlayer playerToCompareAgainst)
        {
            //if (this.HandStrength.CompareTo(playerToCompareAgainst.HandStrength) == 0)
            //{

         
            //}
            //if other player wins, returns 1
            //if this player wins, returns -1
            //if tie, returns 0
            return this.HandStrength.CompareTo(playerToCompareAgainst.HandStrength);
            //if (value == 0)
            //{
            //    value = this.Rank.CompareTo(playerToCompareAgainst.Rank);
            //}

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
