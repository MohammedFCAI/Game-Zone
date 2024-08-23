﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categories.Select(c => new SelectListItem()
            { Value = c.Id.ToString(), Text = c.Name })
                .AsNoTracking().OrderBy(c => c.Text).ToList();
        }
    }
}