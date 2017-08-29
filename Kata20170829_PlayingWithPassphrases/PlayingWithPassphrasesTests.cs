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

        [TestMethod]
        public void input_I_LOVE_YOU()
        {
            PlayPassShouldBe("!!!vPz fWpM J", "I LOVE YOU!!!", 1);
        }

        [TestMethod]
        public void input_MY_GRANMA_CAME_FROM_NY_ON_THE_23RD_OF_APRIL_2015()
        {
            PlayPassShouldBe("4897 NkTrC Hq fT67 GjV Pq aP OqTh gOcE CoPcTi aO", "MY GRANMA CAME FROM NY ON THE 23RD OF APRIL 2015", 2);
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
        public string playPass(string str, int shiftNum)
        {
            var result = str.ToLower().Select((letter, idx) => PassphrasesChar(letter, shiftNum, idx)).Reverse();
            return string.Concat(result);
        }

        private static char PassphrasesChar(char letter, int shiftNum, int idx)
        {
            var newChar = char.IsNumber(letter) 
                ? DigitComplementWithNine(letter) 
                : TransformedLetterByShiftNumber(letter, shiftNum);

            return idx % 2 == 0 ? char.ToUpper(newChar) : newChar;
        }

        private static char TransformedLetterByShiftNumber(char letter, int shiftNum)
        {
            return char.IsLetter(letter) ? (char)(letter + shiftNum > 122 ? letter + shiftNum - 26 : letter + shiftNum) : letter;
        }

        private static char DigitComplementWithNine(char letter)
        {
            return char.Parse((9 - (int)char.GetNumericValue(letter)).ToString());
        }
    }
}
