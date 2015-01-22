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
	[ISTTableView("V_UPLOAD_JOB", false)]
	public partial class VUploadJob : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VUploadJob_Record _currentRecord = null;
	private IList<VUploadJob_Record> _All_Record = new List<VUploadJob_Record>();
		/*建構子*/
		public VUploadJob(){}
		public VUploadJob(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VUploadJob(IDataBaseConfigInfo dbc): base(dbc){}
		public VUploadJob(IDataBaseConfigInfo dbc,VUploadJob_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VUploadJob(IList<VUploadJob_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string FRAME_HEAD_UUID {get{return "FRAME_HEAD_UUID" ; }}
		public string RAW_HEAD_UUID {get{return "RAW_HEAD_UUID" ; }}
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string FILES_GROUP_ID {get{return "FILES_GROUP_ID" ; }}
		public string VALUE {get{return "VALUE" ; }}
		public string EXPLAIN {get{return "EXPLAIN" ; }}
		public string DWG1_GID {get{return "DWG1_GID" ; }}
		public string DWG2_GID {get{return "DWG2_GID" ; }}
		public string DWG3_GID {get{return "DWG3_GID" ; }}
		public string DWG4_GID {get{return "DWG4_GID" ; }}
		public string DWG5_GID {get{return "DWG5_GID" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string STATUS {get{return "STATUS" ; }}
		public string SKIP {get{return "SKIP" ; }}
		public string SKIP_RESULT {get{return "SKIP_RESULT" ; }}
		public string DWG1_SHOW {get{return "DWG1_SHOW" ; }}
		public string DWG2_SHOW {get{return "DWG2_SHOW" ; }}
		public string DWG3_SHOW {get{return "DWG3_SHOW" ; }}
		public string DWG4_SHOW {get{return "DWG4_SHOW" ; }}
		public string DWG5_SHOW {get{return "DWG5_SHOW" ; }}
		public string FINISH {get{return "FINISH" ; }}
		public string FULL_ATTENDANT_UUID {get{return "FULL_ATTENDANT_UUID" ; }}
		public string FILES_COUNT {get{return "FILES_COUNT" ; }}
		public string NOW_ATTENDANT_UUID {get{return "NOW_ATTENDANT_UUID" ; }}
		public string LAST_ATTENDANT_UUID {get{return "LAST_ATTENDANT_UUID" ; }}
		public string FRAME_HEAD_IS_ACTIVE {get{return "FRAME_HEAD_IS_ACTIVE" ; }}
		public string REGION_UUID {get{return "REGION_UUID" ; }}
		public string REGION_NAME {get{return "REGION_NAME" ; }}
		public string DLEVEL {get{return "DLEVEL" ; }}
		public string FULL_FRAME_NAME_LIST {get{return "FULL_FRAME_NAME_LIST" ; }}
		public string FULL_FRAME_UUID_LIST {get{return "FULL_FRAME_UUID_LIST" ; }}
		public string FULL_FRAME_ID_LIST {get{return "FULL_FRAME_ID_LIST" ; }}
		public string RAW_ID {get{return "RAW_ID" ; }}
		public string RAW_C_DESC {get{return "RAW_C_DESC" ; }}
		public string RAW_E_DESC {get{return "RAW_E_DESC" ; }}
		public string RAW_UNIT {get{return "RAW_UNIT" ; }}
		public string RAW_CAN_NULL {get{return "RAW_CAN_NULL" ; }}
		public string RAW_TIME_TYPE {get{return "RAW_TIME_TYPE" ; }}
		public string RAW_NEED_DESC {get{return "RAW_NEED_DESC" ; }}
		public string RAW_NEED_FILS {get{return "RAW_NEED_FILS" ; }}
		public string RAW_VALUEDISPLAY {get{return "RAW_VALUEDISPLAY" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VUploadJob_Record CurrentRecord(){
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
		public VUploadJob_Record CreateNew(){
			try{
				VUploadJob_Record newData = new VUploadJob_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VUploadJob_Record> AllRecord(){
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
				_All_Record = new List<VUploadJob_Record>();
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
