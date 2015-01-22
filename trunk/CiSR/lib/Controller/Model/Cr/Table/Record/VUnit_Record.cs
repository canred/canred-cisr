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
	[ISTTableView("V_UNIT", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VUnit_Record : RecordBase{
		public VUnit_Record(){}
		/*欄位資訊 Start*/
		string _UNIT_CATEGORY_UUID=null;
		string _COMPANY_UUID=null;
		string _UNIT_CATEGORY_NAME=null;
		string _UNIT_CATEGORY_DESCRIPTION=null;
		string _UNIT_CATEGORY_IS_PUBLIC=null;
		string _UNIT_CATEGORY_IS_ACTIVE=null;
		string _UNIT_UUID=null;
		string _UNIT_NAME=null;
		string _UNIT_C_DESC=null;
		string _UNIT_IS_ACTIVE=null;
		string _UNIT_E_DESC=null;
		/*欄位資訊 End*/

		[ColumnName("UNIT_CATEGORY_UUID",false,typeof(string))]
		public string UNIT_CATEGORY_UUID
		{
			set
			{
				_UNIT_CATEGORY_UUID=value;
			}
			get
			{
				return _UNIT_CATEGORY_UUID;
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

		[ColumnName("UNIT_CATEGORY_NAME",false,typeof(string))]
		public string UNIT_CATEGORY_NAME
		{
			set
			{
				_UNIT_CATEGORY_NAME=value;
			}
			get
			{
				return _UNIT_CATEGORY_NAME;
			}
		}

		[ColumnName("UNIT_CATEGORY_DESCRIPTION",false,typeof(string))]
		public string UNIT_CATEGORY_DESCRIPTION
		{
			set
			{
				_UNIT_CATEGORY_DESCRIPTION=value;
			}
			get
			{
				return _UNIT_CATEGORY_DESCRIPTION;
			}
		}

		[ColumnName("UNIT_CATEGORY_IS_PUBLIC",false,typeof(string))]
		public string UNIT_CATEGORY_IS_PUBLIC
		{
			set
			{
				_UNIT_CATEGORY_IS_PUBLIC=value;
			}
			get
			{
				return _UNIT_CATEGORY_IS_PUBLIC;
			}
		}

		[ColumnName("UNIT_CATEGORY_IS_ACTIVE",false,typeof(string))]
		public string UNIT_CATEGORY_IS_ACTIVE
		{
			set
			{
				_UNIT_CATEGORY_IS_ACTIVE=value;
			}
			get
			{
				return _UNIT_CATEGORY_IS_ACTIVE;
			}
		}

		[ColumnName("UNIT_UUID",false,typeof(string))]
		public string UNIT_UUID
		{
			set
			{
				_UNIT_UUID=value;
			}
			get
			{
				return _UNIT_UUID;
			}
		}

		[ColumnName("UNIT_NAME",false,typeof(string))]
		public string UNIT_NAME
		{
			set
			{
				_UNIT_NAME=value;
			}
			get
			{
				return _UNIT_NAME;
			}
		}

		[ColumnName("UNIT_C_DESC",false,typeof(string))]
		public string UNIT_C_DESC
		{
			set
			{
				_UNIT_C_DESC=value;
			}
			get
			{
				return _UNIT_C_DESC;
			}
		}

		[ColumnName("UNIT_IS_ACTIVE",false,typeof(string))]
		public string UNIT_IS_ACTIVE
		{
			set
			{
				_UNIT_IS_ACTIVE=value;
			}
			get
			{
				return _UNIT_IS_ACTIVE;
			}
		}

		[ColumnName("UNIT_E_DESC",false,typeof(string))]
		public string UNIT_E_DESC
		{
			set
			{
				_UNIT_E_DESC=value;
			}
			get
			{
				return _UNIT_E_DESC;
			}
		}
		public VUnit_Record Clone(){
			try{
				return this.Clone<VUnit_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VUnit gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VUnit ret = new VUnit(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
