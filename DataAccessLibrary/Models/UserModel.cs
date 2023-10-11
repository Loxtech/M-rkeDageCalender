using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime birthday { get; set; }
    }
}
