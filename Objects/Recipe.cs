using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RecipeBox.Objects
{
  public class Recipe
  {
    private int _id;
    private string _name;
    private string _instructions;

    public Recipe(string Name, string Instructions, int Id = 0)
    {
      _name = Name;
      _instructions = Instructions;
      _id = Id;
    }

//GETTERS
    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetInstructions()
    {
      return _instructions;
    }
//SETTERS
    public void SetId(int newId)
    {
      _id = newId;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }


    public void SetInstructions(string newInstructions)
    {
      _instructions = newInstructions;
    }

//EQUALS OVERRIDE
    public override bool Equals(System.Object otherRecipe)
    {
      if(!(otherRecipe is Recipe))
      {
        return false;
      }
      else
      {
        Recipe newRecipe = (Recipe) otherRecipe;
        bool nameEquality = this.GetName() == newRecipe.GetName();
        bool instructionsEquality = this.GetInstructions() == newRecipe.GetInstructions();
        bool idEquality = this.GetId() == newRecipe.GetId();

        return (nameEquality && instructionsEquality && idEquality);
      }
    }

//CLASS METHODS

    public static List<Recipe> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM recipes;", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Recipe> allRecipes = new List<Recipe>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string instructions = rdr.GetString(2);

        Recipe newRecipe = new Recipe(name, instructions, id);
        allRecipes.Add(newRecipe);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allRecipes;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO recipes (name, instructions) OUTPUT INSERTED.id VALUES (@Name, @Instructions)", conn);

      SqlParameter nameParam = new SqlParameter("@Name", this.GetName());
      cmd.Parameters.Add(nameParam);
      SqlParameter instructionsParam = new SqlParameter("@Instructions", this.GetInstructions());
      cmd.Parameters.Add(instructionsParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }

      if(rdr !=null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void AddTag(Tag newTag)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO join_recipes_tags(id_recipes, id_tags) VALUES (@RecipeId, @TagId)", conn);

      SqlParameter RecipeIdParam = new SqlParameter();
      RecipeIdParam.ParameterName = "@RecipeId";
      RecipeIdParam.Value = this.GetId();
      cmd.Parameters.Add(RecipeIdParam);

      SqlParameter TagIdParam = new SqlParameter();
      TagIdParam.ParameterName = "@TagId";
      TagIdParam.Value = newTag.GetId();
      cmd.Parameters.Add(TagIdParam);

      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }

    public List<Tag> GetTags()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT tags.* FROM recipes JOIN join_recipes_tags ON (recipes.id = join_recipes_tags.id_recipes) JOIN tags ON (tags.id = join_recipes_tags.id_tags) WHERE recipes.id = @RecipeId", conn);

      SqlParameter RecipeIdParam = new SqlParameter();
      RecipeIdParam.ParameterName = "@RecipeId";
      RecipeIdParam.Value = this.GetId().ToString();

      cmd.Parameters.Add(RecipeIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Tag> tags = new List<Tag>{};

      while(rdr.Read())
      {
        int tagId = rdr.GetInt32(0);
        string tagName = rdr.GetString(1);

        Tag newTag = new Tag(tagName, tagId);
        tags.Add(newTag);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return tags;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM recipes;", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }

  }
}
