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
	[ISTTableView("VIEW_HOME", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class ViewHome_Record : RecordBase{
		public ViewHome_Record(){}
		/*欄位資訊 Start*/
		string _TIME_ID=null;
		string _KPI_HEAD_UUID=null;
		string _FRAME_HEAD_UUID=null;
		decimal? _MEASURE=null;
		string _COLOR=null;
		decimal? _LAST_MEASURE=null;
		string _LAST_COLOR=null;
		decimal? _TARGET_MEASURE=null;
		string _TARGET_COLOR=null;
		DateTime? _CREATE_DATE=null;
		string _IS_ACTIVE=null;
		string _LAST_TIME_ID=null;
		string _VISION_SHARE_RULE_UUID=null;
		string _IS_INSTRUCTION=null;
		string _IS_EXPLAIN=null;
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

		[ColumnName("KPI_HEAD_UUID",true,typeof(string))]
		public string KPI_HEAD_UUID
		{
			set
			{
				_KPI_HEAD_UUID=value;
			}
			get
			{
				return _KPI_HEAD_UUID;
			}
		}

		[ColumnName("FRAME_HEAD_UUID",true,typeof(string))]
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

		[ColumnName("MEASURE",false,typeof(decimal?))]
		public decimal? MEASURE
		{
			set
			{
				_MEASURE=value;
			}
			get
			{
				return _MEASURE;
			}
		}

		[ColumnName("COLOR",false,typeof(string))]
		public string COLOR
		{
			set
			{
				_COLOR=value;
			}
			get
			{
				return _COLOR;
			}
		}

		[ColumnName("LAST_MEASURE",false,typeof(decimal?))]
		public decimal? LAST_MEASURE
		{
			set
			{
				_LAST_MEASURE=value;
			}
			get
			{
				return _LAST_MEASURE;
			}
		}

		[ColumnName("LAST_COLOR",false,typeof(string))]
		public string LAST_COLOR
		{
			set
			{
				_LAST_COLOR=value;
			}
			get
			{
				return _LAST_COLOR;
			}
		}

		[ColumnName("TARGET_MEASURE",false,typeof(decimal?))]
		public decimal? TARGET_MEASURE
		{
			set
			{
				_TARGET_MEASURE=value;
			}
			get
			{
				return _TARGET_MEASURE;
			}
		}

		[ColumnName("TARGET_COLOR",false,typeof(string))]
		public string TARGET_COLOR
		{
			set
			{
				_TARGET_COLOR=value;
			}
			get
			{
				return _TARGET_COLOR;
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

		[ColumnName("LAST_TIME_ID",false,typeof(string))]
		public string LAST_TIME_ID
		{
			set
			{
				_LAST_TIME_ID=value;
			}
			get
			{
				return _LAST_TIME_ID;
			}
		}

		[ColumnName("VISION_SHARE_RULE_UUID",true,typeof(string))]
		public string VISION_SHARE_RULE_UUID
		{
			set
			{
				_VISION_SHARE_RULE_UUID=value;
			}
			get
			{
				return _VISION_SHARE_RULE_UUID;
			}
		}

		[ColumnName("IS_INSTRUCTION",false,typeof(string))]
		public string IS_INSTRUCTION
		{
			set
			{
				_IS_INSTRUCTION=value;
			}
			get
			{
				return _IS_INSTRUCTION;
			}
		}

		[ColumnName("IS_EXPLAIN",false,typeof(string))]
		public string IS_EXPLAIN
		{
			set
			{
				_IS_EXPLAIN=value;
			}
			get
			{
				return _IS_EXPLAIN;
			}
		}
		public ViewHome_Record Clone(){
			try{
				return this.Clone<ViewHome_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public ViewHome gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ViewHome ret = new ViewHome(dbc,this);
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
