namespace EntertainmentLibrary.Models
{
    public class MediaModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Quality { get; set; }
        public bool hasSubs { get; set; }
        public string? uploader { get; set; }
    }
}
