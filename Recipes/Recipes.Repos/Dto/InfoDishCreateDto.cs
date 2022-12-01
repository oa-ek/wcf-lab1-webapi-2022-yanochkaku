using Recipes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Repos.Dto
{
    public class InfoDishCreateDto
    {
        public int? Id { get; set; }

        public string? Title { get; set; }

        public string? IconPath { get; set; }

        public string? Difficulty { get; set; }

        public string? CookingTime { get; set; }

        public string? Ingredients { get; set; }

        public string? Preparation { get; set; }

        public Category? Categories { get; set; }

    }
}
