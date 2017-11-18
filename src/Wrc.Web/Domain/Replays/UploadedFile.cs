using System;

namespace Wrc.Web.Domain.Replays
{
    public class UploadedFile
    {
        public UploadedFile(
            string downloadLink,
            string fileHash,
            DateTime uploadedAt)
        {
            DownloadLink = downloadLink;
            FileHash = fileHash;
            UploadedAt = uploadedAt;
        }

        public string DownloadLink { get; }

        public string FileHash { get; }

        public DateTime UploadedAt { get; }
    }
}