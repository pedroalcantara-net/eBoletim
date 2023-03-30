using System;
using System.Collections.Generic;

namespace eBoletimServer.Domain.ModelsTeste
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal? Grade1 { get; set; }
        public int Quarter { get; set; }
    }
}
