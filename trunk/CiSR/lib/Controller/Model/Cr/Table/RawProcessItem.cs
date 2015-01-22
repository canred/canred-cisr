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
	[ISTTableView("RAW_PROCESS_ITEM", true)]
	public partial class RawProcessItem : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private RawProcessItem_Record _currentRecord = null;
	private IList<RawProcessItem_Record> _All_Record = new List<RawProcessItem_Record>();
		/*建構子*/
		public RawProcessItem(){}
		public RawProcessItem(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public RawProcessItem(IDataBaseConfigInfo dbc): base(dbc){}
		public RawProcessItem(IDataBaseConfigInfo dbc,RawProcessItem_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public RawProcessItem(IList<RawProcessItem_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string RAW_PROCESS_HEAD_UUID {get{return "RAW_PROCESS_HEAD_UUID" ; }}
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string RAW_HEAD_UUID {get{return "RAW_HEAD_UUID" ; }}
		public string VALUE {get{return "VALUE" ; }}
		public string USER_FILE_NAME {get{return "USER_FILE_NAME" ; }}
		public string SYSTEM_FILE_NAME {get{return "SYSTEM_FILE_NAME" ; }}
		public string ERROR_MESSAGE {get{return "ERROR_MESSAGE" ; }}
		public string USER_EXPLAIN {get{return "USER_EXPLAIN" ; }}
		public string APPROVED_VALUE {get{return "APPROVED_VALUE" ; }}
		public string BATCH_UUID {get{return "BATCH_UUID" ; }}
		public string IS_SUBMIT {get{return "IS_SUBMIT" ; }}
		public string SUBMIT_DATE {get{return "SUBMIT_DATE" ; }}
		public string APPROVED_DATE {get{return "APPROVED_DATE" ; }}
		public string CONTROL_VOUCHER_POINT_UUID {get{return "CONTROL_VOUCHER_POINT_UUID" ; }}
		public string REJECT_RAW_PROCESS_ITEM_UUID {get{return "REJECT_RAW_PROCESS_ITEM_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public RawProcessItem_Record CurrentRecord(){
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
		public RawProcessItem_Record CreateNew(){
			try{
				RawProcessItem_Record newData = new RawProcessItem_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<RawProcessItem_Record> AllRecord(){
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
				_All_Record = new List<RawProcessItem_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public RawProcessItem Fill_By_PK(string pUUID){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>()  ;  
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
		public RawProcessItem Fill_By_PK(string pUUID,DB db){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>(db)  ;  
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
		public RawProcessItem_Record Fetch_By_PK(string pUUID){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public RawProcessItem_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public RawProcessItem Fill_By_Uuid(string pUUID){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>()  ;  
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
		public RawProcessItem Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>(db)  ;  
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
		public RawProcessItem_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public RawProcessItem_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<RawProcessItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawProcessItem_Record>(db)  ;  
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
				UpdateAllRecord<RawProcessItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<RawProcessItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<RawProcessItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<RawProcessItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<RawProcessItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<RawProcessItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<RawProcessHead_Record> Link_RawProcessHead_By_Uuid()
		{
			try{
				List<RawProcessHead_Record> ret= new List<RawProcessHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessHead ___table = new RawProcessHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_PROCESS_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawProcessHead_Record>)
						___table.Where(condition)
						.FetchAll<RawProcessHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<RawProcessHead_Record> Link_RawProcessHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawProcessHead_Record> ret= new List<RawProcessHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawProcessHead ___table = new RawProcessHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_PROCESS_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawProcessHead_Record>)
						___table.Where(condition)
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
		/*201303180336*/
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
		/*201303180337*/
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
