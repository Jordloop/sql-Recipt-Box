using Xunit;
using RecipeBox.Objects;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBox
{
  [Collection("RecipeBox")]

  public class TagTests : IDisposable
  {
    public TagTests()
    {
    DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=recipebox_test;Integrated Security=SSPI;";
    }


    [Fact]
    public void Tag_DatebaseIsEmpty_True()
    {
      //Arrange
      List<Tag> expectedList = new List<Tag>{};
      List<Tag> actualList = Tag.GetAll();

      //Assert
      Assert.Equal(expectedList, actualList);
    }

    [Fact]
    public void Equal_TagsAreTheSame_True()
    {
      Tag firstTag = new Tag("Soup");
      Tag secondTag = new Tag("Soup");

      Assert.Equal(firstTag, secondTag);
    }

    public void Dispose()
    {
      Tag.DeleteAll();
    }


  }
}
