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
	[ISTTableView("BASE_LINE", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class BaseLine_Record : RecordBase{
		public BaseLine_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _COMPANY_UUID=null;
		string _START_YEAR=null;
		string _END_YEAR=null;
		string _BASE_YEAR=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
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

		[ColumnName("COMPANY_UUID",false,typeof(string))]
		public string COMPANY_UUID
		{
			set
			{
				_COMPANY_UUID=value;
			}
			get
			{
				return _COMPANY_UUID;
			}
		}

		[ColumnName("START_YEAR",false,typeof(string))]
		public string START_YEAR
		{
			set
			{
				_START_YEAR=value;
			}
			get
			{
				return _START_YEAR;
			}
		}

		[ColumnName("END_YEAR",false,typeof(string))]
		public string END_YEAR
		{
			set
			{
				_END_YEAR=value;
			}
			get
			{
				return _END_YEAR;
			}
		}

		[ColumnName("BASE_YEAR",false,typeof(string))]
		public string BASE_YEAR
		{
			set
			{
				_BASE_YEAR=value;
			}
			get
			{
				return _BASE_YEAR;
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

		[ColumnName("UPDATE_DATE",false,typeof(DateTime?))]
		public DateTime? UPDATE_DATE
		{
			set
			{
				_UPDATE_DATE=value;
			}
			get
			{
				return _UPDATE_DATE;
			}
		}
		public BaseLine_Record Clone(){
			try{
				return this.Clone<BaseLine_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public BaseLine gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				BaseLine ret = new BaseLine(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
