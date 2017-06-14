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

    public int GetId()
    {
        return _id;
    }

    public void SetId(newId)
    {
      _id = newId;
    }

    public int GetName()
    {
        return _name;
    }

    public void SetName(newName)
    {
      _name = newName;
    }



  }
}
