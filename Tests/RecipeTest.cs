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

    [Fact]
    public void Save_RecipeIsSavedToDatabase_True()
    {
      //Arrange
      Recipe newRecipe = new Recipe("Soup", "Heat up Soup");
      //Act
      newRecipe.Save();
      Recipe savedRecipe = Recipe.GetAll()[0];
      //Assert
      Assert.Equal(newRecipe, savedRecipe);
    }

    [Fact]
    public void AddTag_AddTagsToOneRecipe_True()
    {
      //Arrange
      Recipe testRecipe = new Recipe("Soup", "Heat up Soup");
      testRecipe.Save();

      Tag firstTag = new Tag("Hearty");
      firstTag.Save();
      Tag secondTag = new Tag("Soupy");
      secondTag.Save();
      //Act
      testRecipe.AddTag(firstTag);
      testRecipe.AddTag(secondTag);

      List<Tag> result = testRecipe.GetTags();
      List<Tag> testList = new List<Tag>{firstTag, secondTag};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void GetTags_ReturnsAllTagsFromOneRecipe_True()
    {
      //Arrange
      Recipe testRecipe = new Recipe("Soup", "Heat that soup!");
      testRecipe.Save();

      Tag firstTag = new Tag("Hearty");
      firstTag.Save();
      Tag secondTag = new Tag("Soupy");
      secondTag.Save();
      //Act
      testRecipe.AddTag(firstTag);
      testRecipe.AddTag(secondTag);
      List<Tag> testTags = testRecipe.GetTags();
      List<Tag> contolTags = new List<Tag>{firstTag, secondTag};
      //Assert
      Assert.Equal(contolTags, testTags);
    }

    public void Dispose()
    {
      Recipe.DeleteAll();
    }


  }
}
