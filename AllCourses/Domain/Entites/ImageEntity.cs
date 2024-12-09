namespace AllCourses.Domain.Entites
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
