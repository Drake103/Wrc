using System;

namespace Wrc.Web.Domain.Replays
{
    public class UploadedFile
    {
        public UploadedFile(
            string downloadLink,
            string fileHash,
            DateTime uploadDate)
        {
            DownloadLink = downloadLink;
            FileHash = fileHash;
            UploadDate = uploadDate;
        }

        public string DownloadLink { get; }

        public string FileHash { get; }

        public DateTime UploadDate { get; }
    }
}