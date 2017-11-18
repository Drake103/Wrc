using System;

namespace Wrc.Web.Domain.Replays
{
    public class UploadedFile
    {
        public UploadedFile(
            string fileName,
            string fileHash,
            DateTime uploadedAt)
        {
            FileName = fileName;
            FileHash = fileHash;
            UploadedAt = uploadedAt;
        }

        public string FileName { get; }

        public string FileHash { get; }

        public DateTime UploadedAt { get; }
    }
}