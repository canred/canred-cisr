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
	[ISTTableView("RAW_HEAD", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class RawHead_Record : RecordBase{
		public RawHead_Record(){}
		/*欄位資訊 Start*/
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
		public RawHead_Record Clone(){
			try{
				return this.Clone<RawHead_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RawHead gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ret = new RawHead(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<RawData_Record> Link_RawData_By_RawHeadUuid()
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				ret=(List<RawData_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
					.FetchAll<RawData_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<RawHeadSpecRule_Record> Link_RawHeadSpecRule_By_RawHeadUuid()
		{
			try{
				List<RawHeadSpecRule_Record> ret= new List<RawHeadSpecRule_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadSpecRule ___table = new RawHeadSpecRule(dbc);
				ret=(List<RawHeadSpecRule_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
					.FetchAll<RawHeadSpecRule_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<UploadJob_Record> Link_UploadJob_By_RawHeadUuid()
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				ret=(List<UploadJob_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
					.FetchAll<UploadJob_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_RawHeadUuid()
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				ret=(List<KpiPackageExpend_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
					.FetchAll<KpiPackageExpend_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<RawData_Record> Link_RawData_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				ret=(List<RawData_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
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
		/*201303180348*/
		public List<RawHeadSpecRule_Record> Link_RawHeadSpecRule_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<RawHeadSpecRule_Record> ret= new List<RawHeadSpecRule_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadSpecRule ___table = new RawHeadSpecRule(dbc);
				ret=(List<RawHeadSpecRule_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<RawHeadSpecRule_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<UploadJob_Record> Link_UploadJob_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				ret=(List<UploadJob_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
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
		/*201303180348*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				ret=(List<KpiPackageExpend_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_HEAD_UUID,this.UUID))
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
		public List<RawHeadCategory_Record> Link_RawHeadCategory_By_Uuid()
		{
			try{
				List<RawHeadCategory_Record> ret= new List<RawHeadCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadCategory ___table = new RawHeadCategory(dbc);
				ret=(List<RawHeadCategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_CATEGORY_UUID))
					.FetchAll<RawHeadCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<RawHeadCategory_Record> Link_RawHeadCategory_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawHeadCategory_Record> ret= new List<RawHeadCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadCategory ___table = new RawHeadCategory(dbc);
				ret=(List<RawHeadCategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_CATEGORY_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<RawHeadCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public RawData LinkFill_RawData_By_RawHeadUuid()
		{
			try{
				var data = Link_RawData_By_RawHeadUuid();
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public RawHeadSpecRule LinkFill_RawHeadSpecRule_By_RawHeadUuid()
		{
			try{
				var data = Link_RawHeadSpecRule_By_RawHeadUuid();
				RawHeadSpecRule ret=new RawHeadSpecRule(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public UploadJob LinkFill_UploadJob_By_RawHeadUuid()
		{
			try{
				var data = Link_UploadJob_By_RawHeadUuid();
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_RawHeadUuid()
		{
			try{
				var data = Link_KpiPackageExpend_By_RawHeadUuid();
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public RawData LinkFill_RawData_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawData_By_RawHeadUuid(limit);
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public RawHeadSpecRule LinkFill_RawHeadSpecRule_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHeadSpecRule_By_RawHeadUuid(limit);
				RawHeadSpecRule ret=new RawHeadSpecRule(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public UploadJob LinkFill_UploadJob_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_UploadJob_By_RawHeadUuid(limit);
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_RawHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageExpend_By_RawHeadUuid(limit);
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public RawHeadCategory LinkFill_RawHeadCategory_By_Uuid()
		{
			try{
				var data = Link_RawHeadCategory_By_Uuid();
				RawHeadCategory ret=new RawHeadCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public RawHeadCategory LinkFill_RawHeadCategory_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHeadCategory_By_Uuid(limit);
				RawHeadCategory ret=new RawHeadCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
