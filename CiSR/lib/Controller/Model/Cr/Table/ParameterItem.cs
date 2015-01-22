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
	[ISTTableView("PARAMETER_ITEM", true)]
	public partial class ParameterItem : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private ParameterItem_Record _currentRecord = null;
	private IList<ParameterItem_Record> _All_Record = new List<ParameterItem_Record>();
		/*建構子*/
		public ParameterItem(){}
		public ParameterItem(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public ParameterItem(IDataBaseConfigInfo dbc): base(dbc){}
		public ParameterItem(IDataBaseConfigInfo dbc,ParameterItem_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public ParameterItem(IList<ParameterItem_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string PARAMETER_HEAD_UUID {get{return "PARAMETER_HEAD_UUID" ; }}
		public string REGION_UUID {get{return "REGION_UUID" ; }}
		public string DESCRIPTION {get{return "DESCRIPTION" ; }}
		public string VALUE {get{return "VALUE" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public ParameterItem_Record CurrentRecord(){
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
		public ParameterItem_Record CreateNew(){
			try{
				ParameterItem_Record newData = new ParameterItem_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<ParameterItem_Record> AllRecord(){
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
				_All_Record = new List<ParameterItem_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public ParameterItem Fill_By_PK(string pUUID){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>()  ;  
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
		public ParameterItem Fill_By_PK(string pUUID,DB db){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>(db)  ;  
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
		public ParameterItem_Record Fetch_By_PK(string pUUID){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public ParameterItem_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public ParameterItem Fill_By_Uuid(string pUUID){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>()  ;  
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
		public ParameterItem Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>(db)  ;  
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
		public ParameterItem_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public ParameterItem_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<ParameterItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<ParameterItem_Record>(db)  ;  
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
				UpdateAllRecord<ParameterItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<ParameterItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<ParameterItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<ParameterItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<ParameterItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<ParameterItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<ParameterMonth_Record> Link_ParameterMonth_By_ParameterItemUuid()
		{
			try{
				List<ParameterMonth_Record> ret= new List<ParameterMonth_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterMonth ___table = new ParameterMonth(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_ITEM_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterMonth_Record>)
						___table.Where(condition)
						.FetchAll<ParameterMonth_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<ParameterItemOwner_Record> Link_ParameterItemOwner_By_ParameterItemUuid()
		{
			try{
				List<ParameterItemOwner_Record> ret= new List<ParameterItemOwner_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItemOwner ___table = new ParameterItemOwner(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_ITEM_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterItemOwner_Record>)
						___table.Where(condition)
						.FetchAll<ParameterItemOwner_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<ParameterMonth_Record> Link_ParameterMonth_By_ParameterItemUuid(OrderLimit limit)
		{
			try{
				List<ParameterMonth_Record> ret= new List<ParameterMonth_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterMonth ___table = new ParameterMonth(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_ITEM_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterMonth_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<ParameterMonth_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<ParameterItemOwner_Record> Link_ParameterItemOwner_By_ParameterItemUuid(OrderLimit limit)
		{
			try{
				List<ParameterItemOwner_Record> ret= new List<ParameterItemOwner_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItemOwner ___table = new ParameterItemOwner(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.PARAMETER_ITEM_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterItemOwner_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<ParameterItemOwner_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<ParameterHead_Record> Link_ParameterHead_By_Uuid()
		{
			try{
				List<ParameterHead_Record> ret= new List<ParameterHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterHead ___table = new ParameterHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.PARAMETER_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterHead_Record>)
						___table.Where(condition)
						.FetchAll<ParameterHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<Region_Record> Link_Region_By_Uuid()
		{
			try{
				List<Region_Record> ret= new List<Region_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Region ___table = new Region(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.REGION_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Region_Record>)
						___table.Where(condition)
						.FetchAll<Region_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<ParameterHead_Record> Link_ParameterHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<ParameterHead_Record> ret= new List<ParameterHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterHead ___table = new ParameterHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.PARAMETER_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ParameterHead_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<ParameterHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<Region_Record> Link_Region_By_Uuid(OrderLimit limit)
		{
			try{
				List<Region_Record> ret= new List<Region_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Region ___table = new Region(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.REGION_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Region_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Region_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public ParameterMonth LinkFill_ParameterMonth_By_ParameterItemUuid()
		{
			try{
				var data = Link_ParameterMonth_By_ParameterItemUuid();
				ParameterMonth ret=new ParameterMonth(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public ParameterItemOwner LinkFill_ParameterItemOwner_By_ParameterItemUuid()
		{
			try{
				var data = Link_ParameterItemOwner_By_ParameterItemUuid();
				ParameterItemOwner ret=new ParameterItemOwner(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public ParameterMonth LinkFill_ParameterMonth_By_ParameterItemUuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterMonth_By_ParameterItemUuid(limit);
				ParameterMonth ret=new ParameterMonth(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public ParameterItemOwner LinkFill_ParameterItemOwner_By_ParameterItemUuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterItemOwner_By_ParameterItemUuid(limit);
				ParameterItemOwner ret=new ParameterItemOwner(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public ParameterHead LinkFill_ParameterHead_By_Uuid()
		{
			try{
				var data = Link_ParameterHead_By_Uuid();
				ParameterHead ret=new ParameterHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public Region LinkFill_Region_By_Uuid()
		{
			try{
				var data = Link_Region_By_Uuid();
				Region ret=new Region(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public ParameterHead LinkFill_ParameterHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterHead_By_Uuid(limit);
				ParameterHead ret=new ParameterHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public Region LinkFill_Region_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_Region_By_Uuid(limit);
				Region ret=new Region(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
