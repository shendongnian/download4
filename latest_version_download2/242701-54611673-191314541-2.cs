csharp
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;
namespace MultiValueDictionaryTests
{
    public class MultiValueDictionaryTests
    {
        [Fact]
        public void UnderstandsPairsCorrectly()
        {
            /* Mimics the following file contents:
             Guild1-ServerDEF
             Guild2-ServerDEF
             Guild2-ServerABC
             Guild1 ServerXYZ
             Guild2-ServerABC
             Guild2-ServerABC
             */
            var testString = "Guild1-ServerDEF\r\nGuild2-ServerDEF\r\nGuild2-ServerABC\r\nGuild1\tServerXYZ\r\nGuild2-ServerABC\r\nGuild2-ServerABC\r\n";
            var builder = new GuildBuilder();
            var result = builder.BuildGuilds(testString);
            result.Should().ContainKey("Guild1");
            result.Should().ContainKey("Guild2");
            result["Guild1"].Should().ContainKey("ServerDEF")
                .And.ContainKey("ServerXYZ");
            result["Guild1"].Should().NotContainKey("ServerABC");
            result["Guild2"].Should().ContainKey("ServerDEF")
                .And.ContainKey("ServerABC");
            result["Guild2"].First().Key.Should().Be("ServerABC");
        }
        [Fact]
        public void WriteLine_ShowsCommaSeparatedValues()
        {
            var builder = new GuildBuilder();
            var example = new SortedDictionary<string, SortedList<string, string>>
            {
                {
                    "Guild1", new SortedList<string, string> {{"ServerABC", "ServerABC"}, {"ServerDEF", "ServerDEF"}}
                },
                {
                    "Guild2", new SortedList<string, string> {{"ServerABC", "ServerABC"}, {"ServerXYZ", "ServerXYZ"}}
                }
            };
            List<string> resultLines = builder.WriteGuildLines(example);
            resultLines.First().Should().Be("Guild1 - ServerABC, ServerDEF");
            resultLines.Last().Should().Be("Guild2 - ServerABC, ServerXYZ");
        }
    }
    public class GuildBuilder
    {
        readonly char[] delimiters = { '-', '\t' };
        public SortedDictionary<string, SortedList<string,string>> BuildGuilds(string inputString) // instead of file
        {
            var result = new SortedDictionary<string, SortedList<string,string>>();
            using (var reader = new StringReader(inputString))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var splitArray = line.Split(delimiters);
                    var guild = splitArray[0];
                    var server = splitArray[1];
                    if (!result.ContainsKey(guild))
                    {
                        result.Add(guild, new SortedList<string,string>());
                    }
                    if (!result[guild].ContainsKey(server))
                    {
                        result[guild].Add(server, server);
                    }
                }
            }
            return result;
        }
        public List<string> WriteGuildLines(SortedDictionary<string, SortedList<string, string>> input)
        {
            var result = new List<string>();
            foreach (var item in input)
            {
                result.Add($"{item.Key} - {string.Join(", ", item.Value.Keys)}");
            }
            return result;
        }
    }
}
