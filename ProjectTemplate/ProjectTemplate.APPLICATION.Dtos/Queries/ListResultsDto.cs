using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.APPLICATION.Dtos.Queries
{
    public abstract class ListResultsDto<T>
    {
        public IList<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
