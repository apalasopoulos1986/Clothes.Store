﻿using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Responses;
using Clothes.Store.Db.DbEntities;

namespace Clothes.Store.Db.Interfaces
{
    public interface IProductRepository
    {
        public Task<Result<IEnumerable<Product>>> GetProductsFromDb();
        public Task<Result<bool>> InsertProductsAsync(IEnumerable<ProductResponse> productResponses);
    }
}
