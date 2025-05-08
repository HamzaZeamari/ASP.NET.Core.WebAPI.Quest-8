using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Domain
{
    public class Wookie
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        
        public List<Selfie> Selfies { get; set; }   

    }
}
