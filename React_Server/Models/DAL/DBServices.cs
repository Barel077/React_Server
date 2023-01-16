using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging.Abstractions;
using React_Server.Models;
using System.Net;
using React_Server.Controllers;

namespace Server.Models.DAL
{
    public class DBServices
    {
        //---------------------------------------------------------------------------------------------------------------------------//
        //General DB Functions//
        //---------------------------------------------------------------------------------------------------------------------------//
        public SqlConnection connect(String conString)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            string cStr = configuration.GetConnectionString("myProjDB");
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }




        ///////////////////////////Functions for getting all INGREDIENTS
        public List<Ingredient> GetIngs()
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            { con = connect("myProjDB"); }
            catch (Exception ex)
            { throw (ex); }

            cmd = SP_GetIngs(con);

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                List<Ingredient> tempList = new List<Ingredient>();

                while (dataReader.Read())
                {
                    Ingredient tmpIng = new Ingredient();
                    tmpIng.Id = Convert.ToInt32(dataReader["id"]);
                    tmpIng.Name = (dataReader["name"]).ToString();
                    tmpIng.Image = (dataReader["image"]).ToString();
                    tmpIng.Cal = Convert.ToInt32(dataReader["cal"]);
                    tempList.Add(tmpIng);
                }
                return tempList;
            }
            catch (Exception ex)
            { throw (ex); }

            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        private SqlCommand SP_GetIngs(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "React_GetIngs";
            cmd.CommandTimeout = 10;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }
        ////////////////////////////////////////////////////////////////




        ///////////////////////////Functions for getting all RECIPES
        public List<Recipe> GetRecs()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlCommand cmd1;

            try
            { con = connect("myProjDB"); }
            catch (Exception ex)
            { throw (ex); }

            cmd = SP_GetRecs(con);
            
            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                List<Recipe> tempList = new List<Recipe>();

                while (dataReader.Read())
                {
                    Recipe tmpRec = new Recipe();
                    tmpRec.Id = Convert.ToInt32(dataReader["id"]);
                    tmpRec.Name = (dataReader["name"]).ToString();
                    tmpRec.Image = (dataReader["image"]).ToString();
                    tmpRec.CookingMethod = (dataReader["cookingMethod"]).ToString();
                    tmpRec.Time = Convert.ToInt32(dataReader["time"]);
                    tempList.Add(tmpRec);
                }
                return tempList;
            }
            catch (Exception ex)
            { throw (ex); }

            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        private SqlCommand SP_GetRecs(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "React_GetRecs";
            cmd.CommandTimeout = 10;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }
        ////////////////////////////////////////////////////////////




        ///////////////////////////Functions for inserting a RECIPE
        public bool PostRec(Recipe recipe, ref int id)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            { con = connect("myProjDB"); }
            catch (Exception ex)
            { throw (ex); }

            cmd = SP_PostRec(con, recipe);

            try
            {
                int numEffected = cmd.ExecuteNonQuery();
                if (numEffected == 1)
                {
                    cmd = SP_GetLastRec(con);
                    SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dataReader.Read())
                    {
                        id = Convert.ToInt32(dataReader["id"]);
                    }
                    return true;

                }
                else return false;
            }

            catch (Exception ex)
            { throw (ex); }

            finally
            {
                if (con != null)
                    con.Close();

            }

        }

        private SqlCommand SP_PostRec(SqlConnection con, Recipe recipe)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "React_PostRec";
            cmd.CommandTimeout = 10;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", recipe.Name);
            cmd.Parameters.AddWithValue("@image", recipe.Image);
            cmd.Parameters.AddWithValue("@cookingMethod", recipe.CookingMethod);
            cmd.Parameters.AddWithValue("@time", recipe.Time);
            return cmd;
        }

        private SqlCommand SP_GetLastRec(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "React_GetLastRec";
            cmd.CommandTimeout = 10;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }

        public bool PostRecIngs(Recipe recipe, Ingredient ing)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            { con = connect("myProjDB"); }
            catch (Exception ex)
            { throw (ex); }

            cmd = SP_PostRecIngs(con, recipe, ing);

            try
            {
                int numEffected = cmd.ExecuteNonQuery();
                if (numEffected == 1)
                {
                    return true;

                }
                else return false;
            }

            catch (Exception ex)
            { throw (ex); }

            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        private SqlCommand SP_PostRecIngs(SqlConnection con, Recipe recipe, Ingredient ing)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "React_PostRecIngs";
            cmd.CommandTimeout = 10;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@recId", recipe.Id);
            cmd.Parameters.AddWithValue("@ingId", ing.Id);
            return cmd;
        }
        ////////////////////////////////////////////////////////////




        ///////////////////////////Functions for inserting an INGREDIENT
        public bool PostIng(Ingredient ing)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            { con = connect("myProjDB"); }
            catch (Exception ex)
            { throw (ex); }

            cmd = SP_PostIng(con, ing);

            try
            {
                int numEffected = cmd.ExecuteNonQuery();
                if (numEffected == 1)
                {
                    return true;
                }
                else return false;
            }

            catch (Exception ex)
            { throw (ex); }

            finally
            {
                if (con != null)
                    con.Close();

            }

        }

        private SqlCommand SP_PostIng(SqlConnection con, Ingredient ing)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "React_PostIng";
            cmd.CommandTimeout = 10;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", ing.Name);
            cmd.Parameters.AddWithValue("@image", ing.Image);
            cmd.Parameters.AddWithValue("@cal", ing.Cal);

            return cmd;
        }
        ////////////////////////////////////////////////////////////
    }

}
