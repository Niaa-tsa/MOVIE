using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Domain.DTOs
{
    public class MovieFilterDTO
    {
        public string? Title { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public string? StudioName { get; set; }

        public bool IsEmpty =>
            string.IsNullOrWhiteSpace(Title) && FromYear == null &&
            ToYear == null && string.IsNullOrWhiteSpace(StudioName);
    }
}