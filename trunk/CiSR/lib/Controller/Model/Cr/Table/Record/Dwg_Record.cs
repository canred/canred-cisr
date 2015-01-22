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
	[ISTTableView("DWG", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class Dwg_Record : RecordBase{
		public Dwg_Record(){}
		/*欄位資訊 Start*/
		string _DWG_GID=null;
		string _ATTENDANT_UUID=null;
		string _IS_FINISH=null;
		/*欄位資訊 End*/

		[ColumnName("DWG_GID",true,typeof(string))]
		public string DWG_GID
		{
			set
			{
				_DWG_GID=value;
			}
			get
			{
				return _DWG_GID;
			}
		}

		[ColumnName("ATTENDANT_UUID",true,typeof(string))]
		public string ATTENDANT_UUID
		{
			set
			{
				_ATTENDANT_UUID=value;
			}
			get
			{
				return _ATTENDANT_UUID;
			}
		}

		[ColumnName("IS_FINISH",false,typeof(string))]
		public string IS_FINISH
		{
			set
			{
				_IS_FINISH=value;
			}
			get
			{
				return _IS_FINISH;
			}
		}
		public Dwg_Record Clone(){
			try{
				return this.Clone<Dwg_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Dwg gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Dwg ret = new Dwg(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
