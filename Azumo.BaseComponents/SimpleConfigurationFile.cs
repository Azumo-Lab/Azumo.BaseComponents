//-----------------------------------------------------------------------------------------------
//<Azumo.BaseComponents>
//Copyright (C) <2024>  <Azumi Lab>
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <https://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Azumo.BaseComponents
{
    /// <summary>
    /// 
    /// </summary>
    public static class SimpleConfigurationFile
    {
        /// <summary>
        /// 
        /// </summary>
        private const string PATH = "config";

        /// <summary>
        /// 
        /// </summary>
        private static bool ChangeFlag = false;

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, string> _Configs = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        static SimpleConfigurationFile()
        {
            if (File.Exists(PATH))
            {
                using (FileStream fileStream = new FileStream(PATH, FileMode.Open))
                {
                    while (fileStream.Position < fileStream.Length)
                    {
                        int keySize = fileStream.ReadInt();
                        string keyStr = Encoding.BigEndianUnicode.GetString(fileStream.ReadBytes(keySize));
                        int valueSize = fileStream.ReadInt();
                        string valueStr = Encoding.BigEndianUnicode.GetString(fileStream.ReadBytes(valueSize));

                        _Configs.Add(keyStr, valueStr);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Read(string key)
        {
            return _Configs.TryGetValue(key, out string value) ? value : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Write(string key, string value)
        {
            if (_Configs.ContainsKey(key))
                _Configs[key] = value;
            else
                _Configs.Add(key, value);
            ChangeFlag = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SaveChange()
        {
            if(ChangeFlag)
                using (FileStream fileStream = new FileStream(PATH, FileMode.OpenOrCreate))
                {
                    foreach (var item in _Configs)
                    {
                        byte[] keyBytes = Encoding.BigEndianUnicode.GetBytes(item.Key);
                        byte[] valueBytes = Encoding.BigEndianUnicode.GetBytes(item.Value);
                        fileStream.WriteInt(keyBytes.Length);
                        fileStream.WriteBytes(keyBytes);
                        fileStream.WriteInt(valueBytes.Length);
                        fileStream.WriteBytes(valueBytes);
                    }
                }
        }
    }
}
