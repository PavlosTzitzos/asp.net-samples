using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebApp1CoreMVC.Models;

namespace WebApp1CoreMVC.Models;

/// <summary>
/// Model used to search by genre
/// </summary>
public class MovieGenreViewModel
{
    public List<Movie>? Movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
}