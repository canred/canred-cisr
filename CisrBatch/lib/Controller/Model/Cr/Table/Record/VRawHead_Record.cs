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
	[ISTTableView("V_RAW_HEAD", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VRawHead_Record : RecordBase{
		public VRawHead_Record(){}
		/*欄位資訊 Start*/
		string _COMPANY_ID=null;
		string _COMPANY_C_NAME=null;
		string _COMPANY_E_NAME=null;
		string _COMPANY_ZH_CN=null;
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _COMPANY_UUID=null;
		string _RAW_ID=null;
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
		string _RAW_HEAD_CATEGORY_NAME=null;
		string _RAW_HEAD_CATEGORY_DESCRIPTION=null;
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

		[ColumnName("COMPANY_ZH_CN",false,typeof(string))]
		public string COMPANY_ZH_CN
		{
			set
			{
				_COMPANY_ZH_CN=value;
			}
			get
			{
				return _COMPANY_ZH_CN;
			}
		}

		[ColumnName("UUID",false,typeof(string))]
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

		[ColumnName("RAW_HEAD_CATEGORY_NAME",false,typeof(string))]
		public string RAW_HEAD_CATEGORY_NAME
		{
			set
			{
				_RAW_HEAD_CATEGORY_NAME=value;
			}
			get
			{
				return _RAW_HEAD_CATEGORY_NAME;
			}
		}

		[ColumnName("RAW_HEAD_CATEGORY_DESCRIPTION",false,typeof(string))]
		public string RAW_HEAD_CATEGORY_DESCRIPTION
		{
			set
			{
				_RAW_HEAD_CATEGORY_DESCRIPTION=value;
			}
			get
			{
				return _RAW_HEAD_CATEGORY_DESCRIPTION;
			}
		}
		public VRawHead_Record Clone(){
			try{
				return this.Clone<VRawHead_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VRawHead gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VRawHead ret = new VRawHead(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
