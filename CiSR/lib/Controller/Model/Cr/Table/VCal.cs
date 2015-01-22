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
	[ISTTableView("V_CAL", false)]
	public partial class VCal : TableBase{
	/*固定物件*/
	//IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
	/*固定物件但名稱需更新*/
	private VCal_Record _currentRecord = null;
	private IList<VCal_Record> _All_Record = new List<VCal_Record>();
		/*建構子*/
		public VCal(){}
		public VCal(IDataBaseConfigInfo dbc,string db): base(dbc,db){}
		public VCal(IDataBaseConfigInfo dbc): base(dbc){}
		public VCal(IDataBaseConfigInfo dbc,VCal_Record currenData){
			this.setDataBaseConfigInfo(dbc);
			this._currentRecord = currenData;
		}
		public VCal(IList<VCal_Record> currenData){
			this._All_Record = currenData;
		}
		/*欄位資訊 Start*/
		public string UUID {get{return "UUID" ; }}
		public string FRAME_HEAD_UUID {get{return "FRAME_HEAD_UUID" ; }}
		public string TIME_ID {get{return "TIME_ID" ; }}
		public string KPI_HEAD_UUID {get{return "KPI_HEAD_UUID" ; }}
		public string ORD {get{return "ORD" ; }}
		public string STATUS {get{return "STATUS" ; }}
		public string ERROR_MSG {get{return "ERROR_MSG" ; }}
		public string VALUE {get{return "VALUE" ; }}
		public string FORMULA {get{return "FORMULA" ; }}
		public string CAL_LOG {get{return "CAL_LOG" ; }}
		public string FRAME_LEVEL {get{return "FRAME_LEVEL" ; }}
		public string C_NAME {get{return "C_NAME" ; }}
		public string FULL_FRAME_UUID_LIST {get{return "FULL_FRAME_UUID_LIST" ; }}
		public string FULL_FRAME_NAME_LIST {get{return "FULL_FRAME_NAME_LIST" ; }}
		public string KPI_ID {get{return "KPI_ID" ; }}
		public string C_DESC {get{return "C_DESC" ; }}
		public string UNIT {get{return "UNIT" ; }}
		public string HASCHILD {get{return "HASCHILD" ; }}
		public string KPI_ALIASES {get{return "KPI_ALIASES" ; }}
		/*欄位資訊 End*/
		/*固定的方法，但名稱需變更 Start*/
		public VCal_Record CurrentRecord(){
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
		public VCal_Record CreateNew(){
			try{
				VCal_Record newData = new VCal_Record();
				return newData;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public IList<VCal_Record> AllRecord(){
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
				_All_Record = new List<VCal_Record>();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*固定的方法，但名稱需變更 End*/
		/*有關PK的方法*/
		//TEMPLATE TABLE 201303180156
		public VCal Fill_By_PK(string pUUID){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>()  ;  
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
		public VCal Fill_By_PK(string pUUID,DB db){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>(db)  ;  
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
		public VCal_Record Fetch_By_PK(string pUUID){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319044
		public VCal_Record Fetch_By_PK(string pUUID,DB db){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		//TEMPLATE TABLE 20130319045
		public VCal Fill_By_Uuid(string pUUID){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>()  ;  
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
		public VCal Fill_By_Uuid(string pUUID,DB db){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>(db)  ;  
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
		public VCal_Record Fetch_By_Uuid(string pUUID){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>()  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.ErrorNoThrowException(this, ex);
				return null;
			}
		}
		//TEMPLATE TABLE 20130319048
		public VCal_Record Fetch_By_Uuid(string pUUID,DB db){
			try{
				IList<VCal_Record> ret = null;
				ret = this.Where(
				new SQLCondition(this)
									.Equal(this.UUID,pUUID)
				).FetchAll<VCal_Record>(db)  ;  
				return ret.First();
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*依照資料表與資料表的關係，產生出來的方法*/
		public List<Cal_Record> Link_Cal_By_Uuid()
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Cal_Record>)
						___table.Where(condition)
						.FetchAll<Cal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180340*/
		public List<Cal_Record> Link_Cal_By_Uuid(OrderLimit limit)
		{
			try{
				List<Cal_Record> ret= new List<Cal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ___table = new Cal(dbc);
				SQLCondition condition = new SQLCondition(___table) ;
				foreach(var item in AllRecord()){
						condition
						.L().Equal(___table.UUID,item.UUID).R().Or()  ; 
 				}
				condition.CheckSQL();
				ret=(List<Cal_Record>)
						___table.Where(condition)
						.Order(limit)
						.Limit(limit)
						.FetchAll<Cal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180336*/
		public Cal LinkFill_Cal_By_Uuid()
		{
			try{
				var data = Link_Cal_By_Uuid();
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180337*/
		public Cal LinkFill_Cal_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_Cal_By_Uuid(limit);
				Cal ret=new Cal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
