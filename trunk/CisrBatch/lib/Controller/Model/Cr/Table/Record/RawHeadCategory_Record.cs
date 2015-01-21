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
	[ISTTableView("RAW_HEAD_CATEGORY", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class RawHeadCategory_Record : RecordBase{
		public RawHeadCategory_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _NAME=null;
		string _DESCRIPTION=null;
		decimal? _LAN_NO=null;
		string _COMPANY_UUID=null;
		/*欄位資訊 End*/

		[ColumnName("UUID",true,typeof(string))]
		public string UUID
		{
			set
			{
				_UUID=value;
			}
			get
			{
				return _UUID;
			}
		}

		[ColumnName("NAME",false,typeof(string))]
		public string NAME
		{
			set
			{
				_NAME=value;
			}
			get
			{
				return _NAME;
			}
		}

		[ColumnName("DESCRIPTION",false,typeof(string))]
		public string DESCRIPTION
		{
			set
			{
				_DESCRIPTION=value;
			}
			get
			{
				return _DESCRIPTION;
			}
		}

		[ColumnName("LAN_NO",false,typeof(decimal?))]
		public decimal? LAN_NO
		{
			set
			{
				_LAN_NO=value;
			}
			get
			{
				return _LAN_NO;
			}
		}

		[ColumnName("COMPANY_UUID",false,typeof(string))]
		public string COMPANY_UUID
		{
			set
			{
				_COMPANY_UUID=value;
			}
			get
			{
				return _COMPANY_UUID;
			}
		}
		public RawHeadCategory_Record Clone(){
			try{
				return this.Clone<RawHeadCategory_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RawHeadCategory gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHeadCategory ret = new RawHeadCategory(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<RawHead_Record> Link_RawHead_By_RawCategoryUuid()
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				ret=(List<RawHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_CATEGORY_UUID,this.UUID))
					.FetchAll<RawHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<RawHead_Record> Link_RawHead_By_RawCategoryUuid(OrderLimit limit)
		{
			try{
				List<RawHead_Record> ret= new List<RawHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RawHead ___table = new RawHead(dbc);
				ret=(List<RawHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.RAW_CATEGORY_UUID,this.UUID))
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
		/*201303180357*/
		public RawHead LinkFill_RawHead_By_RawCategoryUuid()
		{
			try{
				var data = Link_RawHead_By_RawCategoryUuid();
				RawHead ret=new RawHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public RawHead LinkFill_RawHead_By_RawCategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_RawHead_By_RawCategoryUuid(limit);
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
