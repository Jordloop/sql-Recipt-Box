using Nancy;
using System.Collections.Generic;
using System;

namespace RecipeBox
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => "Hey you";
    }
  }
}
