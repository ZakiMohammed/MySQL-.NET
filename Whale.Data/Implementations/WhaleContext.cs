using System.Data;
using System.Data.Entity;
using Whale.Model;

namespace Whale.Data
{
    public class WhaleContext : BaseContext<WhaleContext>, IWhaleContext
    {
        public IDbSet<Post> Posts { get; set; }
    }
}
