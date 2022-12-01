﻿using Recipes.Core;
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

        public string? Ingredients1 { get; set; }
        public string? Ingredients2 { get; set; }
        public string? Ingredients3 { get; set; }
        public string? Ingredients4 { get; set; }
        public string? Ingredients5 { get; set; }
        public string? Ingredients6 { get; set; }
        public string? Ingredients7 { get; set; }
        public string? Ingredients8 { get; set; }

        public string? Preparation1 { get; set; }
        public string? Preparation2 { get; set; }
        public string? Preparation3 { get; set; }
        public string? Preparation4 { get; set; }

        public string?  Categories { get; set; }

    }
}
