using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace Create_Users_DataGrid.Models
{
    public static class CommonFunction
    {
        #region AutoSave
        public static void AutoSave(User_Image UI, string Directory)
        {
            UI.ImageURL = "../Image/" + SaveImage(UI, Directory);
            User_Image.SaveData(UI);
        }

        public static void AutoSave(User_Image UI, string Directory, string ImageName)
        {
            SaveImage(UI, Directory, ImageName);
            User_Image.SaveData(UI);
        }
        #endregion
        #region GetImageName
        public static string[] GetImageName(User_Image UI) 
        {
            string[] ImageName = Path.GetFileName(UI.GetImage.FileName).Split('.');
            return ImageName;
        }

        public static string GetImageName(User_Image UI, bool FileAutoModifiedSave = false, string SaveFileInProjectDirectory = "Image")
        {
            string[] ImageName = GetImageName(UI);
            ImageName[1] = "../" + SaveFileInProjectDirectory + "/" + foo(ImageName);   //WriteOver index 1
            return ImageName[1];
        }
        #endregion
        # region SaveImage
        public static String SaveImage(User_Image UI, string Directory)
        {
            string[] ImageName = GetImageName(UI);
            string ReturnImageDirectory = foo(ImageName);           //Save it Because the time will change thus Image Name will change also when i call the function again any where else
            string ImageSavePath = Path.Combine(Directory, ReturnImageDirectory);
            UI.GetImage.SaveAs(ImageSavePath);
            return ReturnImageDirectory;
        }

        public static void SaveImage(User_Image UI,string Directory, string ImageName)
        {
            string ImageSavePath = Path.Combine(Directory, ImageName);
            UI.GetImage.SaveAs(ImageSavePath);
        }
        #endregion
        #region Private Member Function
        static string foo(string[] ImageName) { return ImageName[0] + DateTime.Now.ToString("yymmssfff") + '.' + ImageName[1];}
        #endregion

    }
}