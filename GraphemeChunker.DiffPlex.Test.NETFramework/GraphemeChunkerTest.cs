using System.IO;
using System.Text.Json;
using Xunit;

namespace TsukuyoOka.DiffPlex.Chunkers.Test
{
    public class GraphemeChunkerTest
    {
        private JsonElement TestData { get; } = JsonSerializer.Deserialize<JsonDocument>(File.ReadAllText("TestData.json")).RootElement.GetProperty(nameof(GraphemeChunkerTest));

        private void Execute(string name)
        {
            var prop = TestData.GetProperty(name);
            var testDataValue = prop.GetProperty("Pattern").GetString();
            var expectedLength = prop.GetProperty("ExpectedLength").GetInt32();

            Assert.Equal(expectedLength, new GraphemeChunker().Chunk(testDataValue).Length);
        }

        /// <summary>
        /// ASCII
        /// </summary>
        [Fact]
        public void Test1()
        {
            Execute(nameof(Test1));
        }

        /// <summary>
        /// Surrogate Pairs
        /// </summary>
        [Fact]
        public void Test2()
        {
            Execute(nameof(Test2));
        }

        /// <summary>
        /// Diacritical Marks
        /// </summary>
        [Fact]
        public void Test3()
        {
            Execute(nameof(Test3));
        }

        /// <summary>
        /// Japanese Kanji Variation Selector
        /// </summary>
        [Fact]
        public void Test4()
        {
            Execute(nameof(Test4));
        }

        /// <summary>
        /// Korean Hangul Syllable
        /// </summary>
        [Fact]
        public void Test5()
        {
            Execute(nameof(Test5));
        }

        /// <summary>
        /// Family Emoji
        /// </summary>
        [Fact]
        public void Test6()
        {
            Execute(nameof(Test6));
        }

        /// <summary>
        /// Emoji Skin Tone
        /// </summary>
        [Fact]
        public void Test7()
        {
            Execute(nameof(Test7));
        }

#if NET5_0_OR_GREATER
        /// <summary>
        /// Regional Indicator
        /// </summary>
        /// <remarks>
        /// GraphemeSplitter does not support to split multiple regional indicators.
        /// </remarks>
        [Fact]
        public void Test8()
        {
            Execute(nameof(Test8));
        }
#endif

        /// <summary>
        /// Tag Sequence
        /// </summary>
        [Fact]
        public void Test9()
        {
            Execute(nameof(Test9));
        }
    }
}