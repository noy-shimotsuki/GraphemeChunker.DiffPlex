using DiffPlex;
using System.Collections.Generic;
#if NET5_0_OR_GREATER
using System.Globalization;
#else
using GraphemeSplitter;
#endif

namespace TsukuyoOka.DiffPlex.Chunkers
{
    public class GraphemeChunker : IChunker
    {
        public string[] Chunk(string text)
        {
            var result = new List<string>();
#if NET5_0_OR_GREATER
            var enumerator = StringInfo.GetTextElementEnumerator(text);
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.GetTextElement());
            }
#else
            foreach (var grapheme in text.GetGraphemes())
            {
                result.Add(grapheme.String);
            }
#endif
            return result.ToArray();
        }
    }
}
