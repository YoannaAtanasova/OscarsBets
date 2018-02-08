﻿using Microsoft.Practices.Unity;
using MovieScrapper.Business;
using MovieScrapper.Business.Interfaces;
using MovieScrapper.Entities;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace MovieScrapper
{
    public partial class MovieDetails : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {      
            
            RegisterAsyncTask(new PageAsyncTask(LoadMovieDetailsAsync));

            if (HttpContext.Current.User.IsInRole("admin") & Request.QueryString["categoryId"]!=null)
            {
                AddMovieToCategoryButton.Visible = true;
            }
            else
            {
                AddMovieToCategoryButton.Visible = false;
            }

        }

        private async Task LoadMovieDetailsAsync()
        {
            var apiKey = ConfigurationManager.AppSettings["tmdb:ApiKey"];
            var movieClient = new MovieClient(apiKey);
            var id= Request.QueryString["id"];
            var movie = await movieClient.GetMovieAsync(id);

            DetailsView1.DataSource = new Movie[] { movie };
            DetailsView1.DataBind();

            RptCredits.DataSource = movie.Credits;
            RptCredits.DataBind();

            ViewState["Movie"] = movie;
        }

        private async Task LoadMovieCreditsAsync()
        {
            var apiKey = ConfigurationManager.AppSettings["tmdb:ApiKey"];
            var movieClient = new MovieClient(apiKey);
            var id = Request.QueryString["id"];
            var movie = await movieClient.GetMovieAsync(id);

            DetailsView1.DataSource = new Movie[] { movie };
            DetailsView1.DataBind();

            ViewState["Movie"] = movie;

        }

        protected string BuildPosterUrl(string path)
        {
            return "http://image.tmdb.org/t/p/w500" + path;
        }

        protected string BuildProfileUrl(string path)
        {
            return "http://image.tmdb.org/t/p/w92" + path;
        }

        protected string BuildBackUrl()
        {
            
            string backUrl = Request.QueryString["back"];
            return backUrl;
        }

        protected string BuildImdbUrl(string movieId)
        {

            return "http://www.imdb.com/title/" + movieId;
        }

        protected string DisplayYear(string dateString)
        {
            DateTime res;

            if (DateTime.TryParse(dateString, out res))
            {
                return res.Year.ToString();
            }
            else
            {
                return dateString;
            }
        }

        protected void AddMovieToCategoryButton_Click(object sender, EventArgs e)
        {           
            var movie = ViewState["Movie"] as Movie;
            var movieCredit = ViewState["Credit"] as MovieCredit;

            if (movie != null)
            {
                var categoryId = Int32.Parse(Request.QueryString["categoryId"]);
                var categoryService = GetBuisnessService<ICategoryService>();
                categoryService.AddMovieInCategory(categoryId, movie, movieCredit);              

                Response.Redirect("/Admin/EditMoviesInThisCategory?categoryId=" + categoryId);               
            }
        }
        
    }
}