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
	[ISTTableView("PARAMETER_ITEM_OWNER", true)]
	public partial class ParameterItemOwner : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private ParameterItemOwner_Record _currentRecord = null;
	private IList<ParameterItemOwner_Record> _All_Record = new List<ParameterItemOwner_Record>();
		/*建構子*/
		public ParameterItemOwner(){}
		public ParameterItemOwner(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public ParameterItemOwner(IDataBaseConfigInfo dbc): base(dbc){}
		public ParameterItemOwner(IDataBaseConfigInfo dbc,ParameterItemOwner_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public ParameterItemOwner(IList<ParameterItemOwner_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string PARAMETER_ITEM_UUID {get{return "PARAMETER_ITEM_UUID" ; }}
		public string ATTENDANT_UUID {get{return "ATTENDANT_UUID" ; }}
		public string CREATE_USER {get{return "CREATE_USER" ; }}
		public string UPDATE_USER {get{return "UPDATE_USER" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public ParameterItemOwner_Record CurrentRecord(){
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
		public ParameterItemOwner_Record CreateNew(){
			try{
				ParameterItemOwner_Record newData = new ParameterItemOwner_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<ParameterItemOwner_Record> AllRecord(){
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
				_All_Record = new List<ParameterItemOwner_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public ParameterItemOwner Fill_By_PK(string pUUID){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>()  ;  
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
		public ParameterItemOwner Fill_By_PK(string pUUID,DB db){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>(db)  ;  
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
		public ParameterItemOwner_Record Fetch_By_PK(string pUUID){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public ParameterItemOwner_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public ParameterItemOwner Fill_By_Uuid(string pUUID){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>()  ;  
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
		public ParameterItemOwner Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>(db)  ;  
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
		public ParameterItemOwner_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public ParameterItemOwner_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<ParameterItemOwner_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItemOwner_Record>(db)  ;  
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
				UpdateAllRecord<ParameterItemOwner_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<ParameterItemOwner_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<ParameterItemOwner_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<ParameterItemOwner_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<ParameterItemOwner_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<ParameterItemOwner_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<ParameterItem_Record> Link_ParameterItem_By_Uuid()
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.PARAMETER_ITEM_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterItem_Record>)
						___table.Where(condition)
						.FetchAll<ParameterItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<ParameterItem_Record> Link_ParameterItem_By_Uuid(OrderLimit limit)
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.PARAMETER_ITEM_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterItem_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<ParameterItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public ParameterItem LinkFill_ParameterItem_By_Uuid()
		{
			try{
				var data = Link_ParameterItem_By_Uuid();
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public ParameterItem LinkFill_ParameterItem_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterItem_By_Uuid(limit);
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
