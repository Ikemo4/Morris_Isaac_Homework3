﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Morris_Isaac_Homework3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Morris_Isaac_Homework3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext con)
        {
            _logger = logger;
            context = con;
        }

        //Index Page Action
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movieResponse);
                context.SaveChanges();
                return RedirectToAction("Movies");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Movies()
        {
            return View(context.Movies);
        }

        //Edit Action that takes user to Edit page and allows
        //them to edit selected movie
        [HttpPost]
        public IActionResult Edit(int movieID)
        {
            //Find correct movie to update from context by comparing to
            //movieID parameter. Set equal to variable movie
            var movie = context.Movies
                .FirstOrDefault(m => m.MovieID == movieID);

            //pass Movie object to Edit view
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(MovieResponse movie)
        {
            context.Movies.Update(movie);
            context.SaveChanges();

            return RedirectToAction("Movies");
        }

        //Delete Action to delete selected movie
        public IActionResult Delete(int movieID)
        {
            //assign Movie object that matches movieID (parameter passed in by delete button)
            //to movie variable
            var movie = context.Movies
                .FirstOrDefault(m => m.MovieID == movieID);
            //remove Movie from database
            context.Movies.Remove(movie);
            context.SaveChanges();

            return RedirectToAction("Movies");
        }

        //Podcasts Page Action
        public IActionResult Podcasts()
        {
            return View();
        }

        //Privacy Page Action
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
