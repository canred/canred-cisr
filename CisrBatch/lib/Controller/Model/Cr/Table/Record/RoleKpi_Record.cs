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
	[ISTTableView("ROLE_KPI", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class RoleKpi_Record : RecordBase{
		public RoleKpi_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _ROLE_HEAD_UUID=null;
		string _KPI_HEAD_UUID=null;
		decimal? _SEQ=null;
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

		[ColumnName("ROLE_HEAD_UUID",false,typeof(string))]
		public string ROLE_HEAD_UUID
		{
			set
			{
				_ROLE_HEAD_UUID=value;
			}
			get
			{
				return _ROLE_HEAD_UUID;
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

		[ColumnName("SEQ",false,typeof(decimal?))]
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
		public RoleKpi_Record Clone(){
			try{
				return this.Clone<RoleKpi_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public RoleKpi gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				RoleKpi ret = new RoleKpi(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
