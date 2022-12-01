using Recipes.Core;
using Recipes.Repos.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Repos
{
    public class InfoDishRepository
    {
        private readonly RecipesContext _ctx;
        public InfoDishRepository(RecipesContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<InfoDish> AddInfoDishAsync(InfoDish infoDish)
        {
            _ctx.InfoDishes.Add(infoDish);
            await _ctx.SaveChangesAsync();
            return _ctx.InfoDishes.Include(x => x.Categories).FirstOrDefault(x => x.Title == infoDish.Title);
            
        }

        public InfoDish GetInfoDish(int id)
        {
            return _ctx.InfoDishes.Include(x => x.Categories).FirstOrDefault(x => x.Id == id);
        }

        public List<InfoDish> GetInfoDishes()
        {
            var infoDishList = _ctx.InfoDishes.Include(x => x.Categories).ToList();
            return infoDishList;
        }

        public async Task DeleteInfoDishAsync(int id)
        {
            _ctx.Remove(GetInfoDish(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateInfoDishAsync(InfoDish updatedInfoDish)
        {
            var infoDish = _ctx.InfoDishes.FirstOrDefault(x => x.Id == updatedInfoDish.Id);
            infoDish.Title = updatedInfoDish.Title;
            infoDish.IconPath = updatedInfoDish.IconPath;
            infoDish.Difficulty = updatedInfoDish.Difficulty;
            infoDish.CookingTime = updatedInfoDish.CookingTime;
            infoDish.Ingredients = updatedInfoDish.Ingredients;
            infoDish.Preparation = updatedInfoDish.Preparation;
            infoDish.Categories = updatedInfoDish.Categories;
            await _ctx.SaveChangesAsync();
        }

        public async Task<InfoDishCreateDto> GetInfoDishDto(int id)
        {
            var i = await _ctx.InfoDishes.Include(x => x.Categories).FirstAsync(x => x.Id == id);

            var infoDishDto = new InfoDishCreateDto
            {
                Id = i.Id,
                Title = i.Title,
                IconPath = i.IconPath,
                Difficulty = i.Difficulty,
                CookingTime = i.CookingTime,
                Ingredients = i.Ingredients,
                Preparation = i.Preparation,
                Categories = i.Categories,
            };
            return infoDishDto;
        }

        public async Task UpdateAsync(InfoDishCreateDto model, string categories)
        {
            var infoDish = _ctx.InfoDishes.Include(x => x.Categories).FirstOrDefault(x => x.Id == model.Id);
            if (infoDish.Title != model.Title)
                infoDish.Title = model.Title;
            if (infoDish.IconPath != model.IconPath)
                infoDish.IconPath = model.IconPath;
            if (infoDish.Difficulty != model.Difficulty)
                infoDish.CookingTime = model.CookingTime;
            if (infoDish.Ingredients != model.Ingredients)
                infoDish.Ingredients = model.Ingredients;
            if (infoDish.Preparation != model.Preparation)
                infoDish.Preparation = model.Preparation;
            if (infoDish.Categories != model.Categories)
                infoDish.Categories = _ctx.Categories.FirstOrDefault(x => x.NameCategory == categories);
            _ctx.SaveChanges();
        }


        public async Task<InfoDishCreateDto> GetInfoDishById(int id)
        {
            var infoDish = await _ctx.InfoDishes.FindAsync(id);
            if(infoDish != null)
            {
                var Details = new InfoDishCreateDto()
                {
                    Id = infoDish.Id,
                    Title = infoDish.Title,
                    IconPath = infoDish.IconPath,
                    Difficulty = infoDish.Difficulty,
                    CookingTime = infoDish.CookingTime,
                    Ingredients = infoDish.Ingredients,
                    Preparation = infoDish.Preparation,
                    Categories = infoDish.Categories,
                };
                return Details;
            }
            return null;
        }
    }
}