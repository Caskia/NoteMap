using Jane.AutoMapper;

namespace NoteMap.Maps
{
    [AutoMapTo(typeof(Map))]
    public class CreateMapInput
    {
        public string Name { get; set; }

        public long UserId { get; set; }
    }
}