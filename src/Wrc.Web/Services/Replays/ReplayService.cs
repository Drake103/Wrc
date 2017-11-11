using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;
using Wrc.Web.Services.ReplayParsing;

namespace Wrc.Web.Services.Replays
{
    public class ReplayService : IReplayService
    {
        private readonly IReplayParser _parser;
        private readonly IReplayMapper _mapper;
        private readonly IUnitOfWorkFactory _uowFactory;

        public ReplayService(
            IReplayParser parser,
            IReplayMapper mapper,
            IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
            _parser = parser;
            _mapper = mapper;
        }

        public async Task<Replay> SaveReplayAsync(Stream replayFile, string filePath)
        {
            using (var uow = _uowFactory.Create())
            {
                var hash = ComputeFileHash(replayFile);

                var parsedReplayDto = _parser.ParseFile(CopyStream(replayFile));

                var replay = _mapper.GetEntity(parsedReplayDto);

                replay.Link = filePath;
                replay.Title = "no title";
                replay.UploadDate = DateTime.Now;
                replay.FileHash = hash;

                uow.ReplayRepository.Add(replay);

                await uow.SaveChangesAsync();

                return replay;
            }
        }

        private Guid ComputeFileHash(Stream replayFile)
        {
            var streamCopy = CopyStream(replayFile);

            using (var md5 = MD5.Create())
            {
                var fileHash = md5.ComputeHash(streamCopy);
                return new Guid(fileHash);
            }
        }

        private Stream CopyStream(Stream inputStream)
        {
            var startPosition = inputStream.Position;

            inputStream.Position = 0;
            MemoryStream streamCopy = new MemoryStream();
            inputStream.CopyTo(streamCopy);
            inputStream.Position = startPosition;

            streamCopy.Position = 0;
            return streamCopy;
        }

        public bool IsAlreadyUploaded(Stream replayFile, out string title)
        {
            using (var unitOfWork = _uowFactory.Create())
            {
                var hash = ComputeFileHash(replayFile);
                return unitOfWork.ReplayRepository.IsAlreadyUploaded(hash, out title);
            }
        }
    }
}