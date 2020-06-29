using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace pytnashki.Tests
{
    [TestClass]
    public class PlayerTest
    {
        private Player Player;
        private Pole Pole;        

        [TestInitialize]
        public void TestInitialize()
        {
            Pole = Pole.getInstance();
            Pole.NewState(4);
            Player = Player.getInstance();           
        }

        [TestCleanup]
        public void Cleanup()
        {
            Pole.NewState(4);
            Player.HistoryClear();
        }

        [TestMethod]
        public void Move_leftIn_expected_true() 
        {            
            Assert.IsTrue(Player.Move(ConsoleKey.LeftArrow));            
        }

        [TestMethod]
        public void Move_HistoryCountCheck_expected3()
        {
            Player.Move(ConsoleKey.LeftArrow);
            Player.Move(ConsoleKey.LeftArrow);
            Player.Move(ConsoleKey.LeftArrow);
            Player.Move(ConsoleKey.LeftArrow);
            Assert.AreEqual(3, Player.HistoryCount());
        }
    }
}
