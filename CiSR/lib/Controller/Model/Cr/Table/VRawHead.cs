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
	[ISTTableView("V_RAW_HEAD", false)]
	public partial class VRawHead : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VRawHead_Record _currentRecord = null;
	private IList<VRawHead_Record> _All_Record = new List<VRawHead_Record>();
		/*建構子*/
		public VRawHead(){}
		public VRawHead(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VRawHead(IDataBaseConfigInfo dbc): base(dbc){}
		public VRawHead(IDataBaseConfigInfo dbc,VRawHead_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VRawHead(IList<VRawHead_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string COMPANY_ID {get{return "COMPANY_ID" ; }}
		public string COMPANY_C_NAME {get{return "COMPANY_C_NAME" ; }}
		public string COMPANY_E_NAME {get{return "COMPANY_E_NAME" ; }}
		public string COMPANY_ZH_CN {get{return "COMPANY_ZH_CN" ; }}
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string RAW_ID {get{return "RAW_ID" ; }}
		public string RAW_CATEGORY_UUID {get{return "RAW_CATEGORY_UUID" ; }}
		public string C_DESC {get{return "C_DESC" ; }}
		public string E_DESC {get{return "E_DESC" ; }}
		public string C_DEFINE {get{return "C_DEFINE" ; }}
		public string E_DEFINE {get{return "E_DEFINE" ; }}
		public string UNIT {get{return "UNIT" ; }}
		public string CAN_NULL {get{return "CAN_NULL" ; }}
		public string TIME_TYPE {get{return "TIME_TYPE" ; }}
		public string NEED_DESC {get{return "NEED_DESC" ; }}
		public string NEED_FILE {get{return "NEED_FILE" ; }}
		public string VALUEDISPLAY {get{return "VALUEDISPLAY" ; }}
		public string RAW_HEAD_CATEGORY_NAME {get{return "RAW_HEAD_CATEGORY_NAME" ; }}
		public string RAW_HEAD_CATEGORY_DESCRIPTION {get{return "RAW_HEAD_CATEGORY_DESCRIPTION" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VRawHead_Record CurrentRecord(){
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
		public VRawHead_Record CreateNew(){
			try{
				VRawHead_Record newData = new VRawHead_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VRawHead_Record> AllRecord(){
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
				_All_Record = new List<VRawHead_Record>();
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
