using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManager.Models.Domains
{
    public class Product
    {
        public Product()
        {
            InvoicePosition = new Collection<InvoicePosition>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Value { get; set; }

        public ICollection<InvoicePosition> InvoicePosition { get; set; }
    }
}