using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; }
        public string ContractName { get; set; }
        public int CompanyName { get; set; }
        public string City { get; set; }
    }
}
