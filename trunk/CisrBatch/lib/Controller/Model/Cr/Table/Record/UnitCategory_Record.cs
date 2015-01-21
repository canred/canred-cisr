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
	[ISTTableView("UNIT_CATEGORY", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class UnitCategory_Record : RecordBase{
		public UnitCategory_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _COMPANY_UUID=null;
		string _NAME=null;
		string _DESCRIPTION=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_PUBLIC=null;
		string _IS_ACTIVE=null;
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

		[ColumnName("IS_PUBLIC",false,typeof(string))]
		public string IS_PUBLIC
		{
			set
			{
				_IS_PUBLIC=value;
			}
			get
			{
				return _IS_PUBLIC;
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
		public UnitCategory_Record Clone(){
			try{
				return this.Clone<UnitCategory_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public UnitCategory gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				UnitCategory ret = new UnitCategory(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<Unit_Record> Link_Unit_By_UnitCategoryUuid()
		{
			try{
				List<Unit_Record> ret= new List<Unit_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Unit ___table = new Unit(dbc);
				ret=(List<Unit_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UNIT_CATEGORY_UUID,this.UUID))
					.FetchAll<Unit_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<Unit_Record> Link_Unit_By_UnitCategoryUuid(OrderLimit limit)
		{
			try{
				List<Unit_Record> ret= new List<Unit_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Unit ___table = new Unit(dbc);
				ret=(List<Unit_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UNIT_CATEGORY_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<Unit_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public Unit LinkFill_Unit_By_UnitCategoryUuid()
		{
			try{
				var data = Link_Unit_By_UnitCategoryUuid();
				Unit ret=new Unit(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public Unit LinkFill_Unit_By_UnitCategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_Unit_By_UnitCategoryUuid(limit);
				Unit ret=new Unit(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
