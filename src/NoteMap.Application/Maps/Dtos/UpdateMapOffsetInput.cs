using Jane.Application.Services.Dto;

namespace NoteMap.Maps
{
    public class UpdateMapOffsetInput:EntityDto<long>
    {
        public Position Offset { get; set; }
    }
}