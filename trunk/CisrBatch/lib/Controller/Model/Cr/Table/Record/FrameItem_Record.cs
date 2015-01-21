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
	[ISTTableView("FRAME_ITEM", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class FrameItem_Record : RecordBase{
		public FrameItem_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _FRAME_HEAD_UUID=null;
		string _RAW_HEAD_UUID=null;
		decimal? _ORD=null;
		string _PWG1_GID=null;
		string _PWG2_GID=null;
		string _PWG3_GID=null;
		string _PWG4_GID=null;
		string _PWG5_GID=null;
		string _PWG1_SHOW=null;
		string _PWG2_SHOW=null;
		string _PWG3_SHOW=null;
		string _PWG4_SHOW=null;
		string _PWG5_SHOW=null;
		string _SKIP=null;
		string _SKIP_RESULT=null;
		decimal? _LAST_FLOW=null;
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

		[ColumnName("CREATE_DATE",false,typeof(DateTime?))]
		public DateTime? CREATE_DATE
		{
			set
			{
				_CREATE_DATE=value;
			}
			get
			{
				return _CREATE_DATE;
			}
		}

		[ColumnName("UPDATE_DATE",false,typeof(DateTime?))]
		public DateTime? UPDATE_DATE
		{
			set
			{
				_UPDATE_DATE=value;
			}
			get
			{
				return _UPDATE_DATE;
			}
		}

		[ColumnName("IS_ACTIVE",false,typeof(string))]
		public string IS_ACTIVE
		{
			set
			{
				_IS_ACTIVE=value;
			}
			get
			{
				return _IS_ACTIVE;
			}
		}

		[ColumnName("FRAME_HEAD_UUID",false,typeof(string))]
		public string FRAME_HEAD_UUID
		{
			set
			{
				_FRAME_HEAD_UUID=value;
			}
			get
			{
				return _FRAME_HEAD_UUID;
			}
		}

		[ColumnName("RAW_HEAD_UUID",false,typeof(string))]
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

		[ColumnName("ORD",false,typeof(decimal?))]
		public decimal? ORD
		{
			set
			{
				_ORD=value;
			}
			get
			{
				return _ORD;
			}
		}

		[ColumnName("PWG1_GID",false,typeof(string))]
		public string PWG1_GID
		{
			set
			{
				_PWG1_GID=value;
			}
			get
			{
				return _PWG1_GID;
			}
		}

		[ColumnName("PWG2_GID",false,typeof(string))]
		public string PWG2_GID
		{
			set
			{
				_PWG2_GID=value;
			}
			get
			{
				return _PWG2_GID;
			}
		}

		[ColumnName("PWG3_GID",false,typeof(string))]
		public string PWG3_GID
		{
			set
			{
				_PWG3_GID=value;
			}
			get
			{
				return _PWG3_GID;
			}
		}

		[ColumnName("PWG4_GID",false,typeof(string))]
		public string PWG4_GID
		{
			set
			{
				_PWG4_GID=value;
			}
			get
			{
				return _PWG4_GID;
			}
		}

		[ColumnName("PWG5_GID",false,typeof(string))]
		public string PWG5_GID
		{
			set
			{
				_PWG5_GID=value;
			}
			get
			{
				return _PWG5_GID;
			}
		}

		[ColumnName("PWG1_SHOW",false,typeof(string))]
		public string PWG1_SHOW
		{
			set
			{
				_PWG1_SHOW=value;
			}
			get
			{
				return _PWG1_SHOW;
			}
		}

		[ColumnName("PWG2_SHOW",false,typeof(string))]
		public string PWG2_SHOW
		{
			set
			{
				_PWG2_SHOW=value;
			}
			get
			{
				return _PWG2_SHOW;
			}
		}

		[ColumnName("PWG3_SHOW",false,typeof(string))]
		public string PWG3_SHOW
		{
			set
			{
				_PWG3_SHOW=value;
			}
			get
			{
				return _PWG3_SHOW;
			}
		}

		[ColumnName("PWG4_SHOW",false,typeof(string))]
		public string PWG4_SHOW
		{
			set
			{
				_PWG4_SHOW=value;
			}
			get
			{
				return _PWG4_SHOW;
			}
		}

		[ColumnName("PWG5_SHOW",false,typeof(string))]
		public string PWG5_SHOW
		{
			set
			{
				_PWG5_SHOW=value;
			}
			get
			{
				return _PWG5_SHOW;
			}
		}

		[ColumnName("SKIP",false,typeof(string))]
		public string SKIP
		{
			set
			{
				_SKIP=value;
			}
			get
			{
				return _SKIP;
			}
		}

		[ColumnName("SKIP_RESULT",false,typeof(string))]
		public string SKIP_RESULT
		{
			set
			{
				_SKIP_RESULT=value;
			}
			get
			{
				return _SKIP_RESULT;
			}
		}

		[ColumnName("LAST_FLOW",false,typeof(decimal?))]
		public decimal? LAST_FLOW
		{
			set
			{
				_LAST_FLOW=value;
			}
			get
			{
				return _LAST_FLOW;
			}
		}
		public FrameItem_Record Clone(){
			try{
				return this.Clone<FrameItem_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public FrameItem gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameItem ret = new FrameItem(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public List<FrameHead_Record> Link_FrameHead_By_Uuid()
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.FRAME_HEAD_UUID))
					.FetchAll<FrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180404*/
		public List<FrameHead_Record> Link_FrameHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<FrameHead_Record> ret= new List<FrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameHead ___table = new FrameHead(dbc);
				ret=(List<FrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.FRAME_HEAD_UUID))
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
		/*2013031800428*/
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
		/*201303180429*/
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
	}
}
