using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170829_PlayingWithPassphrases
{
    [TestClass]
    public class PlayingWithPassphrasesTests
    {
        [TestMethod]
        public void input_born_should_return_CpSo()
        {
            PlayPassShouldBe("oSpC", "born", 1);
        }

        [TestMethod]
        public void input_cash_should_return_iTbD()
        {
            PlayPassShouldBe("iTbD", "cash", 1);
        }

        [TestMethod]
        public void input_born_2015_should_return_4897_CpSo()
        {
            PlayPassShouldBe("!4897 oSpC", "born 2015!", 1);
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
            var result = s.ToLower()
                .Select(c => char.IsNumber(c) ? char.Parse((9 - (int)char.GetNumericValue(c)).ToString()) : (char.IsLetter(c) ? (char)(c + 1) : c))
                .Select((c, i) => i % 2 == 0 ? char.ToUpper(c) : c);
            return string.Concat(result.Reverse());
        }
    }
}
