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
	[ISTTableView("PARAMETER_HEAD", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class ParameterHead_Record : RecordBase{
		public ParameterHead_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		DateTime? _CREATE_DATE=null;
		DateTime? _UPDATE_DATE=null;
		string _IS_ACTIVE=null;
		string _NAME=null;
		string _DESCRIPTION=null;
		decimal? _VALUE=null;
		string _COMPANY_UUID=null;
		string _IS_PUBLIC=null;
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

		[ColumnName("IS_PUBLIC",false,typeof(string))]
		public string IS_PUBLIC
		{
			set
			{
				_IS_PUBLIC=value;
			}
			get
			{
				return _IS_PUBLIC;
			}
		}
		public ParameterHead_Record Clone(){
			try{
				return this.Clone<ParameterHead_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public ParameterHead gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterHead ret = new ParameterHead(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<ParameterItem_Record> Link_ParameterItem_By_ParameterHeadUuid()
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				ret=(List<ParameterItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PARAMETER_HEAD_UUID,this.UUID))
					.FetchAll<ParameterItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<ParameterOwner_Record> Link_ParameterOwner_By_ParameterHeadUuid()
		{
			try{
				List<ParameterOwner_Record> ret= new List<ParameterOwner_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterOwner ___table = new ParameterOwner(dbc);
				ret=(List<ParameterOwner_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PARAMETER_HEAD_UUID,this.UUID))
					.FetchAll<ParameterOwner_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<ParameterItem_Record> Link_ParameterItem_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				List<ParameterItem_Record> ret= new List<ParameterItem_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterItem ___table = new ParameterItem(dbc);
				ret=(List<ParameterItem_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PARAMETER_HEAD_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<ParameterItem_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<ParameterOwner_Record> Link_ParameterOwner_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				List<ParameterOwner_Record> ret= new List<ParameterOwner_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				ParameterOwner ___table = new ParameterOwner(dbc);
				ret=(List<ParameterOwner_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.PARAMETER_HEAD_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<ParameterOwner_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public ParameterItem LinkFill_ParameterItem_By_ParameterHeadUuid()
		{
			try{
				var data = Link_ParameterItem_By_ParameterHeadUuid();
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public ParameterOwner LinkFill_ParameterOwner_By_ParameterHeadUuid()
		{
			try{
				var data = Link_ParameterOwner_By_ParameterHeadUuid();
				ParameterOwner ret=new ParameterOwner(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public ParameterItem LinkFill_ParameterItem_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterItem_By_ParameterHeadUuid(limit);
				ParameterItem ret=new ParameterItem(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public ParameterOwner LinkFill_ParameterOwner_By_ParameterHeadUuid(OrderLimit limit)
		{
			try{
				var data = Link_ParameterOwner_By_ParameterHeadUuid(limit);
				ParameterOwner ret=new ParameterOwner(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
