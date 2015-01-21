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
	[ISTTableView("KPI_FORMULA_DETAIL", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class KpiFormulaDetail_Record : RecordBase{
		public KpiFormulaDetail_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _KPI_FORMULA_UUID=null;
		string _LEFT_BRACKETS=null;
		string _DATA_TYPE=null;
		string _DATA_UUID=null;
		string _OPERATION=null;
		string _LEFT_INTERVAL=null;
		string _LEFT_NO=null;
		string _RIGHT_INTERVAL=null;
		string _RIGHT_NO=null;
		string _OPERATION_CODE=null;
		string _RIGHT_BARCKETS=null;
		decimal? _ORD=null;
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

		[ColumnName("KPI_FORMULA_UUID",false,typeof(string))]
		public string KPI_FORMULA_UUID
		{
			set
			{
				_KPI_FORMULA_UUID=value;
			}
			get
			{
				return _KPI_FORMULA_UUID;
			}
		}

		[ColumnName("LEFT_BRACKETS",false,typeof(string))]
		public string LEFT_BRACKETS
		{
			set
			{
				_LEFT_BRACKETS=value;
			}
			get
			{
				return _LEFT_BRACKETS;
			}
		}

		[ColumnName("DATA_TYPE",false,typeof(string))]
		public string DATA_TYPE
		{
			set
			{
				_DATA_TYPE=value;
			}
			get
			{
				return _DATA_TYPE;
			}
		}

		[ColumnName("DATA_UUID",false,typeof(string))]
		public string DATA_UUID
		{
			set
			{
				_DATA_UUID=value;
			}
			get
			{
				return _DATA_UUID;
			}
		}

		[ColumnName("OPERATION",false,typeof(string))]
		public string OPERATION
		{
			set
			{
				_OPERATION=value;
			}
			get
			{
				return _OPERATION;
			}
		}

		[ColumnName("LEFT_INTERVAL",false,typeof(string))]
		public string LEFT_INTERVAL
		{
			set
			{
				_LEFT_INTERVAL=value;
			}
			get
			{
				return _LEFT_INTERVAL;
			}
		}

		[ColumnName("LEFT_NO",false,typeof(string))]
		public string LEFT_NO
		{
			set
			{
				_LEFT_NO=value;
			}
			get
			{
				return _LEFT_NO;
			}
		}

		[ColumnName("RIGHT_INTERVAL",false,typeof(string))]
		public string RIGHT_INTERVAL
		{
			set
			{
				_RIGHT_INTERVAL=value;
			}
			get
			{
				return _RIGHT_INTERVAL;
			}
		}

		[ColumnName("RIGHT_NO",false,typeof(string))]
		public string RIGHT_NO
		{
			set
			{
				_RIGHT_NO=value;
			}
			get
			{
				return _RIGHT_NO;
			}
		}

		[ColumnName("OPERATION_CODE",false,typeof(string))]
		public string OPERATION_CODE
		{
			set
			{
				_OPERATION_CODE=value;
			}
			get
			{
				return _OPERATION_CODE;
			}
		}

		[ColumnName("RIGHT_BARCKETS",false,typeof(string))]
		public string RIGHT_BARCKETS
		{
			set
			{
				_RIGHT_BARCKETS=value;
			}
			get
			{
				return _RIGHT_BARCKETS;
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
		public KpiFormulaDetail_Record Clone(){
			try{
				return this.Clone<KpiFormulaDetail_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public KpiFormulaDetail gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormulaDetail ret = new KpiFormulaDetail(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<KpiFormula_Record> Link_KpiFormula_By_Uuid()
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				ret=(List<KpiFormula_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_FORMULA_UUID))
					.FetchAll<KpiFormula_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<KpiFormula_Record> Link_KpiFormula_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiFormula_Record> ret= new List<KpiFormula_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ___table = new KpiFormula(dbc);
				ret=(List<KpiFormula_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_FORMULA_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<KpiFormula_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public KpiFormula LinkFill_KpiFormula_By_Uuid()
		{
			try{
				var data = Link_KpiFormula_By_Uuid();
				KpiFormula ret=new KpiFormula(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public KpiFormula LinkFill_KpiFormula_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiFormula_By_Uuid(limit);
				KpiFormula ret=new KpiFormula(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
