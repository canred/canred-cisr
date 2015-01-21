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
	[ISTTableView("TIME", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class Time_Record : RecordBase{
		public Time_Record(){}
		/*欄位資訊 Start*/
		string _TIME_ID=null;
		string _TIME_TYPE=null;
		/*欄位資訊 End*/

		[ColumnName("TIME_ID",true,typeof(string))]
		public string TIME_ID
		{
			set
			{
				_TIME_ID=value;
			}
			get
			{
				return _TIME_ID;
			}
		}

		[ColumnName("TIME_TYPE",true,typeof(string))]
		public string TIME_TYPE
		{
			set
			{
				_TIME_TYPE=value;
			}
			get
			{
				return _TIME_TYPE;
			}
		}
		public Time_Record Clone(){
			try{
				return this.Clone<Time_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Time gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Time ret = new Time(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
