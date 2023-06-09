﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(p);
            if(results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
