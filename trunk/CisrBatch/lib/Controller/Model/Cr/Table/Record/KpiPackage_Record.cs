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
	[ISTTableView("KPI_PACKAGE", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class KpiPackage_Record : RecordBase{
		public KpiPackage_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _COMPANY_UUID=null;
		string _NAME=null;
		string _SCOPE_MONTH_ID=null;
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

		[ColumnName("SCOPE_MONTH_ID",false,typeof(string))]
		public string SCOPE_MONTH_ID
		{
			set
			{
				_SCOPE_MONTH_ID=value;
			}
			get
			{
				return _SCOPE_MONTH_ID;
			}
		}
		public KpiPackage_Record Clone(){
			try{
				return this.Clone<KpiPackage_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public KpiPackage gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackage ret = new KpiPackage(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_KpiPackageUuid()
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				ret=(List<KpiPackageItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
					.FetchAll<KpiPackageItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VKpiExp_Record> Link_VKpiExp_By_KpiPackageUuid()
		{
			try{
				List<VKpiExp_Record> ret= new List<VKpiExp_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpiExp ___table = new VKpiExp(dbc);
				ret=(List<VKpiExp_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
					.FetchAll<VKpiExp_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_KpiPackageUuid()
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				ret=(List<KpiPackageExpend_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
					.FetchAll<KpiPackageExpend_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<FrameHead_Record> Link_FrameHead_By_KpiPackageUuid()
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
					.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<KpiPackageItem_Record> Link_KpiPackageItem_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageItem_Record> ret= new List<KpiPackageItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ___table = new KpiPackageItem(dbc);
				ret=(List<KpiPackageItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
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
		public List<VKpiExp_Record> Link_VKpiExp_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				List<VKpiExp_Record> ret= new List<VKpiExp_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpiExp ___table = new VKpiExp(dbc);
				ret=(List<VKpiExp_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<VKpiExp_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				ret=(List<KpiPackageExpend_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
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
		/*201303180348*/
		public List<FrameHead_Record> Link_FrameHead_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_UUID,this.UUID))
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
		/*201303180357*/
		public KpiPackageItem LinkFill_KpiPackageItem_By_KpiPackageUuid()
		{
			try{
				var data = Link_KpiPackageItem_By_KpiPackageUuid();
				KpiPackageItem ret=new KpiPackageItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VKpiExp LinkFill_VKpiExp_By_KpiPackageUuid()
		{
			try{
				var data = Link_VKpiExp_By_KpiPackageUuid();
				VKpiExp ret=new VKpiExp(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_KpiPackageUuid()
		{
			try{
				var data = Link_KpiPackageExpend_By_KpiPackageUuid();
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public FrameHead LinkFill_FrameHead_By_KpiPackageUuid()
		{
			try{
				var data = Link_FrameHead_By_KpiPackageUuid();
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public KpiPackageItem LinkFill_KpiPackageItem_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageItem_By_KpiPackageUuid(limit);
				KpiPackageItem ret=new KpiPackageItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VKpiExp LinkFill_VKpiExp_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				var data = Link_VKpiExp_By_KpiPackageUuid(limit);
				VKpiExp ret=new VKpiExp(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageExpend_By_KpiPackageUuid(limit);
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public FrameHead LinkFill_FrameHead_By_KpiPackageUuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameHead_By_KpiPackageUuid(limit);
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
