using System.Collections.Generic;

namespace FinanceApp.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubCategory> Children { get; set; }
    }
}
