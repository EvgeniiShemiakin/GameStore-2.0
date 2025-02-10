﻿namespace GameStore_2._0.Models
{
    public class GameVM
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ClickCount { get; set; } = 0;
        public List<Genre>? Genres { get; set; }
        public string? CrslImg { get; set; }
        public string? CoverImg { get; set; }
        public string? Scr_Thumb { get; set; }
        public string? Trailer { get; set; }
        public string? Trailer_Thumb { get; set; }
        public List<string>? ScreenImg { get; set; }

        public GameVM()
        {
            Id = _id++;
        }

        public GameVM(string title, decimal price, string description)
        {
            Id = _id++;
            Title = title;
            Price = price;
            Description = description;
        }
    }
}