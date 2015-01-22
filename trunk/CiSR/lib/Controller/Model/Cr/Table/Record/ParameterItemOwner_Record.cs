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
	[ISTTableView("PARAMETER_ITEM_OWNER", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class ParameterItemOwner_Record : RecordBase{
		public ParameterItemOwner_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _IS_ACTIVE=null;
		DateTime? _UPDATE_DATE=null;
		DateTime? _CREATE_DATE=null;
		string _PARAMETER_ITEM_UUID=null;
		string _ATTENDANT_UUID=null;
		string _CREATE_USER=null;
		string _UPDATE_USER=null;
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

		[ColumnName("CREATE_USER",false,typeof(string))]
		public string CREATE_USER
		{
			set
			{
				_CREATE_USER=value;
			}
			get
			{
				return _CREATE_USER;
			}
		}

		[ColumnName("UPDATE_USER",false,typeof(string))]
		public string UPDATE_USER
		{
			set
			{
				_UPDATE_USER=value;
			}
			get
			{
				return _UPDATE_USER;
			}
		}
		public ParameterItemOwner_Record Clone(){
			try{
				return this.Clone<ParameterItemOwner_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public ParameterItemOwner gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItemOwner ret = new ParameterItemOwner(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<ParameterItem_Record> Link_ParameterItem_By_Uuid()
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				ret=(List<ParameterItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.PARAMETER_ITEM_UUID))
					.FetchAll<ParameterItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<ParameterItem_Record> Link_ParameterItem_By_Uuid(OrderLimit limit)
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				ret=(List<ParameterItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.PARAMETER_ITEM_UUID))
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
		/*2013031800428*/
		public ParameterItem LinkFill_ParameterItem_By_Uuid()
		{
			try{
				var data = Link_ParameterItem_By_Uuid();
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public ParameterItem LinkFill_ParameterItem_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterItem_By_Uuid(limit);
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
