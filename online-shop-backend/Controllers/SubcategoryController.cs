using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers
{
    [Route("/api/subcategory")]
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoriesRepository subcategoriesRepository;

        public SubcategoryController(ISubcategoriesRepository subcategoriesRepository)
        {
            this.subcategoriesRepository = subcategoriesRepository;
        }
        
        [HttpGet]
        public ICollection<Subcategory> Index()
        {
            return subcategoriesRepository.GetAllSubcategories();
        }

        [HttpGet("{id:required}")]
        public SubcategoryPageDTO Subcategory(int id, int? page, int? limit)
        {
            var result = new SubcategoryPageDTO
            {
                Subcategory = subcategoriesRepository.GetSubcategory(id),
                Products = subcategoriesRepository.GetProductsForSubcategory(id, page ?? 1, limit ?? 20)
            };

            return result;
        }
    }
}