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
        private static string Path { get; } = "config";

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, string> _Configs = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            using (StreamReader sr = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate)))
            {
                string line = sr.ReadLine();
                var strs = line.Split('=', options: StringSplitOptions.RemoveEmptyEntries);
                if (strs.Length == 1)
                    _Configs.Add(strs[0], string.Empty);

                if (strs.Length == 2)
                {
                    bool flag = false;
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (char item in strs[1])
                    {
                        if (item == '"')
                        {
                            flag = !flag;
                            continue;
                        }
                        if (flag)
                            stringBuilder.Append(item);
                    }
                    if (flag)
                        throw new FormatException("Invalid format");
                    _Configs.Add(strs[0], stringBuilder.ToString());
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
        }

        /// <summary>
        /// 
        /// </summary>
        public static void End()
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(Path, FileMode.OpenOrCreate)))
            {
                foreach (var item in _Configs)
                {
                    sw.WriteLine(item.Key + "=\"" + item.Value + "\"");
                }
            }
        }
    }
}
