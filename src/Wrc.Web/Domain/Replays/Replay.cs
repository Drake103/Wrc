namespace Wrc.Web.Domain.Replays
{
    public class Replay
    {
        public Replay(
            int id,
            string title,
            IGameInfo gameInfo,
            UploadedFile uploadedFile,
            int downloadCount)
        {
            Id = id;
            Title = title;
            GameInfo = gameInfo;
            UploadedFile = uploadedFile;
            DownloadCount = downloadCount;
        }

        public int Id { get; }

        public string Title { get; }

        public IGameInfo GameInfo { get; }

        public UploadedFile UploadedFile { get; }

        public int DownloadCount { get; }
    }
}