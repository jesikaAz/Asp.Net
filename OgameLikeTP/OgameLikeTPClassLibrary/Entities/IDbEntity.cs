using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeTPClassLibrary.Entities
{
    public interface IDbEntity
    {
        long? Id { get; set; }
    }
}
