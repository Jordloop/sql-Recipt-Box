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

    [Fact]
    public void Save_TagIsSavedToDatabase_True()
    {
      //Arrange
      Tag newTag = new Tag("Soup");
      //Act
      newTag.Save();
      Tag savedTag = Tag.GetAll()[0];
      //Assert
      Assert.Equal(newTag, savedTag);
    }

    [Fact]
    public void AddRecipe_AddRecipesToOneTag_True()
    {
      //Arrange
      Tag testTag = new Tag("Funky");
      testTag.Save();

      Recipe firstRecipe = new Recipe("Soup", "Heat up soup.");
      firstRecipe.Save();
      Recipe secondRecipe = new Recipe("Pizza", "Eat that pizza.");
      secondRecipe.Save();
      //Act
      testTag.AddRecipe(firstRecipe);
      testTag.AddRecipe(secondRecipe);

      List<Recipe> result = testTag.GetRecipe();
      List<Recipe> testList = new List<Recipe>{firstRecipe, secondRecipe};
      //Assert
      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Tag.DeleteAll();
    }


  }
}
