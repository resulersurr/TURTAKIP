using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourTrackingAPI.Models
{
    public class Tour
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public List<TourDate> Days { get; set; } = new();
    }

    public class TourDate
    {
        [Key]
        public int Id { get; set; }
        public string TourId { get; set; } = string.Empty;
        public int DayNumber { get; set; }
        public string? Date { get; set; }
        public string? Hour { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Activity { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}
