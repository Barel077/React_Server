using Microsoft.AspNetCore.SignalR;
using Server.Models.DAL;
using System;

namespace React_Server.Models
{
    public class Recipe
    {
        int id;
        string name;
        string image;
        string cookingMethod;
        Ingredient[] ings;
        int time;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string CookingMethod { get => cookingMethod; set => cookingMethod = value; }
        public int Time { get => time; set => time = value; }
        public Ingredient[] Ings { get => ings; set => ings = value; }

        static public List<Recipe> GetRecs()
        {
            DBServices dbs = new DBServices();
            return dbs.GetRecs();
        }

        public bool PostRec()
        {
            DBServices dbs = new DBServices();
            bool b = true;
            int id = 0;
            bool a  = dbs.PostRec(this, ref id);
            if (a == false)
                return false;
            else { 
                this.id = id;
             foreach (var ing in this.Ings)
               b =  dbs.PostRecIngs(this, ing);
            }
            if (b == false)
                return false;
            else
                return true;
        }
    }
}
