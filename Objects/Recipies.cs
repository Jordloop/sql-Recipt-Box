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

    public Recipe(string Name, string Instructions, int id = 0)
    {
      _name = Name;
      _instructions = Instructions;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newNamel
    }

    public string GetInstructions()
    {
      return _instructions;
    }

    public void SetInstructions(newInstructions)
    {
      _instructions = Instructions;
    }






  }
}
