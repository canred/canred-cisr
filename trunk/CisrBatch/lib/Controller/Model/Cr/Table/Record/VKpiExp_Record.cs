using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.Attribute;
using IST.DB;  
using IST.DB.SQLCreater;  
using CISR.Model.Cr.Table;
namespace CISR.Model.Cr.Table.Record
{
	[ISTRecord]
	[ISTTableView("V_KPI_EXP", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VKpiExp_Record : RecordBase{
		public VKpiExp_Record(){}
		/*欄位資訊 Start*/
		string _KPI_PACKAGE_EXPEND_UUID=null;
		string _KPI_PACKAGE_UUID=null;
		string _KPI_PACKAGE_ITEM_UUID=null;
		string _RAW_HEAD_UUID=null;
		string _RAW_ID=null;
		string _RAW_HEAD_IS_ACTIVE=null;
		string _RAW_CATEGORY_UUID=null;
		string _C_DESC=null;
		string _E_DESC=null;
		string _C_DEFINE=null;
		string _E_DEFINE=null;
		string _UNIT=null;
		string _CAN_NULL=null;
		string _TIME_TYPE=null;
		string _NEED_DESC=null;
		string _NEED_FILE=null;
		string _VALUEDISPLAY=null;
		/*欄位資訊 End*/

		[ColumnName("KPI_PACKAGE_EXPEND_UUID",false,typeof(string))]
		public string KPI_PACKAGE_EXPEND_UUID
		{
			set
			{
				_KPI_PACKAGE_EXPEND_UUID=value;
			}
			get
			{
				return _KPI_PACKAGE_EXPEND_UUID;
			}
		}

		[ColumnName("KPI_PACKAGE_UUID",false,typeof(string))]
		public string KPI_PACKAGE_UUID
		{
			set
			{
				_KPI_PACKAGE_UUID=value;
			}
			get
			{
				return _KPI_PACKAGE_UUID;
			}
		}

		[ColumnName("KPI_PACKAGE_ITEM_UUID",false,typeof(string))]
		public string KPI_PACKAGE_ITEM_UUID
		{
			set
			{
				_KPI_PACKAGE_ITEM_UUID=value;
			}
			get
			{
				return _KPI_PACKAGE_ITEM_UUID;
			}
		}

		[ColumnName("RAW_HEAD_UUID",false,typeof(string))]
		public string RAW_HEAD_UUID
		{
			set
			{
				_RAW_HEAD_UUID=value;
			}
			get
			{
				return _RAW_HEAD_UUID;
			}
		}

		[ColumnName("RAW_ID",false,typeof(string))]
		public string RAW_ID
		{
			set
			{
				_RAW_ID=value;
			}
			get
			{
				return _RAW_ID;
			}
		}

		[ColumnName("RAW_HEAD_IS_ACTIVE",false,typeof(string))]
		public string RAW_HEAD_IS_ACTIVE
		{
			set
			{
				_RAW_HEAD_IS_ACTIVE=value;
			}
			get
			{
				return _RAW_HEAD_IS_ACTIVE;
			}
		}

		[ColumnName("RAW_CATEGORY_UUID",false,typeof(string))]
		public string RAW_CATEGORY_UUID
		{
			set
			{
				_RAW_CATEGORY_UUID=value;
			}
			get
			{
				return _RAW_CATEGORY_UUID;
			}
		}

		[ColumnName("C_DESC",false,typeof(string))]
		public string C_DESC
		{
			set
			{
				_C_DESC=value;
			}
			get
			{
				return _C_DESC;
			}
		}

		[ColumnName("E_DESC",false,typeof(string))]
		public string E_DESC
		{
			set
			{
				_E_DESC=value;
			}
			get
			{
				return _E_DESC;
			}
		}

		[ColumnName("C_DEFINE",false,typeof(string))]
		public string C_DEFINE
		{
			set
			{
				_C_DEFINE=value;
			}
			get
			{
				return _C_DEFINE;
			}
		}

		[ColumnName("E_DEFINE",false,typeof(string))]
		public string E_DEFINE
		{
			set
			{
				_E_DEFINE=value;
			}
			get
			{
				return _E_DEFINE;
			}
		}

		[ColumnName("UNIT",false,typeof(string))]
		public string UNIT
		{
			set
			{
				_UNIT=value;
			}
			get
			{
				return _UNIT;
			}
		}

		[ColumnName("CAN_NULL",false,typeof(string))]
		public string CAN_NULL
		{
			set
			{
				_CAN_NULL=value;
			}
			get
			{
				return _CAN_NULL;
			}
		}

		[ColumnName("TIME_TYPE",false,typeof(string))]
		public string TIME_TYPE
		{
			set
			{
				_TIME_TYPE=value;
			}
			get
			{
				return _TIME_TYPE;
			}
		}

		[ColumnName("NEED_DESC",false,typeof(string))]
		public string NEED_DESC
		{
			set
			{
				_NEED_DESC=value;
			}
			get
			{
				return _NEED_DESC;
			}
		}

		[ColumnName("NEED_FILE",false,typeof(string))]
		public string NEED_FILE
		{
			set
			{
				_NEED_FILE=value;
			}
			get
			{
				return _NEED_FILE;
			}
		}

		[ColumnName("VALUEDISPLAY",false,typeof(string))]
		public string VALUEDISPLAY
		{
			set
			{
				_VALUEDISPLAY=value;
			}
			get
			{
				return _VALUEDISPLAY;
			}
		}
		public VKpiExp_Record Clone(){
			try{
				return this.Clone<VKpiExp_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VKpiExp gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpiExp ret = new VKpiExp(dbc,this);
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
				ret=(List<KpiPackage_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_PACKAGE_UUID))
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
				ret=(List<KpiPackageItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_PACKAGE_ITEM_UUID))
					.FetchAll<KpiPackageItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<KpiPackage_Record> Link_KpiPackage_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiPackage_Record> ret= new List<KpiPackage_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackage ___table = new KpiPackage(dbc);
				ret=(List<KpiPackage_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_PACKAGE_UUID))
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
		/*201303180404*/
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				ret=(List<KpiPackageItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_PACKAGE_ITEM_UUID))
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
		/*2013031800428*/
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
		/*2013031800428*/
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
		/*201303180429*/
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
		/*201303180429*/
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
