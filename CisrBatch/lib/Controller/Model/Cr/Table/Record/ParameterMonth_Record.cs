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
	[ISTTableView("PARAMETER_MONTH", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class ParameterMonth_Record : RecordBase{
		public ParameterMonth_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _PARAMETER_ITEM_UUID=null;
		string _MONTH_ID=null;
		string _DESCRIPTION=null;
		decimal? _VALUE=null;
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

		[ColumnName("MONTH_ID",false,typeof(string))]
		public string MONTH_ID
		{
			set
			{
				_MONTH_ID=value;
			}
			get
			{
				return _MONTH_ID;
			}
		}

		[ColumnName("DESCRIPTION",false,typeof(string))]
		public string DESCRIPTION
		{
			set
			{
				_DESCRIPTION=value;
			}
			get
			{
				return _DESCRIPTION;
			}
		}

		[ColumnName("VALUE",false,typeof(decimal?))]
		public decimal? VALUE
		{
			set
			{
				_VALUE=value;
			}
			get
			{
				return _VALUE;
			}
		}
		public ParameterMonth_Record Clone(){
			try{
				return this.Clone<ParameterMonth_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public ParameterMonth gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterMonth ret = new ParameterMonth(dbc,this);
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
