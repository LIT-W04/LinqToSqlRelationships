using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToSqlRelationships.Data;

namespace LinqToSqlRelationships.Web.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Person> People { get; set; }
    }
}