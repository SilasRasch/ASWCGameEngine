using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.Interfaces
{
    public interface IGameObject
    {
        int Id { get; set; }
        Position Position { get; set; }
    }
}
