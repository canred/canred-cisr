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
	[ISTTableView("V_FRAME_HEAD", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VFrameHead_Record : RecordBase{
		public VFrameHead_Record(){}
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
		string _FRAME_CATEGORY_NAME=null;
		/*欄位資訊 End*/

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

		[ColumnName("FRAME_CATEGORY_NAME",false,typeof(string))]
		public string FRAME_CATEGORY_NAME
		{
			set
			{
				_FRAME_CATEGORY_NAME=value;
			}
			get
			{
				return _FRAME_CATEGORY_NAME;
			}
		}
		public VFrameHead_Record Clone(){
			try{
				return this.Clone<VFrameHead_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VFrameHead gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameHead ret = new VFrameHead(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<FrameHead_Record> Link_FrameHead_By_Uuid()
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
					.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<FrameCategory_Record> Link_FrameCategory_By_Uuid()
		{
			try{
				List<FrameCategory_Record> ret= new List<FrameCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameCategory ___table = new FrameCategory(dbc);
				ret=(List<FrameCategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.FRAME_CATEGORY_UUID))
					.FetchAll<FrameCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<FrameCategory_Record> Link_FrameCategory_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameCategory_Record> ret= new List<FrameCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameCategory ___table = new FrameCategory(dbc);
				ret=(List<FrameCategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.FRAME_CATEGORY_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<FrameCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public FrameHead LinkFill_FrameHead_By_Uuid()
		{
			try{
				var data = Link_FrameHead_By_Uuid();
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public FrameCategory LinkFill_FrameCategory_By_Uuid()
		{
			try{
				var data = Link_FrameCategory_By_Uuid();
				FrameCategory ret=new FrameCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public FrameHead LinkFill_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameHead_By_Uuid(limit);
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public FrameCategory LinkFill_FrameCategory_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameCategory_By_Uuid(limit);
				FrameCategory ret=new FrameCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
