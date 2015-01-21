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
	[ISTTableView("V_FRAMEITEM", false)]
	public partial class VFrameitem : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VFrameitem_Record _currentRecord = null;
	private IList<VFrameitem_Record> _All_Record = new List<VFrameitem_Record>();
		/*建構子*/
		public VFrameitem(){}
		public VFrameitem(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VFrameitem(IDataBaseConfigInfo dbc): base(dbc){}
		public VFrameitem(IDataBaseConfigInfo dbc,VFrameitem_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VFrameitem(IList<VFrameitem_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string FRAME_ITEM_IS_ACTIVE {get{return "FRAME_ITEM_IS_ACTIVE" ; }}
		public string FRAME_HEAD_UUID {get{return "FRAME_HEAD_UUID" ; }}
		public string RAW_HEAD_UUID {get{return "RAW_HEAD_UUID" ; }}
		public string FRAME_ITEM_ORD {get{return "FRAME_ITEM_ORD" ; }}
		public string PWG1_GID {get{return "PWG1_GID" ; }}
		public string PWG2_GID {get{return "PWG2_GID" ; }}
		public string PWG3_GID {get{return "PWG3_GID" ; }}
		public string PWG4_GID {get{return "PWG4_GID" ; }}
		public string PWG5_GID {get{return "PWG5_GID" ; }}
		public string PWG1_SHOW {get{return "PWG1_SHOW" ; }}
		public string PWG2_SHOW {get{return "PWG2_SHOW" ; }}
		public string PWG3_SHOW {get{return "PWG3_SHOW" ; }}
		public string PWG4_SHOW {get{return "PWG4_SHOW" ; }}
		public string PWG5_SHOW {get{return "PWG5_SHOW" ; }}
		public string RAW_ID {get{return "RAW_ID" ; }}
		public string RAW_CATEGORY_UUID {get{return "RAW_CATEGORY_UUID" ; }}
		public string C_DESC {get{return "C_DESC" ; }}
		public string E_DESC {get{return "E_DESC" ; }}
		public string UNIT {get{return "UNIT" ; }}
		public string CAN_NULL {get{return "CAN_NULL" ; }}
		public string TIME_TYPE {get{return "TIME_TYPE" ; }}
		public string NEED_DESC {get{return "NEED_DESC" ; }}
		public string NEED_FILE {get{return "NEED_FILE" ; }}
		public string VALUEDISPLAY {get{return "VALUEDISPLAY" ; }}
		public string SKIP {get{return "SKIP" ; }}
		public string SKIP_RESULT {get{return "SKIP_RESULT" ; }}
		public string LAST_FLOW {get{return "LAST_FLOW" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VFrameitem_Record CurrentRecord(){
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
		public VFrameitem_Record CreateNew(){
			try{
				VFrameitem_Record newData = new VFrameitem_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VFrameitem_Record> AllRecord(){
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
				_All_Record = new List<VFrameitem_Record>();
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
