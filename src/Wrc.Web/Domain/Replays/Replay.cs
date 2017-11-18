namespace Wrc.Web.Domain.Replays
{
    public class Replay
    {
        public Replay(
            int id,
            string title,
            IGameInfo gameInfo,
            UploadedFile uploadedFile)
        {
            Id = id;
            Title = title;
            GameInfo = gameInfo;
            UploadedFile = uploadedFile;
        }

        public int Id { get; }

        public string Title { get; }

        public IGameInfo GameInfo { get; }

        public UploadedFile UploadedFile { get; }

        public int DownloadsCounter { get; }
    }
}