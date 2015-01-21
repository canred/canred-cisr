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
	[ISTTableView("UPLOAD_JOB_LOG", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class UploadJobLog_Record : RecordBase{
		public UploadJobLog_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _UPLOAD_JOB_UUID=null;
		decimal? _SEQ=null;
		DateTime? _CREATE_DATE=null;
		string _ATTENDANT_UUID=null;
		string _MSG=null;
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

		[ColumnName("UPLOAD_JOB_UUID",false,typeof(string))]
		public string UPLOAD_JOB_UUID
		{
			set
			{
				_UPLOAD_JOB_UUID=value;
			}
			get
			{
				return _UPLOAD_JOB_UUID;
			}
		}

		[ColumnName("SEQ",false,typeof(decimal?))]
		public decimal? SEQ
		{
			set
			{
				_SEQ=value;
			}
			get
			{
				return _SEQ;
			}
		}

		[ColumnName("CREATE_DATE",false,typeof(DateTime?))]
		public DateTime? CREATE_DATE
		{
			set
			{
				_CREATE_DATE=value;
			}
			get
			{
				return _CREATE_DATE;
			}
		}

		[ColumnName("ATTENDANT_UUID",false,typeof(string))]
		public string ATTENDANT_UUID
		{
			set
			{
				_ATTENDANT_UUID=value;
			}
			get
			{
				return _ATTENDANT_UUID;
			}
		}

		[ColumnName("MSG",false,typeof(string))]
		public string MSG
		{
			set
			{
				_MSG=value;
			}
			get
			{
				return _MSG;
			}
		}
		public UploadJobLog_Record Clone(){
			try{
				return this.Clone<UploadJobLog_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public UploadJobLog gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJobLog ret = new UploadJobLog(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
