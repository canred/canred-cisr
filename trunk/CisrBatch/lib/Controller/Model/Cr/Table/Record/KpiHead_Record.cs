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
	[ISTTableView("KPI_HEAD", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class KpiHead_Record : RecordBase{
		public KpiHead_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _COMPANY_UUID=null;
		string _KPI_ID=null;
		string _C_DESC=null;
		string _E_DESC=null;
		string _UNIT=null;
		decimal? _DEGREE=null;
		string _C_NOTICE=null;
		decimal? _SIGNAL=null;
		string _TIME_TYPE=null;
		string _C_DESC_GROUP=null;
		string _E_DESC_GROUP=null;
		string _INCLUDE_KPI=null;
		decimal? _CALCULTE_ORD=null;
		string _NEED_SUMMARY=null;
		string _NEED_SECURITY=null;
		string _ZH_DESC=null;
		string _E_NOTICE=null;
		string _NEED_AVG=null;
		string _AVG_TYPE=null;
		string _ZH_NOTICE=null;
		string _ALIASES=null;
		/*欄位資訊 End*/

		[ColumnName("UUID",true,typeof(string))]
		public string UUID
		{
			set
			{
				_UUID=value;
			}
			get
			{
				return _UUID;
			}
		}

		[ColumnName("CREATE_DATE",false,typeof(DateTime?))]
		public DateTime? CREATE_DATE
		{
			set
			{
				_CREATE_DATE=value;
			}
			get
			{
				return _CREATE_DATE;
			}
		}

		[ColumnName("UPDATE_DATE",false,typeof(DateTime?))]
		public DateTime? UPDATE_DATE
		{
			set
			{
				_UPDATE_DATE=value;
			}
			get
			{
				return _UPDATE_DATE;
			}
		}

		[ColumnName("IS_ACTIVE",false,typeof(string))]
		public string IS_ACTIVE
		{
			set
			{
				_IS_ACTIVE=value;
			}
			get
			{
				return _IS_ACTIVE;
			}
		}

		[ColumnName("COMPANY_UUID",false,typeof(string))]
		public string COMPANY_UUID
		{
			set
			{
				_COMPANY_UUID=value;
			}
			get
			{
				return _COMPANY_UUID;
			}
		}

		[ColumnName("KPI_ID",false,typeof(string))]
		public string KPI_ID
		{
			set
			{
				_KPI_ID=value;
			}
			get
			{
				return _KPI_ID;
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

		[ColumnName("DEGREE",false,typeof(decimal?))]
		public decimal? DEGREE
		{
			set
			{
				_DEGREE=value;
			}
			get
			{
				return _DEGREE;
			}
		}

		[ColumnName("C_NOTICE",false,typeof(string))]
		public string C_NOTICE
		{
			set
			{
				_C_NOTICE=value;
			}
			get
			{
				return _C_NOTICE;
			}
		}

		[ColumnName("SIGNAL",false,typeof(decimal?))]
		public decimal? SIGNAL
		{
			set
			{
				_SIGNAL=value;
			}
			get
			{
				return _SIGNAL;
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

		[ColumnName("C_DESC_GROUP",false,typeof(string))]
		public string C_DESC_GROUP
		{
			set
			{
				_C_DESC_GROUP=value;
			}
			get
			{
				return _C_DESC_GROUP;
			}
		}

		[ColumnName("E_DESC_GROUP",false,typeof(string))]
		public string E_DESC_GROUP
		{
			set
			{
				_E_DESC_GROUP=value;
			}
			get
			{
				return _E_DESC_GROUP;
			}
		}

		[ColumnName("INCLUDE_KPI",false,typeof(string))]
		public string INCLUDE_KPI
		{
			set
			{
				_INCLUDE_KPI=value;
			}
			get
			{
				return _INCLUDE_KPI;
			}
		}

		[ColumnName("CALCULTE_ORD",false,typeof(decimal?))]
		public decimal? CALCULTE_ORD
		{
			set
			{
				_CALCULTE_ORD=value;
			}
			get
			{
				return _CALCULTE_ORD;
			}
		}

		[ColumnName("NEED_SUMMARY",false,typeof(string))]
		public string NEED_SUMMARY
		{
			set
			{
				_NEED_SUMMARY=value;
			}
			get
			{
				return _NEED_SUMMARY;
			}
		}

		[ColumnName("NEED_SECURITY",false,typeof(string))]
		public string NEED_SECURITY
		{
			set
			{
				_NEED_SECURITY=value;
			}
			get
			{
				return _NEED_SECURITY;
			}
		}

		[ColumnName("ZH_DESC",false,typeof(string))]
		public string ZH_DESC
		{
			set
			{
				_ZH_DESC=value;
			}
			get
			{
				return _ZH_DESC;
			}
		}

		[ColumnName("E_NOTICE",false,typeof(string))]
		public string E_NOTICE
		{
			set
			{
				_E_NOTICE=value;
			}
			get
			{
				return _E_NOTICE;
			}
		}

		[ColumnName("NEED_AVG",false,typeof(string))]
		public string NEED_AVG
		{
			set
			{
				_NEED_AVG=value;
			}
			get
			{
				return _NEED_AVG;
			}
		}

		[ColumnName("AVG_TYPE",false,typeof(string))]
		public string AVG_TYPE
		{
			set
			{
				_AVG_TYPE=value;
			}
			get
			{
				return _AVG_TYPE;
			}
		}

		[ColumnName("ZH_NOTICE",false,typeof(string))]
		public string ZH_NOTICE
		{
			set
			{
				_ZH_NOTICE=value;
			}
			get
			{
				return _ZH_NOTICE;
			}
		}

		[ColumnName("ALIASES",false,typeof(string))]
		public string ALIASES
		{
			set
			{
				_ALIASES=value;
			}
			get
			{
				return _ALIASES;
			}
		}
		public KpiHead_Record Clone(){
			try{
				return this.Clone<KpiHead_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public KpiHead gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiHead ret = new KpiHead(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_KpiHeadUuid()
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				ret=(List<KpiPackageItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_HEAD_UUID,this.UUID))
					.FetchAll<KpiPackageItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<KpiFormula_Record> Link_KpiFormula_By_KpiHeadUuid()
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				ret=(List<KpiFormula_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_HEAD_UUID,this.UUID))
					.FetchAll<KpiFormula_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<Cal_Record> Link_Cal_By_KpiHeadUuid()
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				ret=(List<Cal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_HEAD_UUID,this.UUID))
					.FetchAll<Cal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				ret=(List<KpiPackageItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_HEAD_UUID,this.UUID))
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
		/*201303180348*/
		public List<KpiFormula_Record> Link_KpiFormula_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				ret=(List<KpiFormula_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_HEAD_UUID,this.UUID))
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
		/*201303180348*/
		public List<Cal_Record> Link_Cal_By_KpiHeadUuid(OrderLimit limit)
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				ret=(List<Cal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_HEAD_UUID,this.UUID))
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
		/*201303180357*/
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
		/*201303180357*/
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
		/*201303180357*/
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
		/*201303180358*/
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
		/*201303180358*/
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
		/*201303180358*/
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
