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
	[ISTTableView("V_KPI_EXP", false)]
	public partial class VKpiExp : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VKpiExp_Record _currentRecord = null;
	private IList<VKpiExp_Record> _All_Record = new List<VKpiExp_Record>();
		/*建構子*/
		public VKpiExp(){}
		public VKpiExp(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VKpiExp(IDataBaseConfigInfo dbc): base(dbc){}
		public VKpiExp(IDataBaseConfigInfo dbc,VKpiExp_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VKpiExp(IList<VKpiExp_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string KPI_PACKAGE_EXPEND_UUID {get{return "KPI_PACKAGE_EXPEND_UUID" ; }}
		public string KPI_PACKAGE_UUID {get{return "KPI_PACKAGE_UUID" ; }}
		public string KPI_PACKAGE_ITEM_UUID {get{return "KPI_PACKAGE_ITEM_UUID" ; }}
		public string RAW_HEAD_UUID {get{return "RAW_HEAD_UUID" ; }}
		public string RAW_ID {get{return "RAW_ID" ; }}
		public string RAW_HEAD_IS_ACTIVE {get{return "RAW_HEAD_IS_ACTIVE" ; }}
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
		public VKpiExp_Record CurrentRecord(){
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
		public VKpiExp_Record CreateNew(){
			try{
				VKpiExp_Record newData = new VKpiExp_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VKpiExp_Record> AllRecord(){
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
				_All_Record = new List<VKpiExp_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		/*依照資料表與資料表的關係，產生出來的方法*/
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
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_Uuid()
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_PACKAGE_ITEM_UUID).R().Or()  ; 
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
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.KPI_PACKAGE_ITEM_UUID).R().Or()  ; 
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
		public KpiPackageItem LinkFill_KpiPackageItem_By_Uuid()
		{
			try{
				var data = Link_KpiPackageItem_By_Uuid();
				KpiPackageItem ret=new KpiPackageItem(data);
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
		public KpiPackageItem LinkFill_KpiPackageItem_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageItem_By_Uuid(limit);
				KpiPackageItem ret=new KpiPackageItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
