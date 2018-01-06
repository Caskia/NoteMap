using Jane.AutoMapper;
using NoteMap.Elements;
using NoteMap.Maps;
using System.Collections.Generic;

namespace NoteMap.Elements
{
    [AutoMapTo(typeof(Element))]
    public class CreateElementInput
    {
        public string Content { get; set; }

        public Layer Layer { get; set; } = new Layer();

        public List<LayerStyle> LayerStyles { get; set; } = new List<LayerStyle>();

        public long MapId { get; set; }

        public Position Position { get; set; }

        public string Resource { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public ElementType Type { get; set; }

        public long UserId { get; set; }
    }
}