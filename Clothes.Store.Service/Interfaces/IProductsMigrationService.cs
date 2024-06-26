﻿using Clothes.Store.Common.Models.Result;
using Clothes.Store.Common.Responses;

namespace Clothes.Store.Service.Interfaces
{
    public interface IProductsMigrationService
    {
        public Task<Result<List<ProductResponse>>> FetchProductsFromWebServiceAsync();

        public  Task<Result<bool>> MigrateProductsAsync();

        public Task<Result<int>> UpdateProductsFromWebServiceAsync();
    }
}
