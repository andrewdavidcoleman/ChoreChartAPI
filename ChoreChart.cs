using System;
using System.Collections.Generic;

namespace ChoreChartAPI
{
    public class Chore
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public int Value { get; set; }
    }
    
    public class Day
    {
        public int Id { get; set; }
        public int ChoreId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
