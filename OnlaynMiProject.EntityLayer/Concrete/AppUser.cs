using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlaynMiProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int ConfirmCode { get; set; }
        public decimal Sum { get; set; }
        
        public decimal TotalSum { get; set; }
        
        public List<UserGroup>? UserGroups { get; set; }
        
        public List<Group>? Groups { get; set; }
        public List<EventAttendance>? EventAttendances { get; set; }

    }
}
