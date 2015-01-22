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
	[ISTTableView("CHART_LIST", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class ChartList_Record : RecordBase{
		public ChartList_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _CHART_NAME=null;
		string _CHART_DESC=null;
		string _CHART_TITLE=null;
		string _CHART_TYPE=null;
		string _CHART_X=null;
		string _CHART_Y=null;
		string _CHART_TIME=null;
		string _ATTENDANT_UUID=null;
		string _DISPLAY=null;
		string _JOBJECT=null;
		string _COMPANY_UUID=null;
		string _CHART_GROUP=null;
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

		[ColumnName("CHART_NAME",false,typeof(string))]
		public string CHART_NAME
		{
			set
			{
				_CHART_NAME=value;
			}
			get
			{
				return _CHART_NAME;
			}
		}

		[ColumnName("CHART_DESC",false,typeof(string))]
		public string CHART_DESC
		{
			set
			{
				_CHART_DESC=value;
			}
			get
			{
				return _CHART_DESC;
			}
		}

		[ColumnName("CHART_TITLE",false,typeof(string))]
		public string CHART_TITLE
		{
			set
			{
				_CHART_TITLE=value;
			}
			get
			{
				return _CHART_TITLE;
			}
		}

		[ColumnName("CHART_TYPE",false,typeof(string))]
		public string CHART_TYPE
		{
			set
			{
				_CHART_TYPE=value;
			}
			get
			{
				return _CHART_TYPE;
			}
		}

		[ColumnName("CHART_X",false,typeof(string))]
		public string CHART_X
		{
			set
			{
				_CHART_X=value;
			}
			get
			{
				return _CHART_X;
			}
		}

		[ColumnName("CHART_Y",false,typeof(string))]
		public string CHART_Y
		{
			set
			{
				_CHART_Y=value;
			}
			get
			{
				return _CHART_Y;
			}
		}

		[ColumnName("CHART_TIME",false,typeof(string))]
		public string CHART_TIME
		{
			set
			{
				_CHART_TIME=value;
			}
			get
			{
				return _CHART_TIME;
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

		[ColumnName("DISPLAY",false,typeof(string))]
		public string DISPLAY
		{
			set
			{
				_DISPLAY=value;
			}
			get
			{
				return _DISPLAY;
			}
		}

		[ColumnName("JOBJECT",false,typeof(string))]
		public string JOBJECT
		{
			set
			{
				_JOBJECT=value;
			}
			get
			{
				return _JOBJECT;
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

		[ColumnName("CHART_GROUP",false,typeof(string))]
		public string CHART_GROUP
		{
			set
			{
				_CHART_GROUP=value;
			}
			get
			{
				return _CHART_GROUP;
			}
		}
		public ChartList_Record Clone(){
			try{
				return this.Clone<ChartList_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public ChartList gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ChartList ret = new ChartList(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
