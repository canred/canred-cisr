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
	[ISTTableView("KPI_FORMULA", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class KpiFormula_Record : RecordBase{
		public KpiFormula_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _KPI_HEAD_UUID=null;
		string _TIME_ID=null;
		string _ALGORITHM=null;
		string _DESCRIPTION=null;
		string _ALGORITHM_MAN=null;
		string _JSS=null;
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

		[ColumnName("ALGORITHM",false,typeof(string))]
		public string ALGORITHM
		{
			set
			{
				_ALGORITHM=value;
			}
			get
			{
				return _ALGORITHM;
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

		[ColumnName("ALGORITHM_MAN",false,typeof(string))]
		public string ALGORITHM_MAN
		{
			set
			{
				_ALGORITHM_MAN=value;
			}
			get
			{
				return _ALGORITHM_MAN;
			}
		}

		[ColumnName("JSS",false,typeof(string))]
		public string JSS
		{
			set
			{
				_JSS=value;
			}
			get
			{
				return _JSS;
			}
		}
		public KpiFormula_Record Clone(){
			try{
				return this.Clone<KpiFormula_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public KpiFormula gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormula ret = new KpiFormula(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<KpiFormulaDetail_Record> Link_KpiFormulaDetail_By_KpiFormulaUuid()
		{
			try{
				List<KpiFormulaDetail_Record> ret= new List<KpiFormulaDetail_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormulaDetail ___table = new KpiFormulaDetail(dbc);
				ret=(List<KpiFormulaDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_FORMULA_UUID,this.UUID))
					.FetchAll<KpiFormulaDetail_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<KpiFormulaDetail_Record> Link_KpiFormulaDetail_By_KpiFormulaUuid(OrderLimit limit)
		{
			try{
				List<KpiFormulaDetail_Record> ret= new List<KpiFormulaDetail_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiFormulaDetail ___table = new KpiFormulaDetail(dbc);
				ret=(List<KpiFormulaDetail_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.KPI_FORMULA_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<KpiFormulaDetail_Record>() ; 
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
		public KpiFormulaDetail LinkFill_KpiFormulaDetail_By_KpiFormulaUuid()
		{
			try{
				var data = Link_KpiFormulaDetail_By_KpiFormulaUuid();
				KpiFormulaDetail ret=new KpiFormulaDetail(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public KpiFormulaDetail LinkFill_KpiFormulaDetail_By_KpiFormulaUuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiFormulaDetail_By_KpiFormulaUuid(limit);
				KpiFormulaDetail ret=new KpiFormulaDetail(data);
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
