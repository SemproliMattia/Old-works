using System;
using Microsoft.AspNetCore.Http;

namespace semproli.mattia._5H.SecondaWeb.Models
{
   public class CreatePost
  {
    public IFormFile MyCSV {get;set;}
    public string Descrizione {get;set;}

  }

}