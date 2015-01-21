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
	[ISTTableView("DWG", true)]
	public partial class Dwg : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private Dwg_Record _currentRecord = null;
	private IList<Dwg_Record> _All_Record = new List<Dwg_Record>();
		/*建構子*/
		public Dwg(){}
		public Dwg(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public Dwg(IDataBaseConfigInfo dbc): base(dbc){}
		public Dwg(IDataBaseConfigInfo dbc,Dwg_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public Dwg(IList<Dwg_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string DWG_GID {get{return "DWG_GID" ; }}
		public string ATTENDANT_UUID {get{return "ATTENDANT_UUID" ; }}
		public string IS_FINISH {get{return "IS_FINISH" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public Dwg_Record CurrentRecord(){
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
		public Dwg_Record CreateNew(){
			try{
				Dwg_Record newData = new Dwg_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<Dwg_Record> AllRecord(){
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
				_All_Record = new List<Dwg_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public Dwg Fill_By_PK(string pDWG_GID,string pATTENDANT_UUID){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.And()
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>()  ;  
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
		public Dwg Fill_By_PK(string pDWG_GID,string pATTENDANT_UUID,DB db){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.And()
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>(db)  ;  
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
		public Dwg_Record Fetch_By_PK(string pDWG_GID,string pATTENDANT_UUID){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public Dwg_Record Fetch_By_PK(string pDWG_GID,string pATTENDANT_UUID,DB db){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public Dwg Fill_By_DwgGid_And_AttendantUuid(string pDWG_GID,string pATTENDANT_UUID){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>()  ;  
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
		public Dwg Fill_By_DwgGid_And_AttendantUuid(string pDWG_GID,string pATTENDANT_UUID,DB db){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>(db)  ;  
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
		public Dwg_Record Fetch_By_DwgGid_And_AttendantUuid(string pDWG_GID,string pATTENDANT_UUID){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public Dwg_Record Fetch_By_DwgGid_And_AttendantUuid(string pDWG_GID,string pATTENDANT_UUID,DB db){
			try{
				IList<Dwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.DWG_GID,pDWG_GID)
									.Equal(this.ATTENDANT_UUID,pATTENDANT_UUID)
				).FetchAll<Dwg_Record>(db)  ;  
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
				UpdateAllRecord<Dwg_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<Dwg_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<Dwg_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<Dwg_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<Dwg_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<Dwg_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
