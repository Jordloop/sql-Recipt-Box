using Xunit;
using AirlinePlanner.Objects;
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
    public void Recipe_DatebaseIsEmpty_True
    {
      //Arrange
      List<Recipe> expectedList = new List<Recipe>{};
      List<Recipe> actualList = Recipe.GetAll();

      //Assert
      Assert.Equal(expectedList, actualList);
    }

    public void Dispose()
    {
      Recipe.DeleteAll();
    }
  }
}
