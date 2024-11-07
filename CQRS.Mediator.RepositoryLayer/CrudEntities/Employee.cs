using System;
using System.Collections.Generic;

namespace CQRS.Mediator.RepositoryLayer.CrudEntities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }
}
