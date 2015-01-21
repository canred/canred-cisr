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
	[ISTTableView("KPI_PACKAGE_ITEM", true)]
	public partial class KpiPackageItem : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private KpiPackageItem_Record _currentRecord = null;
	private IList<KpiPackageItem_Record> _All_Record = new List<KpiPackageItem_Record>();
		/*建構子*/
		public KpiPackageItem(){}
		public KpiPackageItem(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public KpiPackageItem(IDataBaseConfigInfo dbc): base(dbc){}
		public KpiPackageItem(IDataBaseConfigInfo dbc,KpiPackageItem_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public KpiPackageItem(IList<KpiPackageItem_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string KPI_PACKAGE_UUID {get{return "KPI_PACKAGE_UUID" ; }}
		public string KPI_HEAD_UUID {get{return "KPI_HEAD_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public KpiPackageItem_Record CurrentRecord(){
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
		public KpiPackageItem_Record CreateNew(){
			try{
				KpiPackageItem_Record newData = new KpiPackageItem_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<KpiPackageItem_Record> AllRecord(){
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
				_All_Record = new List<KpiPackageItem_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public KpiPackageItem Fill_By_PK(string pUUID){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>()  ;  
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
		public KpiPackageItem Fill_By_PK(string pUUID,DB db){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>(db)  ;  
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
		public KpiPackageItem_Record Fetch_By_PK(string pUUID){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public KpiPackageItem_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public KpiPackageItem Fill_By_Uuid(string pUUID){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>()  ;  
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
		public KpiPackageItem Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>(db)  ;  
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
		public KpiPackageItem_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public KpiPackageItem_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<KpiPackageItem_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<KpiPackageItem_Record>(db)  ;  
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
				UpdateAllRecord<KpiPackageItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來更新資料行*/
		public void UpdateAllRecord(DB db) {
			try{
				UpdateAllRecord<KpiPackageItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord() {
			try{
				InsertAllRecord<KpiPackageItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來新增資料行*/
		public void InsertAllRecord(DB db) {
			try{
				InsertAllRecord<KpiPackageItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord() {
			try{
				DeleteAllRecord<KpiPackageItem_Record>(this.AllRecord());   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*利用物件自已的AllRecord的資料來刪除資料行*/
		public void DeleteAllRecord(DB db) {
			try{
				DeleteAllRecord<KpiPackageItem_Record>(this.AllRecord(),db);   
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		/*201303180320*/
		public List<VKpiExp_Record> Link_VKpiExp_By_KpiPackageItemUuid()
		{
			try{
				List<VKpiExp_Record> ret= new List<VKpiExp_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpiExp ___table = new VKpiExp(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_PACKAGE_ITEM_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VKpiExp_Record>)
						___table.Where(condition)
						.FetchAll<VKpiExp_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180320*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_KpiPackageItemUuid()
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_PACKAGE_ITEM_UUID,item.UUID).R().Or()  ; 
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
		public List<VKpiExp_Record> Link_VKpiExp_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				List<VKpiExp_Record> ret= new List<VKpiExp_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpiExp ___table = new VKpiExp(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_PACKAGE_ITEM_UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<VKpiExp_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<VKpiExp_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180321*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.KPI_PACKAGE_ITEM_UUID,item.UUID).R().Or()  ; 
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
		public VKpiExp LinkFill_VKpiExp_By_KpiPackageItemUuid()
		{
			try{
				var data = Link_VKpiExp_By_KpiPackageItemUuid();
				VKpiExp ret=new VKpiExp(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180324*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_KpiPackageItemUuid()
		{
			try{
				var data = Link_KpiPackageExpend_By_KpiPackageItemUuid();
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public VKpiExp LinkFill_VKpiExp_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				var data = Link_VKpiExp_By_KpiPackageItemUuid(limit);
				VKpiExp ret=new VKpiExp(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180325*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageExpend_By_KpiPackageItemUuid(limit);
				KpiPackageExpend ret=new KpiPackageExpend(data);
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
