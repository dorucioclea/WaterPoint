using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Bll.Interfaces;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Repository;

namespace WaterPoint.Data.Bll
{
    public class SupplierBll : BllBase, ISupplierBll
    {
        public SupplierBll(IRepository repo)
            : base(repo)
        {

        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await Task.Run<IEnumerable<Supplier>>(() =>
            {
                return Repo.ListAsync<Supplier>("select * from supplier where id < @id", new { id = 10 });
            });
        }
    }
}
