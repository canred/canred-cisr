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
	[ISTTableView("V_KPI", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VKpi_Record : RecordBase{
		public VKpi_Record(){}
		/*欄位資訊 Start*/
		string _KPI_HEAD_UUID=null;
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
		string _KPI_FORMULA_UUID=null;
		string _TIME_ID=null;
		string _ALGORITHM=null;
		string _KPI_FORMULA_DESC=null;
		string _ALGORITHM_MAN=null;
		/*欄位資訊 End*/

		[ColumnName("KPI_HEAD_UUID",false,typeof(string))]
		public string KPI_HEAD_UUID
		{
			set
			{
				_KPI_HEAD_UUID=value;
			}
			get
			{
				return _KPI_HEAD_UUID;
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

		[ColumnName("KPI_FORMULA_UUID",false,typeof(string))]
		public string KPI_FORMULA_UUID
		{
			set
			{
				_KPI_FORMULA_UUID=value;
			}
			get
			{
				return _KPI_FORMULA_UUID;
			}
		}

		[ColumnName("TIME_ID",false,typeof(string))]
		public string TIME_ID
		{
			set
			{
				_TIME_ID=value;
			}
			get
			{
				return _TIME_ID;
			}
		}

		[ColumnName("ALGORITHM",false,typeof(string))]
		public string ALGORITHM
		{
			set
			{
				_ALGORITHM=value;
			}
			get
			{
				return _ALGORITHM;
			}
		}

		[ColumnName("KPI_FORMULA_DESC",false,typeof(string))]
		public string KPI_FORMULA_DESC
		{
			set
			{
				_KPI_FORMULA_DESC=value;
			}
			get
			{
				return _KPI_FORMULA_DESC;
			}
		}

		[ColumnName("ALGORITHM_MAN",false,typeof(string))]
		public string ALGORITHM_MAN
		{
			set
			{
				_ALGORITHM_MAN=value;
			}
			get
			{
				return _ALGORITHM_MAN;
			}
		}
		public VKpi_Record Clone(){
			try{
				return this.Clone<VKpi_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VKpi gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpi ret = new VKpi(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
