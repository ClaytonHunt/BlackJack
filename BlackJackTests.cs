using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack
{
    [TestClass]
    public class BlackJackTests
    {
        private Hand _hand;

        [TestInitialize]
        public void Initialize()
        {
            _hand = new Hand();
        }

        [TestMethod]
        public void HandDealtAOneHasCurrentScoreOne()
        {
           
            _hand.Deal("1");
            Assert.AreEqual(1, _hand.Score());
        }

        [TestMethod]
        public void HandDealtAQueenHasCurrentScoreTen()
        {
            
            _hand.Deal("Q");
            Assert.AreEqual(10, _hand.Score());
        }

        [TestMethod]
        public void HandDealtAnAceHasCurrentScoreEleven()
        {
            
            _hand.Deal("A");
            Assert.AreEqual(11, _hand.Score());
        }

        [TestMethod]
        public void HandDealtTwoCardsHasCurrentScoreSumOfCards()
        {
            
            _hand.Deal("2");
            _hand.Deal("3");
            Assert.AreEqual(5, _hand.Score());
        }
    }

    public class Hand
    {
        private readonly List<int> _cardsInHand = new List<int>();

        public void Deal(string card)
        {
            int tempCard;
            int.TryParse(card, out tempCard);

            if(tempCard == 0 && card == "A")
                _cardsInHand.Add(11);
            else if(tempCard == 0)
                _cardsInHand.Add(10);
            else
                _cardsInHand.Add(tempCard);
        }

        public int Score()
        {
            var score = 0;
            _cardsInHand.ForEach(x => score += x);
            return score;
        }
    }
}
