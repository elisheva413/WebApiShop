using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Entities;


namespace Service
{
    public class FinalProducts
    {
        public List<ProductDTO> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
        
    }
}
