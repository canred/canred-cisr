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
	[ISTTableView("RAW_HEAD", true)]
	public partial class RawHead : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private RawHead_Record _currentRecord = null;
	private IList<RawHead_Record> _All_Record = new List<RawHead_Record>();
		/*建構子*/
		public RawHead(){}
		public RawHead(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public RawHead(IDataBaseConfigInfo dbc): base(dbc){}
		public RawHead(IDataBaseConfigInfo dbc,RawHead_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public RawHead(IList<RawHead_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string RAW_ID {get{return "RAW_ID" ; }}
		public string RAW_CATEGORY_UUID {get{return "RAW_CATEGORY_UUID" ; }}
		public string C_DESC {get{return "C_DESC" ; }}
		public string E_DESC {get{return "E_DESC" ; }}
		public string C_DEFINE {get{return "C_DEFINE" ; }}
		public string E_DEFINE {get{return "E_DEFINE" ; }}
		public string UNIT {get{return "UNIT" ; }}
		public string CAN_NULL {get{return "CAN_NULL" ; }}
		public string TIME_TYPE {get{return "TIME_TYPE" ; }}
		public string NEED_DESC {get{return "NEED_DESC" ; }}
		public string NEED_FILE {get{return "NEED_FILE" ; }}
		public string VALUEDISPLAY {get{return "VALUEDISPLAY" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public RawHead_Record CurrentRecord(){
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
		public RawHead_Record CreateNew(){
			try{
				RawHead_Record newData = new RawHead_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<RawHead_Record> AllRecord(){
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
				_All_Record = new List<RawHead_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public RawHead Fill_By_PK(string pUUID){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>()  ;  
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
		public RawHead Fill_By_PK(string pUUID,DB db){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>(db)  ;  
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
		public RawHead_Record Fetch_By_PK(string pUUID){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public RawHead_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public RawHead Fill_By_Uuid(string pUUID){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>()  ;  
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
		public RawHead Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>(db)  ;  
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
		public RawHead_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public RawHead_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<RawHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<RawHead_Record>(db)  ;  
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
				UpdateAllRecord<RawHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<RawHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<RawHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<RawHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<RawHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<RawHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<RawData_Record> Link_RawData_By_RawHeadUuid()
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawData_Record>)
						___table.Where(condition)
						.FetchAll<RawData_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<RawHeadSpecRule_Record> Link_RawHeadSpecRule_By_RawHeadUuid()
		{
			try{
				List<RawHeadSpecRule_Record> ret= new List<RawHeadSpecRule_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadSpecRule ___table = new RawHeadSpecRule(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHeadSpecRule_Record>)
						___table.Where(condition)
						.FetchAll<RawHeadSpecRule_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<UploadJob_Record> Link_UploadJob_By_RawHeadUuid()
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<UploadJob_Record>)
						___table.Where(condition)
						.FetchAll<UploadJob_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_RawHeadUuid()
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiPackageExpend_Record>)
						___table.Where(condition)
						.FetchAll<KpiPackageExpend_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<RawData_Record> Link_RawData_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawData_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<RawData_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<RawHeadSpecRule_Record> Link_RawHeadSpecRule_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<RawHeadSpecRule_Record> ret= new List<RawHeadSpecRule_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadSpecRule ___table = new RawHeadSpecRule(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHeadSpecRule_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<RawHeadSpecRule_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<UploadJob_Record> Link_UploadJob_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<UploadJob_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<UploadJob_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.RAW_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiPackageExpend_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<KpiPackageExpend_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<RawHeadCategory_Record> Link_RawHeadCategory_By_Uuid()
		{
			try{
				List<RawHeadCategory_Record> ret= new List<RawHeadCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadCategory ___table = new RawHeadCategory(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_CATEGORY_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHeadCategory_Record>)
						___table.Where(condition)
						.FetchAll<RawHeadCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<RawHeadCategory_Record> Link_RawHeadCategory_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawHeadCategory_Record> ret= new List<RawHeadCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadCategory ___table = new RawHeadCategory(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_CATEGORY_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHeadCategory_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<RawHeadCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public RawData LinkFill_RawData_By_RawHeadUuid()
		{
			try{
				var data = Link_RawData_By_RawHeadUuid();
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public RawHeadSpecRule LinkFill_RawHeadSpecRule_By_RawHeadUuid()
		{
			try{
				var data = Link_RawHeadSpecRule_By_RawHeadUuid();
				RawHeadSpecRule ret=new RawHeadSpecRule(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public UploadJob LinkFill_UploadJob_By_RawHeadUuid()
		{
			try{
				var data = Link_UploadJob_By_RawHeadUuid();
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_RawHeadUuid()
		{
			try{
				var data = Link_KpiPackageExpend_By_RawHeadUuid();
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public RawData LinkFill_RawData_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawData_By_RawHeadUuid(limit);
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public RawHeadSpecRule LinkFill_RawHeadSpecRule_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHeadSpecRule_By_RawHeadUuid(limit);
				RawHeadSpecRule ret=new RawHeadSpecRule(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public UploadJob LinkFill_UploadJob_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_UploadJob_By_RawHeadUuid(limit);
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageExpend_By_RawHeadUuid(limit);
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public RawHeadCategory LinkFill_RawHeadCategory_By_Uuid()
		{
			try{
				var data = Link_RawHeadCategory_By_Uuid();
				RawHeadCategory ret=new RawHeadCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public RawHeadCategory LinkFill_RawHeadCategory_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHeadCategory_By_Uuid(limit);
				RawHeadCategory ret=new RawHeadCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
