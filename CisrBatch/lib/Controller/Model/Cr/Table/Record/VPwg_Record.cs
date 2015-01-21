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
	[ISTTableView("V_PWG", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VPwg_Record : RecordBase{
		public VPwg_Record(){}
		/*欄位資訊 Start*/
		string _PWG_GID=null;
		string _ATTENDANT_UUID=null;
		string _IS_ACTIVE=null;
		string _COMPANY_UUID=null;
		string _ACCOUNT=null;
		string _C_NAME=null;
		string _E_NAME=null;
		string _EMAIL=null;
		string _IS_SUPPER=null;
		string _IS_ADMIN=null;
		string _CODE_PAGE=null;
		string _DEPARTMENT_UUID=null;
		string _PHONE=null;
		string _SITE_UUID=null;
		string _GENDER=null;
		DateTime? _BIRTHDAY=null;
		DateTime? _HIRE_DATE=null;
		DateTime? _QUIT_DATE=null;
		string _IS_DIRECT=null;
		string _GRADE=null;
		string _IS_DEFAULT_PASS=null;
		/*欄位資訊 End*/

		[ColumnName("PWG_GID",true,typeof(string))]
		public string PWG_GID
		{
			set
			{
				_PWG_GID=value;
			}
			get
			{
				return _PWG_GID;
			}
		}

		[ColumnName("ATTENDANT_UUID",false,typeof(string))]
		public string ATTENDANT_UUID
		{
			set
			{
				_ATTENDANT_UUID=value;
			}
			get
			{
				return _ATTENDANT_UUID;
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

		[ColumnName("ACCOUNT",false,typeof(string))]
		public string ACCOUNT
		{
			set
			{
				_ACCOUNT=value;
			}
			get
			{
				return _ACCOUNT;
			}
		}

		[ColumnName("C_NAME",false,typeof(string))]
		public string C_NAME
		{
			set
			{
				_C_NAME=value;
			}
			get
			{
				return _C_NAME;
			}
		}

		[ColumnName("E_NAME",false,typeof(string))]
		public string E_NAME
		{
			set
			{
				_E_NAME=value;
			}
			get
			{
				return _E_NAME;
			}
		}

		[ColumnName("EMAIL",false,typeof(string))]
		public string EMAIL
		{
			set
			{
				_EMAIL=value;
			}
			get
			{
				return _EMAIL;
			}
		}

		[ColumnName("IS_SUPPER",false,typeof(string))]
		public string IS_SUPPER
		{
			set
			{
				_IS_SUPPER=value;
			}
			get
			{
				return _IS_SUPPER;
			}
		}

		[ColumnName("IS_ADMIN",false,typeof(string))]
		public string IS_ADMIN
		{
			set
			{
				_IS_ADMIN=value;
			}
			get
			{
				return _IS_ADMIN;
			}
		}

		[ColumnName("CODE_PAGE",false,typeof(string))]
		public string CODE_PAGE
		{
			set
			{
				_CODE_PAGE=value;
			}
			get
			{
				return _CODE_PAGE;
			}
		}

		[ColumnName("DEPARTMENT_UUID",false,typeof(string))]
		public string DEPARTMENT_UUID
		{
			set
			{
				_DEPARTMENT_UUID=value;
			}
			get
			{
				return _DEPARTMENT_UUID;
			}
		}

		[ColumnName("PHONE",false,typeof(string))]
		public string PHONE
		{
			set
			{
				_PHONE=value;
			}
			get
			{
				return _PHONE;
			}
		}

		[ColumnName("SITE_UUID",false,typeof(string))]
		public string SITE_UUID
		{
			set
			{
				_SITE_UUID=value;
			}
			get
			{
				return _SITE_UUID;
			}
		}

		[ColumnName("GENDER",false,typeof(string))]
		public string GENDER
		{
			set
			{
				_GENDER=value;
			}
			get
			{
				return _GENDER;
			}
		}

		[ColumnName("BIRTHDAY",false,typeof(DateTime?))]
		public DateTime? BIRTHDAY
		{
			set
			{
				_BIRTHDAY=value;
			}
			get
			{
				return _BIRTHDAY;
			}
		}

		[ColumnName("HIRE_DATE",false,typeof(DateTime?))]
		public DateTime? HIRE_DATE
		{
			set
			{
				_HIRE_DATE=value;
			}
			get
			{
				return _HIRE_DATE;
			}
		}

		[ColumnName("QUIT_DATE",false,typeof(DateTime?))]
		public DateTime? QUIT_DATE
		{
			set
			{
				_QUIT_DATE=value;
			}
			get
			{
				return _QUIT_DATE;
			}
		}

		[ColumnName("IS_DIRECT",false,typeof(string))]
		public string IS_DIRECT
		{
			set
			{
				_IS_DIRECT=value;
			}
			get
			{
				return _IS_DIRECT;
			}
		}

		[ColumnName("GRADE",false,typeof(string))]
		public string GRADE
		{
			set
			{
				_GRADE=value;
			}
			get
			{
				return _GRADE;
			}
		}

		[ColumnName("IS_DEFAULT_PASS",false,typeof(string))]
		public string IS_DEFAULT_PASS
		{
			set
			{
				_IS_DEFAULT_PASS=value;
			}
			get
			{
				return _IS_DEFAULT_PASS;
			}
		}
		public VPwg_Record Clone(){
			try{
				return this.Clone<VPwg_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VPwg gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VPwg ret = new VPwg(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
