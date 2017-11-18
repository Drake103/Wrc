using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Wrc.Web.Common;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;
using Wrc.Web.Services.ReplayParsing;

namespace Wrc.Web.Services.Replays
{
    public class ReplayService : IReplayService
    {
        private readonly IParsedReplayToGameInfoTransformer _parsedReplayToGameInfoTransformer;
        private readonly IReplayParser _parser;
        private readonly ITimeService _timeService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ReplayService(
            IReplayParser parser,
            IUnitOfWorkFactory unitOfWorkFactory,
            IParsedReplayToGameInfoTransformer parsedReplayToGameInfoTransformer,
            ITimeService timeService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _parsedReplayToGameInfoTransformer = parsedReplayToGameInfoTransformer;
            _timeService = timeService;
            _parser = parser;
        }

        public async Task<Replay> SaveReplayAsync(Stream replayFile, string filePath)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var hash = ComputeFileHash(replayFile);

                var parsedReplayDto = _parser.ParseFile(CopyStream(replayFile));

                var gameInfo = _parsedReplayToGameInfoTransformer.ToGameInfo(parsedReplayDto);

                var replay = new Replay(
                    0,
                    "No Title",
                    gameInfo,
                    new UploadedFile(filePath, hash, _timeService.UtcNow));

                unitOfWork.ReplayRepository.Add(replay);

                await unitOfWork.SaveChangesAsync().ConfigureAwait(false);

                return replay;
            }
        }

        public async Task<Replay> IsAlreadyUploadedAsync(Stream replayFile)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var hash = ComputeFileHash(replayFile);
                return await unitOfWork.ReplayRepository.GetByFileHashAsync(hash);
            }
        }

        private string ComputeFileHash(Stream replayFile)
        {
            var streamCopy = CopyStream(replayFile);

            using (var md5 = MD5.Create())
            {
                return Convert.ToBase64String(md5.ComputeHash(streamCopy));
            }
        }

        private Stream CopyStream(Stream inputStream)
        {
            var startPosition = inputStream.Position;

            inputStream.Position = 0;
            var streamCopy = new MemoryStream();
            inputStream.CopyTo(streamCopy);
            inputStream.Position = startPosition;

            streamCopy.Position = 0;
            return streamCopy;
        }
    }
}