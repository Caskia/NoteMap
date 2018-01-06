using Jane.Entities;
using Jane.Entities.Auditing;
using Jane.Timing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NoteMap.Maps;
using System;
using System.Collections.Generic;

namespace NoteMap.Elements
{
    public class Element : Entity<long>, IHasCreationTime
    {
        public string Content { get; set; }

        public DateTime CreationTime { get; set; } = Clock.Now;

        public Layer Layer { get; set; } = new Layer();

        public List<LayerStyle> LayerStyles { get; set; } = new List<LayerStyle>();

        public long MapId { get; set; }

        public Position Position { get; set; }

        public string Resource { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        [BsonRepresentation(BsonType.String)]
        public ElementType Type { get; set; }

        public long UserId { get; set; }
    }
}