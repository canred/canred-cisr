using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.Attribute;
using IST.DB;  
using IST.DB.SQLCreater;  
using CISR.Model.Cr.Table;
using CISR.Model.Cr.Table.Record;
namespace CISR.Model.Cr
{
	public partial class CrModel
	{
        public IList<VUploadJob_Record> getVUploadJob_By_Uuid(string pUUID)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob uploadjob = new CISR.Model.Cr.Table.VUploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)
                    .Equal(uploadjob.UUID, pUUID)
                    )
                    .FetchAll<VUploadJob_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getUnitCategory_By_KeyWord_Count(string pKeyWord)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UnitCategory unitcategory = new CISR.Model.Cr.Table.UnitCategory(dbc);
                return unitcategory.Where(new SQLCondition(unitcategory)
                    .BLike(unitcategory.NAME, pKeyWord)
                    .Or()
                    .BLike(unitcategory.DESCRIPTION, pKeyWord)
                    )
                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UnitCategory_Record> getUnitCategory_By_KeyWord(string pKeyWord,OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UnitCategory unitcategory = new CISR.Model.Cr.Table.UnitCategory(dbc);
                return unitcategory.Where(new SQLCondition(unitcategory)
                    .BLike(unitcategory.NAME, pKeyWord)
                    .Or()
                    .BLike(unitcategory.DESCRIPTION, pKeyWord)
                    )
                    .Limit(or)
                    .FetchAll<UnitCategory_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UnitCategory_Record> getUnitCategory_Active(OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UnitCategory unitcategory = new CISR.Model.Cr.Table.UnitCategory(dbc);
                return unitcategory.Where(new SQLCondition(unitcategory)
                    .Equal(unitcategory.IS_ACTIVE,"Y")
                    )
                    .Limit(or)
                    .FetchAll<UnitCategory_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public int getUnit_By_UnitCategory_KeyWord_Count(string pUnitCategory, string pKeyWord)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Unit unit = new CISR.Model.Cr.Table.Unit(dbc);
                return unit.Where(new SQLCondition(unit)
                    .Equal(unit.UNIT_CATEGORY_UUID, pUnitCategory)
                    .And()
                    .L()
                    .BLike(unit.UNIT_NAME, pKeyWord)
                    .Or()
                    .BLike(unit.UNIT_E_DESC, pKeyWord)
                    .Or()
                    .BLike(unit.UNIT_C_DESC, pKeyWord)                    
                    .R()
                    )
                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Unit_Record> getUnit_By_UnitCategory_KeyWord(string pUnitCateUuid, string pKeyWord,OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Unit unit = new CISR.Model.Cr.Table.Unit(dbc);
                return unit.Where(new SQLCondition(unit)
                    .Equal(unit.UNIT_CATEGORY_UUID, pUnitCateUuid)
                    .And()
                    .L()
                    .BLike(unit.UNIT_NAME, pKeyWord)
                    .Or()
                    .BLike(unit.UNIT_E_DESC, pKeyWord)
                    .Or()
                    .BLike(unit.UNIT_C_DESC, pKeyWord)
                    .R()
                    )
                .Limit(or)
                .FetchAll<Unit_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVUnit_By_KeyWord_Count(string pKeyWord)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUnit vunit = new CISR.Model.Cr.Table.VUnit(dbc);
                return vunit.Where(new SQLCondition(vunit)
                    .BLike(vunit.UNIT_CATEGORY_NAME, pKeyWord)
                    .Or()
                     .BLike(vunit.UNIT_CATEGORY_DESCRIPTION, pKeyWord)
                     .Or()
                     .BLike(vunit.UNIT_NAME, pKeyWord)
                     .Or()
                      .BLike(vunit.UNIT_C_DESC, pKeyWord)
                    )
                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VUnit_Record> getVUnit_By_KeyWord(string pKeyWord,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUnit vunit = new CISR.Model.Cr.Table.VUnit(dbc);
                return vunit.Where(new SQLCondition(vunit)
                    .BLike(vunit.UNIT_CATEGORY_NAME, pKeyWord)
                    .Or()
                     .BLike(vunit.UNIT_CATEGORY_DESCRIPTION, pKeyWord)
                     .Or()
                     .BLike(vunit.UNIT_NAME, pKeyWord)
                     .Or()
                      .BLike(vunit.UNIT_C_DESC, pKeyWord)
                    )
                    .Limit(orderlimit)
                .FetchAll<VUnit_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getRegion_By_Keyword_Count(string pKeyword)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Region region = new CISR.Model.Cr.Table.Region(dbc);
                var condition = new SQLCondition(region);
                if (pKeyword.Trim().Length > 0) {
                    condition.iBLike(region.REGION_NAME,pKeyword).Or().iBLike(region.REGION_DESC, pKeyword);
                }
                return region.Where(condition)
                    .FetchCount();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Region_Record> getRegion_By_Keyword(string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Region region = new CISR.Model.Cr.Table.Region(dbc);
                var condition = new SQLCondition(region);
                if (pKeyword.Trim().Length > 0)
                {
                    condition.iBLike(region.REGION_NAME, pKeyword).Or().iBLike(region.REGION_DESC, pKeyword);
                }
                return region.Where(condition)
                    .Limit(orderlimit)
                    .FetchAll<Region_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VParameterQuery_Record> getVParameterQuery_By_KeyWord(string pCompanyUuid,string pKeyWord, OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VParameterQuery table = new CISR.Model.Cr.Table.VParameterQuery(dbc);
                return table.Where(new SQLCondition(table)
                    .BLike(table.NAME, pKeyWord)
                    .And().Equal(table.COMPANY_UUID,pCompanyUuid)
                    .Or()
                     .BLike(table.DESCRIPTION, pKeyWord)
                     .Or()
                     .BLike(table.VALUE, pKeyWord)
                     .Or()
                      .BLike(table.ITEM_VALUE, pKeyWord)
                      .Or()
                      .BLike(table.REGION_NAME, pKeyWord)
                      .Or()
                      .BLike(table.MONTH_ID, pKeyWord)
                      .Or()
                      .BLike(table.MONTH_VALUE, pKeyWord)
                    )
                    .Limit(orderlimit)
                .FetchAll<VParameterQuery_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVParameterQuery_By_KeyWord_Count(string pCompanyUuid,string pKeyWord)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VParameterQuery table = new CISR.Model.Cr.Table.VParameterQuery(dbc);
                return table.Where(new SQLCondition(table)
                    .BLike(table.NAME, pKeyWord)
                    .And().Equal(table.COMPANY_UUID,pCompanyUuid)
                    .Or()
                     .BLike(table.DESCRIPTION, pKeyWord)
                     .Or()
                     .BLike(table.VALUE, pKeyWord)
                     .Or()
                      .BLike(table.ITEM_VALUE, pKeyWord)
                      .Or()
                      .BLike(table.REGION_NAME, pKeyWord)
                      .Or()
                      .BLike(table.MONTH_ID, pKeyWord)
                      .Or()
                      .BLike(table.MONTH_VALUE, pKeyWord)
                    )

                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVParameterQuery_By_ParameterHeadUuid_RegionNameIsNotNull_Count(string pParameterHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VParameterQuery table = new CISR.Model.Cr.Table.VParameterQuery(dbc);
                return table.Where(new SQLCondition(table)
                   .Equal(table.PARAMETER_UUID,pParameterHeadUuid)
                   .And()
                   .IsNotNull(table.REGION_NAME)
                    )

                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VParameterQuery_Record> getVParameterQuery_By_ParameterHeadUuid_RegionNameIsNotNull(string pParameterHeadUuid, OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VParameterQuery table = new CISR.Model.Cr.Table.VParameterQuery(dbc);
                return table.Where(new SQLCondition(table)
                   .Equal(table.PARAMETER_UUID, pParameterHeadUuid)
                    .And()
                   .IsNotNull(table.REGION_NAME)
                    )
                .Limit(orderlimit)
                .FetchAll<VParameterQuery_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        /// <summary>
        /// 按地區，時間來取得合適的系數值
        /// </summary>
        /// <param name="pParameterHeadUuid"></param>
        /// <param name="regionUuid"></param>
        /// <param name="timeId"></param>
        /// <returns></returns>
        public decimal? getVParameterQuery_Region_TimeId(string pParameterHeadUuid,string regionUuid,string timeId)
        {
            try
            {
                if (timeId.Length == 4) {
                    timeId += "01";
                }
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VParameterQuery table = new CISR.Model.Cr.Table.VParameterQuery(dbc);
                var drsVParameter = table.Where(new SQLCondition(table)
                   .Equal(table.PARAMETER_UUID, pParameterHeadUuid)                   
                    )                
                .FetchAll<VParameterQuery_Record>();

                if (regionUuid.Trim().Length > 0)
                {
                    var drs1 = drsVParameter.Where(c => c.REGION_UUID.Equals(regionUuid)).ToList();
                    if (drs1.Count() > 0)
                    {
                        var drs1_1 = drs1.Where(c => Convert.ToInt32(c.MONTH_ID) < Convert.ToInt32(timeId)).ToList();
                        if (drs1_1.Count > 0)
                        {
                            return drs1_1.OrderByDescending(c => Convert.ToInt32(c.MONTH_ID)).First().MONTH_VALUE;
                        }
                        else
                        {
                            return drs1.First().ITEM_VALUE;
                        }

                    }
                    else
                    {
                        return drsVParameter.First().VALUE;
                    }
                }
                else {
                    var drs2 = drsVParameter.Where(c => Convert.ToInt32(c.MONTH_ID) < Convert.ToInt32(timeId)).ToList();
                    if (drs2.Count > 0)
                    {
                        return drs2.OrderByDescending(c => Convert.ToInt32(c.MONTH_ID)).First().MONTH_VALUE;
                    }
                    else
                    {
                        return drsVParameter.First().VALUE;
                    }
                }
                



            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public decimal? getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(string pKpiHeadUuid,string pFrameHeadUuid,string pTimeId)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VCal vcal = new CISR.Model.Cr.Table.VCal(dbc);
                var data = vcal.Where(new SQLCondition(vcal)
                    .Equal(vcal.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(vcal.KPI_HEAD_UUID, pKpiHeadUuid)
                    .And()
                    .Equal(vcal.TIME_ID, pTimeId)
                    )
                    .FetchOne<VCal_Record>();
                if (data != null)
                    return data.VALUE;
                else
                    return null;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<CISR.Model.Cr.Table.Record.VCal_Record> getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(List<Object> arrFrameHeadUuid, string pTimeId, string pKpiHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VCal vcal = new CISR.Model.Cr.Table.VCal(dbc);
                return  vcal.Where(new SQLCondition(vcal)
                    .In(vcal.FRAME_HEAD_UUID, arrFrameHeadUuid)
                    .And()
                    .Equal(vcal.KPI_HEAD_UUID, pKpiHeadUuid)
                    .And()
                    .Equal(vcal.TIME_ID, pTimeId)
                    )                    
                    .FetchAll<CISR.Model.Cr.Table.Record.VCal_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<CISR.Model.Cr.Table.Record.VCal_Record> getVCal_By_FrameHeadUuid_TimeId_KpiHeadUuid(string pFrameHeadUuid, string pTimeId, List<object> arrKpiHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VCal vcal = new CISR.Model.Cr.Table.VCal(dbc);
                return vcal.Where(new SQLCondition(vcal)
                    .Equal(vcal.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .In(vcal.KPI_HEAD_UUID, arrKpiHeadUuid)
                    .And()
                    .Equal(vcal.TIME_ID, pTimeId)
                    )
                .FetchAll<CISR.Model.Cr.Table.Record.VCal_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<ParameterItem_Record> getParameterItem_By_ParameterHeadUuid_RegionUuid(string pParameterHeadUuid,string pRegionUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.ParameterItem parameteritem = new CISR.Model.Cr.Table.ParameterItem(dbc);
                return parameteritem.Where(new SQLCondition(parameteritem)
                    .Equal(parameteritem.PARAMETER_HEAD_UUID, pParameterHeadUuid)
                    .And()
                    .Equal(parameteritem.REGION_UUID, pRegionUuid)
                    )
                .FetchAll<ParameterItem_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<ParameterMonth_Record> getParameterMonth_By_ParameterItemUuid_MonthId(string pParameterItemUuid,string pMonthId)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.ParameterMonth parametermonth = new CISR.Model.Cr.Table.ParameterMonth(dbc);
                return parametermonth.Where(new SQLCondition(parametermonth)
                    .Equal(parametermonth.PARAMETER_ITEM_UUID, pParameterItemUuid)
                    .And()
                    .Equal(parametermonth.MONTH_ID, pMonthId))
                    .FetchAll<ParameterMonth_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VRawHead_Record> getVRawHead_By_CompanyUuid_Keyword(string pCompanyUuid,string pTimeType,string keyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VRawHead vrawhead = new CISR.Model.Cr.Table.VRawHead(dbc);
                
                var condition = new SQLCondition(vrawhead);
                condition.Equal(vrawhead.COMPANY_UUID,pCompanyUuid).And()
                    .Equal(vrawhead.TIME_TYPE,pTimeType).And();
                if(keyword.Trim().Length>0){
                    condition.L();
                    condition.iBLike(vrawhead.VALUEDISPLAY,keyword).Or()
                        .iBLike(vrawhead.UNIT,keyword).Or()
                        .iBLike(vrawhead.TIME_TYPE,keyword).Or()
                        .iBLike(vrawhead.RAW_ID,keyword).Or()
                        .iBLike(vrawhead.E_DESC,keyword).Or()
                        .iBLike(vrawhead.E_DEFINE,keyword).Or()
                        .iBLike(vrawhead.C_DESC,keyword).Or()
                        .iBLike(vrawhead.C_DEFINE,keyword).Or()
                         .iBLike(vrawhead.RAW_HEAD_CATEGORY_NAME, keyword).Or()
                        .iBLike(vrawhead.RAW_HEAD_CATEGORY_DESCRIPTION,keyword);
                    condition.R();
                }
                condition.CheckSQL();

                return vrawhead.Where(condition)
                    .Limit(orderlimit)
                    .FetchAll<VRawHead_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVRawHead_By_CompanyUuid_Keyword_Count(string pCompanyUuid,string pTimeType, string keyword)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VRawHead vrawhead = new CISR.Model.Cr.Table.VRawHead(dbc);

                var condition = new SQLCondition(vrawhead);
                condition.Equal(vrawhead.COMPANY_UUID, pCompanyUuid).And()
                    .Equal(vrawhead.TIME_TYPE,pTimeType).And();
                if (keyword.Trim().Length > 0)
                {
                    condition.L();
                    condition.iBLike(vrawhead.VALUEDISPLAY, keyword).Or()
                        .iBLike(vrawhead.UNIT, keyword).Or()
                        .iBLike(vrawhead.TIME_TYPE, keyword).Or()
                        .iBLike(vrawhead.RAW_ID, keyword).Or()
                        .iBLike(vrawhead.E_DESC, keyword).Or()
                        .iBLike(vrawhead.E_DEFINE, keyword).Or()
                        .iBLike(vrawhead.C_DESC, keyword).Or()
                        .iBLike(vrawhead.C_DEFINE, keyword).Or()
                        .iBLike(vrawhead.RAW_HEAD_CATEGORY_DESCRIPTION, keyword).Or()
                        .iBLike(vrawhead.RAW_HEAD_CATEGORY_NAME, keyword);
                    condition.R();
                }
                condition.CheckSQL();

                return vrawhead.Where(condition)
                    .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<RawHeadCategory_Record> getRawHeadCategory(string pCompanyUuid,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.RawHeadCategory rawheadcategory = new CISR.Model.Cr.Table.RawHeadCategory(dbc);
                return rawheadcategory.Where(new SQLCondition(rawheadcategory).Equal(rawheadcategory.COMPANY_UUID, pCompanyUuid))
                    .Limit(orderlimit)
                    .FetchAll<RawHeadCategory_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getFrameHead_MaxOrd(string pFrameHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                FrameHead framehead = new FrameHead(dbc);

                var result = framehead.Where(new SQLCondition(framehead)
                    .Equal(framehead.PARENT_FRAME_HEAD_UUID, pFrameHeadUuid)
                ).Select("MAX(ord) maxord").FetchAll();
                if (result.Rows.Count == 1)
                {
                    if (result.Rows[0][0].ToString() == "") {
                        return 0;
                    }
                    else { 
                    return System.Convert.ToInt32(result.Rows[0][0].ToString());
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
                IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public FrameHead_Record getFrameHead_Root(string pCompanyUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameHead framehead = new CISR.Model.Cr.Table.FrameHead(dbc);
                return framehead.Where(new SQLCondition(framehead)
                    .Equal(framehead.COMPANY_UUID, pCompanyUuid)
                    .And()
                    .IsNull(framehead.PARENT_FRAME_HEAD_UUID))
                    .FetchAll<FrameHead_Record>().First();
                //return framehead;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VKpi_Record> getVKpi(string pCompanyUuid,string pKeywork, string pTimeType, OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VKpi vkpi = new CISR.Model.Cr.Table.VKpi(dbc);
                var sc = new SQLCondition(vkpi);
                if (pTimeType.Trim().Length > 0) {
                    sc.Equal(vkpi.TIME_TYPE, pTimeType).And();
                }

                sc.Equal(vkpi.COMPANY_UUID, pCompanyUuid)
                .And()
                .L()
                .iBLike(vkpi.ALGORITHM_MAN, pKeywork).Or()
                .iBLike(vkpi.C_DESC, pKeywork).Or()
                .iBLike(vkpi.C_DESC_GROUP, pKeywork).Or()
                .iBLike(vkpi.C_NOTICE, pKeywork).Or()
                .iBLike(vkpi.E_DESC, pKeywork).Or()
                .iBLike(vkpi.E_DESC_GROUP, pKeywork).Or()
                .iBLike(vkpi.KPI_FORMULA_DESC, pKeywork).Or()
                .iBLike(vkpi.KPI_ID, pKeywork).Or()
                .iBLike(vkpi.TIME_ID, pKeywork).Or()
                .iBLike(vkpi.UNIT, pKeywork).Or()
                .iBLike(vkpi.ZH_DESC, pKeywork)
                .R();

                return vkpi.Where(sc
                
                    )
                    .Limit(or)
                    .FetchAll<VKpi_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VKpi_Record> getVKpi_by_KpiHeadUuid(string pKpiHeadUuid, OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VKpi vkpi = new CISR.Model.Cr.Table.VKpi(dbc);
                return vkpi.Where(new SQLCondition(vkpi)
                    .Equal(vkpi.KPI_HEAD_UUID,pKpiHeadUuid)
                    
                    )
                    .Limit(or)
                    .FetchAll<VKpi_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public int getVKpi_Count(string pCompanyUuid,string pKeywork, string pTimeType)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VKpi vkpi = new CISR.Model.Cr.Table.VKpi(dbc);
                return vkpi.Where(new SQLCondition(vkpi)
                    .Equal(vkpi.TIME_TYPE, pTimeType)
                    .And()
                    .Equal(vkpi.COMPANY_UUID, pCompanyUuid)
                    .And()
                    .L()
                    .iBLike(vkpi.ALGORITHM_MAN, pKeywork).Or()
                    .iBLike(vkpi.C_DESC, pKeywork).Or()
                    .iBLike(vkpi.C_DESC_GROUP, pKeywork).Or()
                    .iBLike(vkpi.C_NOTICE, pKeywork).Or()
                    .iBLike(vkpi.E_DESC, pKeywork).Or()
                    .iBLike(vkpi.E_DESC_GROUP, pKeywork).Or()
                    .iBLike(vkpi.KPI_FORMULA_DESC, pKeywork).Or()
                    .iBLike(vkpi.KPI_ID, pKeywork).Or()
                    .iBLike(vkpi.TIME_ID, pKeywork).Or()
                    .iBLike(vkpi.UNIT, pKeywork).Or()
                    .iBLike(vkpi.ZH_DESC, pKeywork)
                    .R()
                    )
                   .FetchCount();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<KpiFormula_Record> getKpiFormula_By_KpiHeadUuid(string pKpiHeadUuid,OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiFormula kpiformula = new CISR.Model.Cr.Table.KpiFormula(dbc);
                return kpiformula.Where(new SQLCondition(kpiformula)
                    .Equal(kpiformula.KPI_HEAD_UUID,pKpiHeadUuid))
                    .Limit(or)
                    .FetchAll<KpiFormula_Record>();
                //return kpiformula;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<KpiFormula_Record> getKpiFormula_By_KpiHeadUuid_TimeId(string pKpiHeadUuid,string pTimeId, OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiFormula kpiformula = new CISR.Model.Cr.Table.KpiFormula(dbc);
                return kpiformula.Where(new SQLCondition(kpiformula)
                    .Equal(kpiformula.KPI_HEAD_UUID, pKpiHeadUuid)
                    .And()
                    .Equal(kpiformula.TIME_ID,pTimeId)  
                    )                  
                    .Limit(or)
                    .FetchAll<KpiFormula_Record>();
                //return kpiformula;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<KpiFormula_Record> getKpiFormula_By_Algorithm(string pAligorithm)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiFormula kpiformula = new CISR.Model.Cr.Table.KpiFormula(dbc);
                return kpiformula.Where(new SQLCondition(kpiformula)
                    .Equal(kpiformula.ALGORITHM, pAligorithm)                    
                    )                    
                    .FetchAll<KpiFormula_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public int getKpiFormula_By_KpiHeadUuid_Count(string pKpiHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiFormula kpiformula = new CISR.Model.Cr.Table.KpiFormula(dbc);
                return kpiformula.Where(new SQLCondition(kpiformula)
                    .Equal(kpiformula.KPI_HEAD_UUID, pKpiHeadUuid))

                    .FetchCount();
                //return kpiformula;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VKpiItem_Record> getVKpiItem(string pKpiHeadUuid, OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VKpiItem vkpiItem = new CISR.Model.Cr.Table.VKpiItem(dbc);
                return vkpiItem.Where(new SQLCondition(vkpiItem)
                    .Equal(vkpiItem.KPI_HEAD_UUID, pKpiHeadUuid)
                    
                    )
                    .Limit(or)
                    .FetchAll<VKpiItem_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVKpiItem_Count(string pKpiHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VKpiItem vkpiItem = new CISR.Model.Cr.Table.VKpiItem(dbc);
                return vkpiItem.Where(new SQLCondition(vkpiItem)
                    .Equal(vkpiItem.KPI_HEAD_UUID, pKpiHeadUuid)

                    )
                    
                    .FetchCount();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<KpiPackageItem_Record> getKpiPackageItem_By_PackageHeadUuid(string pKpiPackageUuid,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiPackageItem kpipackageitem = new CISR.Model.Cr.Table.KpiPackageItem(dbc);
                return kpipackageitem.Where(new SQLCondition(kpipackageitem).Equal(kpipackageitem.KPI_PACKAGE_UUID, pKpiPackageUuid))
                    .Limit(orderlimit)
                    .FetchAll<KpiPackageItem_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<KpiPackageItem_Record> getKpiPackageItem_By_PackageHeadUuid_KpiHeadUuid(string pKpiPackageUuid,string pKpiHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiPackageItem kpipackageitem = new CISR.Model.Cr.Table.KpiPackageItem(dbc);
                return kpipackageitem.Where(new SQLCondition(kpipackageitem).Equal(kpipackageitem.KPI_PACKAGE_UUID, pKpiPackageUuid)
                    .And()
                    .Equal(kpipackageitem.KPI_HEAD_UUID,pKpiHeadUuid)
                    )                    
                    .FetchAll<KpiPackageItem_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<KpiPackageExpend_Record> getKpiPackageExpend_By_KpiPackageUuid(string pKpiPackageUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiPackageExpend kpipackageexpend = new CISR.Model.Cr.Table.KpiPackageExpend(dbc);
                return kpipackageexpend.Where(new SQLCondition(kpipackageexpend)
                    .Equal(kpipackageexpend.KPI_PACKAGE_UUID, pKpiPackageUuid))
                .FetchAll<KpiPackageExpend_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<KpiPackageExpend_Record> getKpiPackageExpend_By_KpiPackageItemUuid(string pKpiPackageItemUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiPackageExpend kpipackageexpend = new CISR.Model.Cr.Table.KpiPackageExpend(dbc);
                return kpipackageexpend.Where(new SQLCondition(kpipackageexpend)
                    .Equal(kpipackageexpend.KPI_PACKAGE_ITEM_UUID, pKpiPackageItemUuid))
                .FetchAll<KpiPackageExpend_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VKpiExp_Record> getVKpi_By_KpiPackageUuid_KeyWord(string pKpiPackageUuid, string pKeywork, OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VKpiExp vkpiexp = new CISR.Model.Cr.Table.VKpiExp(dbc);
                var sc = new SQLCondition(vkpiexp)
                    .Equal(vkpiexp.KPI_PACKAGE_UUID, pKpiPackageUuid);
                if (pKeywork.Trim().Length > 0) {
                    sc.And().L()
                        .iBLike(vkpiexp.RAW_ID, pKeywork)
                        .Or()
                        .iBLike(vkpiexp.C_DEFINE, pKeywork)
                        .Or()
                        .iBLike(vkpiexp.C_DESC, pKeywork)
                        .Or()
                        .iBLike(vkpiexp.E_DESC, pKeywork)
                        .Or()
                        .iBLike(vkpiexp.E_DEFINE, pKeywork)
                        .R();
                }
                return vkpiexp.Where(sc)
                    .Limit(or)
                    .FetchAll<VKpiExp_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<FrameItem_Record> getFrameItem_By_FrameHeadUuid(string pFrameHeadUuid,OrderLimit orderlimit)
        {
            try
            {

                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameItem frameitem = new CISR.Model.Cr.Table.FrameItem(dbc);
                return frameitem.Where(new SQLCondition(frameitem)
                    .Equal(frameitem.FRAME_HEAD_UUID, pFrameHeadUuid)
                    )
                    .Limit(orderlimit)
                    .FetchAll<FrameItem_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VFrameitem_Record> getVFrameItem_by_FrameHeadUuid_Skip(string pFrameHeadUuid,bool pSkip, OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VFrameitem vframeitem = new CISR.Model.Cr.Table.VFrameitem(dbc);
                return vframeitem.Where(new SQLCondition(vframeitem)
                    .Equal(vframeitem.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(vframeitem.SKIP,pSkip==true?"Y":"N")
                    )
                    .Limit(or)
                    .FetchAll<VFrameitem_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getVFrameItem_by_FrameHeadUuid_Skip_Count(string pFrameHeadUuid, bool pSkip)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VFrameitem vframeitem = new CISR.Model.Cr.Table.VFrameitem(dbc);
                return vframeitem.Where(new SQLCondition(vframeitem)
                    .Equal(vframeitem.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(vframeitem.SKIP, pSkip == true ? "Y" : "N")
                    )
                   .FetchCount();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public FrameItem_Record getFrameItem_By_FrameHeadUuid(string pFrameHeadUuid,string pRawHeadUuid)
        {
            try
            {

                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameItem frameitem = new CISR.Model.Cr.Table.FrameItem(dbc);
                return frameitem.Where(new SQLCondition(frameitem)
                    .Equal(frameitem.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(frameitem.RAW_HEAD_UUID, pRawHeadUuid)
                    )
                    .FetchOne<FrameItem_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


        public IList<Pwg_Record> getPwg_By_Uuid(string pGID)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Pwg pwg = new CISR.Model.Cr.Table.Pwg(dbc);
                return pwg.Where(new SQLCondition(pwg).Equal(pwg.GID, pGID))
                    .FetchAll<Pwg_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Time_Record> getTime_By_TimeType(string pTimeType,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Time time = new CISR.Model.Cr.Table.Time(dbc);
                return time.Where(new SQLCondition(time).Equal(time.TIME_TYPE, pTimeType))
                    .Limit(orderlimit)
                    .FetchAll<Time_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<FrameItem_Record> getVFrameItem_By_FrameHeadUuid_TimeType(string pFrameHeadUuid,string pTimeType, OrderLimit orderlimit)
        {
            try
            {

                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VFrameitem vframeitem = new CISR.Model.Cr.Table.VFrameitem(dbc);
                return vframeitem.Where(new SQLCondition(vframeitem)
                    .Equal(vframeitem.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(vframeitem.TIME_TYPE,pTimeType)
                    )
                    .Limit(orderlimit)
                    .FetchAll<FrameItem_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UploadJob_Record> getUploadJob_By_FrameHeadUuid_RawHeadUuid_TimeId(string pFrameHeadUuid,string pRawHeadUuid,string pTimeId)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJob uploadjob = new CISR.Model.Cr.Table.UploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)
                    .Equal(uploadjob.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(uploadjob.RAW_HEAD_UUID, pRawHeadUuid)
                    .And()
                    .Equal(uploadjob.TIME_ID, pTimeId)
                    ).FetchAll<UploadJob_Record>();
                
            }
            catch (Exception ex) 
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UploadJob_Record> getUploadJob_By_FrameHeadUuid_RawHeadUuid_TimeId(string pFrameHeadUuid, string pRawHeadUuid, string pTimeId, int pFinish)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJob uploadjob = new CISR.Model.Cr.Table.UploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)
                    .Equal(uploadjob.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(uploadjob.RAW_HEAD_UUID, pRawHeadUuid)
                    .And()
                    .Equal(uploadjob.TIME_ID, pTimeId).And()
                    .Equal(uploadjob.FINISH, pFinish)
                    ).FetchAll<UploadJob_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UploadJob_Record> getVUploadJob_By_FrameHeadUuid_RawHeadUuid_TimeId(string pFrameHeadUuid, string pRawHeadUuid, string pTimeId, int pFinish)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJob uploadjob = new CISR.Model.Cr.Table.UploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)
                    .Equal(uploadjob.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(uploadjob.RAW_HEAD_UUID, pRawHeadUuid)
                    .And()
                    .Equal(uploadjob.TIME_ID, pTimeId)
                    .And()
                    .Equal(uploadjob.FINISH,pFinish)
                    ).FetchAll<UploadJob_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UploadJob_Record> getVUploadJobValue_EndLikeFullFrameHeadUuid(string pFullFrameHeadUuid, string pRawHeadUuid, string pTimeId, int pFinish)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob uploadjob = new CISR.Model.Cr.Table.VUploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)
                    .ELike(uploadjob.FULL_FRAME_UUID_LIST, pFullFrameHeadUuid)
                    .And()
                    .Equal(uploadjob.RAW_HEAD_UUID, pRawHeadUuid)
                    .And()
                    .Equal(uploadjob.TIME_ID, pTimeId)
                    .And()
                    .Equal(uploadjob.FINISH, pFinish)
                    ).FetchAll<UploadJob_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UploadJob_Record> getVUploadJobValue_FullFrameHeadUuid(string pFullFrameHeadUuid, string pRawHeadUuid, string pTimeId, int pFinish)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob uploadjob = new CISR.Model.Cr.Table.VUploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)
                    .Equal(uploadjob.FULL_FRAME_UUID_LIST, pFullFrameHeadUuid)
                    .And()
                    .Equal(uploadjob.RAW_HEAD_UUID, pRawHeadUuid)
                    .And()
                    .Equal(uploadjob.TIME_ID, pTimeId)
                    .And()
                    .Equal(uploadjob.FINISH, pFinish)
                    ).FetchAll<UploadJob_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<UploadJob_Record> getUploadJob_By_TimeId_Finish(string pTimeId,int pFinish)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJob uploadjob = new CISR.Model.Cr.Table.UploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)                    
                    .Equal(uploadjob.TIME_ID, pTimeId)
                    .And()
                    .Equal(uploadjob.FINISH,pFinish)
                    ).FetchAll<UploadJob_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<VUploadJob_Record> getVUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid(string pTimeType, string pTimeId, string pAttendantUuid, string pKeyword, string pFrameHeadUuid, OrderLimit orderlimit)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob vuploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(vuploadJob);

                if (pTimeType.Trim().Length > 0) {
                    sc.Equal(vuploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.TIME_ID, pTimeId).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();
                    sc.BLike(vuploadJob.DWG1_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG2_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG3_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG4_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG5_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.EXPLAIN, pKeyword).Or();
                    sc.BLike(vuploadJob.FULL_FRAME_NAME_LIST, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_C_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_E_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.REGION_NAME, pKeyword).Or();
                    sc.BLike(vuploadJob.VALUE, pKeyword);
                    sc.R();
                }

                if (pFrameHeadUuid.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.FRAME_HEAD_UUID, pFrameHeadUuid).And();
                }

                if (pAttendantUuid.Trim().Length > 0)
                {                    
                    sc.BLike(vuploadJob.FULL_ATTENDANT_UUID, pAttendantUuid);
                }


                sc.CheckSQL();

                return vuploadJob.Where(sc)
                .Limit(orderlimit)
                .FetchAll<VUploadJob_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


        public Int32 getVUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid_Count(string pTimeType, string pTimeId, string pAttendantUuid, string pKeyword, string pFrameHeadUuid)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob vuploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(vuploadJob);

                if (pTimeType.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.TIME_ID, pTimeId).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();
                    sc.BLike(vuploadJob.DWG1_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG2_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG3_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG4_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.DWG5_SHOW, pKeyword).Or();
                    sc.BLike(vuploadJob.EXPLAIN, pKeyword).Or();
                    sc.BLike(vuploadJob.FULL_FRAME_NAME_LIST, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_C_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_E_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.REGION_NAME, pKeyword).Or();
                    sc.BLike(vuploadJob.VALUE, pKeyword);
                    sc.R();
                }

                if (pFrameHeadUuid.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.FRAME_HEAD_UUID, pFrameHeadUuid).And();
                }

                if (pAttendantUuid.Trim().Length > 0)
                {
                    sc.BLike(vuploadJob.FULL_ATTENDANT_UUID, pAttendantUuid);
                }

                sc.CheckSQL();

                return vuploadJob.Where(sc)
                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VUploadJob_Record> getMyUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid(string pTimeType, string pTimeId, string pAttendantUuid, string pKeyword, string pFrameHeadUuid, OrderLimit orderlimit)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob vuploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(vuploadJob);

                if (pTimeType.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.TIME_ID, pTimeId).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();                
                    sc.BLike(vuploadJob.EXPLAIN, pKeyword).Or();
                    sc.BLike(vuploadJob.FULL_FRAME_NAME_LIST, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_C_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_E_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.REGION_NAME, pKeyword).Or();
                    sc.BLike(vuploadJob.VALUE, pKeyword);
                    sc.R();
                }

                if (pFrameHeadUuid.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.FRAME_HEAD_UUID, pFrameHeadUuid).And();
                }

                sc.BLike(vuploadJob.NOW_ATTENDANT_UUID, pAttendantUuid).And().Equal(vuploadJob.FINISH,0);
                


                sc.CheckSQL();

                return vuploadJob.Where(sc)
                .Limit(orderlimit)
                .FetchAll<VUploadJob_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VUploadJob_Record> getMyUploadJobHistory_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid(string pTimeType, string pTimeId, string pAttendantUuid, string pKeyword, string pFrameHeadUuid, OrderLimit orderlimit)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob vuploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(vuploadJob);

                if (pTimeType.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.TIME_ID, pTimeId).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();
                    sc.BLike(vuploadJob.EXPLAIN, pKeyword).Or();
                    sc.BLike(vuploadJob.FULL_FRAME_NAME_LIST, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_C_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_E_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.REGION_NAME, pKeyword).Or();
                    sc.BLike(vuploadJob.VALUE, pKeyword);
                    sc.R();
                }

                if (pFrameHeadUuid.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.FRAME_HEAD_UUID, pFrameHeadUuid).And();
                }

                sc.BLike(vuploadJob.FULL_ATTENDANT_UUID, pAttendantUuid).And().Equal(vuploadJob.FINISH, 1);



                sc.CheckSQL();

                return vuploadJob.Where(sc)
                .Limit(orderlimit)
                .FetchAll<VUploadJob_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getMyUploadJob_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid_Count(string pTimeType, string pTimeId, string pAttendantUuid, string pKeyword, string pFrameHeadUuid)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob vuploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(vuploadJob);

                if (pTimeType.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.TIME_ID, pTimeId).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();
                    sc.BLike(vuploadJob.EXPLAIN, pKeyword).Or();
                    sc.BLike(vuploadJob.FULL_FRAME_NAME_LIST, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_C_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_E_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.REGION_NAME, pKeyword).Or();
                    sc.BLike(vuploadJob.VALUE, pKeyword);
                    sc.R();
                }

                if (pFrameHeadUuid.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.FRAME_HEAD_UUID, pFrameHeadUuid).And();
                }

                sc.BLike(vuploadJob.NOW_ATTENDANT_UUID, pAttendantUuid).And().Equal(vuploadJob.FINISH, 0);



                sc.CheckSQL();

                return vuploadJob.Where(sc)

                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getMyUploadJobHistory_TimeType_TimeId_AttendnatnUuid_Keyword_FrameHeadUuid_Count(string pTimeType, string pTimeId, string pAttendantUuid, string pKeyword, string pFrameHeadUuid)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob vuploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(vuploadJob);

                if (pTimeType.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.TIME_ID, pTimeId).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();
                    sc.BLike(vuploadJob.EXPLAIN, pKeyword).Or();
                    sc.BLike(vuploadJob.FULL_FRAME_NAME_LIST, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_C_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.RAW_E_DESC, pKeyword).Or();
                    sc.BLike(vuploadJob.REGION_NAME, pKeyword).Or();
                    sc.BLike(vuploadJob.VALUE, pKeyword);
                    sc.R();
                }

                if (pFrameHeadUuid.Trim().Length > 0)
                {
                    sc.Equal(vuploadJob.FRAME_HEAD_UUID, pFrameHeadUuid).And();
                }

                sc.BLike(vuploadJob.FULL_ATTENDANT_UUID, pAttendantUuid).And().Equal(vuploadJob.FINISH, 1);



                sc.CheckSQL();

                return vuploadJob.Where(sc)

                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<Dwg_Record> getDwg_By_AttendantUuid( string pATTENDANT_UUID)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Dwg dwg = new CISR.Model.Cr.Table.Dwg(dbc);
                return dwg.Where(new SQLCondition(dwg).Equal(dwg.ATTENDANT_UUID, pATTENDANT_UUID))
                    .FetchAll<Dwg_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UploadJobLog_Record> getUploadJobLog_By_UploadJobUuid(string pUploadJobUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJobLog uploadjoblog = new CISR.Model.Cr.Table.UploadJobLog(dbc);
                return uploadjoblog.Where(new SQLCondition(uploadjoblog)
                    .Equal(uploadjoblog.UPLOAD_JOB_UUID, pUploadJobUuid)
                    ).FetchAll<UploadJobLog_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<UploadJobLog_Record> getUploadJobLog_By_UploadJobUuid(string pUploadJobUuid,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJobLog uploadjoblog = new CISR.Model.Cr.Table.UploadJobLog(dbc);
                return uploadjoblog.Where(new SQLCondition(uploadjoblog)
                    .Equal(uploadjoblog.UPLOAD_JOB_UUID, pUploadJobUuid)
                    )
                    .Limit(orderlimit)
                        .FetchAll<UploadJobLog_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getUploadJobLog_By_UploadJobUuid_Count(string pUploadJobUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJobLog uploadjoblog = new CISR.Model.Cr.Table.UploadJobLog(dbc);
                return uploadjoblog.Where(new SQLCondition(uploadjoblog)
                    .Equal(uploadjoblog.UPLOAD_JOB_UUID, pUploadJobUuid)
                    )

                    .FetchCount();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<UploadJob_Record> getUploadJob_By_FileGroupId(string pFileGroupId)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.UploadJob uploadjob = new CISR.Model.Cr.Table.UploadJob(dbc);
                return uploadjob.Where(new SQLCondition(uploadjob)
                    .Equal(uploadjob.FILES_GROUP_ID, pFileGroupId)
                    ).FetchAll<UploadJob_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<Files_Record> getFiles_By_FileGroupId(string pFileGroupId,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Files files = new CISR.Model.Cr.Table.Files(dbc);
                return files.Where(new SQLCondition(files)
                    .Equal(files.FILES_GROUP_ID, pFileGroupId)
                    )
                    .Limit(orderlimit)
                    .FetchAll<Files_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getFiles_By_FileGroupId_Count(string pFileGroupId)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Files files = new CISR.Model.Cr.Table.Files(dbc);
                return files.Where(new SQLCondition(files)
                    .Equal(files.FILES_GROUP_ID, pFileGroupId)
                    ).FetchCount();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Dwg_Record> getDwg_By_DwgGid(string pDWG_GID)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Dwg dwg = new CISR.Model.Cr.Table.Dwg(dbc);
                return dwg.Where(new SQLCondition(dwg).Equal(dwg.DWG_GID, pDWG_GID))
                    .FetchAll<Dwg_Record>();
                    
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<FrameHead_Record> getFrameHead_By_EndLike_FullFrameHeadUuid(string pFullFrameHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameHead framehead = new CISR.Model.Cr.Table.FrameHead(dbc);
                return framehead.Where(new SQLCondition(framehead)
                    .ELike(framehead.FULL_FRAME_UUID_LIST,pFullFrameHeadUuid))
                    .FetchAll<FrameHead_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<FrameHead_Record> getFrameHead_By_ParentFrameHeadUuid(string pParentFrameHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameHead framehead = new CISR.Model.Cr.Table.FrameHead(dbc);
                return framehead.Where(new SQLCondition(framehead)
                    .ELike(framehead.PARENT_FRAME_HEAD_UUID, pParentFrameHeadUuid))
                    .FetchAll<FrameHead_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Cal_Record> getCal_By_FrameHeadUuid_TimeID_KpiHeadUuid(string pFrameHeadUuid, string pTimeId, string pKpiHeadUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Cal cal = new CISR.Model.Cr.Table.Cal(dbc);
                return cal.Where(new SQLCondition(cal)
                    .Equal(cal.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(cal.TIME_ID, pTimeId)
                    .And()
                    .Equal(cal.KPI_HEAD_UUID, pKpiHeadUuid)
                    )
                    .FetchAll<Cal_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<Cal_Record> getCal_By_FrameHeadUuid_TimeID(string pFrameHeadUuid, string pTimeId)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Cal cal = new CISR.Model.Cr.Table.Cal(dbc);
                return cal.Where(new SQLCondition(cal)
                    .Equal(cal.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(cal.TIME_ID, pTimeId)                    
                    )
                    .FetchAll<Cal_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VCal_Record> getVCal_By_Wait()
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VCal cal = new CISR.Model.Cr.Table.VCal(dbc);
                return cal.Where(new SQLCondition(cal)
                    .Equal(cal.STATUS,"W")                    
                    )
                    .OrderASC("TIME_ID,ORD")
                    .FetchAll<VCal_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VCal_Record> getVCal_Distinct_TimeId_By_Wait()
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VCal cal = new CISR.Model.Cr.Table.VCal(dbc);
                return cal.Where(new SQLCondition(cal)
                    .Equal(cal.STATUS, "W")
                    )
                    .Select("DISTINCT TIME_ID AS TIME_ID")
                    .FetchAll<VCal_Record>();
                    

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<Cal_Record> getCal_By_FrameHeadUuid_TimeID_Ord(string pFrameHeadUuid, string pTimeId,string pOrd)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.Cal cal = new CISR.Model.Cr.Table.Cal(dbc);
                return cal.Where(new SQLCondition(cal)
                    .Equal(cal.FRAME_HEAD_UUID, pFrameHeadUuid)
                    .And()
                    .Equal(cal.TIME_ID, pTimeId)
                    .And()
                    .Equal(cal.ORD,pOrd)
                    )
                    .FetchAll<Cal_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        

        public IList<VCal_Record> getVCal_By_TimeId_Keyword_FrameHeadUuid(string pTimeId,string pTimeId2,string pKeyword,string pFullFrameHeadUuid,string pStatus,string pKeyType,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VCal vcal = new CISR.Model.Cr.Table.VCal(dbc);
                var sc = new SQLCondition(vcal);

                if (pTimeId.Trim().Length > 0 && pTimeId2.Trim().Length > 0)
                {
                    sc.L()
                        .OverEqual(vcal.TIME_ID, pTimeId).And()
                        .LessEqual(vcal.TIME_ID,pTimeId2)
                      .R().And();
                }
                else if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vcal.TIME_ID, pTimeId).And();
                }
                    

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();
                    sc.BLike(vcal.C_DESC, pKeyword).Or()
                        .BLike(vcal.C_NAME, pKeyword).Or()
                        .BLike(vcal.KPI_ID,pKeyword).Or()
                        .BLike(vcal.KPI_ALIASES,pKeyword);
                    sc.R().And();
                }
                    

                if (pFullFrameHeadUuid.Trim().Length > 0)
                    sc.ELike(vcal.FULL_FRAME_UUID_LIST, pFullFrameHeadUuid).And();

                if (pStatus.Trim().Length > 0)
                {
                    if (pStatus.ToUpper() == "COMPLETE") {
                        sc.Equal(vcal.STATUS, "Y").And();
                    }
                    else if (pStatus.ToUpper() == "ERROR") {
                        sc.L().Equal(vcal.STATUS, "D").Or().Equal(vcal.STATUS,"E").R().And();
                    }
                    else if (pStatus.ToUpper() == "WAIT")
                    {
                        sc.Equal(vcal.STATUS, "W").And();
                    }

                }

                if (pKeyType.Trim().Length > 0) {
                    sc.ELike(vcal.KPI_ID, pKeyType);
                }

                sc.CheckSQL();

                return vcal.Where(sc)
                    .Limit(orderlimit)
                    .FetchAll<VCal_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public int getVCal_By_TimeId_Keyword_FrameHeadUuid_Count(string pTimeId, string pTimeId2, string pKeyword, string pFullFrameHeadUuid, string pStatus, string pKpiType)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VCal vcal = new CISR.Model.Cr.Table.VCal(dbc);
                var sc = new SQLCondition(vcal);

                if (pTimeId.Trim().Length > 0 && pTimeId2.Trim().Length > 0)
                {
                    sc.L()
                        .OverEqual(vcal.TIME_ID, pTimeId).And()
                        .LessEqual(vcal.TIME_ID, pTimeId2)
                      .R().And();
                }
                else if (pTimeId.Trim().Length > 0)
                {
                    sc.Equal(vcal.TIME_ID, pTimeId).And();
                }

                if (pKeyword.Trim().Length > 0)
                {
                    sc.L();
                    sc.BLike(vcal.C_DESC, pKeyword).Or()
                        .BLike(vcal.C_NAME, pKeyword).Or()
                        .BLike(vcal.KPI_ID, pKeyword).Or()
                        .BLike(vcal.KPI_ALIASES, pKeyword);
                    sc.R().And();
                }


                if (pFullFrameHeadUuid.Trim().Length > 0)
                    sc.ELike(vcal.FULL_FRAME_UUID_LIST, pFullFrameHeadUuid).And();

                if (pStatus.Trim().Length > 0)
                {
                    if (pStatus.ToUpper() == "COMPLETE")
                    {
                        sc.Equal(vcal.STATUS, "Y").And();
                    }
                    else if (pStatus.ToUpper() == "ERROR")
                    {
                        sc.L().Equal(vcal.STATUS, "D").Or().Equal(vcal.STATUS, "E").R().And();
                    }
                    else if (pStatus.ToUpper() == "WAIT")
                    {
                        sc.Equal(vcal.STATUS, "W").And();
                    }

                }

                if (pKpiType.Trim().Length > 0) {
                    sc.ELike(vcal.KPI_ID, pKpiType);
                }
                sc.CheckSQL();

                return vcal.Where(sc)
                  .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public RawHead_Record getRawHead_By_RawId(string pRawId,string pCompanyUuid)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.RawHead rawhead = new CISR.Model.Cr.Table.RawHead(dbc);
                return rawhead.Where(new SQLCondition(rawhead)
                    .Equal(rawhead.RAW_ID, pRawId)
                    .And()
                    .Equal(rawhead.COMPANY_UUID, pCompanyUuid)
                    )
                    .FetchOne<RawHead_Record>();                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public Int32 getVUploadJob_By_Attendant_Finish_TimeType_Count(string pAttendantUuid,string pTimeType,int pFinish)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob uploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(uploadJob);

                if (pTimeType.Trim().Length > 0)
                {
                    sc.BLike(uploadJob.NOW_ATTENDANT_UUID,pAttendantUuid).And();
                }

                if (pTimeType.Trim().Length > 0)
                {
                    sc.Equal(uploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pFinish.ToString().Trim().Length > 0)
                {
                    sc.Equal(uploadJob.FINISH, pFinish).And();
                }
                sc.CheckSQL();
                return uploadJob.Where(sc)
                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


        public Int32 getVUploadJob_By_FullAttendant_Finish_TimeType_Count(string pAttendantUuid, string pTimeType, int pFinish)
        {
            CrModel mod = new CrModel();
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VUploadJob uploadJob = new CISR.Model.Cr.Table.VUploadJob(dbc);

                var sc = new SQLCondition(uploadJob);

                if (pTimeType.Trim().Length > 0)
                {
                    sc.BLike(uploadJob.FULL_ATTENDANT_UUID, pAttendantUuid).And();
                }

                if (pTimeType.Trim().Length > 0)
                {
                    sc.Equal(uploadJob.RAW_TIME_TYPE, pTimeType).And();
                }

                if (pFinish.ToString().Trim().Length > 0)
                {
                    sc.Equal(uploadJob.FINISH, pFinish).And();
                }
                sc.CheckSQL();
                return uploadJob.Where(sc)
                .FetchCount();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<FrameCategory_Record> getFrameCategory(OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameCategory framehead = new CISR.Model.Cr.Table.FrameCategory(dbc);
                return framehead.Where(new SQLCondition(framehead)
                    )
                    .Limit(orderlimit)
                    .FetchAll<FrameCategory_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<FrameCategory_Record> getFrameCategory(string pKeyword,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameCategory framehead = new CISR.Model.Cr.Table.FrameCategory(dbc);
                return framehead.Where(new SQLCondition(framehead)
                .BLike(framehead.FRAME_CATEGORY_NAME,pKeyword)
                    )
                    .Limit(orderlimit)
                    .FetchAll<FrameCategory_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<KpiPackage_Record> getKpiPackage_All()
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.KpiPackage kpipackage = new CISR.Model.Cr.Table.KpiPackage(dbc);
                return kpipackage.Where(new SQLCondition(kpipackage))
                    .FetchAll<KpiPackage_Record>();                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<ChartList_Record> getChartList_By_Attendant(string pAttendantUuid,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.ChartList chartlist = new CISR.Model.Cr.Table.ChartList(dbc);
                return chartlist.Where(new SQLCondition(chartlist)
                    .Equal(chartlist.ATTENDANT_UUID, pAttendantUuid))
                    .Limit(orderlimit)
                    .FetchAll<ChartList_Record>();
                
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }

        public IList<VFrameHead_Record> getVFrameHead_by_PrrentFrameHeadUuid(string pFrameHeadUuid, OrderLimit or)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.VFrameHead vframehead = new CISR.Model.Cr.Table.VFrameHead(dbc);
                return vframehead.Where(new SQLCondition(vframehead)
                    .Equal(vframehead.PARENT_FRAME_HEAD_UUID, pFrameHeadUuid)                    
                    )
                    .Limit(or)
                    .FetchAll<VFrameHead_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


        public IList<FrameCategory_Record> getFrameCategory_InUuid(List<object> uuid,OrderLimit orderlimit)
        {
            try
            {
                dbc = IST.Config.DataBase.Factory.getInfo();
                CISR.Model.Cr.Table.FrameCategory framecategory = new CISR.Model.Cr.Table.FrameCategory(dbc);
                return framecategory.Where(new SQLCondition(framecategory)
                .In(framecategory.UUID, uuid)
                    )
                    .Limit(orderlimit)
                    .FetchAll<FrameCategory_Record>();

            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }


	}

   
}
