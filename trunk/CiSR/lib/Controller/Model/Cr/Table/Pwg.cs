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
	[ISTTableView("PWG", true)]
	public partial class Pwg : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Pwg_Record _currentRecord = null;
	private IList<Pwg_Record> _All_Record = new List<Pwg_Record>();
		/*建構子*/
		public Pwg(){}
		public Pwg(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Pwg(IDataBaseConfigInfo dbc): base(dbc){}
		public Pwg(IDataBaseConfigInfo dbc,Pwg_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Pwg(IList<Pwg_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string GID {get{return "GID" ; }}
		public string ATTENDANT_UUID {get{return "ATTENDANT_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Pwg_Record CurrentRecord(){
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
		public Pwg_Record CreateNew(){
			try{
				Pwg_Record newData = new Pwg_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Pwg_Record> AllRecord(){
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
				_All_Record = new List<Pwg_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Pwg Fill_By_PK(string pGID,string pATTENDANT_UUID){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.And()
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>()  ;  
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
		public Pwg Fill_By_PK(string pGID,string pATTENDANT_UUID,DB db){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.And()
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>(db)  ;  
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
		public Pwg_Record Fetch_By_PK(string pGID,string pATTENDANT_UUID){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Pwg_Record Fetch_By_PK(string pGID,string pATTENDANT_UUID,DB db){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Pwg Fill_By_Gid_And_AttendantUuid(string pGID,string pATTENDANT_UUID){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>()  ;  
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
		public Pwg Fill_By_Gid_And_AttendantUuid(string pGID,string pATTENDANT_UUID,DB db){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>(db)  ;  
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
		public Pwg_Record Fetch_By_Gid_And_AttendantUuid(string pGID,string pATTENDANT_UUID){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Pwg_Record Fetch_By_Gid_And_AttendantUuid(string pGID,string pATTENDANT_UUID,DB db){
			try{
				IList<Pwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.GID,pGID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Pwg_Record>(db)  ;  
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
				UpdateAllRecord<Pwg_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<Pwg_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<Pwg_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<Pwg_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<Pwg_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<Pwg_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
