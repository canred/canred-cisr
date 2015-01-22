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
	[ISTTableView("PARAMETER_HEAD", true)]
	public partial class ParameterHead : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private ParameterHead_Record _currentRecord = null;
	private IList<ParameterHead_Record> _All_Record = new List<ParameterHead_Record>();
		/*建構子*/
		public ParameterHead(){}
		public ParameterHead(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public ParameterHead(IDataBaseConfigInfo dbc): base(dbc){}
		public ParameterHead(IDataBaseConfigInfo dbc,ParameterHead_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public ParameterHead(IList<ParameterHead_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string NAME {get{return "NAME" ; }}
		public string DESCRIPTION {get{return "DESCRIPTION" ; }}
		public string VALUE {get{return "VALUE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string IS_PUBLIC {get{return "IS_PUBLIC" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public ParameterHead_Record CurrentRecord(){
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
		public ParameterHead_Record CreateNew(){
			try{
				ParameterHead_Record newData = new ParameterHead_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<ParameterHead_Record> AllRecord(){
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
				_All_Record = new List<ParameterHead_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public ParameterHead Fill_By_PK(string pUUID){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>()  ;  
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
		public ParameterHead Fill_By_PK(string pUUID,DB db){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>(db)  ;  
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
		public ParameterHead_Record Fetch_By_PK(string pUUID){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public ParameterHead_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public ParameterHead Fill_By_Uuid(string pUUID){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>()  ;  
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
		public ParameterHead Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>(db)  ;  
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
		public ParameterHead_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public ParameterHead_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<ParameterHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterHead_Record>(db)  ;  
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
				UpdateAllRecord<ParameterHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<ParameterHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<ParameterHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<ParameterHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<ParameterHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<ParameterHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<ParameterItem_Record> Link_ParameterItem_By_ParameterHeadUuid()
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_HEAD_UUID,item.UUID).R().Or()  ; 
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
		/*201303180320*/
		public List<ParameterOwner_Record> Link_ParameterOwner_By_ParameterHeadUuid()
		{
			try{
				List<ParameterOwner_Record> ret= new List<ParameterOwner_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterOwner ___table = new ParameterOwner(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterOwner_Record>)
						___table.Where(condition)
						.FetchAll<ParameterOwner_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<ParameterItem_Record> Link_ParameterItem_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_HEAD_UUID,item.UUID).R().Or()  ; 
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
		/*201303180321*/
		public List<ParameterOwner_Record> Link_ParameterOwner_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				List<ParameterOwner_Record> ret= new List<ParameterOwner_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterOwner ___table = new ParameterOwner(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterOwner_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<ParameterOwner_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public ParameterItem LinkFill_ParameterItem_By_ParameterHeadUuid()
		{
			try{
				var data = Link_ParameterItem_By_ParameterHeadUuid();
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public ParameterOwner LinkFill_ParameterOwner_By_ParameterHeadUuid()
		{
			try{
				var data = Link_ParameterOwner_By_ParameterHeadUuid();
				ParameterOwner ret=new ParameterOwner(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public ParameterItem LinkFill_ParameterItem_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterItem_By_ParameterHeadUuid(limit);
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public ParameterOwner LinkFill_ParameterOwner_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterOwner_By_ParameterHeadUuid(limit);
				ParameterOwner ret=new ParameterOwner(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
