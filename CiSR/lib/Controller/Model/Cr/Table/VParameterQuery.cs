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
	[ISTTableView("V_PARAMETER_QUERY", false)]
	public partial class VParameterQuery : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VParameterQuery_Record _currentRecord = null;
	private IList<VParameterQuery_Record> _All_Record = new List<VParameterQuery_Record>();
		/*建構子*/
		public VParameterQuery(){}
		public VParameterQuery(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VParameterQuery(IDataBaseConfigInfo dbc): base(dbc){}
		public VParameterQuery(IDataBaseConfigInfo dbc,VParameterQuery_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VParameterQuery(IList<VParameterQuery_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string COMPANY_ID {get{return "COMPANY_ID" ; }}
		public string COMPANY_C_NAME {get{return "COMPANY_C_NAME" ; }}
		public string COMPANY_E_NAME {get{return "COMPANY_E_NAME" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string PARAMETER_UUID {get{return "PARAMETER_UUID" ; }}
		public string PARAMETER_ITEM_UUID {get{return "PARAMETER_ITEM_UUID" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string NAME {get{return "NAME" ; }}
		public string DESCRIPTION {get{return "DESCRIPTION" ; }}
		public string VALUE {get{return "VALUE" ; }}
		public string ITEM_IS_ACTIVE {get{return "ITEM_IS_ACTIVE" ; }}
		public string IS_PUBLIC {get{return "IS_PUBLIC" ; }}
		public string ITEM_DESCRIPTION {get{return "ITEM_DESCRIPTION" ; }}
		public string ITEM_VALUE {get{return "ITEM_VALUE" ; }}
		public string REGION_NAME {get{return "REGION_NAME" ; }}
		public string REGION_UUID {get{return "REGION_UUID" ; }}
		public string MONTH_ID {get{return "MONTH_ID" ; }}
		public string MONTH_VALUE {get{return "MONTH_VALUE" ; }}
		public string PARAMETER_MONTH_UUID {get{return "PARAMETER_MONTH_UUID" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VParameterQuery_Record CurrentRecord(){
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
		public VParameterQuery_Record CreateNew(){
			try{
				VParameterQuery_Record newData = new VParameterQuery_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VParameterQuery_Record> AllRecord(){
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
				_All_Record = new List<VParameterQuery_Record>();
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
