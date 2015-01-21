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
	[ISTTableView("FRAME_HEAD", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class FrameHead_Record : RecordBase{
		public FrameHead_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _COMPANY_UUID=null;
		string _C_NAME=null;
		string _E_NAME=null;
		string _PARENT_FRAME_HEAD_UUID=null;
		decimal? _ORD=null;
		string _REGION_UUID=null;
		string _FRAME_ID=null;
		string _FULL_FRAME_UUID_LIST=null;
		decimal? _DLEVEL=null;
		string _ZH_NAME=null;
		string _FULL_FRAME_NAME_LIST=null;
		string _FULL_FRAME_ID_LIST=null;
		string _KPI_PACKAGE_UUID=null;
		string _HASCHILD=null;
		string _FRAME_CATEGORY_UUID=null;
		string _CURRENCY=null;
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

		[ColumnName("PARENT_FRAME_HEAD_UUID",false,typeof(string))]
		public string PARENT_FRAME_HEAD_UUID
		{
			set
			{
				_PARENT_FRAME_HEAD_UUID=value;
			}
			get
			{
				return _PARENT_FRAME_HEAD_UUID;
			}
		}

		[ColumnName("ORD",false,typeof(decimal?))]
		public decimal? ORD
		{
			set
			{
				_ORD=value;
			}
			get
			{
				return _ORD;
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

		[ColumnName("FRAME_ID",false,typeof(string))]
		public string FRAME_ID
		{
			set
			{
				_FRAME_ID=value;
			}
			get
			{
				return _FRAME_ID;
			}
		}

		[ColumnName("FULL_FRAME_UUID_LIST",false,typeof(string))]
		public string FULL_FRAME_UUID_LIST
		{
			set
			{
				_FULL_FRAME_UUID_LIST=value;
			}
			get
			{
				return _FULL_FRAME_UUID_LIST;
			}
		}

		[ColumnName("DLEVEL",false,typeof(decimal?))]
		public decimal? DLEVEL
		{
			set
			{
				_DLEVEL=value;
			}
			get
			{
				return _DLEVEL;
			}
		}

		[ColumnName("ZH_NAME",false,typeof(string))]
		public string ZH_NAME
		{
			set
			{
				_ZH_NAME=value;
			}
			get
			{
				return _ZH_NAME;
			}
		}

		[ColumnName("FULL_FRAME_NAME_LIST",false,typeof(string))]
		public string FULL_FRAME_NAME_LIST
		{
			set
			{
				_FULL_FRAME_NAME_LIST=value;
			}
			get
			{
				return _FULL_FRAME_NAME_LIST;
			}
		}

		[ColumnName("FULL_FRAME_ID_LIST",false,typeof(string))]
		public string FULL_FRAME_ID_LIST
		{
			set
			{
				_FULL_FRAME_ID_LIST=value;
			}
			get
			{
				return _FULL_FRAME_ID_LIST;
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

		[ColumnName("HASCHILD",false,typeof(string))]
		public string HASCHILD
		{
			set
			{
				_HASCHILD=value;
			}
			get
			{
				return _HASCHILD;
			}
		}

		[ColumnName("FRAME_CATEGORY_UUID",false,typeof(string))]
		public string FRAME_CATEGORY_UUID
		{
			set
			{
				_FRAME_CATEGORY_UUID=value;
			}
			get
			{
				return _FRAME_CATEGORY_UUID;
			}
		}

		[ColumnName("CURRENCY",false,typeof(string))]
		public string CURRENCY
		{
			set
			{
				_CURRENCY=value;
			}
			get
			{
				return _CURRENCY;
			}
		}
		public FrameHead_Record Clone(){
			try{
				return this.Clone<FrameHead_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public FrameHead gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ret = new FrameHead(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<RawData_Record> Link_RawData_By_FrameHeadUuid()
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				ret=(List<RawData_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
					.FetchAll<RawData_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<ViewHome_Record> Link_ViewHome_By_FrameHeadUuid()
		{
			try{
				List<ViewHome_Record> ret= new List<ViewHome_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ViewHome ___table = new ViewHome(dbc);
				ret=(List<ViewHome_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
					.FetchAll<ViewHome_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<FrameItem_Record> Link_FrameItem_By_FrameHeadUuid()
		{
			try{
				List<FrameItem_Record> ret= new List<FrameItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameItem ___table = new FrameItem(dbc);
				ret=(List<FrameItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
					.FetchAll<FrameItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<UploadJob_Record> Link_UploadJob_By_FrameHeadUuid()
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				ret=(List<UploadJob_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
					.FetchAll<UploadJob_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<Cal_Record> Link_Cal_By_FrameHeadUuid()
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				ret=(List<Cal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
					.FetchAll<Cal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VFrameHead_Record> Link_VFrameHead_By_Uuid()
		{
			try{
				List<VFrameHead_Record> ret= new List<VFrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameHead ___table = new VFrameHead(dbc);
				ret=(List<VFrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
					.FetchAll<VFrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<RawData_Record> Link_RawData_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<RawData_Record> ret= new List<RawData_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawData ___table = new RawData(dbc);
				ret=(List<RawData_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
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
		public List<ViewHome_Record> Link_ViewHome_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<ViewHome_Record> ret= new List<ViewHome_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ViewHome ___table = new ViewHome(dbc);
				ret=(List<ViewHome_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<ViewHome_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<FrameItem_Record> Link_FrameItem_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<FrameItem_Record> ret= new List<FrameItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameItem ___table = new FrameItem(dbc);
				ret=(List<FrameItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<FrameItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<UploadJob_Record> Link_UploadJob_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<UploadJob_Record> ret= new List<UploadJob_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UploadJob ___table = new UploadJob(dbc);
				ret=(List<UploadJob_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
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
		public List<Cal_Record> Link_Cal_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				ret=(List<Cal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_HEAD_UUID,this.UUID))
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
		/*201303180348*/
		public List<VFrameHead_Record> Link_VFrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<VFrameHead_Record> ret= new List<VFrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameHead ___table = new VFrameHead(dbc);
				ret=(List<VFrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<VFrameHead_Record>() ; 
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
		/*201303180357*/
		public RawData LinkFill_RawData_By_FrameHeadUuid()
		{
			try{
				var data = Link_RawData_By_FrameHeadUuid();
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public ViewHome LinkFill_ViewHome_By_FrameHeadUuid()
		{
			try{
				var data = Link_ViewHome_By_FrameHeadUuid();
				ViewHome ret=new ViewHome(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public FrameItem LinkFill_FrameItem_By_FrameHeadUuid()
		{
			try{
				var data = Link_FrameItem_By_FrameHeadUuid();
				FrameItem ret=new FrameItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public UploadJob LinkFill_UploadJob_By_FrameHeadUuid()
		{
			try{
				var data = Link_UploadJob_By_FrameHeadUuid();
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public Cal LinkFill_Cal_By_FrameHeadUuid()
		{
			try{
				var data = Link_Cal_By_FrameHeadUuid();
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VFrameHead LinkFill_VFrameHead_By_Uuid()
		{
			try{
				var data = Link_VFrameHead_By_Uuid();
				VFrameHead ret=new VFrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public RawData LinkFill_RawData_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawData_By_FrameHeadUuid(limit);
				RawData ret=new RawData(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public ViewHome LinkFill_ViewHome_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_ViewHome_By_FrameHeadUuid(limit);
				ViewHome ret=new ViewHome(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public FrameItem LinkFill_FrameItem_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameItem_By_FrameHeadUuid(limit);
				FrameItem ret=new FrameItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public UploadJob LinkFill_UploadJob_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_UploadJob_By_FrameHeadUuid(limit);
				UploadJob ret=new UploadJob(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public Cal LinkFill_Cal_By_FrameHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_Cal_By_FrameHeadUuid(limit);
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VFrameHead LinkFill_VFrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_VFrameHead_By_Uuid(limit);
				VFrameHead ret=new VFrameHead(data);
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
	}
}
