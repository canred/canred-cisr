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
	[ISTTableView("KPI_FORMULA_DETAIL", true)]
	public partial class KpiFormulaDetail : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private KpiFormulaDetail_Record _currentRecord = null;
	private IList<KpiFormulaDetail_Record> _All_Record = new List<KpiFormulaDetail_Record>();
		/*建構子*/
		public KpiFormulaDetail(){}
		public KpiFormulaDetail(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public KpiFormulaDetail(IDataBaseConfigInfo dbc): base(dbc){}
		public KpiFormulaDetail(IDataBaseConfigInfo dbc,KpiFormulaDetail_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public KpiFormulaDetail(IList<KpiFormulaDetail_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string KPI_FORMULA_UUID {get{return "KPI_FORMULA_UUID" ; }}
		public string LEFT_BRACKETS {get{return "LEFT_BRACKETS" ; }}
		public string DATA_TYPE {get{return "DATA_TYPE" ; }}
		public string DATA_UUID {get{return "DATA_UUID" ; }}
		public string OPERATION {get{return "OPERATION" ; }}
		public string LEFT_INTERVAL {get{return "LEFT_INTERVAL" ; }}
		public string LEFT_NO {get{return "LEFT_NO" ; }}
		public string RIGHT_INTERVAL {get{return "RIGHT_INTERVAL" ; }}
		public string RIGHT_NO {get{return "RIGHT_NO" ; }}
		public string OPERATION_CODE {get{return "OPERATION_CODE" ; }}
		public string RIGHT_BARCKETS {get{return "RIGHT_BARCKETS" ; }}
		public string ORD {get{return "ORD" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public KpiFormulaDetail_Record CurrentRecord(){
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
		public KpiFormulaDetail_Record CreateNew(){
			try{
				KpiFormulaDetail_Record newData = new KpiFormulaDetail_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<KpiFormulaDetail_Record> AllRecord(){
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
				_All_Record = new List<KpiFormulaDetail_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public KpiFormulaDetail Fill_By_PK(string pUUID){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>()  ;  
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
		public KpiFormulaDetail Fill_By_PK(string pUUID,DB db){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>(db)  ;  
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
		public KpiFormulaDetail_Record Fetch_By_PK(string pUUID){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public KpiFormulaDetail_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public KpiFormulaDetail Fill_By_Uuid(string pUUID){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>()  ;  
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
		public KpiFormulaDetail Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>(db)  ;  
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
		public KpiFormulaDetail_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public KpiFormulaDetail_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiFormulaDetail_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormulaDetail_Record>(db)  ;  
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
				UpdateAllRecord<KpiFormulaDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<KpiFormulaDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<KpiFormulaDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<KpiFormulaDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<KpiFormulaDetail_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<KpiFormulaDetail_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<KpiFormula_Record> Link_KpiFormula_By_Uuid()
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_FORMULA_UUID).R().Or()  ; 
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
		/*201303180340*/
		public List<KpiFormula_Record> Link_KpiFormula_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_FORMULA_UUID).R().Or()  ; 
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
		/*201303180336*/
		public KpiFormula LinkFill_KpiFormula_By_Uuid()
		{
			try{
				var data = Link_KpiFormula_By_Uuid();
				KpiFormula ret=new KpiFormula(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public KpiFormula LinkFill_KpiFormula_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiFormula_By_Uuid(limit);
				KpiFormula ret=new KpiFormula(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
