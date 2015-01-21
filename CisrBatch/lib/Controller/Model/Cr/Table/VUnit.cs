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
	[ISTTableView("V_UNIT", false)]
	public partial class VUnit : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VUnit_Record _currentRecord = null;
	private IList<VUnit_Record> _All_Record = new List<VUnit_Record>();
		/*建構子*/
		public VUnit(){}
		public VUnit(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VUnit(IDataBaseConfigInfo dbc): base(dbc){}
		public VUnit(IDataBaseConfigInfo dbc,VUnit_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VUnit(IList<VUnit_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UNIT_CATEGORY_UUID {get{return "UNIT_CATEGORY_UUID" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string UNIT_CATEGORY_NAME {get{return "UNIT_CATEGORY_NAME" ; }}
		public string UNIT_CATEGORY_DESCRIPTION {get{return "UNIT_CATEGORY_DESCRIPTION" ; }}
		public string UNIT_CATEGORY_IS_PUBLIC {get{return "UNIT_CATEGORY_IS_PUBLIC" ; }}
		public string UNIT_CATEGORY_IS_ACTIVE {get{return "UNIT_CATEGORY_IS_ACTIVE" ; }}
		public string UNIT_UUID {get{return "UNIT_UUID" ; }}
		public string UNIT_NAME {get{return "UNIT_NAME" ; }}
		public string UNIT_C_DESC {get{return "UNIT_C_DESC" ; }}
		public string UNIT_IS_ACTIVE {get{return "UNIT_IS_ACTIVE" ; }}
		public string UNIT_E_DESC {get{return "UNIT_E_DESC" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VUnit_Record CurrentRecord(){
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
		public VUnit_Record CreateNew(){
			try{
				VUnit_Record newData = new VUnit_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VUnit_Record> AllRecord(){
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
				_All_Record = new List<VUnit_Record>();
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
