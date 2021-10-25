using ReverseRow;
using System;
using Xunit;

namespace ReverseRowTest
{
    public class ReversTest
    {
        private Revers revers;
        public ReversTest()
        {
            revers = new Revers();
        }


        [Fact]
        public void WordRevers()
        {
            var input = "слово";
            var expected = "оволс";

            var result = revers.StringRevers(input);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void PhraseRevers()
        {
            var input = "несколько слов";
            var expected = "волс окьлоксен";

            var result = revers.StringRevers(input);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void PhraseWithNumbersRevers()
        {
            var input = "несколько слов c цифрами 123 = 123";
            var expected = "321 = 321 имарфиц c волс окьлоксен";

            var result = revers.StringRevers(input);

            Assert.Equal(expected, result);
        }
    }
}
