﻿using System;
using System.Collections.Generic;

namespace Flashcards.Application.Images
{
    public interface IImagesStorage
    {
        string VirtualPath { get; }
        void SaveImages(string deck, Guid cardId, IEnumerable<ImageDataInfo> imagesData);
        void RemoveImages(string deck, Guid cardId);
    }
}
