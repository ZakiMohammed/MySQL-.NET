using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whale.Data
{
    public class WhaleUnitOfWork : UnitOfWork
    {
        public WhaleUnitOfWork()
        {
            Context = new WhaleContext();
        }
    }
}
