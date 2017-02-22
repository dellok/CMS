using LL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model;
using System.Data;
using System.Data.SqlClient;
using LL.DAL;
namespace LL.BLL
{
 public abstract    class ServiceBase<TAggregateRoot>:Repository<TAggregateRoot>,IRepository<TAggregateRoot>  where  TAggregateRoot:class,IAggregateRoot
    {

        

    }
}
