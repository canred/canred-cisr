using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.Attribute;
using IST.DB;  
using log4net;  
using System.Reflection;  
using IST.DB.SQLCreater;  
using CISR.Model.Cr.Table;
namespace CISR.Model.Cr
{
	[ModelName("Cr")]
	[ISTDataBase("CISR")]
	public partial class CrModel
	{
		public new static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private IST.Config.DataBase.IDataBaseConfigInfo dbc = null;
		public CrModel(){}
		/*Templete Model A001*/
		public CISR.Model.Cr.Table.BaseLine getBaseLine_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.BaseLine baseline = new CISR.Model.Cr.Table.BaseLine(dbc);
				baseline.Fill_By_PK(pUUID);
				return baseline;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.ParameterItemOwner getParameterItemOwner_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.ParameterItemOwner parameteritemowner = new CISR.Model.Cr.Table.ParameterItemOwner(dbc);
				parameteritemowner.Fill_By_PK(pUUID);
				return parameteritemowner;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.ParameterOwner getParameterOwner_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.ParameterOwner parameterowner = new CISR.Model.Cr.Table.ParameterOwner(dbc);
				parameterowner.Fill_By_PK(pUUID);
				return parameterowner;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.RawData getRawData_By_TimeId_And_FrameHeadUuid_And_RawHeadUuid(string pTIME_ID,string pFRAME_HEAD_UUID,string pRAW_HEAD_UUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.RawData rawdata = new CISR.Model.Cr.Table.RawData(dbc);
				rawdata.Fill_By_PK(pTIME_ID,pFRAME_HEAD_UUID,pRAW_HEAD_UUID);
				return rawdata;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.RawHeadSpecRule getRawHeadSpecRule_By_RawHeadUuid_And_Seq(string pRAW_HEAD_UUID,decimal? pSEQ){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.RawHeadSpecRule rawheadspecrule = new CISR.Model.Cr.Table.RawHeadSpecRule(dbc);
				rawheadspecrule.Fill_By_PK(pRAW_HEAD_UUID,pSEQ);
				return rawheadspecrule;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.RawProcessHead getRawProcessHead_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.RawProcessHead rawprocesshead = new CISR.Model.Cr.Table.RawProcessHead(dbc);
				rawprocesshead.Fill_By_PK(pUUID);
				return rawprocesshead;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.RawProcessItem getRawProcessItem_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.RawProcessItem rawprocessitem = new CISR.Model.Cr.Table.RawProcessItem(dbc);
				rawprocessitem.Fill_By_PK(pUUID);
				return rawprocessitem;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.RoleKpi getRoleKpi_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.RoleKpi rolekpi = new CISR.Model.Cr.Table.RoleKpi(dbc);
				rolekpi.Fill_By_PK(pUUID);
				return rolekpi;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.Unit getUnit_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.Unit unit = new CISR.Model.Cr.Table.Unit(dbc);
				unit.Fill_By_PK(pUUID);
				return unit;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.UnitCategory getUnitCategory_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.UnitCategory unitcategory = new CISR.Model.Cr.Table.UnitCategory(dbc);
				unitcategory.Fill_By_PK(pUUID);
				return unitcategory;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.ViewHome getViewHome_By_TimeId_And_KpiHeadUuid_And_FrameHeadUuid_And_VisionShareRuleUuid(string pTIME_ID,string pKPI_HEAD_UUID,string pFRAME_HEAD_UUID,string pVISION_SHARE_RULE_UUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.ViewHome viewhome = new CISR.Model.Cr.Table.ViewHome(dbc);
				viewhome.Fill_By_PK(pTIME_ID,pKPI_HEAD_UUID,pFRAME_HEAD_UUID,pVISION_SHARE_RULE_UUID);
				return viewhome;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.ParameterHead getParameterHead_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.ParameterHead parameterhead = new CISR.Model.Cr.Table.ParameterHead(dbc);
				parameterhead.Fill_By_PK(pUUID);
				return parameterhead;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.ParameterItem getParameterItem_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.ParameterItem parameteritem = new CISR.Model.Cr.Table.ParameterItem(dbc);
				parameteritem.Fill_By_PK(pUUID);
				return parameteritem;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.ParameterMonth getParameterMonth_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.ParameterMonth parametermonth = new CISR.Model.Cr.Table.ParameterMonth(dbc);
				parametermonth.Fill_By_PK(pUUID);
				return parametermonth;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.Region getRegion_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.Region region = new CISR.Model.Cr.Table.Region(dbc);
				region.Fill_By_PK(pUUID);
				return region;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.RawHeadCategory getRawHeadCategory_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.RawHeadCategory rawheadcategory = new CISR.Model.Cr.Table.RawHeadCategory(dbc);
				rawheadcategory.Fill_By_PK(pUUID);
				return rawheadcategory;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.KpiPackage getKpiPackage_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.KpiPackage kpipackage = new CISR.Model.Cr.Table.KpiPackage(dbc);
				kpipackage.Fill_By_PK(pUUID);
				return kpipackage;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.KpiPackageItem getKpiPackageItem_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.KpiPackageItem kpipackageitem = new CISR.Model.Cr.Table.KpiPackageItem(dbc);
				kpipackageitem.Fill_By_PK(pUUID);
				return kpipackageitem;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.KpiFormulaDetail getKpiFormulaDetail_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.KpiFormulaDetail kpiformuladetail = new CISR.Model.Cr.Table.KpiFormulaDetail(dbc);
				kpiformuladetail.Fill_By_PK(pUUID);
				return kpiformuladetail;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.KpiFormula getKpiFormula_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.KpiFormula kpiformula = new CISR.Model.Cr.Table.KpiFormula(dbc);
				kpiformula.Fill_By_PK(pUUID);
				return kpiformula;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.VPwg getVPwg_By_PwgGid(string pPWG_GID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.VPwg vpwg = new CISR.Model.Cr.Table.VPwg(dbc);
				vpwg.Fill_By_PK(pPWG_GID);
				return vpwg;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.Pwg getPwg_By_Gid_And_AttendantUuid(string pGID,string pATTENDANT_UUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.Pwg pwg = new CISR.Model.Cr.Table.Pwg(dbc);
				pwg.Fill_By_PK(pGID,pATTENDANT_UUID);
				return pwg;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.FrameItem getFrameItem_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.FrameItem frameitem = new CISR.Model.Cr.Table.FrameItem(dbc);
				frameitem.Fill_By_PK(pUUID);
				return frameitem;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.Dwg getDwg_By_DwgGid_And_AttendantUuid(string pDWG_GID,string pATTENDANT_UUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.Dwg dwg = new CISR.Model.Cr.Table.Dwg(dbc);
				dwg.Fill_By_PK(pDWG_GID,pATTENDANT_UUID);
				return dwg;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.Time getTime_By_TimeId_And_TimeType(string pTIME_ID,string pTIME_TYPE){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.Time time = new CISR.Model.Cr.Table.Time(dbc);
				time.Fill_By_PK(pTIME_ID,pTIME_TYPE);
				return time;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.UploadJobLog getUploadJobLog_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.UploadJobLog uploadjoblog = new CISR.Model.Cr.Table.UploadJobLog(dbc);
				uploadjoblog.Fill_By_PK(pUUID);
				return uploadjoblog;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.Files getFiles_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.Files files = new CISR.Model.Cr.Table.Files(dbc);
				files.Fill_By_PK(pUUID);
				return files;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.UploadJob getUploadJob_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.UploadJob uploadjob = new CISR.Model.Cr.Table.UploadJob(dbc);
				uploadjob.Fill_By_PK(pUUID);
				return uploadjob;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.Cal getCal_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.Cal cal = new CISR.Model.Cr.Table.Cal(dbc);
				cal.Fill_By_PK(pUUID);
				return cal;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.VCal getVCal_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.VCal vcal = new CISR.Model.Cr.Table.VCal(dbc);
				vcal.Fill_By_PK(pUUID);
				return vcal;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.KpiPackageExpend getKpiPackageExpend_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.KpiPackageExpend kpipackageexpend = new CISR.Model.Cr.Table.KpiPackageExpend(dbc);
				kpipackageexpend.Fill_By_PK(pUUID);
				return kpipackageexpend;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.FrameHead getFrameHead_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.FrameHead framehead = new CISR.Model.Cr.Table.FrameHead(dbc);
				framehead.Fill_By_PK(pUUID);
				return framehead;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.FrameCategory getFrameCategory_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.FrameCategory framecategory = new CISR.Model.Cr.Table.FrameCategory(dbc);
				framecategory.Fill_By_PK(pUUID);
				return framecategory;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.RawHead getRawHead_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.RawHead rawhead = new CISR.Model.Cr.Table.RawHead(dbc);
				rawhead.Fill_By_PK(pUUID);
				return rawhead;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.ChartList getChartList_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.ChartList chartlist = new CISR.Model.Cr.Table.ChartList(dbc);
				chartlist.Fill_By_PK(pUUID);
				return chartlist;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

		/*Templete Model A001*/
		public CISR.Model.Cr.Table.KpiHead getKpiHead_By_Uuid(string pUUID){
			try{
				dbc = IST.Config.DataBase.Factory.getInfo();
				CISR.Model.Cr.Table.KpiHead kpihead = new CISR.Model.Cr.Table.KpiHead(dbc);
				kpihead.Fill_By_PK(pUUID);
				return kpihead;
			}
			catch (Exception ex){
				log.Error(ex);IST.MyException.MyException.Error(this, ex);
				throw ex;
			}
		}

	}
}
