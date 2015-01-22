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
	[ISTTableView("V_PWG", false)]
	public partial class VPwg : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VPwg_Record _currentRecord = null;
	private IList<VPwg_Record> _All_Record = new List<VPwg_Record>();
		/*建構子*/
		public VPwg(){}
		public VPwg(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VPwg(IDataBaseConfigInfo dbc): base(dbc){}
		public VPwg(IDataBaseConfigInfo dbc,VPwg_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VPwg(IList<VPwg_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string PWG_GID {get{return "PWG_GID" ; }}
		public string ATTENDANT_UUID {get{return "ATTENDANT_UUID" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string ACCOUNT {get{return "ACCOUNT" ; }}
		public string C_NAME {get{return "C_NAME" ; }}
		public string E_NAME {get{return "E_NAME" ; }}
		public string EMAIL {get{return "EMAIL" ; }}
		public string IS_SUPPER {get{return "IS_SUPPER" ; }}
		public string IS_ADMIN {get{return "IS_ADMIN" ; }}
		public string CODE_PAGE {get{return "CODE_PAGE" ; }}
		public string DEPARTMENT_UUID {get{return "DEPARTMENT_UUID" ; }}
		public string PHONE {get{return "PHONE" ; }}
		public string SITE_UUID {get{return "SITE_UUID" ; }}
		public string GENDER {get{return "GENDER" ; }}
		public string BIRTHDAY {get{return "BIRTHDAY" ; }}
		public string HIRE_DATE {get{return "HIRE_DATE" ; }}
		public string QUIT_DATE {get{return "QUIT_DATE" ; }}
		public string IS_DIRECT {get{return "IS_DIRECT" ; }}
		public string GRADE {get{return "GRADE" ; }}
		public string IS_DEFAULT_PASS {get{return "IS_DEFAULT_PASS" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VPwg_Record CurrentRecord(){
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
		public VPwg_Record CreateNew(){
			try{
				VPwg_Record newData = new VPwg_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VPwg_Record> AllRecord(){
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
				_All_Record = new List<VPwg_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VPwg Fill_By_PK(string pPWG_GID){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>()  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 201303180156
		public VPwg Fill_By_PK(string pPWG_GID,DB db){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>(db)  ;  
				_All_Record = ret;
				if (_All_Record.Count > 0){
					_currentRecord = ret.First();}
				else{
					_currentRecord = null;}
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319042
		public VPwg_Record Fetch_By_PK(string pPWG_GID){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VPwg_Record Fetch_By_PK(string pPWG_GID,DB db){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VPwg Fill_By_PwgGid(string pPWG_GID){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>()  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319046
		public VPwg Fill_By_PwgGid(string pPWG_GID,DB db){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>(db)  ;  
				_All_Record = ret;
				_currentRecord = ret.First();
				return this;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319047
		public VPwg_Record Fetch_By_PwgGid(string pPWG_GID){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VPwg_Record Fetch_By_PwgGid(string pPWG_GID,DB db){
			try{
				IList<VPwg_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.PWG_GID,pPWG_GID)
				).FetchAll<VPwg_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
	}
}
