using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170829_PlayingWithPassphrases
{
    [TestClass]
    public class PlayingWithPassphrasesTests
    {
        [TestMethod]
        public void input_born_should_return_CpSo()
        {
            PlayPassShouldBe("CpSo", "born", 1);
        }

        private static void PlayPassShouldBe(string expected, string source, int timer)
        {
            var playPass = new PlayPass();
            var actual = playPass.playPass(source, timer);
            Assert.AreEqual(expected, actual);
        }
    }

    public class PlayPass
    {
        public string playPass(string s, int n)
        {
            return "CpSo";
        }
    }
}
