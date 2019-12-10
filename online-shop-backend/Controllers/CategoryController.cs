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

        public CategoryController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }
        
        [HttpGet]
        public ICollection<Category> Index()
        {
            return categoriesRepository.GetAllCategories();
        }

        [HttpGet("{id:required}")]
        public Category Category(int id)
        {
            return categoriesRepository.GetCategory(id);
        }
    }
}