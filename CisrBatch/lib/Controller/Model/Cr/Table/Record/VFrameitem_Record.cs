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
	[ISTTableView("V_FRAMEITEM", false)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class VFrameitem_Record : RecordBase{
		public VFrameitem_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _FRAME_ITEM_IS_ACTIVE=null;
		string _FRAME_HEAD_UUID=null;
		string _RAW_HEAD_UUID=null;
		decimal? _FRAME_ITEM_ORD=null;
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
		string _RAW_ID=null;
		string _RAW_CATEGORY_UUID=null;
		string _C_DESC=null;
		string _E_DESC=null;
		string _UNIT=null;
		string _CAN_NULL=null;
		string _TIME_TYPE=null;
		string _NEED_DESC=null;
		string _NEED_FILE=null;
		string _VALUEDISPLAY=null;
		string _SKIP=null;
		string _SKIP_RESULT=null;
		decimal? _LAST_FLOW=null;
		/*欄位資訊 End*/

		[ColumnName("UUID",false,typeof(string))]
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

		[ColumnName("FRAME_ITEM_IS_ACTIVE",false,typeof(string))]
		public string FRAME_ITEM_IS_ACTIVE
		{
			set
			{
				_FRAME_ITEM_IS_ACTIVE=value;
			}
			get
			{
				return _FRAME_ITEM_IS_ACTIVE;
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

		[ColumnName("FRAME_ITEM_ORD",false,typeof(decimal?))]
		public decimal? FRAME_ITEM_ORD
		{
			set
			{
				_FRAME_ITEM_ORD=value;
			}
			get
			{
				return _FRAME_ITEM_ORD;
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

		[ColumnName("RAW_ID",false,typeof(string))]
		public string RAW_ID
		{
			set
			{
				_RAW_ID=value;
			}
			get
			{
				return _RAW_ID;
			}
		}

		[ColumnName("RAW_CATEGORY_UUID",false,typeof(string))]
		public string RAW_CATEGORY_UUID
		{
			set
			{
				_RAW_CATEGORY_UUID=value;
			}
			get
			{
				return _RAW_CATEGORY_UUID;
			}
		}

		[ColumnName("C_DESC",false,typeof(string))]
		public string C_DESC
		{
			set
			{
				_C_DESC=value;
			}
			get
			{
				return _C_DESC;
			}
		}

		[ColumnName("E_DESC",false,typeof(string))]
		public string E_DESC
		{
			set
			{
				_E_DESC=value;
			}
			get
			{
				return _E_DESC;
			}
		}

		[ColumnName("UNIT",false,typeof(string))]
		public string UNIT
		{
			set
			{
				_UNIT=value;
			}
			get
			{
				return _UNIT;
			}
		}

		[ColumnName("CAN_NULL",false,typeof(string))]
		public string CAN_NULL
		{
			set
			{
				_CAN_NULL=value;
			}
			get
			{
				return _CAN_NULL;
			}
		}

		[ColumnName("TIME_TYPE",false,typeof(string))]
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

		[ColumnName("NEED_DESC",false,typeof(string))]
		public string NEED_DESC
		{
			set
			{
				_NEED_DESC=value;
			}
			get
			{
				return _NEED_DESC;
			}
		}

		[ColumnName("NEED_FILE",false,typeof(string))]
		public string NEED_FILE
		{
			set
			{
				_NEED_FILE=value;
			}
			get
			{
				return _NEED_FILE;
			}
		}

		[ColumnName("VALUEDISPLAY",false,typeof(string))]
		public string VALUEDISPLAY
		{
			set
			{
				_VALUEDISPLAY=value;
			}
			get
			{
				return _VALUEDISPLAY;
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
		public VFrameitem_Record Clone(){
			try{
				return this.Clone<VFrameitem_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public VFrameitem gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameitem ret = new VFrameitem(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
