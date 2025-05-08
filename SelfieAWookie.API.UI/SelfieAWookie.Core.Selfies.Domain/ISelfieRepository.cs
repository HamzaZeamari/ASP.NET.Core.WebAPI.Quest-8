using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Domain
{   /// <summary>
    ///Repository to manage selfie 
    /// </summary>
    public interface ISelfieRepository : IRepository
    {
        ICollection<Selfie> GetAll(int? wookieId);
        Selfie AddOne(Selfie item);
        Picture AddOne(string url);
    }
}
