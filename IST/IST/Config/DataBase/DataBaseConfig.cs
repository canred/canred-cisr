using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Web;
using IST.Config;
using log4net;
using System.Reflection;
namespace IST.Config.DataBase
{
    /// <summary>
    /// �򥻳]�m�T���޲z��
    /// </summary>
    public class DataBaseConfig 
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private static string _focusTag = "DataBaseConfig";
        private static string focusTag = "DataBaseConfig";
        /// <summary>�t�m���Ҧb���|</summary>
        public static string filename;

        #region DataBaseConfigFileManager()

        /// <summary>
        /// ��l�Ƥ��ק�ɶ��M�ﹳ���
        /// </summary>
        static DataBaseConfig()
        {
        }
        #endregion

        public static System.Xml.XmlDocument Init()
        {
            try
            {
                var a = new object();
                lock (a)
                {
                    focusTag = _focusTag;
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.Load(ConfigFilePath());
                    return doc;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        #region ConfigFilePath

        private static string ConfigFilePath()
        {
            try
            {
                HttpContext context = HttpContext.Current;
                var nv = new NameValueCollection();
                var a = new object();
                lock (a)
                {
                    focusTag = _focusTag;
                }
                nv = (NameValueCollection)ConfigurationManager.GetSection("APConfigFiles");
                for (int i = 0; i < nv.AllKeys.Length; i++)
                {
                    if (nv.AllKeys[i].ToUpper() == focusTag.ToUpper())
                    {
                        filename = nv[i];
                        break;
                    }
                }
                if (context != null)
                {
                    if (filename.IndexOf("~") > -1)
                    {
                        filename = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + filename.Replace("~", "");
                            
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                    }
                }
                else
                {
                    filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename.Replace("~/", ""));
                }


                if (!File.Exists(filename))
                {
                    throw new Exception("�o�Ϳ��~: �S�����T��" + focusTag + "���");
                }
                return filename;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion
    }
}