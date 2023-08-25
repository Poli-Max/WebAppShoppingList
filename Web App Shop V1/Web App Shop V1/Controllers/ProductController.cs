using System;
using Microsoft.AspNetCore.Mvc;
using Web_App_Shop_V1.DAL.Interfaces;
using Web_App_Shop_V1.Domain.Models;
using Web_App_Shop_V1.Domain.Enum;
using Web_App_Shop_V1.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Web_App_Shop_V1.Domain.ViewModels.Product;

namespace Web_App_Shop_V1.Controllers;

public class ProductController : Controller
{
	private readonly IProductService _productService;

	public ProductController (IProductService productService)
	{
		this._productService = productService;
	}

	[HttpGet]
	public async Task<IActionResult> GetProducts()
	{
		var response = await _productService.GetProductsAll();
		if (response.statusCode == Domain.Enum.StatusCode.OK)
		{
            var productList = response.data ?? new List<Product>();
            return View(productList.ToList());
        }
		
		return RedirectToAction("Error");
	}

    [HttpGet]
    public async Task<IActionResult> GetProduct(int id)
    {
        var response = await _productService.GetProductOne(id);
        if (response.statusCode == Domain.Enum.StatusCode.OK)
		{
            return View(response.data);
        }

        return RedirectToAction("Error");
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
	public async Task<IActionResult> DeleteProduct(int id)
	{
		var response = await _productService.DeleteProduct(id);
		if (response.statusCode == Domain.Enum.StatusCode.OK)
		{
			return RedirectToAction("GetProducts");
		}
		return RedirectToAction("Error");
	}

    [HttpGet]
    public IActionResult CreateProduct()
    {
        var newProductModel = new ProductViewModels();
        return View(newProductModel);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateProduct(ProductViewModels model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProduct(model);
            if (response.statusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetProduct", new { id = response.data.id });
            }
            else
            {
                ModelState.AddModelError("", response.description); // Добавляем ошибку в ModelState
            }
        }
        return View("CreateProduct", model);
    }

    [HttpGet]
    public async Task<IActionResult> EditProduct(int id)
    {
        var response = await _productService.GetProductOne(id);
        if (response.statusCode == Domain.Enum.StatusCode.OK)
        {
            var productViewModel = new ProductViewModels
            {
                id = response.data.id,
                name = response.data.name,
                description = response.data.description,
                price = response.data.price
            };

            return View(productViewModel);
        }

        return RedirectToAction("Error");
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> EditProduct(ProductViewModels model)
	{
        if (ModelState.IsValid)
        {
            var response = await _productService.EditProduct(model.id, model);
            if (response.statusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetProduct", new { id = response.data.id });
            }
            else
            {
                ModelState.AddModelError("", response.description); // Добавляем ошибку в ModelState
            }
        }
        return View("EditProduct", model);
    }

    public async Task<IActionResult> GetProductsSort(string productName, decimal? minPrice, decimal? maxPrice)
    {
        var response = await _productService.GetProductsByFilters(productName, minPrice, maxPrice);
        if (response.statusCode == Domain.Enum.StatusCode.OK)
        {
            return View("GetProducts", response.data);
        }

        return RedirectToAction("Error");
    }
}

