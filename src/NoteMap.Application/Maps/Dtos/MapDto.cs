using Jane.Application.Services.Dto;
using Jane.AutoMapper;
using NoteMap.Elements;

namespace NoteMap.Maps
{
    [AutoMap(typeof(Map))]
    public class MapDto : EntityDto<long>
    {
        public string Name { get; set; }

        public Scale Scale { get; set; }

        public long UserId { get; set; }
    }
}