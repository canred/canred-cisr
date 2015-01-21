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
	[ISTTableView("V_CAL", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VCal_Record : RecordBase{
		public VCal_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _FRAME_HEAD_UUID=null;
		string _TIME_ID=null;
		string _KPI_HEAD_UUID=null;
		decimal? _ORD=null;
		string _STATUS=null;
		string _ERROR_MSG=null;
		decimal? _VALUE=null;
		string _FORMULA=null;
		string _CAL_LOG=null;
		decimal? _FRAME_LEVEL=null;
		string _C_NAME=null;
		string _FULL_FRAME_UUID_LIST=null;
		string _FULL_FRAME_NAME_LIST=null;
		string _KPI_ID=null;
		string _C_DESC=null;
		string _UNIT=null;
		string _HASCHILD=null;
		string _KPI_ALIASES=null;
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

		[ColumnName("FRAME_HEAD_UUID",false,typeof(string))]
		public string FRAME_HEAD_UUID
		{
			set
			{
				_FRAME_HEAD_UUID=value;
			}
			get
			{
				return _FRAME_HEAD_UUID;
			}
		}

		[ColumnName("TIME_ID",false,typeof(string))]
		public string TIME_ID
		{
			set
			{
				_TIME_ID=value;
			}
			get
			{
				return _TIME_ID;
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

		[ColumnName("STATUS",false,typeof(string))]
		public string STATUS
		{
			set
			{
				_STATUS=value;
			}
			get
			{
				return _STATUS;
			}
		}

		[ColumnName("ERROR_MSG",false,typeof(string))]
		public string ERROR_MSG
		{
			set
			{
				_ERROR_MSG=value;
			}
			get
			{
				return _ERROR_MSG;
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

		[ColumnName("FORMULA",false,typeof(string))]
		public string FORMULA
		{
			set
			{
				_FORMULA=value;
			}
			get
			{
				return _FORMULA;
			}
		}

		[ColumnName("CAL_LOG",false,typeof(string))]
		public string CAL_LOG
		{
			set
			{
				_CAL_LOG=value;
			}
			get
			{
				return _CAL_LOG;
			}
		}

		[ColumnName("FRAME_LEVEL",false,typeof(decimal?))]
		public decimal? FRAME_LEVEL
		{
			set
			{
				_FRAME_LEVEL=value;
			}
			get
			{
				return _FRAME_LEVEL;
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

		[ColumnName("KPI_ID",false,typeof(string))]
		public string KPI_ID
		{
			set
			{
				_KPI_ID=value;
			}
			get
			{
				return _KPI_ID;
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

		[ColumnName("KPI_ALIASES",false,typeof(string))]
		public string KPI_ALIASES
		{
			set
			{
				_KPI_ALIASES=value;
			}
			get
			{
				return _KPI_ALIASES;
			}
		}
		public VCal_Record Clone(){
			try{
				return this.Clone<VCal_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VCal gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VCal ret = new VCal(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<Cal_Record> Link_Cal_By_Uuid()
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				ret=(List<Cal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
					.FetchAll<Cal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<Cal_Record> Link_Cal_By_Uuid(OrderLimit limit)
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				ret=(List<Cal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
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
		/*2013031800428*/
		public Cal LinkFill_Cal_By_Uuid()
		{
			try{
				var data = Link_Cal_By_Uuid();
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public Cal LinkFill_Cal_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_Cal_By_Uuid(limit);
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
