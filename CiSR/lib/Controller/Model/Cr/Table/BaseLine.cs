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
	[ISTTableView("BASE_LINE", true)]
	public partial class BaseLine : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private BaseLine_Record _currentRecord = null;
	private IList<BaseLine_Record> _All_Record = new List<BaseLine_Record>();
		/*建構子*/
		public BaseLine(){}
		public BaseLine(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public BaseLine(IDataBaseConfigInfo dbc): base(dbc){}
		public BaseLine(IDataBaseConfigInfo dbc,BaseLine_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public BaseLine(IList<BaseLine_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string START_YEAR {get{return "START_YEAR" ; }}
		public string END_YEAR {get{return "END_YEAR" ; }}
		public string BASE_YEAR {get{return "BASE_YEAR" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public BaseLine_Record CurrentRecord(){
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
		public BaseLine_Record CreateNew(){
			try{
				BaseLine_Record newData = new BaseLine_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<BaseLine_Record> AllRecord(){
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
				_All_Record = new List<BaseLine_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public BaseLine Fill_By_PK(string pUUID){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>()  ;  
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
		public BaseLine Fill_By_PK(string pUUID,DB db){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>(db)  ;  
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
		public BaseLine_Record Fetch_By_PK(string pUUID){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public BaseLine_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public BaseLine Fill_By_Uuid(string pUUID){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>()  ;  
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
		public BaseLine Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>(db)  ;  
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
		public BaseLine_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public BaseLine_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<BaseLine_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<BaseLine_Record>(db)  ;  
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
				UpdateAllRecord<BaseLine_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<BaseLine_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<BaseLine_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<BaseLine_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<BaseLine_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<BaseLine_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
