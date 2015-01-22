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
	[ISTTableView("REGION", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class Region_Record : RecordBase{
		public Region_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _REGION_NAME=null;
		string _COMPNAY_UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _REGION_DESC=null;
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

		[ColumnName("COMPNAY_UUID",false,typeof(string))]
		public string COMPNAY_UUID
		{
			set
			{
				_COMPNAY_UUID=value;
			}
			get
			{
				return _COMPNAY_UUID;
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

		[ColumnName("REGION_DESC",false,typeof(string))]
		public string REGION_DESC
		{
			set
			{
				_REGION_DESC=value;
			}
			get
			{
				return _REGION_DESC;
			}
		}
		public Region_Record Clone(){
			try{
				return this.Clone<Region_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Region gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Region ret = new Region(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<ParameterItem_Record> Link_ParameterItem_By_RegionUuid()
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				ret=(List<ParameterItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.REGION_UUID,this.UUID))
					.FetchAll<ParameterItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<ParameterItem_Record> Link_ParameterItem_By_RegionUuid(OrderLimit limit)
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				ret=(List<ParameterItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.REGION_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<ParameterItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public ParameterItem LinkFill_ParameterItem_By_RegionUuid()
		{
			try{
				var data = Link_ParameterItem_By_RegionUuid();
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public ParameterItem LinkFill_ParameterItem_By_RegionUuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterItem_By_RegionUuid(limit);
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
