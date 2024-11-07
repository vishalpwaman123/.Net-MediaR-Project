using System;
using System.Collections.Generic;

namespace CQRS.Mediator.RepositoryLayer.CrudEntities
{
    public partial class FactUserMaster
    {
        public int UserId { get; set; }
        public DateTime InsertionDate { get; set; }
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
