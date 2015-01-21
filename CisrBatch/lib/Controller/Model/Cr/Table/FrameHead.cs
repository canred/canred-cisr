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
	[ISTTableView("FRAME_HEAD", true)]
	public partial class FrameHead : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private FrameHead_Record _currentRecord = null;
	private IList<FrameHead_Record> _All_Record = new List<FrameHead_Record>();
		/*建構子*/
		public FrameHead(){}
		public FrameHead(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public FrameHead(IDataBaseConfigInfo dbc): base(dbc){}
		public FrameHead(IDataBaseConfigInfo dbc,FrameHead_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public FrameHead(IList<FrameHead_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string C_NAME {get{return "C_NAME" ; }}
		public string E_NAME {get{return "E_NAME" ; }}
		public string PARENT_FRAME_HEAD_UUID {get{return "PARENT_FRAME_HEAD_UUID" ; }}
		public string ORD {get{return "ORD" ; }}
		public string REGION_UUID {get{return "REGION_UUID" ; }}
		public string FRAME_ID {get{return "FRAME_ID" ; }}
		public string FULL_FRAME_UUID_LIST {get{return "FULL_FRAME_UUID_LIST" ; }}
		public string DLEVEL {get{return "DLEVEL" ; }}
		public string ZH_NAME {get{return "ZH_NAME" ; }}
		public string FULL_FRAME_NAME_LIST {get{return "FULL_FRAME_NAME_LIST" ; }}
		public string FULL_FRAME_ID_LIST {get{return "FULL_FRAME_ID_LIST" ; }}
		public string KPI_PACKAGE_UUID {get{return "KPI_PACKAGE_UUID" ; }}
		public string HASCHILD {get{return "HASCHILD" ; }}
		public string FRAME_CATEGORY_UUID {get{return "FRAME_CATEGORY_UUID" ; }}
		public string CURRENCY {get{return "CURRENCY" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public FrameHead_Record CurrentRecord(){
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
		public FrameHead_Record CreateNew(){
			try{
				FrameHead_Record newData = new FrameHead_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<FrameHead_Record> AllRecord(){
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
				_All_Record = new List<FrameHead_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public FrameHead Fill_By_PK(string pUUID){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>()  ;  
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
		public FrameHead Fill_By_PK(string pUUID,DB db){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>(db)  ;  
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
		public FrameHead_Record Fetch_By_PK(string pUUID){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public FrameHead_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public FrameHead Fill_By_Uuid(string pUUID){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>()  ;  
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
		public FrameHead Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>(db)  ;  
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
		public FrameHead_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public FrameHead_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<FrameHead_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<FrameHead_Record>(db)  ;  
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
				UpdateAllRecord<FrameHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<FrameHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<FrameHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<FrameHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<FrameHead_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<FrameHead_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<RawData_Record> Link_RawData_By_FrameHeadUuid()
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
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
		public List<ViewHome_Record> Link_ViewHome_By_FrameHeadUuid()
		{
			try{
				List<ViewHome_Record> ret= new List<ViewHome_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ViewHome ___table = new ViewHome(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ViewHome_Record>)
						___table.Where(condition)
						.FetchAll<ViewHome_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<FrameItem_Record> Link_FrameItem_By_FrameHeadUuid()
		{
			try{
				List<FrameItem_Record> ret= new List<FrameItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameItem ___table = new FrameItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameItem_Record>)
						___table.Where(condition)
						.FetchAll<FrameItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<UploadJob_Record> Link_UploadJob_By_FrameHeadUuid()
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
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
		public List<Cal_Record> Link_Cal_By_FrameHeadUuid()
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
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
		/*201303180320*/
		public List<VFrameHead_Record> Link_VFrameHead_By_Uuid()
		{
			try{
				List<VFrameHead_Record> ret= new List<VFrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameHead ___table = new VFrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VFrameHead_Record>)
						___table.Where(condition)
						.FetchAll<VFrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<RawData_Record> Link_RawData_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
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
		public List<ViewHome_Record> Link_ViewHome_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<ViewHome_Record> ret= new List<ViewHome_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ViewHome ___table = new ViewHome(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<ViewHome_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<ViewHome_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<FrameItem_Record> Link_FrameItem_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<FrameItem_Record> ret= new List<FrameItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameItem ___table = new FrameItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameItem_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<FrameItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<UploadJob_Record> Link_UploadJob_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
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
		public List<Cal_Record> Link_Cal_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.FRAME_HEAD_UUID,item.UUID).R().Or()  ; 
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
		/*201303180321*/
		public List<VFrameHead_Record> Link_VFrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<VFrameHead_Record> ret= new List<VFrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameHead ___table = new VFrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VFrameHead_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<VFrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<KpiPackage_Record> Link_KpiPackage_By_Uuid()
		{
			try{
				List<KpiPackage_Record> ret= new List<KpiPackage_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackage ___table = new KpiPackage(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_PACKAGE_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiPackage_Record>)
						___table.Where(condition)
						.FetchAll<KpiPackage_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<KpiPackage_Record> Link_KpiPackage_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiPackage_Record> ret= new List<KpiPackage_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackage ___table = new KpiPackage(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_PACKAGE_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<KpiPackage_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<KpiPackage_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public RawData LinkFill_RawData_By_FrameHeadUuid()
		{
			try{
				var data = Link_RawData_By_FrameHeadUuid();
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public ViewHome LinkFill_ViewHome_By_FrameHeadUuid()
		{
			try{
				var data = Link_ViewHome_By_FrameHeadUuid();
				ViewHome ret=new ViewHome(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public FrameItem LinkFill_FrameItem_By_FrameHeadUuid()
		{
			try{
				var data = Link_FrameItem_By_FrameHeadUuid();
				FrameItem ret=new FrameItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public UploadJob LinkFill_UploadJob_By_FrameHeadUuid()
		{
			try{
				var data = Link_UploadJob_By_FrameHeadUuid();
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public Cal LinkFill_Cal_By_FrameHeadUuid()
		{
			try{
				var data = Link_Cal_By_FrameHeadUuid();
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public VFrameHead LinkFill_VFrameHead_By_Uuid()
		{
			try{
				var data = Link_VFrameHead_By_Uuid();
				VFrameHead ret=new VFrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public RawData LinkFill_RawData_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawData_By_FrameHeadUuid(limit);
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public ViewHome LinkFill_ViewHome_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_ViewHome_By_FrameHeadUuid(limit);
				ViewHome ret=new ViewHome(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public FrameItem LinkFill_FrameItem_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameItem_By_FrameHeadUuid(limit);
				FrameItem ret=new FrameItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public UploadJob LinkFill_UploadJob_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_UploadJob_By_FrameHeadUuid(limit);
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public Cal LinkFill_Cal_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_Cal_By_FrameHeadUuid(limit);
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public VFrameHead LinkFill_VFrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_VFrameHead_By_Uuid(limit);
				VFrameHead ret=new VFrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public KpiPackage LinkFill_KpiPackage_By_Uuid()
		{
			try{
				var data = Link_KpiPackage_By_Uuid();
				KpiPackage ret=new KpiPackage(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public KpiPackage LinkFill_KpiPackage_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackage_By_Uuid(limit);
				KpiPackage ret=new KpiPackage(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
