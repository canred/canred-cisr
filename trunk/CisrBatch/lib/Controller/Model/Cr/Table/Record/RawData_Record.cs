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
	[ISTTableView("RAW_DATA", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class RawData_Record : RecordBase{
		public RawData_Record(){}
		/*欄位資訊 Start*/
		string _TIME_ID=null;
		string _FRAME_HEAD_UUID=null;
		string _RAW_HEAD_UUID=null;
		decimal? _VALUE=null;
		string _SOURCE_TABLE=null;
		string _SOURCE_TABLE_UUID=null;
		string _USER_FILE_NAME=null;
		string _SYSTEM_FILE_NAME=null;
		string _USER_EXPLAIN=null;
		DateTime? _INSERT_DATE=null;
		/*欄位資訊 End*/

		[ColumnName("TIME_ID",true,typeof(string))]
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

		[ColumnName("FRAME_HEAD_UUID",true,typeof(string))]
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

		[ColumnName("RAW_HEAD_UUID",true,typeof(string))]
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

		[ColumnName("SOURCE_TABLE",false,typeof(string))]
		public string SOURCE_TABLE
		{
			set
			{
				_SOURCE_TABLE=value;
			}
			get
			{
				return _SOURCE_TABLE;
			}
		}

		[ColumnName("SOURCE_TABLE_UUID",false,typeof(string))]
		public string SOURCE_TABLE_UUID
		{
			set
			{
				_SOURCE_TABLE_UUID=value;
			}
			get
			{
				return _SOURCE_TABLE_UUID;
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

		[ColumnName("INSERT_DATE",false,typeof(DateTime?))]
		public DateTime? INSERT_DATE
		{
			set
			{
				_INSERT_DATE=value;
			}
			get
			{
				return _INSERT_DATE;
			}
		}
		public RawData_Record Clone(){
			try{
				return this.Clone<RawData_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RawData gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ret = new RawData(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<FrameHead_Record> Link_FrameHead_By_Uuid()
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.FRAME_HEAD_UUID))
					.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<RawHead_Record> Link_RawHead_By_Uuid()
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				ret=(List<RawHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_HEAD_UUID))
					.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.FRAME_HEAD_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<RawHead_Record> Link_RawHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				ret=(List<RawHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_HEAD_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public FrameHead LinkFill_FrameHead_By_Uuid()
		{
			try{
				var data = Link_FrameHead_By_Uuid();
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public RawHead LinkFill_RawHead_By_Uuid()
		{
			try{
				var data = Link_RawHead_By_Uuid();
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public FrameHead LinkFill_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameHead_By_Uuid(limit);
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public RawHead LinkFill_RawHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHead_By_Uuid(limit);
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
