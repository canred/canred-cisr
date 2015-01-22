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
	[ISTTableView("VIEW_HOME", true)]
	public partial class ViewHome : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private ViewHome_Record _currentRecord = null;
	private IList<ViewHome_Record> _All_Record = new List<ViewHome_Record>();
		/*建構子*/
		public ViewHome(){}
		public ViewHome(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public ViewHome(IDataBaseConfigInfo dbc): base(dbc){}
		public ViewHome(IDataBaseConfigInfo dbc,ViewHome_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public ViewHome(IList<ViewHome_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string KPI_HEAD_UUID {get{return "KPI_HEAD_UUID" ; }}
		public string FRAME_HEAD_UUID {get{return "FRAME_HEAD_UUID" ; }}
		public string MEASURE {get{return "MEASURE" ; }}
		public string COLOR {get{return "COLOR" ; }}
		public string LAST_MEASURE {get{return "LAST_MEASURE" ; }}
		public string LAST_COLOR {get{return "LAST_COLOR" ; }}
		public string TARGET_MEASURE {get{return "TARGET_MEASURE" ; }}
		public string TARGET_COLOR {get{return "TARGET_COLOR" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string LAST_TIME_ID {get{return "LAST_TIME_ID" ; }}
		public string VISION_SHARE_RULE_UUID {get{return "VISION_SHARE_RULE_UUID" ; }}
		public string IS_INSTRUCTION {get{return "IS_INSTRUCTION" ; }}
		public string IS_EXPLAIN {get{return "IS_EXPLAIN" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public ViewHome_Record CurrentRecord(){
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
		public ViewHome_Record CreateNew(){
			try{
				ViewHome_Record newData = new ViewHome_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<ViewHome_Record> AllRecord(){
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
				_All_Record = new List<ViewHome_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public ViewHome Fill_By_PK(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.And()
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.And()
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.And()
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>()  ;  
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
		public ViewHome Fill_By_PK(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID,DB db){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.And()
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.And()
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.And()
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>(db)  ;  
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
		public ViewHome_Record Fetch_By_PK(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public ViewHome_Record Fetch_By_PK(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID,DB db){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public ViewHome Fill_By_TimeId_And_KpiHeadUuid_And_FrameHeadUuid_And_VisionShareRuleUuid(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>()  ;  
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
		public ViewHome Fill_By_TimeId_And_KpiHeadUuid_And_FrameHeadUuid_And_VisionShareRuleUuid(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID,DB db){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>(db)  ;  
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
		public ViewHome_Record Fetch_By_TimeId_And_KpiHeadUuid_And_FrameHeadUuid_And_VisionShareRuleUuid(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public ViewHome_Record Fetch_By_TimeId_And_KpiHeadUuid_And_FrameHeadUuid_And_VisionShareRuleUuid(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID,DB db){
			try{
				IList<ViewHome_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.TIME_ID,pTIME_ID)
									.Equal(this.KPI_HEAD_UUID,pKPI_HEAD_UUID)
									.Equal(this.FRAME_HEAD_UUID,pFRAME_HEAD_UUID)
									.Equal(this.VISION_SHARE_RULE_UUID,pVISION_SHARE_RULE_UUID)
				).FetchAll<ViewHome_Record>(db)  ;  
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
				UpdateAllRecord<ViewHome_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<ViewHome_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<ViewHome_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<ViewHome_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<ViewHome_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<ViewHome_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid()
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.FRAME_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameHead_Record>)
						___table.Where(condition)
						.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.FRAME_HEAD_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameHead_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public FrameHead LinkFill_FrameHead_By_Uuid()
		{
			try{
				var data = Link_FrameHead_By_Uuid();
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public FrameHead LinkFill_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameHead_By_Uuid(limit);
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
