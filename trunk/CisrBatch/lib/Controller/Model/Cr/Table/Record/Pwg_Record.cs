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
	[ISTTableView("PWG", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class Pwg_Record : RecordBase{
		public Pwg_Record(){}
		/*欄位資訊 Start*/
		string _GID=null;
		string _ATTENDANT_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("GID",true,typeof(string))]
		public string GID
		{
			set
			{
				_GID=value;
			}
			get
			{
				return _GID;
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
		public Pwg_Record Clone(){
			try{
				return this.Clone<Pwg_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Pwg gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Pwg ret = new Pwg(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
