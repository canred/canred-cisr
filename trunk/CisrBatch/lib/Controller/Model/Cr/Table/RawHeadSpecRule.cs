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
	[ISTTableView("RAW_HEAD_SPEC_RULE", true)]
	public partial class RawHeadSpecRule : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private RawHeadSpecRule_Record _currentRecord = null;
	private IList<RawHeadSpecRule_Record> _All_Record = new List<RawHeadSpecRule_Record>();
		/*建構子*/
		public RawHeadSpecRule(){}
		public RawHeadSpecRule(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public RawHeadSpecRule(IDataBaseConfigInfo dbc): base(dbc){}
		public RawHeadSpecRule(IDataBaseConfigInfo dbc,RawHeadSpecRule_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public RawHeadSpecRule(IList<RawHeadSpecRule_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string RAW_HEAD_UUID {get{return "RAW_HEAD_UUID" ; }}
		public string SEQ {get{return "SEQ" ; }}
		public string COLUMNNAME {get{return "COLUMNNAME" ; }}
		public string PREDICATE {get{return "PREDICATE" ; }}
		public string COLUMNVALUE {get{return "COLUMNVALUE" ; }}
		public string CONTROLLCOLUMNNAME {get{return "CONTROLLCOLUMNNAME" ; }}
		public string CONTROLLVALUE {get{return "CONTROLLVALUE" ; }}
		public string MSG_TW {get{return "MSG_TW" ; }}
		public string MSG_US {get{return "MSG_US" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public RawHeadSpecRule_Record CurrentRecord(){
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
		public RawHeadSpecRule_Record CreateNew(){
			try{
				RawHeadSpecRule_Record newData = new RawHeadSpecRule_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<RawHeadSpecRule_Record> AllRecord(){
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
				_All_Record = new List<RawHeadSpecRule_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public RawHeadSpecRule Fill_By_PK(string pRAW_HEAD_UUID,decimal? pSEQ){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.And()
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>()  ;  
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
		public RawHeadSpecRule Fill_By_PK(string pRAW_HEAD_UUID,decimal? pSEQ,DB db){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.And()
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>(db)  ;  
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
		public RawHeadSpecRule_Record Fetch_By_PK(string pRAW_HEAD_UUID,decimal? pSEQ){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public RawHeadSpecRule_Record Fetch_By_PK(string pRAW_HEAD_UUID,decimal? pSEQ,DB db){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public RawHeadSpecRule Fill_By_RawHeadUuid_And_Seq(string pRAW_HEAD_UUID,decimal? pSEQ){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>()  ;  
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
		public RawHeadSpecRule Fill_By_RawHeadUuid_And_Seq(string pRAW_HEAD_UUID,decimal? pSEQ,DB db){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>(db)  ;  
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
		public RawHeadSpecRule_Record Fetch_By_RawHeadUuid_And_Seq(string pRAW_HEAD_UUID,decimal? pSEQ){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public RawHeadSpecRule_Record Fetch_By_RawHeadUuid_And_Seq(string pRAW_HEAD_UUID,decimal? pSEQ,DB db){
			try{
				IList<RawHeadSpecRule_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.RAW_HEAD_UUID,pRAW_HEAD_UUID)
									.Equal(this.SEQ,pSEQ)
				).FetchAll<RawHeadSpecRule_Record>(db)  ;  
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
				UpdateAllRecord<RawHeadSpecRule_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<RawHeadSpecRule_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<RawHeadSpecRule_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<RawHeadSpecRule_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<RawHeadSpecRule_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<RawHeadSpecRule_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<RawHead_Record> Link_RawHead_By_Uuid()
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHead_Record>)
						___table.Where(condition)
						.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<RawHead_Record> Link_RawHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.RAW_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<RawHead_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public RawHead LinkFill_RawHead_By_Uuid()
		{
			try{
				var data = Link_RawHead_By_Uuid();
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public RawHead LinkFill_RawHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHead_By_Uuid(limit);
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
