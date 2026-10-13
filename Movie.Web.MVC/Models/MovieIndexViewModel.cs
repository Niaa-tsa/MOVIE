using Movie.Domain.DTOs;

namespace Movie.Web.MVC.Models
{
    public class MovieIndexViewModel
    {
        public MovieFilterDTO Filter { get; set; } = new();
        public ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
        public string? Error { get; set; }
    }
}
