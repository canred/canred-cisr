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
	[ISTTableView("TIME", true)]
	public partial class Time : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Time_Record _currentRecord = null;
	private IList<Time_Record> _All_Record = new List<Time_Record>();
		/*建構子*/
		public Time(){}
		public Time(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Time(IDataBaseConfigInfo dbc): base(dbc){}
		public Time(IDataBaseConfigInfo dbc,Time_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Time(IList<Time_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string TIME_TYPE {get{return "TIME_TYPE" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Time_Record CurrentRecord(){
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
		public Time_Record CreateNew(){
			try{
				Time_Record newData = new Time_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Time_Record> AllRecord(){
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
				_All_Record = new List<Time_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Time Fill_By_PK(string pTIME_ID,string pTIME_TYPE){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.And()
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>()  ;  
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
		public Time Fill_By_PK(string pTIME_ID,string pTIME_TYPE,DB db){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.And()
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>(db)  ;  
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
		public Time_Record Fetch_By_PK(string pTIME_ID,string pTIME_TYPE){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Time_Record Fetch_By_PK(string pTIME_ID,string pTIME_TYPE,DB db){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Time Fill_By_TimeId_And_TimeType(string pTIME_ID,string pTIME_TYPE){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>()  ;  
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
		public Time Fill_By_TimeId_And_TimeType(string pTIME_ID,string pTIME_TYPE,DB db){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>(db)  ;  
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
		public Time_Record Fetch_By_TimeId_And_TimeType(string pTIME_ID,string pTIME_TYPE){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Time_Record Fetch_By_TimeId_And_TimeType(string pTIME_ID,string pTIME_TYPE,DB db){
			try{
				IList<Time_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.TIME_TYPE,pTIME_TYPE)
				).FetchAll<Time_Record>(db)  ;  
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
				UpdateAllRecord<Time_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<Time_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<Time_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<Time_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<Time_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<Time_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
