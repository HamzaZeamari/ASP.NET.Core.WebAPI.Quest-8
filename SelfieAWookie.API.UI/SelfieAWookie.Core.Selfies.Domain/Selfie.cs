namespace SelfieAWookie.Core.Selfies.Domain
{   
    /// <summary>
    /// Représente un selfie avec un wookie
    /// </summary>
    public class Selfie
    {
        
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string Title { get; set; }
        
        public int WookieId { get; set; }
        public Wookie Wookie { get; set; }

        public int PictureId { get; set; }
        public Picture Picture { get; set; }    

    }
}
