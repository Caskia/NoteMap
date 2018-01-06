using Jane.Application.Services.Dto;
using Jane.AutoMapper;
using NoteMap.Maps;
using System.Collections.Generic;

namespace NoteMap.Elements
{
    [AutoMap(typeof(Element))]
    public class ElementDto : EntityDto<long>
    {
        public string Content { get; set; }

        public Layer Layer { get; set; }

        public List<LayerStyle> LayerStyles { get; set; }

        public long MapId { get; set; }

        public Position Position { get; set; }

        public string Resource { get; set; }

        public List<string> Tags { get; set; }

        public ElementType Type { get; set; }

        public long UserId { get; set; }
    }
}