using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using IST.Attribute;  
using IST.DB;  
using IST.Config.DataBase;  
using IST.DB.SQLCreater;  
using CISR.Model.Cr.Table.Record  ;  
namespace CISR.Model.Cr.Table
{
	[ISTDataBase("CISR")]
	[ISTTableView("V_KPI", false)]
	public partial class VKpi : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VKpi_Record _currentRecord = null;
	private IList<VKpi_Record> _All_Record = new List<VKpi_Record>();
		/*建構子*/
		public VKpi(){}
		public VKpi(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VKpi(IDataBaseConfigInfo dbc): base(dbc){}
		public VKpi(IDataBaseConfigInfo dbc,VKpi_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VKpi(IList<VKpi_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string KPI_HEAD_UUID {get{return "KPI_HEAD_UUID" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string KPI_ID {get{return "KPI_ID" ; }}
		public string C_DESC {get{return "C_DESC" ; }}
		public string E_DESC {get{return "E_DESC" ; }}
		public string UNIT {get{return "UNIT" ; }}
		public string DEGREE {get{return "DEGREE" ; }}
		public string C_NOTICE {get{return "C_NOTICE" ; }}
		public string SIGNAL {get{return "SIGNAL" ; }}
		public string TIME_TYPE {get{return "TIME_TYPE" ; }}
		public string C_DESC_GROUP {get{return "C_DESC_GROUP" ; }}
		public string E_DESC_GROUP {get{return "E_DESC_GROUP" ; }}
		public string INCLUDE_KPI {get{return "INCLUDE_KPI" ; }}
		public string CALCULTE_ORD {get{return "CALCULTE_ORD" ; }}
		public string NEED_SUMMARY {get{return "NEED_SUMMARY" ; }}
		public string NEED_SECURITY {get{return "NEED_SECURITY" ; }}
		public string ZH_DESC {get{return "ZH_DESC" ; }}
		public string KPI_FORMULA_UUID {get{return "KPI_FORMULA_UUID" ; }}
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string ALGORITHM {get{return "ALGORITHM" ; }}
		public string KPI_FORMULA_DESC {get{return "KPI_FORMULA_DESC" ; }}
		public string ALGORITHM_MAN {get{return "ALGORITHM_MAN" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VKpi_Record CurrentRecord(){
			try{
				if (_currentRecord == null){
					if (this._All_Record.Count > 0){
						_currentRecord = this._All_Record.First();
					}
				}
				return _currentRecord;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VKpi_Record CreateNew(){
			try{
				VKpi_Record newData = new VKpi_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VKpi_Record> AllRecord(){
			try{
				return _All_Record;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public void RemoveAllRecord(){
			try{
				_All_Record = new List<VKpi_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
