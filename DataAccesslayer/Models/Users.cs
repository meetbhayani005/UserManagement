using System;
using System.Collections.Generic;

namespace DataAccesslayer.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public string Gender { get; set; }
        public int? RoleId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
