using Clothes.Store.Common.Models.Result;
using Clothes.Store.Db.DbEntities;

namespace Clothes.Store.Db.Interfaces
{
    public interface IProductRepository
    {
        public Task<Result<IEnumerable<Product>>> GetProductsFromDb();
    }
}
