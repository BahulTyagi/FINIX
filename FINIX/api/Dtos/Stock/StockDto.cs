﻿using api.Dtos.Comment;
using api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Stock
{
    public class StockDto
    {

        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }

        public List<CommentDto> comment { get; set; }

    }
}
