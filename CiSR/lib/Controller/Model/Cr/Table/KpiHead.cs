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
	[ISTTableView("KPI_HEAD", true)]
	public partial class KpiHead : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private KpiHead_Record _currentRecord = null;
	private IList<KpiHead_Record> _All_Record = new List<KpiHead_Record>();
		/*建構子*/
		public KpiHead(){}
		public KpiHead(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public KpiHead(IDataBaseConfigInfo dbc): base(dbc){}
		public KpiHead(IDataBaseConfigInfo dbc,KpiHead_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public KpiHead(IList<KpiHead_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string KPI_ID {get{return "KPI_ID" ; }}
		public string C_DESC {get{return "C_DESC" ; }}
		public string E_DESC {get{return "E_DESC" ; }}
		public string UNIT {get{return "UNIT" ; }}
		public string DEGREE {get{return "DEGREE" ; }}
		public string C_NOTICE {get{return "C_NOTICE" ; }}
		public string SIGNAL {get{return "SIGNAL" ; }}
		public string TIME_TYPE {get{return "TIME_TYPE" ; }}
		public string C_DESC_GROUP {get{return "C_DESC_GROUP" ; }}
		public string E_DESC_GROUP {get{return "E_DESC_GROUP" ; }}
		public string INCLUDE_KPI {get{return "INCLUDE_KPI" ; }}
		public string CALCULTE_ORD {get{return "CALCULTE_ORD" ; }}
		public string NEED_SUMMARY {get{return "NEED_SUMMARY" ; }}
		public string NEED_SECURITY {get{return "NEED_SECURITY" ; }}
		public string ZH_DESC {get{return "ZH_DESC" ; }}
		public string E_NOTICE {get{return "E_NOTICE" ; }}
		public string NEED_AVG {get{return "NEED_AVG" ; }}
		public string AVG_TYPE {get{return "AVG_TYPE" ; }}
		public string ZH_NOTICE {get{return "ZH_NOTICE" ; }}
		public string ALIASES {get{return "ALIASES" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public KpiHead_Record CurrentRecord(){
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
		public KpiHead_Record CreateNew(){
			try{
				KpiHead_Record newData = new KpiHead_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<KpiHead_Record> AllRecord(){
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
				_All_Record = new List<KpiHead_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public KpiHead Fill_By_PK(string pUUID){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>()  ;  
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
		public KpiHead Fill_By_PK(string pUUID,DB db){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>(db)  ;  
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
		public KpiHead_Record Fetch_By_PK(string pUUID){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public KpiHead_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public KpiHead Fill_By_Uuid(string pUUID){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>()  ;  
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
		public KpiHead Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>(db)  ;  
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
		public KpiHead_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public KpiHead_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiHead_Record>(db)  ;  
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
				UpdateAllRecord<KpiHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<KpiHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<KpiHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<KpiHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<KpiHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<KpiHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_KpiHeadUuid()
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiPackageItem_Record>)
						___table.Where(condition)
						.FetchAll<KpiPackageItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<KpiFormula_Record> Link_KpiFormula_By_KpiHeadUuid()
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiFormula_Record>)
						___table.Where(condition)
						.FetchAll<KpiFormula_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<Cal_Record> Link_Cal_By_KpiHeadUuid()
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Cal_Record>)
						___table.Where(condition)
						.FetchAll<Cal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiPackageItem_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<KpiPackageItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<KpiFormula_Record> Link_KpiFormula_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiFormula_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<KpiFormula_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<Cal_Record> Link_Cal_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Cal_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Cal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public KpiPackageItem LinkFill_KpiPackageItem_By_KpiHeadUuid()
		{
			try{
				var data = Link_KpiPackageItem_By_KpiHeadUuid();
				KpiPackageItem ret=new KpiPackageItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public KpiFormula LinkFill_KpiFormula_By_KpiHeadUuid()
		{
			try{
				var data = Link_KpiFormula_By_KpiHeadUuid();
				KpiFormula ret=new KpiFormula(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public Cal LinkFill_Cal_By_KpiHeadUuid()
		{
			try{
				var data = Link_Cal_By_KpiHeadUuid();
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public KpiPackageItem LinkFill_KpiPackageItem_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageItem_By_KpiHeadUuid(limit);
				KpiPackageItem ret=new KpiPackageItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public KpiFormula LinkFill_KpiFormula_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiFormula_By_KpiHeadUuid(limit);
				KpiFormula ret=new KpiFormula(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public Cal LinkFill_Cal_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_Cal_By_KpiHeadUuid(limit);
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
