using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whale.Data;
using Whale.Model;

namespace Whale.Repository
{
    public class ApplicationRepository
    {
        public IEnumerable<Post> GetPostAll()
        {
            using (var uow = new WhaleUnitOfWork())
            {
                var repo = new GenericRepository<Post>();
                repo.UnitOfWork = uow;
                return repo.GetAll();
            }
        }
    }
}
