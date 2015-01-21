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
	[ISTTableView("UNIT", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class Unit_Record : RecordBase{
		public Unit_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _UNIT_NAME=null;
		string _UNIT_C_DESC=null;
		string _IS_ACTIVE=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _UNIT_CATEGORY_UUID=null;
		string _UNIT_E_DESC=null;
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

		[ColumnName("UNIT_NAME",false,typeof(string))]
		public string UNIT_NAME
		{
			set
			{
				_UNIT_NAME=value;
			}
			get
			{
				return _UNIT_NAME;
			}
		}

		[ColumnName("UNIT_C_DESC",false,typeof(string))]
		public string UNIT_C_DESC
		{
			set
			{
				_UNIT_C_DESC=value;
			}
			get
			{
				return _UNIT_C_DESC;
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

		[ColumnName("UNIT_CATEGORY_UUID",false,typeof(string))]
		public string UNIT_CATEGORY_UUID
		{
			set
			{
				_UNIT_CATEGORY_UUID=value;
			}
			get
			{
				return _UNIT_CATEGORY_UUID;
			}
		}

		[ColumnName("UNIT_E_DESC",false,typeof(string))]
		public string UNIT_E_DESC
		{
			set
			{
				_UNIT_E_DESC=value;
			}
			get
			{
				return _UNIT_E_DESC;
			}
		}
		public Unit_Record Clone(){
			try{
				return this.Clone<Unit_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Unit gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Unit ret = new Unit(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<UnitCategory_Record> Link_UnitCategory_By_Uuid()
		{
			try{
				List<UnitCategory_Record> ret= new List<UnitCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UnitCategory ___table = new UnitCategory(dbc);
				ret=(List<UnitCategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UNIT_CATEGORY_UUID))
					.FetchAll<UnitCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<UnitCategory_Record> Link_UnitCategory_By_Uuid(OrderLimit limit)
		{
			try{
				List<UnitCategory_Record> ret= new List<UnitCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UnitCategory ___table = new UnitCategory(dbc);
				ret=(List<UnitCategory_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UNIT_CATEGORY_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<UnitCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public UnitCategory LinkFill_UnitCategory_By_Uuid()
		{
			try{
				var data = Link_UnitCategory_By_Uuid();
				UnitCategory ret=new UnitCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public UnitCategory LinkFill_UnitCategory_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_UnitCategory_By_Uuid(limit);
				UnitCategory ret=new UnitCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
