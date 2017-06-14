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
