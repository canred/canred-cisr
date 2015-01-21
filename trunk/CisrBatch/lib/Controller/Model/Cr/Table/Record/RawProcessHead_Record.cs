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
	[ISTTableView("RAW_PROCESS_HEAD", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class RawProcessHead_Record : RecordBase{
		public RawProcessHead_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _COMPANY_UUID=null;
		string _FRAME_HEAD_UUID=null;
		string _ROLE_HEAD_UUID=null;
		string _TIME_TYPE=null;
		string _TIME_ID=null;
		string _CLASS=null;
		string _NAME=null;
		string _KEY=null;
		string _SOURCE=null;
		string _VOUCHER_POINT_UUID=null;
		string _USER_FILE_NAME=null;
		string _SYSTEM_FILE_NAME=null;
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

		[ColumnName("FRAME_HEAD_UUID",false,typeof(string))]
		public string FRAME_HEAD_UUID
		{
			set
			{
				_FRAME_HEAD_UUID=value;
			}
			get
			{
				return _FRAME_HEAD_UUID;
			}
		}

		[ColumnName("ROLE_HEAD_UUID",false,typeof(string))]
		public string ROLE_HEAD_UUID
		{
			set
			{
				_ROLE_HEAD_UUID=value;
			}
			get
			{
				return _ROLE_HEAD_UUID;
			}
		}

		[ColumnName("TIME_TYPE",false,typeof(string))]
		public string TIME_TYPE
		{
			set
			{
				_TIME_TYPE=value;
			}
			get
			{
				return _TIME_TYPE;
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

		[ColumnName("CLASS",false,typeof(string))]
		public string CLASS
		{
			set
			{
				_CLASS=value;
			}
			get
			{
				return _CLASS;
			}
		}

		[ColumnName("NAME",false,typeof(string))]
		public string NAME
		{
			set
			{
				_NAME=value;
			}
			get
			{
				return _NAME;
			}
		}

		[ColumnName("KEY",false,typeof(string))]
		public string KEY
		{
			set
			{
				_KEY=value;
			}
			get
			{
				return _KEY;
			}
		}

		[ColumnName("SOURCE",false,typeof(string))]
		public string SOURCE
		{
			set
			{
				_SOURCE=value;
			}
			get
			{
				return _SOURCE;
			}
		}

		[ColumnName("VOUCHER_POINT_UUID",false,typeof(string))]
		public string VOUCHER_POINT_UUID
		{
			set
			{
				_VOUCHER_POINT_UUID=value;
			}
			get
			{
				return _VOUCHER_POINT_UUID;
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
		public RawProcessHead_Record Clone(){
			try{
				return this.Clone<RawProcessHead_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RawProcessHead gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessHead ret = new RawProcessHead(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<RawProcessItem_Record> Link_RawProcessItem_By_RawProcessHeadUuid()
		{
			try{
				List<RawProcessItem_Record> ret= new List<RawProcessItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessItem ___table = new RawProcessItem(dbc);
				ret=(List<RawProcessItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_PROCESS_HEAD_UUID,this.UUID))
					.FetchAll<RawProcessItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<RawProcessItem_Record> Link_RawProcessItem_By_RawProcessHeadUuid(OrderLimit limit)
		{
			try{
				List<RawProcessItem_Record> ret= new List<RawProcessItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessItem ___table = new RawProcessItem(dbc);
				ret=(List<RawProcessItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_PROCESS_HEAD_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<RawProcessItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public RawProcessItem LinkFill_RawProcessItem_By_RawProcessHeadUuid()
		{
			try{
				var data = Link_RawProcessItem_By_RawProcessHeadUuid();
				RawProcessItem ret=new RawProcessItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public RawProcessItem LinkFill_RawProcessItem_By_RawProcessHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawProcessItem_By_RawProcessHeadUuid(limit);
				RawProcessItem ret=new RawProcessItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
