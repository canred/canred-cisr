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
	[ISTTableView("FRAME_CATEGORY", true)]
	[ISTDataBase("CISR")]
	[Serializable]
	public class FrameCategory_Record : RecordBase{
		public FrameCategory_Record(){}
		/*欄位資訊 Start*/
		string _UUID=null;
		string _FRAME_CATEGORY_NAME=null;
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

		[ColumnName("FRAME_CATEGORY_NAME",false,typeof(string))]
		public string FRAME_CATEGORY_NAME
		{
			set
			{
				_FRAME_CATEGORY_NAME=value;
			}
			get
			{
				return _FRAME_CATEGORY_NAME;
			}
		}
		public FrameCategory_Record Clone(){
			try{
				return this.Clone<FrameCategory_Record>(this);
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		public FrameCategory gotoTable(){
			try{
				var dbc = IST.Config.DataBase.Factory.getInfo();
				FrameCategory ret = new FrameCategory(dbc,this);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180347*/
		public List<VFrameHead_Record> Link_VFrameHead_By_FrameCategoryUuid()
		{
			try{
				List<VFrameHead_Record> ret= new List<VFrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameHead ___table = new VFrameHead(dbc);
				ret=(List<VFrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_CATEGORY_UUID,this.UUID))
					.FetchAll<VFrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180348*/
		public List<VFrameHead_Record> Link_VFrameHead_By_FrameCategoryUuid(OrderLimit limit)
		{
			try{
				List<VFrameHead_Record> ret= new List<VFrameHead_Record>();
				var dbc = IST.Config.DataBase.Factory.getInfo();
				VFrameHead ___table = new VFrameHead(dbc);
				ret=(List<VFrameHead_Record>)
										___table.Where(new SQLCondition(___table)
										.Equal(___table.FRAME_CATEGORY_UUID,this.UUID))
					.Order(limit)
					.Limit(limit)
					.FetchAll<VFrameHead_Record>() ; 
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180357*/
		public VFrameHead LinkFill_VFrameHead_By_FrameCategoryUuid()
		{
			try{
				var data = Link_VFrameHead_By_FrameCategoryUuid();
				VFrameHead ret=new VFrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
		/*201303180358*/
		public VFrameHead LinkFill_VFrameHead_By_FrameCategoryUuid(OrderLimit limit)
		{
			try{
				var data = Link_VFrameHead_By_FrameCategoryUuid(limit);
				VFrameHead ret=new VFrameHead(data);
				return ret;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}
	}
}
