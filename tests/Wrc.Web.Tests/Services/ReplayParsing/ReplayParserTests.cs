using System.IO;
using Wrc.Web.Services.ReplayParsing;
using Xunit;

namespace Wrc.Web.Tests.Services.ReplayParsing
{
    public class ReplayParserTests
    {
        [Fact]
        public void ParseTest01()
        {
            var replayParser = new ReplayParser();

            var memoryStream = new MemoryStream(ReplayParserTestsResources.Steel_Balalaika_vs_We_suck_at_wargame_3vs3);

            var replayDto = replayParser.ParseFile(memoryStream);

            Assert.NotNull(replayDto);
            Assert.Equal(1, replayDto.IsNetworkMode);
            Assert.Equal("430000610", replayDto.Version);
            Assert.Equal("1", replayDto.GameMode);
            Assert.Equal(6, replayDto.NbMaxPlayer);
            Assert.Equal(0, replayDto.NbAI);
            Assert.Equal("0", replayDto.GameType);
            Assert.Equal(1, replayDto.Private);
            Assert.Equal(3000, replayDto.InitMoney);
            Assert.Equal(2400, replayDto.TimeLimit);
            Assert.Equal(500, replayDto.ScoreLimit);
            Assert.Equal("Игра (|:Serega:|)", replayDto.ServerName);
        }

        [Fact]
        public void ParseTest02()
        {
            var replayParser = new ReplayParser();

            var memoryStream = new MemoryStream(ReplayParserTestsResources.WRG_B5P_vs_1144_Tough_Jungle);

            var replayDto = replayParser.ParseFile(memoryStream);

            Assert.NotNull(replayDto);
            Assert.Equal(1, replayDto.IsNetworkMode);
            Assert.Equal("430000610", replayDto.Version);
        }

        [Fact]
        public void ParseTest03()
        {
            var replayParser = new ReplayParser();

            var memoryStream = new MemoryStream(ReplayParserTestsResources._3v3_Tourney_Viteska_Brigada_B5P);

            var replayDto = replayParser.ParseFile(memoryStream);

            Assert.NotNull(replayDto);
            Assert.Equal(1, replayDto.IsNetworkMode);
            Assert.Equal("430000610", replayDto.Version);
        }
    }
}
