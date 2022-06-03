namespace Create_Users_DataGrid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;    //DisplayName use this library
    using System.Data.Entity.Spatial;
    using System.Web;               //HttpPostedFilebase use this library
    using System.Linq;
    

    
    public partial class User_Image
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(2000)]
        [DisplayName("Upload Image")]
        public string ImageURL { get; set; }

        public long? NationalID { get; set; }
        [NotMapped]
        public HttpPostedFileBase GetImage { get; set; }

        public static void SaveData(User_Image UI) 
        {
            Model1 Mod = new Model1();
            Mod.User_Image.Add(UI);
            Mod.SaveChanges();
        }

        public static IEnumerable<User_Image> DefaultTable()
        {
            Model1 Mod = new Model1();
            return Mod.User_Image;
        }

        public static IEnumerable<User_Image> SearchedTable(string Field = "UserName", string Search = "Baher")
        {
            Model1 Mod = new Model1();
            if (Field == "NationalID") { IEnumerable<User_Image> UI = Mod.User_Image.Where(ee => ee.NationalID == Int64.Parse(Search)); return UI; }
            else { IEnumerable<User_Image> UI = Mod.User_Image.Where(ee => ee.UserName == Search); return UI; }       
        }

        public static IEnumerable<User_Image> SortedAscTable(string Field = "UserName")
        {
            Model1 Mod = new Model1();
            if (Field == "NationalID") { IEnumerable<User_Image> UI = Mod.User_Image.OrderBy(User_Image => User_Image.NationalID); return UI; }
            else { IEnumerable<User_Image> UI = Mod.User_Image.OrderBy(User_Image => User_Image.UserName); return UI; }      
        }
        public static IEnumerable<User_Image> SortedDecTable(string Field = "UserName")
        {
            Model1 Mod = new Model1();
            if (Field == "NationalID") { IEnumerable<User_Image> UI = Mod.User_Image.OrderByDescending(User_Image => User_Image.NationalID); return UI; }
            else { IEnumerable<User_Image> UI = Mod.User_Image.OrderByDescending(User_Image => User_Image.UserName); return UI; }
        }

        public static string[] Split(string Field)
        {
            string[] arrtemp = Field.Split(':');
            return arrtemp;
        }
    }
}
