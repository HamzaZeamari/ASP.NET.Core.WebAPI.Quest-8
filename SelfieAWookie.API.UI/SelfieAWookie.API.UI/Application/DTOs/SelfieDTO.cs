using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.API.UI.Application.DTOs
{
    public class SelfieDTO
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string Title { get; set; }
    }
}
