using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MagasLib.SaveSystem
{
    public class SaveData
    {    
        /// <summary>
        /// Save object with a string identifier
        /// </summary>
        /// <typeparam name="T">Type of object to save</typeparam>
        /// <param name="objectToSave">Object to save</param>
        /// <param name="key">String identifier for the data to load</param>
        public static void Save<T>(T objectToSave, string key)where T : struct
        {
            SaveToFile<T>(objectToSave, key);
        }

//        /// <summary>
//        /// Save object with a string identifier
//        /// </summary>
//        /// <param name="objectToSave">Object to save</param>
//        /// <param name="key">String identifier for the data to load</param>
//        public static void Save(Object objectToSave, string key)
//        {
//            SaveToFile<Object>(objectToSave, key);
//        }

        /// <summary>
        /// Handle saving data to File
        /// </summary>
        /// <typeparam name="T">Type of object to save</typeparam>
        /// <param name="objectToSave">Object to serialize</param>
        /// <param name="fileName">Name of file to save to</param>
        private static void SaveToFile<T>(T objectToSave, string fileName)where T : struct
        {
            // Set the path to the persistent data path (works on most devices by default)
            string path = Application.persistentDataPath + "/saves/";
            // Create the directory IF it doesn't already exist
            Directory.CreateDirectory(path);
            // Grab an instance of the BinaryFormatter that will handle serializing our data
            BinaryFormatter formatter = new BinaryFormatter();
            // Open up a filestream, combining the path and object key
            FileStream fileStream = new FileStream(path + fileName + ".ryl", FileMode.Create);

            // Try/Catch/Finally block that will attempt to serialize/write-to-stream, closing stream when complete
            try
            {
                formatter.Serialize(fileStream, objectToSave);
            }
            catch (SerializationException exception)
            {
                Debug.Log("Save failed. Error: " + exception.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }

        /// <summary>
        /// Load data using a string identifier
        /// </summary>
        /// <typeparam name="T">Type of object to load</typeparam>
        /// <param name="key">String identifier for the data to load</param>
        /// <returns></returns>
        public static Nullable<T> Load<T>(string key) where T : struct
        {
            // Set the path to the persistent data path (works on most devices by default)
            string path = Application.persistentDataPath + "/saves/";
            // Grab an instance of the BinaryFormatter that will handle serializing our data
            BinaryFormatter formatter = new BinaryFormatter();
            T returnValue = default(T);
            // Open up a filestream, combining the path and object key
            if (File.Exists(@path + key + ".ryl"))
            {
               
                FileStream fileStream = new FileStream(path + key + ".ryl", FileMode.Open);
                // Initialize a variable with the default value of whatever type we're using
               
                /* 
             * Try/Catch/Finally block that will attempt to deserialize the data
             * If we fail to successfully deserialize the data, we'll just return the default value for Type
             */
                try
                {
                    returnValue = (T) formatter.Deserialize(fileStream);
                }
                catch (SerializationException exception)
                {
                    Debug.Log("Load failed. Error: " + exception.Message);
                }
                finally
                {
                    fileStream.Close();
                }
                return returnValue;
            }

            return null;
        }
    }
}
