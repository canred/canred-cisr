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
	[ISTTableView("RAW_PROCESS_HEAD", true)]
	public partial class RawProcessHead : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private RawProcessHead_Record _currentRecord = null;
	private IList<RawProcessHead_Record> _All_Record = new List<RawProcessHead_Record>();
		/*建構子*/
		public RawProcessHead(){}
		public RawProcessHead(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public RawProcessHead(IDataBaseConfigInfo dbc): base(dbc){}
		public RawProcessHead(IDataBaseConfigInfo dbc,RawProcessHead_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public RawProcessHead(IList<RawProcessHead_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string FRAME_HEAD_UUID {get{return "FRAME_HEAD_UUID" ; }}
		public string ROLE_HEAD_UUID {get{return "ROLE_HEAD_UUID" ; }}
		public string TIME_TYPE {get{return "TIME_TYPE" ; }}
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string CLASS {get{return "CLASS" ; }}
		public string NAME {get{return "NAME" ; }}
		public string KEY {get{return "KEY" ; }}
		public string SOURCE {get{return "SOURCE" ; }}
		public string VOUCHER_POINT_UUID {get{return "VOUCHER_POINT_UUID" ; }}
		public string USER_FILE_NAME {get{return "USER_FILE_NAME" ; }}
		public string SYSTEM_FILE_NAME {get{return "SYSTEM_FILE_NAME" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public RawProcessHead_Record CurrentRecord(){
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
		public RawProcessHead_Record CreateNew(){
			try{
				RawProcessHead_Record newData = new RawProcessHead_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<RawProcessHead_Record> AllRecord(){
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
				_All_Record = new List<RawProcessHead_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public RawProcessHead Fill_By_PK(string pUUID){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>()  ;  
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
		public RawProcessHead Fill_By_PK(string pUUID,DB db){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>(db)  ;  
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
		public RawProcessHead_Record Fetch_By_PK(string pUUID){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public RawProcessHead_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public RawProcessHead Fill_By_Uuid(string pUUID){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>()  ;  
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
		public RawProcessHead Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>(db)  ;  
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
		public RawProcessHead_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public RawProcessHead_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<RawProcessHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessHead_Record>(db)  ;  
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
				UpdateAllRecord<RawProcessHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<RawProcessHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<RawProcessHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<RawProcessHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<RawProcessHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<RawProcessHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<RawProcessItem_Record> Link_RawProcessItem_By_RawProcessHeadUuid()
		{
			try{
				List<RawProcessItem_Record> ret= new List<RawProcessItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessItem ___table = new RawProcessItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_PROCESS_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawProcessItem_Record>)
						___table.Where(condition)
						.FetchAll<RawProcessItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<RawProcessItem_Record> Link_RawProcessItem_By_RawProcessHeadUuid(OrderLimit limit)
		{
			try{
				List<RawProcessItem_Record> ret= new List<RawProcessItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessItem ___table = new RawProcessItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_PROCESS_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawProcessItem_Record>)
						___table.Where(condition)
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
		/*201303180324*/
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
		/*201303180325*/
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
