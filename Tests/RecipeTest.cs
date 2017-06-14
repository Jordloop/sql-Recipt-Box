using Xunit;
using RecipeBox.Objects;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBox
{
  [Collection("RecipeBox")]

  public class RecipeTest : IDisposable
  {
    public RecipeTest()
    {
    DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=recipebox_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Recipe_DatebaseIsEmpty_True()
    {
      //Arrange
      List<Recipe> expectedList = new List<Recipe>{};
      List<Recipe> actualList = Recipe.GetAll();

      //Assert
      Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public void Equal_RecipesAreTheSame_True()
    {
      Recipe firstRecipe = new Recipe("Soup", "Heat up soup.");
      Recipe secondRecipe = new Recipe("Soup", "Heat up soup.");

      Assert.Equal(firstRecipe, secondRecipe);
    }

    public void Dispose()
    {
      Recipe.DeleteAll();
    }


  }
}
