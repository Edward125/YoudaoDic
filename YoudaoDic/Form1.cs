using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Xml;
using System.IO.Ports;
using System.Diagnostics;
using System.Media;
using System.Data.OleDb;
using System.Text.RegularExpressions;


namespace YoudaoDic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region 参数

        private static string appFolder = Application.StartupPath + @"\YouDaoDic";
        private static  string wordFolder = Application.StartupPath + @"\YouDaoDic\Word"; // save word list
        private static string voiceFolder = Application.StartupPath + @"\YouDaoDic\Voice"; //save voice 
        private static string engWordList = Application.StartupPath + @"\YouDaoDic\Word\engWordList.DAT";
        private static string chnWordList = Application.StartupPath + @"\YouDaoDic\Word\chnWordList.DAT";
        private static string wordlistDb = Application.StartupPath + @"\YouDaoDic\Word\DB.mdb";

        //database
        private static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + 
            @"Data source=" + @wordlistDb + ";Jet OLEDB:Database Password=Joe";


        //private SpeechSynthesizer speechSyn;

        /**
         conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + //@"Provider=Microsoft.ACE.OLEDB.12.0;" +
         @"Data source= C:\Documents and Settings\username\" +
         @"My Documents\AccessFile.mdb";
         * /
         **/
        List<string> allWordList = new List<string>(); //本地需要背诵的单词
        Int32 allWordCount = -1;
        bool _Eng = true;
        bool _Ran = true;
        enum queryType
        {
            translation,
            usphonetic,
            explains
        }


        Dictionary <string,string> WordListH= new Dictionary <string,string>(); //本地词库的所有单词
        public static string IniFilePath = appFolder+ @"\Sysconfig.ini";


        class wordHtml
        {
            public string Word { set; get; }
            public string HtmlText { set; get; }
        }


        #endregion


        private void btnTranslation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty (txtSource.Text.Trim()))
                return;


            string item = txtSource.Text.Trim();

            int i = lstWordList.Items.IndexOf(item);
            if (i != -1)
            {
                webExplain.DocumentText = WordListH[item];

            }
            else
            {
                MessageBox.Show("未能从离线词库中找到相关信息");
            }


            //string sql = string.Empty;
            //sql = "select word from wordlist";
            //List<string> word = queryFromSql(sql, "word");
            //if (word.Contains(txtSource .Text.Trim ()))
            //{
            //     sql = "SELECT * FROM wordlist WHERE word='" + txtSource.Text.Trim ().ToLower () + "'";
            //    // MessageBox.Show(sql);
            //    EngWord engWord = queryDatabase(sql, txtSource .Text.Trim ().ToLower ());
            //    txtResult.Text  = "---------\r\n" + engWord.Translation + "\r\n---------\r\n" + engWord.Usphonetic + "\r\n---------\r\n" + engWord.Explains;

            //}
            //else 
            //{
            //    EngWord engWord = YouDaoTranslateTool2Word(txtSource.Text.Trim().ToLower());
            //    txtResult.Text = "---------\r\n" + engWord.Translation + "\r\n---------\r\n" + engWord.Usphonetic + "\r\n---------\r\n" + engWord.Explains;
            //}


        }
        public static string YouDaoTranslate(string sourceWord,out int errorCode)
        {

            string serverUrl = @"http://fanyi.youdao.com/openapi.do?keyfrom=edward&key=1307428965&type=data&doctype=xml&version=1.1&q=" + HttpUtility.UrlEncode(sourceWord);
            WebRequest request = WebRequest.Create(serverUrl);
            WebResponse response = request.GetResponse();
            string resXml= new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            string result = string.Empty;

            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
           // settings.IgnoreComments = true;
            //XmlReader reader = XmlReader.Create(resXml, settings);
            xmlDoc.LoadXml(resXml);
            //xmlDoc.Load(reader);


            XmlNode xn = xmlDoc.SelectSingleNode("youdao-fanyi");
            XmlNodeList xnl = xn.ChildNodes;

            foreach (XmlNode xnf in xnl)
            {


                try
                {
                    XmlElement xe = (XmlElement)xnf;
                    MessageBox.Show(xnf.InnerText);
                }
                catch (Exception)
                {
                    
                  //  throw;
                }
  
            }


            //reader.Close();

            errorCode = -1;
            return result;
       
        }

        public static string YouDaoTranslateTool(string sourceWord)
        {
            /* 
            调用：http://fanyi.youdao.com/openapi.do?keyfrom=sasfasdfasf&key=1177596287&type=data&doctype=json&version=1.1&q=中国人
            返回的json格式如下：
            {"translation":["The Chinese"],"basic":{"phonetic":"zhōng guó rén","explains":["Chinese","Chinaman","Chinese people","Chinee","chow"]}
             * ,"query":"中国人","errorCode":0,"web":[{"value":["Chinaren","Chinese people","The Chinese","Chinese person"],"key":"中国人"},
             * {"value":["中国人"],"key":"中國人"},{"value":["CHINA LIFE","LFC","china life insurance","YZC"],"key":"中国人寿"},{"value":["Human Rights in China","HRIC"],"key":"中国人权"},
             * {"value":["China Life Insurance Company","China Life Insurance","China Life","China Life Insurance Co Ltd"],"key":"中国人寿保险"},
             * {"value":["Chinese name","Chinese Names in English","Courtesy Name"],"key":"中国人名"},{"value":["Chinese Names"],"key":"中国人的名字"},
             * {"value":["CJOL"],"key":"中国人才热线"},{"value":["American Born Chinese"],"key":"美生中国人"},{"value":["Chinese Characteristics"],"key":"中国人德行"}]}*/
            string serverUrl = @"http://fanyi.youdao.com/openapi.do?keyfrom=edward&key=1307428965&type=data&doctype=json&version=1.1&q=" + HttpUtility.UrlEncode(sourceWord);
            WebRequest request = WebRequest.Create(serverUrl);
            try
            {
                WebResponse response = request.GetResponse();
                string resJson = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                // return resJson;
                string result = string.Empty;
                // get translation
                //int textIndex = resJson.IndexOf("translation") + 15;
                //int textLen = resJson.IndexOf("\"]", textIndex) - textIndex;
                //string translation = resJson.Substring(textIndex, textLen);
                string translation = getValue(resJson, "translation", 15, "\"]");

                result = "----------" + "\r\n" + translation + "\r\n";
                //get us-phonetic
                string usphonetic = "[" + getValue(resJson, "us-phonetic", 14, "\"") + "]";
                result = result + "----------" + "\r\n" + "美:" + usphonetic;
                //get uk-phonetic
                string ukphonetic = "[" + getValue(resJson, "uk-phonetic", 14, "\"") + "]";
                result = result + "    " + "英:" + ukphonetic + "\r\n";
                //get explains
                string explains = getValue(resJson, "explains", 12, "\"]");

                if (explains.Contains(","))
                {
                    string[] temps = explains.Split(',');

                    for (int i = 0; i < temps.Length; i++)
                    {
                        if (temps[i].Contains("\""))
                            temps[i] = temps[i].Replace("\"", "");
                        if (i == 0)
                            result = result + "----------\r\n" + temps[i] + "\r\n";
                        else
                            result = result + temps[i] + "\r\n";

                    }
                }
                else
                {
                    result = result + "----------\r\n" + explains;
                }

                return result;
            }
            catch (Exception e)
            {

                return e.Message;
            }
          



        }

        public  EngWord YouDaoTranslateTool2Word(string sourceWord)
        {
            EngWord engword = new EngWord();
            engword.Word = sourceWord.ToLower();

            string serverUrl = @"http://fanyi.youdao.com/openapi.do?keyfrom=edward&key=1307428965&type=data&doctype=json&version=1.1&q=" + HttpUtility.UrlEncode(sourceWord);
            WebRequest request = WebRequest.Create(serverUrl);
            WebResponse response = request.GetResponse();
            string resJson = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();

            // return resJson;
            string result = string.Empty;
            // get translation
            //int textIndex = resJson.IndexOf("translation") + 15;
            //int textLen = resJson.IndexOf("\"]", textIndex) - textIndex;
            //string translation = resJson.Substring(textIndex, textLen);
            //string translation = getValue(resJson, "translation", 15, "\"]");
            engword.Translation = getValue(resJson, "translation", 15, "\"]");
           
            //get us-phonetic
            string usphonetic = "[" + getValue(resJson, "us-phonetic", 14, "\"") + "]";
            //result = "美:" + usphonetic;
            engword.Usphonetic = "美:" + usphonetic;
            //get uk-phonetic
            string ukphonetic = "[" + getValue(resJson, "uk-phonetic", 14, "\"") + "]";
            //result = result + "    " + "英:" + ukphonetic;

            engword.Usphonetic = engword.Usphonetic + "    " + "英:" + ukphonetic;
            
            //get explains
            string explains = getValue(resJson, "explains", 12, "\"]");

            if (explains.Contains(","))
            {
                string[] temps = explains.Split(',');

                for (int i = 0; i < temps.Length; i++)
                {
                    if (temps[i].Contains("\""))
                        temps[i] = temps[i].Replace("\"", "");
                    //if (i == 0)
                    //    result = result + "----------\r\n" + temps[i] + "\r\n";
                    //else
                        result = result + temps[i] + "\r\n";

                }
            }
            else
            {
               // result = result + "----------\r\n" + explains;
                result = result + explains;
            }

            engword.Explains = result;


            return engword;
        }

        public static string getValue(string resJson,string v_value,int v_int,string key_value)
        {

            //int textIndex = resJson.IndexOf("translation") + 15;            
            //int textLen = resJson.IndexOf("\"]", textIndex) - textIndex;
            //string translation = resJson.Substring(textIndex, textLen);
            int textIndex = resJson.IndexOf(v_value) + v_int;
            int textLen = resJson.IndexOf(key_value , textIndex) - textIndex;
            return resJson.Substring(textIndex, textLen);
        }

        private string getFilePath()
        {
            string result = string.Empty;

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "文本文件|*.txt|所有文件|*.*";

            if (open.ShowDialog() == DialogResult.OK)
                return open.FileName;
            return result;
        }

        private void txtInputWord_DoubleClick(object sender, EventArgs e)
        {
            txtInputWord.Text = getFilePath();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
           // this.Enabled = false;
            
            if(string.IsNullOrEmpty (txtInputWord.Text.Trim ()))
            {
                MessageBox.Show("u don't select a file");
                return;
            }
           // saveWordList(txtInputWord.Text.Trim(), engWordList, chnWordList);
           // saveWordList2DB(txtInputWord.Text.Trim());
            allWordList.Clear();
            CheckWord(txtInputWord.Text.Trim());
           // this.Enabled = true;
        }


        private void CheckWord( string wordlistfile)
        {

            if (WordListH.Count == 0)
            {
                MessageBox.Show("未发现离线单词库,请重新设置离线单词库", "未发现离线单词库", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }


            int iCount = 0;
            int iAllWordCount = 0;
            int iExitsWordCount = 0;
           



            StreamReader sr = new StreamReader(wordlistfile, Encoding.UTF8);
            string lineStr = string.Empty;
            while (!sr.EndOfStream)
            {

                lineStr = sr.ReadLine();
                iAllWordCount++; // count all word                 
                // check word contains '
                if (WordListH.ContainsKey(lineStr))
                {
                    iExitsWordCount++;
                    allWordList.Add(lineStr);
                }
                else
                    iCount++;
            }

            sr.Close();
            MessageBox.Show("共计发现需要背诵的单词本单词:" + iAllWordCount + "(个),本地词典库中有解释的有:" + iExitsWordCount + "(个),未发现单词:" + iCount+"(个)");
 

        }



        private void checkFoderFile()
        {
            //
            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);
            if (!Directory.Exists(wordFolder))
                Directory.CreateDirectory(wordFolder);
            if (!Directory.Exists(voiceFolder))
                Directory.CreateDirectory(voiceFolder);

            //if (!File.Exists(engWordList))
            //    File.CreateText(engWordList);
            //if (!File.Exists(chnWordList))
            //    File.CreateText(chnWordList);

            //// check db file
            //if (!File.Exists(wordlistDb))
            //{
            //    DialogResult dr = MessageBox.Show("Can't find the words DB,r you ready to use the default db?if u select YES,the program will create a new default db.", "YES or NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dr == DialogResult.Yes)
            //    {
            //        byte[] Save = global::YoudaoDic.Properties.Resources.DB ;
            //        FileStream fsObj = new FileStream(wordlistDb,FileMode.CreateNew);
            //        fsObj.Write(Save, 0, Save.Length);
            //        fsObj.Close();
            //    }
            //}

            //check ini file

            if (!File.Exists(IniFilePath))
            {
                FileStream fs = File.Create(IniFilePath);
                fs.Close();

                IniFile.IniWriteValue("SysConfig", "DicDB", "", @IniFilePath);
                IniFile.IniWriteValue("SysConfig", "VoiceDB", "", @IniFilePath);
                IniFile.IniWriteValue("SysConfig", "LastStart", "1", @IniFilePath);
            }
            else
            {
                txtDic.Text = IniFile.IniReadValue("SysConfig", "DicDB", @IniFilePath);
                txtVoice.Text = IniFile.IniReadValue("SysConfig", "VoiceDB", @IniFilePath);
                txtStart.Text = IniFile.IniReadValue("SysConfig", "LastStart", @IniFilePath);
            }

            if (File.Exists(txtDic.Text.Trim()))
                 LoadDic(txtDic.Text.Trim());
            else
            {
                MessageBox.Show("离线单词库不存在,请重新设置");
                txtDic.SelectAll();
                txtDic.Focus();
            }



           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "本地词典背单词,Ver:" + Application.ProductVersion  + "(" + DateTime.Now.ToString ("yyyyMMdd") +"),Author:edward_song@yeah.net";
            checkFoderFile();
            //
            //ReadStartLine();
            txtNextTime.Text = txtTime.Text;
        }


        private void ReadStartLine()
        {
            string temp = wordFolder + @"\temp";

            if (File.Exists(temp))
            {
                StreamReader sr = new StreamReader(temp);
                txtStart.Text = sr.ReadLine();
                sr.Close();
            }
            else
                txtStart.Text = "0";

           
        }


        private void saveWordList(string wordlistfile, string engwordlistfile, string chnwordlistfile)
        {

            int iCount = 0;
            int iAllWordCount = 0;

            StreamReader sr = new StreamReader(wordlistfile, Encoding.UTF8);
            StreamWriter swEng = new StreamWriter(engwordlistfile, true, Encoding.UTF8);
            StreamWriter swChn = new StreamWriter(chnwordlistfile, true, Encoding.UTF8);
            string lineStr = string.Empty;
            while (!sr.EndOfStream)
            {

                lineStr = sr.ReadLine();
                iAllWordCount++; // count all word 
                // MessageBox.Show(lineStr);


                // check word exits


                    string translation = YouDaoTranslateTool(lineStr.ToLower());
                    if (!string.IsNullOrEmpty(translation))
                    {
                        iCount += 1; // count save word 
                        swEng.WriteLine(iCount + ">" + lineStr.ToLower());
                        swChn.WriteLine(iCount + ">" + translation);
                    }


            }

            sr.Close();
            swEng.Close();
            swChn.Close();




           // MessageBox.Show("your input word list file toal word:" + iAllWordCount + ",find exits word:" + iExitsWordCount + ",save words:" + iCount);

        }


        //private void saveWordList(string wordlistfile,string engwordlistfile,string chnwordlistfile)
        //{

        //    int iCount = 0;
        //    int iAllWordCount = 0;
        //    int iExitsWordCount = 0;

        //    //back file

        //    string englistwordbak = engwordlistfile + ".bak";


        //    if (File.Exists(englistwordbak))
        //        File.Delete(englistwordbak);



        //    if (File.Exists(engwordlistfile))
        //    {
        //        File.Copy(engwordlistfile, englistwordbak);
        //    }
        //    else
        //        return;




        //    StreamReader sr = new StreamReader(wordlistfile, Encoding.UTF8);
        //    StreamWriter swEng = new StreamWriter(engwordlistfile, true, Encoding.UTF8);
        //    StreamWriter swChn = new StreamWriter(chnwordlistfile, true, Encoding.UTF8);
        //    string lineStr = string.Empty;
        //    while (!sr.EndOfStream )
        //    {

        //        lineStr = sr.ReadLine();
        //        iAllWordCount++; // count all word 
        //       // MessageBox.Show(lineStr);


        //       // check word exits


        //        if (!checkWordExits(lineStr, englistwordbak ))
        //        {

        //            string translation = YouDaoTranslateTool(lineStr.ToLower());
        //            if (!string.IsNullOrEmpty(translation))
        //            {
        //                iCount += 1; // count save word 
        //                swEng.WriteLine(iCount + ">" + lineStr.ToLower());
        //                swChn.WriteLine(iCount + ">" + translation);


        //            }

        //        }
        //        else
        //            iExitsWordCount++;


        //    }

        //    sr.Close();
        //    swEng.Close();
        //    swChn.Close();


        //    if (File.Exists(englistwordbak))
        //        File.Delete(englistwordbak);

        //    MessageBox.Show("your input word list file toal word:" + iAllWordCount + ",find exits word:" + iExitsWordCount + ",save words:" + iCount);

        //}

        private void saveWordList2DB(string wordlistfile)
        {
            int iCount = 0;
            int iAllWordCount = 0;
            int iExitsWordCount = 0;

            StreamReader sr = new StreamReader(wordlistfile, Encoding.UTF8);
            string lineStr = string.Empty;
            while (!sr.EndOfStream)
            {

                lineStr = sr.ReadLine();
                iAllWordCount++; // count all word                 
                // check word contains '
                EngWord engword = YouDaoTranslateTool2Word(lineStr.ToLower());
                if (engword.Usphonetic.IndexOf("'") != -1)
                    engword.Usphonetic = engword.Usphonetic.Replace("'", "''");
                if (engword.Translation.IndexOf("'") != -1)
                    engword.Translation = engword.Translation.Replace("'", "''");
                if (engword.Explains.IndexOf("'") != -1)
                    engword.Explains = engword.Explains.Replace("'", "''");
                //check word exits

                string sql = string.Empty;
                sql = "select word from wordlist";
                List<string> word = queryFromSql(sql, "word");
                if (word.Contains(engword.Word))
                    iExitsWordCount++;
                else
                {
                    sql = "INSERT INTO wordlist VALUES ('" + @engword.Word + "','" + @engword.Translation + "','" + @engword.Usphonetic + "','" + @engword.Explains + "')";
                    if (updateDatabase(sql))
                        iCount++;
                }

             
            }

            sr.Close();


            MessageBox.Show("your input word list file toal word:" + iAllWordCount + ",find exits word:" + iExitsWordCount + ",save words:" + iCount);
        }



        /// <summary>
        /// check word if exits in the wordlist
        /// </summary>
        /// <param name="engword">engword</param>
        /// <param name="engwordlist">english word list file </param>
        /// <returns>if exits,return true,if not exits,return false</returns>

        private bool checkWordExits(string engword, string engwordlist)
        {

            StreamReader sr = new StreamReader(engwordlist, Encoding.UTF8);

            string line = string.Empty;

            if (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                line = line.Substring(line.LastIndexOf('>') + 1, line.Length - line.LastIndexOf('>') - 1).ToUpper();
                if (line == engword.ToUpper())
                {
                    sr.Close();
                    return true;
                }
            }

           

            sr.Close();




            return false;
        }

        #region Database

        private bool updateDatabase(string sql)
        {
            OleDbConnection oledConn = new OleDbConnection(connectionString);
            try
            {
                oledConn.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show("Can't open the database,detail message:" + "\r\n" + e.Message);
                oledConn.Close();
                return false;
            }

            OleDbCommand oledComm = new OleDbCommand(sql, oledConn);
            try
            {
                int i = oledComm.ExecuteNonQuery();
               if (i > 0)
               {
                   oledConn.Close();
                   return true;
               }
            }
            catch (System.Data.OleDb.OleDbException e)
            {
               
                MessageBox.Show("Execute sql statement '" + sql + " ' error,detail message:" + "\r\n" + e.Message);
                oledConn.Close();
                return false;
            }







            return true;
        }

        private EngWord queryDatabase(string sql,string word)
        {
            EngWord engword = new EngWord();
            engword.Word = word;

            /**
             *translation,
             *usphonetic,
             *explains
             **/

            //queryType query;
            OleDbConnection oledConn = new OleDbConnection(connectionString);
            try
            {
                oledConn.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show("Can't open the database,detail message:" + "\r\n" + e.Message);
                oledConn.Close();  
            }

            OleDbCommand oledComm = new OleDbCommand(sql, oledConn);
            OleDbDataReader oledReader;
            try
            {
                oledReader = oledComm.ExecuteReader();

                while (oledReader.Read())
                {
                    engword.Translation = oledReader["translation"].ToString();
                    engword.Usphonetic = oledReader["usphonetic"].ToString();
                    engword.Explains = oledReader["explains"].ToString();
                }
             

            }
            catch (Exception e)
            {
                MessageBox.Show("Excute sql statement '" + sql + " ' error,detail message:\r\n" + e.Message);

            }
            finally
            {
                oledConn.Close();
            }


            return engword;
        }



        #endregion

        public class EngWord
        {
            public string Word { set; get; }
            public string Translation{set;get ;}
            public string Usphonetic {set;get; }
            public string Explains { set; get; }
        }

        /// <summary>
        /// 從數據庫中查詢信息
        /// </summary>
        /// <param name="sql">查詢數據的sql語句</param>
        /// <param name="connString">連接數據庫的連接字符串</param>
        /// <param name="querytxt">在數據庫中查詢的查詢字段</param>
        /// <returns>返回一個string的list</returns>
        public static List<string> queryFromSql(string sql, string querytxt)
        {
            List<string> returnString = new List<string>();
            OleDbConnection objConnection = new OleDbConnection(connectionString);
            try
            {
                objConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("連接數據庫出錯,錯誤信息:" + ex.Message);
            }
            OleDbCommand  objCommand = new OleDbCommand (sql, objConnection);
            OleDbDataReader objReader;
            try
            {
                objReader = objCommand.ExecuteReader();
                while (objReader.Read())
                {
                    returnString.Add(objReader[querytxt].ToString().Trim());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("從數據庫讀取信息出錯,錯誤信息:" + ex.Message);
            }
            finally
            {
                objConnection.Close();
            }
            return returnString;
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text.Trim()))
                this.btnRead.Enabled = false;
            else
                this.btnRead.Enabled = true;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadVoice(txtSource.Text.Trim());

            //System.Media.SoundPlayer sp = new SoundPlayer();
            //sp.SoundLocation = @"E:\test\[朗文当代英语辞典第五版语音库]LDOCE5.American\SPEECH\1\1.mp3";
            //sp.Play();
                       
            //return;








            //axWindowsMediaPlayer1.URL = @"http://dict.youdao.com/dictvoice?audio=" + txtSource.Text.Trim().ToLower();



            //
            //clearTemporaryFile();
            //string destFile = voiceFolder + @"\" + @txtSource.Text.Trim().ToLower() + @".mp3";
            //if (!File.Exists(destFile))
            //{
            //    DateTime downloadtime = DateTime.Now;
            //   // MessageBox.Show(downloadtime.ToString());
            //    axWindowsMediaPlayer1.URL = @"http://dict.youdao.com/dictvoice?audio=" + txtSource.Text.Trim().ToLower();
            //    DirectoryInfo di = new DirectoryInfo(@"C:\Users\" + @Environment.UserName + @"\AppData\Local\Microsoft\Windows\Temporary Internet Files\");
            //    //MessageBox.Show(@"C:\Users\" + @Environment.UserName + @"\AppData\Local\Microsoft\Windows\Temporary Internet Files\");
            //    FileInfo[] fi = di.GetFiles("*.mp3", System.IO.SearchOption.AllDirectories);
            //    foreach (var item in fi)
            //    {
            //        try
            //        {
            //            MessageBox.Show(item.FullName);
            //            MessageBox.Show(item.LastAccessTime .ToString ());

            //            //File.Move(item.FullName, destFile);
            //        }
            //        catch (Exception)
            //        {

            //           // throw;
            //        }
            //        finally
            //        {
            //            //try
            //            //{
            //            //    File.Delete(di.FullName);
            //            //}
            //            //catch (Exception)
            //            //{
                            
            //            //    throw;
            //            //}
                       
            //        }
                   

            //    }


            //}
            //else
            //{
            //    axWindowsMediaPlayer1.URL = destFile;

            //}


           

        }



        private void ReadVoice(string word)
        {
            string RootFolder = txtVoice.Text.Trim();


            if (!Directory.Exists(txtVoice.Text.Trim()))
            {
                MessageBox.Show("未发现本地语音库文件夹,请重新设置");
                txtVoice.SelectAll();
                txtVoice.Focus();
                return;
           }





            //string VoiceFolder1 = RootFolder + @"\" + @txtSource.Text.Trim().Substring(0, 1).ToUpper();

            string VoiceFolder1 = RootFolder + @"\" + word.Trim().Substring(0, 1).ToUpper();

            DirectoryInfo di = new DirectoryInfo(VoiceFolder1);
            FileInfo[] fi = di.GetFiles();
            foreach (var item in fi)
            {
               // if (item.Name == txtSource.Text.Trim() + @".mp3")
                if (item.Name == word.Trim() +@".mp3" )
                {
                    axWindowsMediaPlayer1.URL = @item.FullName;
                    axWindowsMediaPlayer1.Ctlcontrols.play();

                }
            }
        }




        private void arrrandom(ref List<string> arr)
        {
            Random ran = new Random();
            int k = 0;
            string strtmp = "";
            for (int i = 0; i < arr.Count; i++)
            {
                k = ran.Next(0, arr.Count);
                if (k != i)
                {
                    strtmp = arr[i];
                    arr[i] = arr[k];
                    arr[k] = strtmp;
                }
            }
        }

        private void btnEng_Click(object sender, EventArgs e)
        {
            _Eng = true;
            txtCN.ReadOnly = false;
            txtEN.ReadOnly = true;
            txtCN.Text = string.Empty;
            txtEN.Text = string.Empty;
            string sql = string.Empty;
            sql = "select word from wordlist";
            allWordList = queryFromSql(sql, "word");
            arrrandom(ref allWordList);
            allWordCount = 0;
            sql = "SELECT * FROM wordlist WHERE word='" + allWordList[0] + "'";
            // MessageBox.Show(sql);
            EngWord engWord = queryDatabase(sql, allWordList[0]);
            txtEN.Text = engWord.Word;
        }

        private void btnChn_Click(object sender, EventArgs e)
        {
            _Eng = false;
            txtCN.ReadOnly = true;
            txtEN.Text = string.Empty;
            txtEN.ReadOnly = false;
            txtCN.Text = string.Empty;
            string sql = string.Empty;
            sql = "select word from wordlist";
            allWordList = queryFromSql(sql, "word");
            arrrandom(ref allWordList );
            allWordCount = 0;
            sql = "SELECT * FROM wordlist WHERE word='" + allWordList[0] +"'";
             // MessageBox.Show(sql);
            EngWord engWord = queryDatabase(sql, allWordList[0]);
            txtCN.Text = "---------\r\n" + engWord.Translation + "\r\n---------\r\n"+ engWord.Usphonetic +"\r\n---------\r\n" + engWord.Explains;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            txtEN.Text = string.Empty;
            txtCN.Text = string.Empty;
            //中文2英文
            
                allWordCount++;
                if (allWordCount < allWordList.Count)
                {
                    string sql = "SELECT * FROM wordlist WHERE word='" + allWordList[allWordCount] + "'";
                    // MessageBox.Show(sql);
                    EngWord engWord = queryDatabase(sql, allWordList[allWordCount]);
                    if (!_Eng)
                        txtCN.Text = "---------\r\n" + engWord.Translation + "\r\n---------\r\n" + engWord.Usphonetic + "\r\n---------\r\n" + engWord.Explains;
                    else
                        txtEN.Text = engWord.Word;


                   
                   // allWordCount++;
                }
                else
                {

                    MessageBox.Show("你已经练习完单词库中的所有单词,点击'EngToChn'或者'ChnToEng'可重新随机练习");
                }

            //英文2中文
        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (allWordList.Count < 1)
            {
                MessageBox.Show("未检测到单词库,请先点击sequence后再点击OK");
                return;
            }

            if (string.IsNullOrEmpty(txtStart.Text.Trim()))
                allWordCount = 0;
            else
            {
                int i = Convert.ToInt16(txtStart.Text.Trim()) + 1;
                if (i > allWordList.Count)  //设置的开始数字大于所有单词的个数，取最后一个
                {
                    txtStart.Text = (allWordList.Count - 1).ToString();
                    allWordCount = allWordList.Count - 1;

                }
                else
                    allWordCount = Convert.ToInt16(txtStart.Text.Trim());

            }

            //SaveStartLine();

            txtStatus.Text = "当前单词库共计单词:" + allWordList.Count + ",当前正在记忆单词:" + (allWordCount).ToString() + ",剩余单词:" + (allWordList.Count - allWordCount);

           // string  sql = "SELECT * FROM wordlist WHERE word='" + allWordList[allWordCount-1] + "'";
           // EngWord engWord = queryDatabase(sql, allWordList[allWordCount-1]);
           // txtEN.Text = engWord.Word;
            //if (allWordCount == 0)
            //{
            //    txtEN.Text = allWordList[allWordCount];

            //}
            //else
            //{
            //    txtEN.Text = allWordList[allWordCount - 1];
            //}
            //txtCN.Text = "---------\r\n" + engWord.Translation + "\r\n---------\r\n" + engWord.Usphonetic + "\r\n---------\r\n" + engWord.Explains;
            txtEN.Text = allWordList[allWordCount - 1];
            webExplain.DocumentText = WordListH[allWordList[allWordCount - 1]];
            ReadVoice(allWordList[allWordCount - 1]);
            timerNext.Enabled = true;
            timerNext.Start();

            btnPause.Enabled = true;
            btnPause.Text = "Pause";
            btnStop.Enabled = true;
    
        }

        private void btnAdd2Dic_Click(object sender, EventArgs e)
        {
            //EngWord engword = YouDaoTranslateTool2Word(txtSource.Text.Trim ().ToLower ());
            //if (engword.Usphonetic.IndexOf("'") != -1)
            //    engword.Usphonetic = engword.Usphonetic.Replace("'", "''");
            //if (engword.Translation.IndexOf("'") != -1)
            //    engword.Translation = engword.Translation.Replace("'", "''");
            //if (engword.Explains.IndexOf("'") != -1)
            //    engword.Explains = engword.Explains.Replace("'", "''");
            ////check word exits

            //string sql = string.Empty;
            //sql = "select word from wordlist";
            //List<string> word = queryFromSql(sql, "word");
            //if (word.Contains(engword.Word))
            //{
            //    MessageBox.Show("该单词已存在于单词库中,无需再次添加");
            //}

            //else
            //{
            //    sql = "INSERT INTO wordlist VALUES ('" + @engword.Word + "','" + @engword.Translation + "','" + @engword.Usphonetic + "','" + @engword.Explains + "')";
            //    if (updateDatabase(sql))
            //        MessageBox.Show("添加单词'" + txtSource.Text.Trim().ToLower() + "'成功");
            //}





        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
          //  _Eng = false;

            timerNext.Stop();
            _Ran = true;
            txtNextTime.Text = txtTime.Text;
            txtCN.ReadOnly = true;
            txtEN.Text = string.Empty;
            txtEN.ReadOnly = true ;
            txtCN.Text = string.Empty;
            txtStatus.Text = string.Empty;
            //string sql = string.Empty;
            //sql = "select word from wordlist";
            //allWordList = queryFromSql(sql, "word");
            allWordList.Clear();
            CheckWord(txtInputWord.Text.Trim());
            if (allWordList.Count == 0)
            {
                MessageBox.Show("单词库中不存在单词,请先在单词库中添加入单词后再开始记忆单词", "未发现单词", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;

            };


            arrrandom(ref allWordList);
            MessageBox.Show("当前单词库中总计有单词:" + allWordList.Count + ",顺序已随机打乱,点击确定后开始自动显示");
            allWordCount = 0;
            txtStatus.Text = "当前单词库共计单词:" + allWordList.Count + ",当前正在记忆单词:" + (allWordCount + 1).ToString() + ",剩余单词:" + (allWordList.Count - allWordCount - 1);
           // sql = "SELECT * FROM wordlist WHERE word='" + allWordList[0] + "'";
            // MessageBox.Show(sql);
            //EngWord engWord = queryDatabase(sql, allWordList[0]);
            txtEN.Text = allWordList[0];
           // txtCN.Text = "---------\r\n" + engWord.Translation + "\r\n---------\r\n" + engWord.Usphonetic + "\r\n---------\r\n" + engWord.Explains;
            webExplain.DocumentText = WordListH[allWordList[0]];
            ReadVoice(allWordList[0]);
            timerNext.Enabled = true;
            timerNext.Start();

            btnPause.Enabled = true;
            btnPause.Text = "Pause";
            btnStop.Enabled = true;
        }

        private void timerNext_Tick(object sender, EventArgs e)
        {
            int nextTime = Convert.ToInt16(txtNextTime.Text.Trim());
            nextTime--;
            txtNextTime.Text = nextTime.ToString();


            if (nextTime <= 0)
            {

                txtEN.Text = string.Empty;
                txtCN.Text = string.Empty;
                //中文2英文
                //if (_Ran )
                    allWordCount++;


                    //if (allWordCount <= allWordList.Count)
                    //{
                    //    EngWord engWord = new EngWord();
                    //    string sql = string.Empty;

                    //    if (_Ran)
                    //    {
                    //        txtStatus.Text = "当前单词库共计单词:" + allWordList.Count + ",当前正在记忆单词:" + (allWordCount + 1).ToString() + ",剩余单词:" + (allWordList.Count - allWordCount - 1);
                    //        sql = "SELECT * FROM wordlist WHERE word='" + allWordList[allWordCount] + "'";
                    //        engWord = queryDatabase(sql, allWordList[allWordCount]);
                    //        txtEN.Text = allWordList[allWordCount];
                    //        webExplain.DocumentText = WordListH[allWordList[allWordCount]];
                    //        ReadVoice(allWordList[allWordCount]);
                    //    }
                    //    else
                    //    {
                    //        txtStatus.Text = "当前单词库共计单词:" + allWordList.Count + ",当前正在记忆单词:" + (allWordCount).ToString() + ",剩余单词:" + (allWordList.Count - allWordCount);
                    //        txtEN.Text = allWordList[allWordCount - 1];
                    //        ReadVoice(allWordList[allWordCount - 1]);
                    //        webExplain.DocumentText = WordListH[allWordList[allWordCount - 1]];


                    //    }

                    //    txtEN.Text = engWord.Word;
                    //    txtCN.Text = "---------\r\n" + engWord.Translation + "\r\n---------\r\n" + engWord.Usphonetic + "\r\n---------\r\n" + engWord.Explains;
                    //    txtEN.Text = engWord.Word;
                    //    txtNextTime.Text = txtTime.Text;
                    //}
                    //else
                    //{
                    //    txtNextTime.Text = txtTime.Text;
                    //    timerNext.Stop();
                    //    MessageBox.Show("你已经练习完单词库中的所有单词,点击'Random'或者'Sequence'可重新开始");
                    //}



                if (_Ran)
                {
                    if (allWordCount < allWordList.Count)
                    {
                        txtStatus.Text = "当前单词库共计单词:" + allWordList.Count + ",当前正在记忆单词:" + (allWordCount + 1).ToString() + ",剩余单词:" + (allWordList.Count - allWordCount - 1);
                        txtEN.Text = allWordList[allWordCount];
                        webExplain.DocumentText = WordListH[allWordList[allWordCount]];
                        ReadVoice(allWordList[allWordCount]);
                        txtNextTime.Text = txtTime.Text;
                    }
                    else
                    {
                        txtNextTime.Text = txtTime.Text;
                        timerNext.Stop();
                        MessageBox.Show("你已经练习完单词库中的所有单词,点击'Random'或者'Sequence'可重新开始");
                        btnOK.Enabled = false;
                        btnPause.Enabled = false;
                        btnStop.Enabled = false;
                        btnPause.Text = "Pause";
                    }
                }
                else
                {
                    if (allWordCount <= allWordList.Count)
                    {
                        txtStatus.Text = "当前单词库共计单词:" + allWordList.Count + ",当前正在记忆单词:" + (allWordCount).ToString() + ",剩余单词:" + (allWordList.Count - allWordCount);
                        txtEN.Text = allWordList[allWordCount - 1];
                        ReadVoice(allWordList[allWordCount - 1]);
                        webExplain.DocumentText = WordListH[allWordList[allWordCount - 1]];
                        txtNextTime.Text = txtTime.Text;
                    }
                    else
                    {
                        txtNextTime.Text = txtTime.Text;
                        timerNext.Stop();
                        MessageBox.Show("你已经练习完单词库中的所有单词,点击'Random'或者'Sequence'可重新开始");
                        btnOK.Enabled = false;
                        btnPause.Enabled = false;
                        btnStop.Enabled = false;
                        btnPause.Text = "Pause";

                    }

                }





            }
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            txtNextTime.Text = txtTime.Text;
        }

        private void btnSequence_Click(object sender, EventArgs e)
        {
            timerNext.Stop();
            _Ran = false;
            txtNextTime.Text = txtTime.Text;
            allWordCount = 0;
            txtCN.ReadOnly = true;
            txtEN.Text = string.Empty;
            txtEN.ReadOnly = true;
            txtCN.Text = string.Empty;
            string sql = string.Empty;
            txtStatus.Text = string.Empty;
            //sql = "select word from wordlist";
            //allWordList = queryFromSql(sql, "word");
            allWordList.Clear();
            CheckWord(txtInputWord.Text.Trim());


            if (allWordList.Count == 0)
            {
                MessageBox.Show("单词库中不存在单词,请先在单词库中添加入单词后再开始记忆单词", "未发现单词", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;

            }
            //arrrandom(ref allWordList);
            MessageBox.Show("当前单词库中总计有单词:" + allWordList.Count + ",在开始行数位置设置从哪个位置开始记忆,设置完成后点击OK开始顺序背诵,不设置默认从第一个单词开始");

            btnOK.Enabled = true;
          
        }

        private void clearTemporaryFile()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\" + @Environment.UserName + @"\AppData\Local\Microsoft\Windows\Temporary Internet Files\");
            //MessageBox.Show(@"C:\Users\" + @Environment.UserName + @"\AppData\Local\Microsoft\Windows\Temporary Internet Files\");
            FileInfo[] fi = di.GetFiles("*.mp3", System.IO.SearchOption.AllDirectories);
            foreach (var item in fi )
            {

                try
                {
                    File.Delete(item.FullName);
                }
                catch (Exception)
                {
                    
                    //throw;
                }
            }
        }

        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }


        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            //int i = Convert.ToInt16(txtStatus.Text.Trim()) + 1;
    

            //save temp   
            SaveStartLine();
            IniFile.IniWriteValue("SysConfig", "LastStart", txtStart.Text.Trim(), @IniFilePath);
            
        }


        private void SaveStartLine()
        {
            string temp = wordFolder + @"\temp";

            if (!File.Exists(temp))
            {
                FileStream fs = File.Create(temp);
                fs.Close();
            }
            try
            {
                StreamWriter sw = new StreamWriter(temp, false);
                if (!string.IsNullOrEmpty(txtStart.Text.Trim()))
                    sw.WriteLine(txtStart.Text.Trim());
                else
                    sw.WriteLine("0");
                sw.Close();
            }
            catch (Exception)
            {

                //throw;
            }
        }
        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void txtDic_DoubleClick(object sender, EventArgs e)
        {
            txtDic.Text = getFilePath();
            if (string.IsNullOrEmpty(txtDic.Text.Trim()))
                return;

            //this.Enabled = false;
            if (backgroundWorker1.IsBusy != true)
            {
                // 启动异步操作
                backgroundWorker1.RunWorkerAsync();
            }

            //backgroundWorker1.RunWorkerAsync();
            //this.Enabled = true;
        }

        private void txtVoice_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                txtVoice.Text = fbd.SelectedPath;
        }


        private void LoadDic(string dicpath)
        {
            if (string.IsNullOrEmpty(dicpath))
                return;

            lstWordList.Items.Clear();
            WordListH.Clear();
            this.Enabled = false;
            StreamReader sr = new StreamReader(dicpath);
            string lineStr = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // MessageBox.Show(StripHTML(sr.ReadLine()));
                // webExplain.DocumentText = lineStr;
                lineStr = ChangePngHTML(lineStr);

                wordHtml wordH = new wordHtml();

                try
                {
                    // this.Text = "正在读取:" + lineStr.Substring(0, lineStr.IndexOf("\t"));

                    wordH.Word = lineStr.Substring(0, lineStr.IndexOf("\t")).Trim();
                    lineStr = lineStr.Remove(0, wordH.Word.Length);
                    wordH.HtmlText = lineStr;

                    this.lstWordList.Items.Add(wordH.Word);
                    WordListH.Add(wordH.Word, wordH.HtmlText);
                    lineStr = sr.ReadLine();
                }
                catch (Exception)
                {

                    //throw;
                }


            }
            sr.Close();
            this.Enabled = true;
        }


        private void LoadDic(string dicpath,BackgroundWorker bw)
        {
            if (string.IsNullOrEmpty(dicpath))
                return;
            this.Invoke((EventHandler)(delegate
                {
                  lstWordList.Items.Clear();
                   WordListH.Clear();

                  // this.Enabled = false;
                   StreamReader sr = new StreamReader(dicpath);
                   string lineStr = sr.ReadLine();
                   while (!sr.EndOfStream)
                   {
                       // MessageBox.Show(StripHTML(sr.ReadLine()));
                       // webExplain.DocumentText = lineStr;
                       lineStr = ChangePngHTML(lineStr);

                       wordHtml wordH = new wordHtml();

                       try
                       {
                           // this.Text = "正在读取:" + lineStr.Substring(0, lineStr.IndexOf("\t"));

                           wordH.Word = lineStr.Substring(0, lineStr.IndexOf("\t")).Trim();
                           lineStr = lineStr.Remove(0, wordH.Word.Length);
                           wordH.HtmlText = lineStr;
                           Application.DoEvents();
                           this.lstWordList.Items.Add(wordH.Word);
                           WordListH.Add(wordH.Word, wordH.HtmlText);
                           lineStr = sr.ReadLine();
                       }
                       catch (Exception)
                       {

                           //throw;
                       }


                   }
                   sr.Close();
                  // this.Enabled = true;
                }));

           



        }

        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="strHtml">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string StripHTML(string strHtml)
        {
            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<script>内容</script>为空格
            string regex_str = "(?is)<script[^>]*>.*?</script>";//替换<script>内容</script>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");
            //
            //regex_str = "[<br>]";
            //strHtml = Regex.Replace(strHtml, regex_str, "/r/n");

            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<style>内容</style>为空格
            regex_str = "(?is)<style[^>]*>.*?</style>";//替换<style>内容</style>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "(&nbsp;)+";//替换&nbsp;为空格
            regex_str = "(?i)&nbsp;";//替换&nbsp;为空格
            strHtml = Regex.Replace(strHtml, regex_str, " ");

            //regex_str = "(\r\n)*";//替换\r\n为空
            regex_str = @"[\r\n]*";//替换\r\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //regex_str = "<[^<]*>";//替换Html标签为空
            regex_str = "<[^<>]*>";//替换Html标签为空
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "\n*";//替换\n为空
            regex_str = @"\n*";//替换\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //可以这样
            regex_str = "\t*";//替换\t为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //可以
            regex_str = "'";//替换'为’
            strHtml = Regex.Replace(strHtml, regex_str, "’", RegexOptions.IgnoreCase);

            //可以
            regex_str = " +";//替换若干个空格为一个空格
            strHtml = Regex.Replace(strHtml, regex_str, "  ", RegexOptions.IgnoreCase);

            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);

            string strOutput = regex.Replace(strHtml, "");//替换掉"<"和">"之间的内容
            strOutput = strOutput.Replace("<", "");
            strOutput = strOutput.Replace(">", "");
            strOutput = strOutput.Replace("&nbsp;", "");


            return strOutput;

        }

        public static string ChangePngHTML(string strHtml)
        {
            string strOutPut = strHtml.Replace(@"snd_", Application.StartupPath +@"/YouDaoDic/snd_");
            return strOutPut;
        }

        

        private void lstWordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lstWordList.SelectedItem .ToString ().Trim()))
                return;
            string keyy = lstWordList.SelectedItem.ToString().Trim();
            txtSource.Text = keyy;
            webExplain.DocumentText = WordListH[keyy];
        }

        private void txtDic_TextChanged(object sender, EventArgs e)
        {
            IniFile.IniWriteValue("SysConfig", "DicDB", txtDic.Text.Trim(), @IniFilePath);
        }

        private void txtVoice_TextChanged(object sender, EventArgs e)
        {
            IniFile.IniWriteValue("SysConfig", "VoiceDB",txtVoice .Text.Trim () , @IniFilePath);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           // BackgroundWorker worker = sender as BackgroundWorker;

            LoadDic(txtDic.Text.Trim(), backgroundWorker1);

            
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text.Trim().ToUpper() == "Pause".ToUpper())
            {
                btnPause.Text = "Continue";
                timerNext.Stop();
            }
            else
            {
                btnPause.Text = "Pause";
                timerNext.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            btnOK.Enabled = false;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            timerNext.Stop();
            txtStatus.Text = string.Empty;
            txtNextTime.Text = "5";
        }

        private void txtSource_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtSource.Text.Trim()))
                    return;


                string item = txtSource.Text.Trim();

                int i = lstWordList.Items.IndexOf(item);
                if (i != -1)
                {
                    webExplain.DocumentText = WordListH[item];

                }
                else
                {
                    MessageBox.Show("未能从离线词库中找到相关信息");
                }

            }


        }
    }
}
