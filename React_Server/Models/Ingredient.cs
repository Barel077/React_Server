using Server.Models.DAL;

namespace React_Server.Models
{
    public class Ingredient
    {
        int id;
        string name;
        string image;
        int cal;
        
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public int Cal { get => cal; set => cal = value; }

        static public List<Ingredient> GetIngs()
        {
            DBServices dbs = new DBServices();
            return dbs.GetIngs();
        }

        public bool PostIng()
        {
            DBServices dbs = new DBServices();
            return dbs.PostIng(this);
        }
    }
}
