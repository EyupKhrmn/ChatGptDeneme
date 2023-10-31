using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceProject.Entities
{
    public class AıReponse
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
    }
}
