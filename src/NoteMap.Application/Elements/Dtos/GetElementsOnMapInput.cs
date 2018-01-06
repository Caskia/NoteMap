namespace NoteMap.Elements
{
    public class GetElementsOnMapInput
    {
        public Position BeginPosition { get; set; }

        public Position EndPosition { get; set; }

        public long MapId { get; set; }
    }
}