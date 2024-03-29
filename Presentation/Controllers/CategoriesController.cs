﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategory([FromRoute] int id)
        {
            var category = await _manager.CategoryService.GetOneCategoryAsync(id, false);
            return Ok(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _manager.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }
    }
}
