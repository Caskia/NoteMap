using Jane.Application.Services.Dto;

namespace NoteMap.Elements
{
    public class UpdateElementPositionInput : EntityDto<long>
    {
        public Position Position { get; set; }
    }
}