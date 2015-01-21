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
	[ISTTableView("RAW_PROCESS_ITEM", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class RawProcessItem_Record : RecordBase{
		public RawProcessItem_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _RAW_PROCESS_HEAD_UUID=null;
		string _TIME_ID=null;
		string _RAW_HEAD_UUID=null;
		decimal? _VALUE=null;
		string _USER_FILE_NAME=null;
		string _SYSTEM_FILE_NAME=null;
		string _ERROR_MESSAGE=null;
		string _USER_EXPLAIN=null;
		decimal? _APPROVED_VALUE=null;
		string _BATCH_UUID=null;
		string _IS_SUBMIT=null;
		DateTime? _SUBMIT_DATE=null;
		DateTime? _APPROVED_DATE=null;
		string _CONTROL_VOUCHER_POINT_UUID=null;
		string _REJECT_RAW_PROCESS_ITEM_UUID=null;
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

		[ColumnName("IS_ACTIVE",false,typeof(string))]
		public string IS_ACTIVE
		{
			set
			{
				_IS_ACTIVE=value;
			}
			get
			{
				return _IS_ACTIVE;
			}
		}

		[ColumnName("RAW_PROCESS_HEAD_UUID",false,typeof(string))]
		public string RAW_PROCESS_HEAD_UUID
		{
			set
			{
				_RAW_PROCESS_HEAD_UUID=value;
			}
			get
			{
				return _RAW_PROCESS_HEAD_UUID;
			}
		}

		[ColumnName("TIME_ID",false,typeof(string))]
		public string TIME_ID
		{
			set
			{
				_TIME_ID=value;
			}
			get
			{
				return _TIME_ID;
			}
		}

		[ColumnName("RAW_HEAD_UUID",false,typeof(string))]
		public string RAW_HEAD_UUID
		{
			set
			{
				_RAW_HEAD_UUID=value;
			}
			get
			{
				return _RAW_HEAD_UUID;
			}
		}

		[ColumnName("VALUE",false,typeof(decimal?))]
		public decimal? VALUE
		{
			set
			{
				_VALUE=value;
			}
			get
			{
				return _VALUE;
			}
		}

		[ColumnName("USER_FILE_NAME",false,typeof(string))]
		public string USER_FILE_NAME
		{
			set
			{
				_USER_FILE_NAME=value;
			}
			get
			{
				return _USER_FILE_NAME;
			}
		}

		[ColumnName("SYSTEM_FILE_NAME",false,typeof(string))]
		public string SYSTEM_FILE_NAME
		{
			set
			{
				_SYSTEM_FILE_NAME=value;
			}
			get
			{
				return _SYSTEM_FILE_NAME;
			}
		}

		[ColumnName("ERROR_MESSAGE",false,typeof(string))]
		public string ERROR_MESSAGE
		{
			set
			{
				_ERROR_MESSAGE=value;
			}
			get
			{
				return _ERROR_MESSAGE;
			}
		}

		[ColumnName("USER_EXPLAIN",false,typeof(string))]
		public string USER_EXPLAIN
		{
			set
			{
				_USER_EXPLAIN=value;
			}
			get
			{
				return _USER_EXPLAIN;
			}
		}

		[ColumnName("APPROVED_VALUE",false,typeof(decimal?))]
		public decimal? APPROVED_VALUE
		{
			set
			{
				_APPROVED_VALUE=value;
			}
			get
			{
				return _APPROVED_VALUE;
			}
		}

		[ColumnName("BATCH_UUID",false,typeof(string))]
		public string BATCH_UUID
		{
			set
			{
				_BATCH_UUID=value;
			}
			get
			{
				return _BATCH_UUID;
			}
		}

		[ColumnName("IS_SUBMIT",false,typeof(string))]
		public string IS_SUBMIT
		{
			set
			{
				_IS_SUBMIT=value;
			}
			get
			{
				return _IS_SUBMIT;
			}
		}

		[ColumnName("SUBMIT_DATE",false,typeof(DateTime?))]
		public DateTime? SUBMIT_DATE
		{
			set
			{
				_SUBMIT_DATE=value;
			}
			get
			{
				return _SUBMIT_DATE;
			}
		}

		[ColumnName("APPROVED_DATE",false,typeof(DateTime?))]
		public DateTime? APPROVED_DATE
		{
			set
			{
				_APPROVED_DATE=value;
			}
			get
			{
				return _APPROVED_DATE;
			}
		}

		[ColumnName("CONTROL_VOUCHER_POINT_UUID",false,typeof(string))]
		public string CONTROL_VOUCHER_POINT_UUID
		{
			set
			{
				_CONTROL_VOUCHER_POINT_UUID=value;
			}
			get
			{
				return _CONTROL_VOUCHER_POINT_UUID;
			}
		}

		[ColumnName("REJECT_RAW_PROCESS_ITEM_UUID",false,typeof(string))]
		public string REJECT_RAW_PROCESS_ITEM_UUID
		{
			set
			{
				_REJECT_RAW_PROCESS_ITEM_UUID=value;
			}
			get
			{
				return _REJECT_RAW_PROCESS_ITEM_UUID;
			}
		}
		public RawProcessItem_Record Clone(){
			try{
				return this.Clone<RawProcessItem_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RawProcessItem gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessItem ret = new RawProcessItem(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<RawProcessHead_Record> Link_RawProcessHead_By_Uuid()
		{
			try{
				List<RawProcessHead_Record> ret= new List<RawProcessHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessHead ___table = new RawProcessHead(dbc);
				ret=(List<RawProcessHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_PROCESS_HEAD_UUID))
					.FetchAll<RawProcessHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<RawProcessHead_Record> Link_RawProcessHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawProcessHead_Record> ret= new List<RawProcessHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessHead ___table = new RawProcessHead(dbc);
				ret=(List<RawProcessHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_PROCESS_HEAD_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<RawProcessHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public RawProcessHead LinkFill_RawProcessHead_By_Uuid()
		{
			try{
				var data = Link_RawProcessHead_By_Uuid();
				RawProcessHead ret=new RawProcessHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public RawProcessHead LinkFill_RawProcessHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_RawProcessHead_By_Uuid(limit);
				RawProcessHead ret=new RawProcessHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
