using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers
{
    [Route("/api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly ISubcategoriesRepository subcategoriesRepository;

        public CategoryController(ICategoriesRepository categoriesRepository, 
            ISubcategoriesRepository subcategoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.subcategoriesRepository = subcategoriesRepository;
        }
        
        [HttpGet]
        public ICollection<Category> Index()
        {
            return categoriesRepository.GetAllCategories();
        }

        [HttpGet("{id:required}")]
        public Category Category(int id)
        {
            var category = categoriesRepository.GetCategory(id);
            category.Subcategories = categoriesRepository.GetSubcategoriesForCategory(id);
            
            return category;
        }
    }
}