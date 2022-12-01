using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Recipes.Core;
using Microsoft.EntityFrameworkCore;

namespace Recipes.UI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly RecipesContext _context;

        public SearchController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/<SearchController>
        [HttpGet("{title}/{difficulty}/{cookingTime}")]
        public async Task<IEnumerable<InfoDish>> Get(string title, string difficulty, string cookingTime)
        {
            IEnumerable<InfoDish> dishes = null;

            string Difficulty = difficulty;
            string CookingTime = cookingTime;
            //Category Categories = categories;

            if (!title.Equals(""))
            {
                dishes = await _context.InfoDishes
                    .Where(o => o.Title == title && o.CookingTime == cookingTime && o.Difficulty == difficulty)
                    .Select(o => new InfoDish
                    {
                        Id = o.Id,
                        Title = o.Title,
                        IconPath = o.IconPath,
                        Difficulty = o.Difficulty,
                        CookingTime = o.CookingTime,
                        Ingredients = o.Ingredients,
                        Preparation = o.Preparation,
                        //Categories = o.Categories
                       
                    })
                    .ToListAsync();
            }

            return dishes;
        }
    }
}
