using Jane.Application.Services.Dto;
using NoteMap.Maps;

namespace NoteMap.Elements
{
    public class UpdateElementPositionInput : EntityDto<long>
    {
        public Position Position { get; set; }
    }
}