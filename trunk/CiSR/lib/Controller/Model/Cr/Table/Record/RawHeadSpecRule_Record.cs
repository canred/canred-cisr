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
	[ISTTableView("RAW_HEAD_SPEC_RULE", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class RawHeadSpecRule_Record : RecordBase{
		public RawHeadSpecRule_Record(){}
		/*欄位資訊 Start*/
		string _RAW_HEAD_UUID=null;
		decimal? _SEQ=null;
		string _COLUMNNAME=null;
		string _PREDICATE=null;
		string _COLUMNVALUE=null;
		string _CONTROLLCOLUMNNAME=null;
		string _CONTROLLVALUE=null;
		string _MSG_TW=null;
		string _MSG_US=null;
		/*欄位資訊 End*/

		[ColumnName("RAW_HEAD_UUID",true,typeof(string))]
		public string RAW_HEAD_UUID
		{
			set
			{
				_RAW_HEAD_UUID=value;
			}
			get
			{
				return _RAW_HEAD_UUID;
			}
		}

		[ColumnName("SEQ",true,typeof(decimal?))]
		public decimal? SEQ
		{
			set
			{
				_SEQ=value;
			}
			get
			{
				return _SEQ;
			}
		}

		[ColumnName("COLUMNNAME",false,typeof(string))]
		public string COLUMNNAME
		{
			set
			{
				_COLUMNNAME=value;
			}
			get
			{
				return _COLUMNNAME;
			}
		}

		[ColumnName("PREDICATE",false,typeof(string))]
		public string PREDICATE
		{
			set
			{
				_PREDICATE=value;
			}
			get
			{
				return _PREDICATE;
			}
		}

		[ColumnName("COLUMNVALUE",false,typeof(string))]
		public string COLUMNVALUE
		{
			set
			{
				_COLUMNVALUE=value;
			}
			get
			{
				return _COLUMNVALUE;
			}
		}

		[ColumnName("CONTROLLCOLUMNNAME",false,typeof(string))]
		public string CONTROLLCOLUMNNAME
		{
			set
			{
				_CONTROLLCOLUMNNAME=value;
			}
			get
			{
				return _CONTROLLCOLUMNNAME;
			}
		}

		[ColumnName("CONTROLLVALUE",false,typeof(string))]
		public string CONTROLLVALUE
		{
			set
			{
				_CONTROLLVALUE=value;
			}
			get
			{
				return _CONTROLLVALUE;
			}
		}

		[ColumnName("MSG_TW",false,typeof(string))]
		public string MSG_TW
		{
			set
			{
				_MSG_TW=value;
			}
			get
			{
				return _MSG_TW;
			}
		}

		[ColumnName("MSG_US",false,typeof(string))]
		public string MSG_US
		{
			set
			{
				_MSG_US=value;
			}
			get
			{
				return _MSG_US;
			}
		}
		public RawHeadSpecRule_Record Clone(){
			try{
				return this.Clone<RawHeadSpecRule_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RawHeadSpecRule gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadSpecRule ret = new RawHeadSpecRule(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<RawHead_Record> Link_RawHead_By_Uuid()
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				ret=(List<RawHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_HEAD_UUID))
					.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<RawHead_Record> Link_RawHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				ret=(List<RawHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.RAW_HEAD_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*2013031800428*/
		public RawHead LinkFill_RawHead_By_Uuid()
		{
			try{
				var data = Link_RawHead_By_Uuid();
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180429*/
		public RawHead LinkFill_RawHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHead_By_Uuid(limit);
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
