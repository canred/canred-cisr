using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.Attribute;
using IST.DB;  
using IST.DB.SQLCreater;  
using CISR.Model.Cr.Table;
namespace CISR.Model.Cr.Table.Record
{
	[ISTRecord]
	[ISTTableView("FILES", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class Files_Record : RecordBase{
		public Files_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _FILES_GROUP_ID=null;
		string _FILE_NAME=null;
		string _SYSTEM_PATH=null;
		/*欄位資訊 End*/

		[ColumnName("UUID",true,typeof(string))]
		public string UUID
		{
			set
			{
				_UUID=value;
			}
			get
			{
				return _UUID;
			}
		}

		[ColumnName("FILES_GROUP_ID",false,typeof(string))]
		public string FILES_GROUP_ID
		{
			set
			{
				_FILES_GROUP_ID=value;
			}
			get
			{
				return _FILES_GROUP_ID;
			}
		}

		[ColumnName("FILE_NAME",false,typeof(string))]
		public string FILE_NAME
		{
			set
			{
				_FILE_NAME=value;
			}
			get
			{
				return _FILE_NAME;
			}
		}

		[ColumnName("SYSTEM_PATH",false,typeof(string))]
		public string SYSTEM_PATH
		{
			set
			{
				_SYSTEM_PATH=value;
			}
			get
			{
				return _SYSTEM_PATH;
			}
		}
		public Files_Record Clone(){
			try{
				return this.Clone<Files_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Files gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Files ret = new Files(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
