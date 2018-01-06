using System;
using Jane.Entities;
using Jane.Entities.Auditing;
using Jane.Timing;
using NoteMap.Elements;

namespace NoteMap.Maps
{
    public class Map : Entity<long>, IHasCreationTime
    {
        public DateTime CreationTime { get; set; } = Clock.Now;

        public string Name { get; set; }

        public Scale Scale { get; set; } = new Scale();

        public long UserId { get; set; }
    }
}