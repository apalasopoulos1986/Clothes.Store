﻿using Clothes.Store.Common.Models;
using Clothes.Store.Common.Responses;
using Newtonsoft.Json;


namespace Clothes.Store.Service.Extensions
{
    public static class JsonExtensions
    {
        public static List<ProductResponse> TransformProducts(string json)
        {

            var products = JsonConvert.DeserializeObject<List<ProductResponse>>(json, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return products;

        }


        public static List<UserResponse> TransformUsers(string json)
        {

            var rootObject = JsonConvert.DeserializeObject<UserRootObject>(json, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return rootObject?.Users;

        }


    }
}
