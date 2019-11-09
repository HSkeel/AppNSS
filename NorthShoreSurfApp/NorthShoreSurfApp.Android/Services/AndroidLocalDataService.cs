using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NorthShoreSurfApp.Database;
using NorthShoreSurfApp.Droid.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidLocalDataService))]
namespace NorthShoreSurfApp.Droid.Services
{
    public class AndroidLocalDataService : ILocalDataService
    {
        /*****************************************************************/
        // PROPERTIES
        /*****************************************************************/
        #region Properties

        private string RootFolderPath { get; set; }
        public ISharedPreferences SharedPreferences { get; set; }

        #endregion

        /*****************************************************************/
        // CONSTRUCTOR
        /*****************************************************************/
        #region Constructor

        public AndroidLocalDataService()
        {
            RootFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            SharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
        }

        #endregion

        /*****************************************************************/
        // INTERFACE METHODS
        /*****************************************************************/
        #region Interface methods

        /// <summary>
        /// Initialize files by moving them from embedded resource into the root of the apps personal folder
        /// </summary>
        /// <param name="force">If true no check if the files already exist they will just be overwritten</param>
        public void InitializeFiles(bool force)
        {
            foreach (var fileName in LocalDataFiles.AllFiles)
            {
                try
                {
                    var path = Path.Combine(RootFolderPath, fileName);
                    if (force || !File.Exists(path))
                    {
                        using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(fileName)))
                        {
                            using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                            {
                                byte[] buffer = new byte[2048];
                                int length = 0;
                                while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    binaryWriter.Write(buffer, 0, length);
                                }
                            }
                        }
                    }
                } catch { }
            }
        }

        /// <summary>
        /// Read contents of a file
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns></returns>
        public string ReadFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(RootFolderPath, fileName);
                return !File.Exists(filePath) ? null : File.ReadAllText(filePath);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Write contents to a file
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <param name="content">Contents to be saved in a file</param>
        /// <param name="append">If true append at the end of the file else. If false overwrite existing content</param>
        public void WriteToFile(string fileName, string content, bool append)
        {
            try
            {
                string filePath = Path.Combine(RootFolderPath, fileName);
                if (append)
                    File.AppendAllText(filePath, content);
                else
                    File.WriteAllText(filePath, content);
            }
            catch { }           
        }

        /// <summary>
        /// Save value on phone
        /// </summary>
        /// <param name="key">Key for value</param>
        /// <param name="value">Value to be saved</param>
        public void SaveValue(string key, string value)
        {
            ISharedPreferencesEditor editor = SharedPreferences.Edit();
            editor.PutString(key, value);
            editor.Apply();        
        }

        /// <summary>
        /// Get value from key
        /// </summary>
        /// <param name="key">Key for a value</param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return SharedPreferences.GetString(key, null);
        }

        #endregion
    }
}