using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Controllers
{
    public class Menu
    {
        public int Menu_ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Parent_ID { get; set; }
        public bool isDisable { get; set; }
        public bool isDisplay { get; set; }
        public string   RedirectController { get; set; }
        public string RedirectAction { get; set; }
        public int Module_ID { get; set; }


        public List<Menu> Get_All_Menu()
        {
            List<Menu> lst = new List<Menu>();

            SqlCommand sc = new SqlCommand("Menu_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_ID", 60);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Menu u = new Menu();
                u.Menu_ID = (int)sdr[0];
                u.Name = (string)sdr[1];
                u.Text = (string)sdr[2];
                u.Parent_ID = (int)sdr[3];
                u.isDisable = (bool)sdr[4];
                u.isDisplay= (bool)sdr[5];
                u.RedirectController= (string)sdr[6];
                u.RedirectAction= (string)sdr[7];
                u.Module_ID= (int)sdr[8];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

    }
}