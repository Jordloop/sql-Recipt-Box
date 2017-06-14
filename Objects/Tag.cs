using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RecipeBox.Objects
{
  public class Tag
  {
    private int _id;
    private string _name;

    public Tag(string Name, int Id = 0)
    {
      _name = Name;
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
//SETTERS
    public void SetId(int newId)
    {
      _id = newId;
    }


    public void SetName(string newName)
    {
      _name = newName;
    }

//EQUALS OVERRIDE
    public override bool Equals(System.Object otherTag)
    {
      if(!(otherTag is Tag))
      {
        return false;
      }
      else
      {
        Tag newTag = (Tag) otherTag;
        bool nameEquality = this.GetName() == newTag.GetName();
        bool idEquality = this.GetId() == newTag.GetId();

        return (nameEquality && idEquality);
      }
    }

//CLASS METHODS

    public static List<Tag> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tags;", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Tag> allTags = new List<Tag>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);

        Tag newTag = new Tag(name, id);
        allTags.Add(newTag);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allTags;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO tags (name) OUTPUT INSERTED.id VALUES (@Name)", conn);

      SqlParameter nameParam = new SqlParameter("@Name", this.GetName());
      cmd.Parameters.Add(nameParam);

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

    public void AddRecipe(Recipe newRecipe)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INERT INTO join_recipes_tags(recipe_id, tag_id) VALUES (@RecipeId, @TagId);", conn);

      SqlParameter RecipeIdParam = new SqlParameter();
      RecipeIdParam.ParameterName = "@RecipeId";
      RecipeIdParam.Value = newTag.GetId();
      cmd.Parameters.Add(RecipeIdParam);

      SqlParameter TagIdParam = new SqlParameter();
      TagIdParam.ParameterName = "@TagId";
      TagIdParam.Value = this.GetId();
      cmd.Parameters.Add(TagIdParam);

      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM tags;", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }


  }
}
