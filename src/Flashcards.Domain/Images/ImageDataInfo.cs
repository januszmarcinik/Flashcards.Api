using System;

namespace Flashcards.Domain.Images
{
    public class ImageDataInfo
    {
        public Guid ImageId { get; }
        public byte[] Data { get; }
        public string Extension { get; }

        public ImageDataInfo(Guid imageId, byte[] data, string extension)
        {
            ImageId = imageId;
            Data = data;
            Extension = extension;
        }
    }
}