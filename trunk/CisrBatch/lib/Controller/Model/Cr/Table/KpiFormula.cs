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
	[ISTTableView("KPI_FORMULA", true)]
	public partial class KpiFormula : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private KpiFormula_Record _currentRecord = null;
	private IList<KpiFormula_Record> _All_Record = new List<KpiFormula_Record>();
		/*建構子*/
		public KpiFormula(){}
		public KpiFormula(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public KpiFormula(IDataBaseConfigInfo dbc): base(dbc){}
		public KpiFormula(IDataBaseConfigInfo dbc,KpiFormula_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public KpiFormula(IList<KpiFormula_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string KPI_HEAD_UUID {get{return "KPI_HEAD_UUID" ; }}
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string ALGORITHM {get{return "ALGORITHM" ; }}
		public string DESCRIPTION {get{return "DESCRIPTION" ; }}
		public string ALGORITHM_MAN {get{return "ALGORITHM_MAN" ; }}
		public string JSS {get{return "JSS" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public KpiFormula_Record CurrentRecord(){
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
		public KpiFormula_Record CreateNew(){
			try{
				KpiFormula_Record newData = new KpiFormula_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<KpiFormula_Record> AllRecord(){
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
				_All_Record = new List<KpiFormula_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public KpiFormula Fill_By_PK(string pUUID){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>()  ;  
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
		public KpiFormula Fill_By_PK(string pUUID,DB db){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>(db)  ;  
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
		public KpiFormula_Record Fetch_By_PK(string pUUID){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public KpiFormula_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public KpiFormula Fill_By_Uuid(string pUUID){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>()  ;  
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
		public KpiFormula Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>(db)  ;  
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
		public KpiFormula_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public KpiFormula_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiFormula_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiFormula_Record>(db)  ;  
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
				UpdateAllRecord<KpiFormula_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<KpiFormula_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<KpiFormula_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<KpiFormula_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<KpiFormula_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<KpiFormula_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<KpiFormulaDetail_Record> Link_KpiFormulaDetail_By_KpiFormulaUuid()
		{
			try{
				List<KpiFormulaDetail_Record> ret= new List<KpiFormulaDetail_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormulaDetail ___table = new KpiFormulaDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_FORMULA_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiFormulaDetail_Record>)
						___table.Where(condition)
						.FetchAll<KpiFormulaDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<KpiFormulaDetail_Record> Link_KpiFormulaDetail_By_KpiFormulaUuid(OrderLimit limit)
		{
			try{
				List<KpiFormulaDetail_Record> ret= new List<KpiFormulaDetail_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormulaDetail ___table = new KpiFormulaDetail(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_FORMULA_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiFormulaDetail_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<KpiFormulaDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<KpiHead_Record> Link_KpiHead_By_Uuid()
		{
			try{
				List<KpiHead_Record> ret= new List<KpiHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiHead ___table = new KpiHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiHead_Record>)
						___table.Where(condition)
						.FetchAll<KpiHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<KpiHead_Record> Link_KpiHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiHead_Record> ret= new List<KpiHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiHead ___table = new KpiHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiHead_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<KpiHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public KpiFormulaDetail LinkFill_KpiFormulaDetail_By_KpiFormulaUuid()
		{
			try{
				var data = Link_KpiFormulaDetail_By_KpiFormulaUuid();
				KpiFormulaDetail ret=new KpiFormulaDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public KpiFormulaDetail LinkFill_KpiFormulaDetail_By_KpiFormulaUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiFormulaDetail_By_KpiFormulaUuid(limit);
				KpiFormulaDetail ret=new KpiFormulaDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public KpiHead LinkFill_KpiHead_By_Uuid()
		{
			try{
				var data = Link_KpiHead_By_Uuid();
				KpiHead ret=new KpiHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public KpiHead LinkFill_KpiHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiHead_By_Uuid(limit);
				KpiHead ret=new KpiHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
