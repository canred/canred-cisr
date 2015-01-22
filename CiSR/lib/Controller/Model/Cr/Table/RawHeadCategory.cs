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
	[ISTTableView("RAW_HEAD_CATEGORY", true)]
	public partial class RawHeadCategory : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private RawHeadCategory_Record _currentRecord = null;
	private IList<RawHeadCategory_Record> _All_Record = new List<RawHeadCategory_Record>();
		/*建構子*/
		public RawHeadCategory(){}
		public RawHeadCategory(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public RawHeadCategory(IDataBaseConfigInfo dbc): base(dbc){}
		public RawHeadCategory(IDataBaseConfigInfo dbc,RawHeadCategory_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public RawHeadCategory(IList<RawHeadCategory_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string NAME {get{return "NAME" ; }}
		public string DESCRIPTION {get{return "DESCRIPTION" ; }}
		public string LAN_NO {get{return "LAN_NO" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public RawHeadCategory_Record CurrentRecord(){
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
		public RawHeadCategory_Record CreateNew(){
			try{
				RawHeadCategory_Record newData = new RawHeadCategory_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<RawHeadCategory_Record> AllRecord(){
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
				_All_Record = new List<RawHeadCategory_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public RawHeadCategory Fill_By_PK(string pUUID){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>()  ;  
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
		public RawHeadCategory Fill_By_PK(string pUUID,DB db){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>(db)  ;  
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
		public RawHeadCategory_Record Fetch_By_PK(string pUUID){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public RawHeadCategory_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public RawHeadCategory Fill_By_Uuid(string pUUID){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>()  ;  
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
		public RawHeadCategory Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>(db)  ;  
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
		public RawHeadCategory_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public RawHeadCategory_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<RawHeadCategory_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHeadCategory_Record>(db)  ;  
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
				UpdateAllRecord<RawHeadCategory_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<RawHeadCategory_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<RawHeadCategory_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<RawHeadCategory_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<RawHeadCategory_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<RawHeadCategory_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<RawHead_Record> Link_RawHead_By_RawCategoryUuid()
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_CATEGORY_UUID,item.UUID).R().Or()  ; 
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
		/*201303180321*/
		public List<RawHead_Record> Link_RawHead_By_RawCategoryUuid(OrderLimit limit)
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_CATEGORY_UUID,item.UUID).R().Or()  ; 
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
		/*201303180324*/
		public RawHead LinkFill_RawHead_By_RawCategoryUuid()
		{
			try{
				var data = Link_RawHead_By_RawCategoryUuid();
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public RawHead LinkFill_RawHead_By_RawCategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHead_By_RawCategoryUuid(limit);
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
