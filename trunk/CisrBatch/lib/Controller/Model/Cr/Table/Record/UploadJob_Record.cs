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
	[ISTTableView("UPLOAD_JOB", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class UploadJob_Record : RecordBase{
		public UploadJob_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _FRAME_HEAD_UUID=null;
		string _RAW_HEAD_UUID=null;
		string _TIME_ID=null;
		string _COMPANY_UUID=null;
		string _FILES_GROUP_ID=null;
		decimal? _VALUE=null;
		string _EXPLAIN=null;
		string _DWG1_GID=null;
		string _DWG2_GID=null;
		string _DWG3_GID=null;
		string _DWG4_GID=null;
		string _DWG5_GID=null;
		DateTime? _UPDATE_DATE=null;
		decimal? _STATUS=null;
		string _SKIP=null;
		string _SKIP_RESULT=null;
		string _DWG1_SHOW=null;
		string _DWG2_SHOW=null;
		string _DWG3_SHOW=null;
		string _DWG4_SHOW=null;
		string _DWG5_SHOW=null;
		decimal? _FINISH=null;
		string _FULL_ATTENDANT_UUID=null;
		decimal? _FILES_COUNT=null;
		string _NOW_ATTENDANT_UUID=null;
		string _LAST_ATTENDANT_UUID=null;
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

		[ColumnName("EXPLAIN",false,typeof(string))]
		public string EXPLAIN
		{
			set
			{
				_EXPLAIN=value;
			}
			get
			{
				return _EXPLAIN;
			}
		}

		[ColumnName("DWG1_GID",false,typeof(string))]
		public string DWG1_GID
		{
			set
			{
				_DWG1_GID=value;
			}
			get
			{
				return _DWG1_GID;
			}
		}

		[ColumnName("DWG2_GID",false,typeof(string))]
		public string DWG2_GID
		{
			set
			{
				_DWG2_GID=value;
			}
			get
			{
				return _DWG2_GID;
			}
		}

		[ColumnName("DWG3_GID",false,typeof(string))]
		public string DWG3_GID
		{
			set
			{
				_DWG3_GID=value;
			}
			get
			{
				return _DWG3_GID;
			}
		}

		[ColumnName("DWG4_GID",false,typeof(string))]
		public string DWG4_GID
		{
			set
			{
				_DWG4_GID=value;
			}
			get
			{
				return _DWG4_GID;
			}
		}

		[ColumnName("DWG5_GID",false,typeof(string))]
		public string DWG5_GID
		{
			set
			{
				_DWG5_GID=value;
			}
			get
			{
				return _DWG5_GID;
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

		[ColumnName("STATUS",false,typeof(decimal?))]
		public decimal? STATUS
		{
			set
			{
				_STATUS=value;
			}
			get
			{
				return _STATUS;
			}
		}

		[ColumnName("SKIP",false,typeof(string))]
		public string SKIP
		{
			set
			{
				_SKIP=value;
			}
			get
			{
				return _SKIP;
			}
		}

		[ColumnName("SKIP_RESULT",false,typeof(string))]
		public string SKIP_RESULT
		{
			set
			{
				_SKIP_RESULT=value;
			}
			get
			{
				return _SKIP_RESULT;
			}
		}

		[ColumnName("DWG1_SHOW",false,typeof(string))]
		public string DWG1_SHOW
		{
			set
			{
				_DWG1_SHOW=value;
			}
			get
			{
				return _DWG1_SHOW;
			}
		}

		[ColumnName("DWG2_SHOW",false,typeof(string))]
		public string DWG2_SHOW
		{
			set
			{
				_DWG2_SHOW=value;
			}
			get
			{
				return _DWG2_SHOW;
			}
		}

		[ColumnName("DWG3_SHOW",false,typeof(string))]
		public string DWG3_SHOW
		{
			set
			{
				_DWG3_SHOW=value;
			}
			get
			{
				return _DWG3_SHOW;
			}
		}

		[ColumnName("DWG4_SHOW",false,typeof(string))]
		public string DWG4_SHOW
		{
			set
			{
				_DWG4_SHOW=value;
			}
			get
			{
				return _DWG4_SHOW;
			}
		}

		[ColumnName("DWG5_SHOW",false,typeof(string))]
		public string DWG5_SHOW
		{
			set
			{
				_DWG5_SHOW=value;
			}
			get
			{
				return _DWG5_SHOW;
			}
		}

		[ColumnName("FINISH",false,typeof(decimal?))]
		public decimal? FINISH
		{
			set
			{
				_FINISH=value;
			}
			get
			{
				return _FINISH;
			}
		}

		[ColumnName("FULL_ATTENDANT_UUID",false,typeof(string))]
		public string FULL_ATTENDANT_UUID
		{
			set
			{
				_FULL_ATTENDANT_UUID=value;
			}
			get
			{
				return _FULL_ATTENDANT_UUID;
			}
		}

		[ColumnName("FILES_COUNT",false,typeof(decimal?))]
		public decimal? FILES_COUNT
		{
			set
			{
				_FILES_COUNT=value;
			}
			get
			{
				return _FILES_COUNT;
			}
		}

		[ColumnName("NOW_ATTENDANT_UUID",false,typeof(string))]
		public string NOW_ATTENDANT_UUID
		{
			set
			{
				_NOW_ATTENDANT_UUID=value;
			}
			get
			{
				return _NOW_ATTENDANT_UUID;
			}
		}

		[ColumnName("LAST_ATTENDANT_UUID",false,typeof(string))]
		public string LAST_ATTENDANT_UUID
		{
			set
			{
				_LAST_ATTENDANT_UUID=value;
			}
			get
			{
				return _LAST_ATTENDANT_UUID;
			}
		}
		public UploadJob_Record Clone(){
			try{
				return this.Clone<UploadJob_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public UploadJob gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ret = new UploadJob(dbc,this);
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
