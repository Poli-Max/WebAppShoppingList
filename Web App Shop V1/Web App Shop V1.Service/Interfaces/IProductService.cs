using System;
using Web_App_Shop_V1.Domain.Models;
using Web_App_Shop_V1.Domain.Response;
using Web_App_Shop_V1.Domain.ViewModels.Product;

namespace Web_App_Shop_V1.Service.Interfaces;

public interface IProductService
{
    Task<IBaseResponse<Product>> GetProductOne(int id);
    Task<IBaseResponse<IEnumerable<Product>>> GetProductsAll();
    Task<IBaseResponse<List<Product>>> GetProductsByFilters(string productName, decimal? minPrice, decimal? maxPrice);
    Task<IBaseResponse<ProductViewModels>> CreateProduct(ProductViewModels productViewModels);
    Task<IBaseResponse<bool>> DeleteProduct(int id);
    Task<IBaseResponse<Product>> EditProduct(int id, ProductViewModels model);
}

