using System;
using System.Collections.Generic;
using System.Text;

namespace supX.FileHandler
{
    /// <summary>
    /// Filehandler 
    /// </summary>
    public static class FileHandler
    {
        #region Public methods
        /// <summary>
        /// Method to save Json files - not used yet. But we were planning to use it in the future to save high score and to update fighter records.
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool Save(object objectToSave, string filename)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectToSave, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(filename, json);
            return true;
        }
        /// <summary>
        /// Method to open Json files
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T Open<T>(string filename)
        {
            string data = System.IO.File.ReadAllText(filename);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }
        #endregion
    }
}
