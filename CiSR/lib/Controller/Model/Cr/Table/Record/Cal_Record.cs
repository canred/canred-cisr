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
	[ISTTableView("CAL", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class Cal_Record : RecordBase{
		public Cal_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _FRAME_HEAD_UUID=null;
		string _TIME_ID=null;
		string _KPI_HEAD_UUID=null;
		decimal? _ORD=null;
		string _STATUS=null;
		string _ERROR_MSG=null;
		decimal? _VALUE=null;
		string _FORMULA=null;
		string _CAL_LOG=null;
		decimal? _FRAME_LEVEL=null;
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

		[ColumnName("TIME_ID",false,typeof(string))]
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

		[ColumnName("KPI_HEAD_UUID",false,typeof(string))]
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

		[ColumnName("STATUS",false,typeof(string))]
		public string STATUS
		{
			set
			{
				_STATUS=value;
			}
			get
			{
				return _STATUS;
			}
		}

		[ColumnName("ERROR_MSG",false,typeof(string))]
		public string ERROR_MSG
		{
			set
			{
				_ERROR_MSG=value;
			}
			get
			{
				return _ERROR_MSG;
			}
		}

		[ColumnName("VALUE",false,typeof(decimal?))]
		public decimal? VALUE
		{
			set
			{
				_VALUE=value;
			}
			get
			{
				return _VALUE;
			}
		}

		[ColumnName("FORMULA",false,typeof(string))]
		public string FORMULA
		{
			set
			{
				_FORMULA=value;
			}
			get
			{
				return _FORMULA;
			}
		}

		[ColumnName("CAL_LOG",false,typeof(string))]
		public string CAL_LOG
		{
			set
			{
				_CAL_LOG=value;
			}
			get
			{
				return _CAL_LOG;
			}
		}

		[ColumnName("FRAME_LEVEL",false,typeof(decimal?))]
		public decimal? FRAME_LEVEL
		{
			set
			{
				_FRAME_LEVEL=value;
			}
			get
			{
				return _FRAME_LEVEL;
			}
		}
		public Cal_Record Clone(){
			try{
				return this.Clone<Cal_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public Cal gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				Cal ret = new Cal(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VCal_Record> Link_VCal_By_Uuid()
		{
			try{
				List<VCal_Record> ret= new List<VCal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VCal ___table = new VCal(dbc);
				ret=(List<VCal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
					.FetchAll<VCal_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VCal_Record> Link_VCal_By_Uuid(OrderLimit limit)
		{
			try{
				List<VCal_Record> ret= new List<VCal_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VCal ___table = new VCal(dbc);
				ret=(List<VCal_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<VCal_Record>() ; 
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
		public List<KpiHead_Record> Link_KpiHead_By_Uuid()
		{
			try{
				List<KpiHead_Record> ret= new List<KpiHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiHead ___table = new KpiHead(dbc);
				ret=(List<KpiHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_HEAD_UUID))
					.FetchAll<KpiHead_Record>() ; 
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
		/*201303180404*/
		public List<KpiHead_Record> Link_KpiHead_By_Uuid(OrderLimit limit)
		{
			try{
				List<KpiHead_Record> ret= new List<KpiHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				KpiHead ___table = new KpiHead(dbc);
				ret=(List<KpiHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.UUID,this.KPI_HEAD_UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<KpiHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VCal LinkFill_VCal_By_Uuid()
		{
			try{
				var data = Link_VCal_By_Uuid();
				VCal ret=new VCal(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VCal LinkFill_VCal_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_VCal_By_Uuid(limit);
				VCal ret=new VCal(data);
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
		/*2013031800428*/
		public KpiHead LinkFill_KpiHead_By_Uuid()
		{
			try{
				var data = Link_KpiHead_By_Uuid();
				KpiHead ret=new KpiHead(data);
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
		/*201303180429*/
		public KpiHead LinkFill_KpiHead_By_Uuid(OrderLimit limit)
		{
			try{
				var data = Link_KpiHead_By_Uuid(limit);
				KpiHead ret=new KpiHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
