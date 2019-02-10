using System.Data.Entity;
using Whale.Model;

namespace Whale.Data
{
    public interface IWhaleContext
    {
        IDbSet<Post> Posts { get; set; }
    }
}
