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
	[ISTTableView("V_PARAMETER_QUERY", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VParameterQuery_Record : RecordBase{
		public VParameterQuery_Record(){}
		/*欄位資訊 Start*/
		string _COMPANY_ID=null;
		string _COMPANY_C_NAME=null;
		string _COMPANY_E_NAME=null;
		string _COMPANY_UUID=null;
		string _PARAMETER_UUID=null;
		string _PARAMETER_ITEM_UUID=null;
		string _IS_ACTIVE=null;
		string _NAME=null;
		string _DESCRIPTION=null;
		decimal? _VALUE=null;
		string _ITEM_IS_ACTIVE=null;
		string _IS_PUBLIC=null;
		string _ITEM_DESCRIPTION=null;
		decimal? _ITEM_VALUE=null;
		string _REGION_NAME=null;
		string _REGION_UUID=null;
		string _MONTH_ID=null;
		decimal? _MONTH_VALUE=null;
		string _PARAMETER_MONTH_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("COMPANY_ID",false,typeof(string))]
		public string COMPANY_ID
		{
			set
			{
				_COMPANY_ID=value;
			}
			get
			{
				return _COMPANY_ID;
			}
		}

		[ColumnName("COMPANY_C_NAME",false,typeof(string))]
		public string COMPANY_C_NAME
		{
			set
			{
				_COMPANY_C_NAME=value;
			}
			get
			{
				return _COMPANY_C_NAME;
			}
		}

		[ColumnName("COMPANY_E_NAME",false,typeof(string))]
		public string COMPANY_E_NAME
		{
			set
			{
				_COMPANY_E_NAME=value;
			}
			get
			{
				return _COMPANY_E_NAME;
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

		[ColumnName("PARAMETER_UUID",false,typeof(string))]
		public string PARAMETER_UUID
		{
			set
			{
				_PARAMETER_UUID=value;
			}
			get
			{
				return _PARAMETER_UUID;
			}
		}

		[ColumnName("PARAMETER_ITEM_UUID",false,typeof(string))]
		public string PARAMETER_ITEM_UUID
		{
			set
			{
				_PARAMETER_ITEM_UUID=value;
			}
			get
			{
				return _PARAMETER_ITEM_UUID;
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

		[ColumnName("NAME",false,typeof(string))]
		public string NAME
		{
			set
			{
				_NAME=value;
			}
			get
			{
				return _NAME;
			}
		}

		[ColumnName("DESCRIPTION",false,typeof(string))]
		public string DESCRIPTION
		{
			set
			{
				_DESCRIPTION=value;
			}
			get
			{
				return _DESCRIPTION;
			}
		}

		[ColumnName("VALUE",false,typeof(decimal?))]
		public decimal? VALUE
		{
			set
			{
				_VALUE=value;
			}
			get
			{
				return _VALUE;
			}
		}

		[ColumnName("ITEM_IS_ACTIVE",false,typeof(string))]
		public string ITEM_IS_ACTIVE
		{
			set
			{
				_ITEM_IS_ACTIVE=value;
			}
			get
			{
				return _ITEM_IS_ACTIVE;
			}
		}

		[ColumnName("IS_PUBLIC",false,typeof(string))]
		public string IS_PUBLIC
		{
			set
			{
				_IS_PUBLIC=value;
			}
			get
			{
				return _IS_PUBLIC;
			}
		}

		[ColumnName("ITEM_DESCRIPTION",false,typeof(string))]
		public string ITEM_DESCRIPTION
		{
			set
			{
				_ITEM_DESCRIPTION=value;
			}
			get
			{
				return _ITEM_DESCRIPTION;
			}
		}

		[ColumnName("ITEM_VALUE",false,typeof(decimal?))]
		public decimal? ITEM_VALUE
		{
			set
			{
				_ITEM_VALUE=value;
			}
			get
			{
				return _ITEM_VALUE;
			}
		}

		[ColumnName("REGION_NAME",false,typeof(string))]
		public string REGION_NAME
		{
			set
			{
				_REGION_NAME=value;
			}
			get
			{
				return _REGION_NAME;
			}
		}

		[ColumnName("REGION_UUID",false,typeof(string))]
		public string REGION_UUID
		{
			set
			{
				_REGION_UUID=value;
			}
			get
			{
				return _REGION_UUID;
			}
		}

		[ColumnName("MONTH_ID",false,typeof(string))]
		public string MONTH_ID
		{
			set
			{
				_MONTH_ID=value;
			}
			get
			{
				return _MONTH_ID;
			}
		}

		[ColumnName("MONTH_VALUE",false,typeof(decimal?))]
		public decimal? MONTH_VALUE
		{
			set
			{
				_MONTH_VALUE=value;
			}
			get
			{
				return _MONTH_VALUE;
			}
		}

		[ColumnName("PARAMETER_MONTH_UUID",false,typeof(string))]
		public string PARAMETER_MONTH_UUID
		{
			set
			{
				_PARAMETER_MONTH_UUID=value;
			}
			get
			{
				return _PARAMETER_MONTH_UUID;
			}
		}
		public VParameterQuery_Record Clone(){
			try{
				return this.Clone<VParameterQuery_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VParameterQuery gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VParameterQuery ret = new VParameterQuery(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
