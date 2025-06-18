using Consuming_WebAPI_MVC_App.Models;
using Consuming_WebAPI_MVC_App.Models.DTOs;
using Consuming_WebAPI_MVC_App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Consuming_WebAPI_MVC_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)
        {
                _service = service;
        }

        //public async Task<IActionResult> Index(string searchItem)
        //{
        //    var products = string.IsNullOrEmpty(searchItem) ?
        //        await _service.GetProductsAsync() : await _service.SearchProductByName(searchItem);

        //    ViewBag.SearchItem = searchItem;
        //    return View(products);
        //}

        //public IActionResult Create() => View();

        //[HttpPost]
        //public  async Task<IActionResult> Create(ProductCreationDTO productDTO)
        //{
        //    await _service.CreateProduct(productDTO);
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var product= await _service.GetProductById(id);
        //    return View(product);
        //}
        //public async Task<IActionResult> Details(int id)
        //{
        //    var product = await _service.GetProductById(id);
        //    return View(product);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id,ProductUpdateDTO productDTO)
        //{
        //    await _service.UpdateProductAsync(id, productDTO);
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var product = await _service.GetProductById(id);
        //    return View(product);
        //}

        //[HttpPost,ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _service.DeleteProduct(id);
        //    return RedirectToAction("Index");
        //}
     

            // Index action to list all products or search by name
            public async Task<IActionResult> Index(string searchItem)
            {
                // Check if searchItem is provided, if not, fetch all products
                var products = string.IsNullOrEmpty(searchItem) ?
                    await _service.GetProductsAsync() : await _service.SearchProductByName(searchItem);

                // Passing the search item to the ViewBag to show in the search box
                ViewBag.SearchItem = searchItem;

                // Return the products to the view
                return View(products);
            }

            // Create action to show create form
            public IActionResult Create() => View();

            // POST: Create a new product
            [HttpPost]
            public async Task<IActionResult> Create(ProductCreationDTO productDTO)
            {
                // Call the service to add the product
                var result = await _service.CreateProduct(productDTO);
                if (result != null)
                {
                    // If the product is created successfully, redirect to the Index page
                    return RedirectToAction("Index");
                }

                // If there’s an error, stay on the create page
                return View(productDTO);
            }

            // Edit action to show the edit form for a specific product
            public async Task<IActionResult> Edit(int id)
            {
                // Get product by ID
                var product = await _service.GetProductById(id);
                return View(product);
            }

            // POST: Update product details
            [HttpPost]
            public async Task<IActionResult> Edit(int id, ProductUpdateDTO productDTO)
            {
                // Call the service to update the product
                var result = await _service.UpdateProductAsync(id, productDTO);
                if (result != null)
                {
                    // If successful, redirect to Index page
                    return RedirectToAction("Index");
                }

                // If there’s an error, stay on the edit page
                return View(productDTO);
            }

            // Details action to show detailed information about a product
            public async Task<IActionResult> Details(int id)
            {
                // Get product by ID
                var product = await _service.GetProductById(id);
                return View(product);
            }

            // Delete action to show delete confirmation
            public async Task<IActionResult> Delete(int id)
            {
                // Get product by ID
                var product = await _service.GetProductById(id);
                return View(product);
            }

            // POST: Confirm deletion of product
            [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                // Call the service to delete the product
                var result = await _service.DeleteProduct(id);
                if (result != null)
                {
                    // If deletion is successful, redirect to Index page
                    return RedirectToAction("Index");
                }

                // If there’s an error, redirect back to the delete confirmation page
                return RedirectToAction("Delete", new { id = id });
            }
        }
    }


