using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using IST.Attribute;  
using IST.DB;  
using IST.Config.DataBase;  
using IST.DB.SQLCreater;  
using CISR.Model.Cr.Table.Record  ;  
namespace CISR.Model.Cr.Table
{
	[ISTDataBase("CISR")]
	[ISTTableView("RAW_DATA", true)]
	public partial class RawData : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private RawData_Record _currentRecord = null;
	private IList<RawData_Record> _All_Record = new List<RawData_Record>();
		/*建構子*/
		public RawData(){}
		public RawData(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public RawData(IDataBaseConfigInfo dbc): base(dbc){}
		public RawData(IDataBaseConfigInfo dbc,RawData_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public RawData(IList<RawData_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string FRAME_HEAD_UUID {get{return "FRAME_HEAD_UUID" ; }}
		public string RAW_HEAD_UUID {get{return "RAW_HEAD_UUID" ; }}
		public string VALUE {get{return "VALUE" ; }}
		public string SOURCE_TABLE {get{return "SOURCE_TABLE" ; }}
		public string SOURCE_TABLE_UUID {get{return "SOURCE_TABLE_UUID" ; }}
		public string USER_FILE_NAME {get{return "USER_FILE_NAME" ; }}
		public string SYSTEM_FILE_NAME {get{return "SYSTEM_FILE_NAME" ; }}
		public string USER_EXPLAIN {get{return "USER_EXPLAIN" ; }}
		public string INSERT_DATE {get{return "INSERT_DATE" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public RawData_Record CurrentRecord(){
			try{
				if (_currentRecord == null){
					if (this._All_Record.Count > 0){
						_currentRecord = this._All_Record.First();
					}
				}
				return _currentRecord;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RawData_Record CreateNew(){
			try{
				RawData_Record newData = new RawData_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<RawData_Record> AllRecord(){
			try{
				return _All_Record;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public void RemoveAllRecord(){
			try{
				_All_Record = new List<RawData_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public RawData Fill_By_PK(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.And()
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.And()
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>()  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 201303180156
		public RawData Fill_By_PK(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID,DB db){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.And()
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.And()
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>(db)  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319042
		public RawData_Record Fetch_By_PK(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public RawData_Record Fetch_By_PK(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID,DB db){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public RawData Fill_By_TimeId_And_FrameHeadUuid_And_RawHeadUuid(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>()  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319046
		public RawData Fill_By_TimeId_And_FrameHeadUuid_And_RawHeadUuid(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID,DB db){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>(db)  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319047
		public RawData_Record Fetch_By_TimeId_And_FrameHeadUuid_And_RawHeadUuid(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public RawData_Record Fetch_By_TimeId_And_FrameHeadUuid_And_RawHeadUuid(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID,DB db){
			try{
				IList<RawData_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
				).FetchAll<RawData_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord() {
			try{
				UpdateAllRecord<RawData_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<RawData_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<RawData_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<RawData_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<RawData_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<RawData_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid()
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.FRAME_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameHead_Record>)
						___table.Where(condition)
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
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHead_Record>)
						___table.Where(condition)
						.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.FRAME_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameHead_Record>)
						___table.Where(condition)
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
		/*201303180340*/
		public List<RawHead_Record> Link_RawHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHead_Record>)
						___table.Where(condition)
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
		/*201303180336*/
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
		/*201303180336*/
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
		/*201303180337*/
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
		/*201303180337*/
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
