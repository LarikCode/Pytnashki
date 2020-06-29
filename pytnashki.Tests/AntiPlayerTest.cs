using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace pytnashki.Tests
{
    [TestClass]
    public class AntiPlayerTest
    {
        private AntiPlayer AntiPlayer;
        private Pole Pole;
        private Player Player;
        [TestInitialize]
        public void TestInitialize()
        {
            AntiPlayer = new AntiPlayer();
            Pole = Pole.getInstance();
            Player = Player.getInstance();
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        public void Randomize_minus1in_expected_false()
        {
            Assert.IsFalse(AntiPlayer.Randomize(-1));
        }

        [TestMethod]
        public void Randomize_100step_expected_true()
        {
            Assert.IsTrue(AntiPlayer.Randomize(100));
        }

        [TestMethod]
        public void Action_HistoryClear_expected_count0()
        {
            AntiPlayer.playOrNo = true;
            AntiPlayer.Action();
            Assert.AreEqual(0, Player.HistoryCount());
        }
    }
}
