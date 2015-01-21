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
	[ISTTableView("KPI_PACKAGE_ITEM", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class KpiPackageItem_Record : RecordBase{
		public KpiPackageItem_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _KPI_PACKAGE_UUID=null;
		string _KPI_HEAD_UUID=null;
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
		public KpiPackageItem_Record Clone(){
			try{
				return this.Clone<KpiPackageItem_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public KpiPackageItem gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageItem ret = new KpiPackageItem(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VKpiExp_Record> Link_VKpiExp_By_KpiPackageItemUuid()
		{
			try{
				List<VKpiExp_Record> ret= new List<VKpiExp_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpiExp ___table = new VKpiExp(dbc);
				ret=(List<VKpiExp_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_ITEM_UUID,this.UUID))
					.FetchAll<VKpiExp_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_KpiPackageItemUuid()
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				ret=(List<KpiPackageExpend_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_ITEM_UUID,this.UUID))
					.FetchAll<KpiPackageExpend_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VKpiExp_Record> Link_VKpiExp_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				List<VKpiExp_Record> ret= new List<VKpiExp_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VKpiExp ___table = new VKpiExp(dbc);
				ret=(List<VKpiExp_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_ITEM_UUID,this.UUID))
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
		public List<KpiPackageExpend_Record> Link_KpiPackageExpend_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				List<KpiPackageExpend_Record> ret= new List<KpiPackageExpend_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiPackageExpend ___table = new KpiPackageExpend(dbc);
				ret=(List<KpiPackageExpend_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_PACKAGE_ITEM_UUID,this.UUID))
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
		public List<KpiHead_Record> Link_KpiHead_By_Uuid()
		{
			try{
				List<KpiHead_Record> ret= new List<KpiHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiHead ___table = new KpiHead(dbc);
				ret=(List<KpiHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_HEAD_UUID))
					.FetchAll<KpiHead_Record>() ; 
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
		/*201303180404*/
		public List<KpiHead_Record> Link_KpiHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiHead_Record> ret= new List<KpiHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiHead ___table = new KpiHead(dbc);
				ret=(List<KpiHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_HEAD_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<KpiHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VKpiExp LinkFill_VKpiExp_By_KpiPackageItemUuid()
		{
			try{
				var data = Link_VKpiExp_By_KpiPackageItemUuid();
				VKpiExp ret=new VKpiExp(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_KpiPackageItemUuid()
		{
			try{
				var data = Link_KpiPackageExpend_By_KpiPackageItemUuid();
				KpiPackageExpend ret=new KpiPackageExpend(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VKpiExp LinkFill_VKpiExp_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				var data = Link_VKpiExp_By_KpiPackageItemUuid(limit);
				VKpiExp ret=new VKpiExp(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public KpiPackageExpend LinkFill_KpiPackageExpend_By_KpiPackageItemUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiPackageExpend_By_KpiPackageItemUuid(limit);
				KpiPackageExpend ret=new KpiPackageExpend(data);
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
		/*2013031800428*/
		public KpiHead LinkFill_KpiHead_By_Uuid()
		{
			try{
				var data = Link_KpiHead_By_Uuid();
				KpiHead ret=new KpiHead(data);
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
		/*201303180429*/
		public KpiHead LinkFill_KpiHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiHead_By_Uuid(limit);
				KpiHead ret=new KpiHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
