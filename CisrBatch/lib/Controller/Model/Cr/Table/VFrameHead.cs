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
	[ISTTableView("V_FRAME_HEAD", false)]
	public partial class VFrameHead : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VFrameHead_Record _currentRecord = null;
	private IList<VFrameHead_Record> _All_Record = new List<VFrameHead_Record>();
		/*建構子*/
		public VFrameHead(){}
		public VFrameHead(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VFrameHead(IDataBaseConfigInfo dbc): base(dbc){}
		public VFrameHead(IDataBaseConfigInfo dbc,VFrameHead_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VFrameHead(IList<VFrameHead_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string CREATE_DATE {get{return "CREATE_DATE" ; }}
		public string UPDATE_DATE {get{return "UPDATE_DATE" ; }}
		public string IS_ACTIVE {get{return "IS_ACTIVE" ; }}
		public string COMPANY_UUID {get{return "COMPANY_UUID" ; }}
		public string C_NAME {get{return "C_NAME" ; }}
		public string E_NAME {get{return "E_NAME" ; }}
		public string PARENT_FRAME_HEAD_UUID {get{return "PARENT_FRAME_HEAD_UUID" ; }}
		public string ORD {get{return "ORD" ; }}
		public string REGION_UUID {get{return "REGION_UUID" ; }}
		public string FRAME_ID {get{return "FRAME_ID" ; }}
		public string FULL_FRAME_UUID_LIST {get{return "FULL_FRAME_UUID_LIST" ; }}
		public string DLEVEL {get{return "DLEVEL" ; }}
		public string ZH_NAME {get{return "ZH_NAME" ; }}
		public string FULL_FRAME_NAME_LIST {get{return "FULL_FRAME_NAME_LIST" ; }}
		public string FULL_FRAME_ID_LIST {get{return "FULL_FRAME_ID_LIST" ; }}
		public string KPI_PACKAGE_UUID {get{return "KPI_PACKAGE_UUID" ; }}
		public string HASCHILD {get{return "HASCHILD" ; }}
		public string FRAME_CATEGORY_UUID {get{return "FRAME_CATEGORY_UUID" ; }}
		public string CURRENCY {get{return "CURRENCY" ; }}
		public string FRAME_CATEGORY_NAME {get{return "FRAME_CATEGORY_NAME" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VFrameHead_Record CurrentRecord(){
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
		public VFrameHead_Record CreateNew(){
			try{
				VFrameHead_Record newData = new VFrameHead_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VFrameHead_Record> AllRecord(){
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
				_All_Record = new List<VFrameHead_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid()
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameHead_Record>)
						___table.Where(condition)
						.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<FrameCategory_Record> Link_FrameCategory_By_Uuid()
		{
			try{
				List<FrameCategory_Record> ret= new List<FrameCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameCategory ___table = new FrameCategory(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.FRAME_CATEGORY_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameCategory_Record>)
						___table.Where(condition)
						.FetchAll<FrameCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameHead_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<FrameCategory_Record> Link_FrameCategory_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameCategory_Record> ret= new List<FrameCategory_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameCategory ___table = new FrameCategory(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.FRAME_CATEGORY_UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<FrameCategory_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<FrameCategory_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public FrameHead LinkFill_FrameHead_By_Uuid()
		{
			try{
				var data = Link_FrameHead_By_Uuid();
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public FrameCategory LinkFill_FrameCategory_By_Uuid()
		{
			try{
				var data = Link_FrameCategory_By_Uuid();
				FrameCategory ret=new FrameCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public FrameHead LinkFill_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameHead_By_Uuid(limit);
				FrameHead ret=new FrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public FrameCategory LinkFill_FrameCategory_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_FrameCategory_By_Uuid(limit);
				FrameCategory ret=new FrameCategory(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
