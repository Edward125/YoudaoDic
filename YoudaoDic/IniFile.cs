using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace YoudaoDic
{
    class IniFile
    {
        #region declare Read_Write ini file API

        [DllImport("kernel32")]
        private  static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private  static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);
        #endregion

        #region Write INI file
        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <param name="iValue">值</param>

        public static void IniWriteValue(string section, string key, string iValue, string filePath)
        {
            WritePrivateProfileString(section, key, iValue, filePath);
        }
        #endregion

        #region Read INI file

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <returns>返回的键值</returns>
        public static string IniReadValue(string section, string key, string filePath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, filePath);
            return temp.ToString();
        }

        #endregion


    }
}

