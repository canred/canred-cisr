using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IST.Attribute;
using IST.DB;
using IST.Config.DataBase;
using IST.DB.SQLCreater;
using CISR.Controller.Model.Basic.Table.Record;
namespace CISR.Controller.Model.Basic.Table
{
    [ISTDataBase("BASIC")]
    [ISTTableView("SCHEDULE", true)]
    public partial class Schedule : TableBase
    {
        /*固定物件*/
        //IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
        /*固定物件但名稱需更新*/
        private Schedule_Record _currentRecord = null;
        private IList<Schedule_Record> _All_Record = new List<Schedule_Record>();
        /*建構子*/
        public Schedule() { }
        public Schedule(IDataBaseConfigInfo dbc, string db) : base(dbc, db) { }
        public Schedule(IDataBaseConfigInfo dbc) : base(dbc) { }
        public Schedule(IDataBaseConfigInfo dbc, Schedule_Record currenData)
        {
            this.setDataBaseConfigInfo(dbc);
            this._currentRecord = currenData;
        }
        public Schedule(IList<Schedule_Record> currenData)
        {
            this._All_Record = currenData;
        }
        /*欄位資訊 Start*/
        public string UUID { get { return "UUID"; } }
        public string SCHEDULE_NAME { get { return "SCHEDULE_NAME"; } }
        public string SCHEDULE_END_DATE { get { return "SCHEDULE_END_DATE"; } }
        public string LAST_RUN_TIME { get { return "LAST_RUN_TIME"; } }
        public string LAST_RUN_STATUS { get { return "LAST_RUN_STATUS"; } }
        public string IS_CYCLE { get { return "IS_CYCLE"; } }
        public string SINGLE_DATE { get { return "SINGLE_DATE"; } }
        public string HOUR { get { return "HOUR"; } }
        public string MINUTE { get { return "MINUTE"; } }
        public string CYCLE_TYPE { get { return "CYCLE_TYPE"; } }
        public string C_MINUTE { get { return "C_MINUTE"; } }
        public string C_HOUR { get { return "C_HOUR"; } }
        public string C_DAY { get { return "C_DAY"; } }
        public string C_WEEK { get { return "C_WEEK"; } }
        public string C_DAY_OF_WEEK { get { return "C_DAY_OF_WEEK"; } }
        public string C_MONTH { get { return "C_MONTH"; } }
        public string C_DAY_OF_MONTH { get { return "C_DAY_OF_MONTH"; } }
        public string C_WEEK_OF_MONTH { get { return "C_WEEK_OF_MONTH"; } }
        public string C_YEAR { get { return "C_YEAR"; } }
        public string C_WEEK_OF_YEAR { get { return "C_WEEK_OF_YEAR"; } }
        public string RUN_URL { get { return "RUN_URL"; } }
        public string RUN_URL_PARAMETER { get { return "RUN_URL_PARAMETER"; } }
        public string RUN_ATTENDANT_UUID { get { return "RUN_ATTENDANT_UUID"; } }
        public string IS_ACTIVE { get { return "IS_ACTIVE"; } }
        public string START_DATE { get { return "START_DATE"; } }
        public string RUN_SECURITY { get { return "RUN_SECURITY"; } }
        public string EXPEND_ALL { get { return "EXPEND_ALL"; } }
        public string CONTIUNE_DATETIME { get { return "CONTIUNE_DATETIME"; } }
        /*欄位資訊 End*/
        /*固定的方法，但名稱需變更 Start*/
        public Schedule_Record CurrentRecord()
        {
            try
            {
                if (_currentRecord == null)
                {
                    if (this._All_Record.Count > 0)
                    {
                        _currentRecord = this._All_Record.First();
                    }
                }
                return _currentRecord;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public Schedule_Record CreateNew()
        {
            try
            {
                Schedule_Record newData = new Schedule_Record();
                return newData;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<Schedule_Record> AllRecord()
        {
            try
            {
                return _All_Record;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public void RemoveAllRecord()
        {
            try
            {
                _All_Record = new List<Schedule_Record>();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*固定的方法，但名稱需變更 End*/
        /*有關PK的方法*/
        //TEMPLATE TABLE 201303180156
        public Schedule Fill_By_PK(string pUUID)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>();
                _All_Record = ret;
                if (_All_Record.Count > 0)
                {
                    _currentRecord = ret.First();
                }
                else
                {
                    _currentRecord = null;
                }
                return this;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 201303180156
        public Schedule Fill_By_PK(string pUUID, DB db)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>(db);
                _All_Record = ret;
                if (_All_Record.Count > 0)
                {
                    _currentRecord = ret.First();
                }
                else
                {
                    _currentRecord = null;
                }
                return this;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319042
        public Schedule_Record Fetch_By_PK(string pUUID)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319044
        public Schedule_Record Fetch_By_PK(string pUUID, DB db)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>(db);
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319045
        public Schedule Fill_By_Uuid(string pUUID)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>();
                _All_Record = ret;
                _currentRecord = ret.First();
                return this;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319046
        public Schedule Fill_By_Uuid(string pUUID, DB db)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>(db);
                _All_Record = ret;
                _currentRecord = ret.First();
                return this;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319047
        public Schedule_Record Fetch_By_Uuid(string pUUID)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.ErrorNoThrowException(this, ex);
                return null;
            }
        }
        //TEMPLATE TABLE 20130319048
        public Schedule_Record Fetch_By_Uuid(string pUUID, DB db)
        {
            try
            {
                IList<Schedule_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<Schedule_Record>(db);
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*利用物件自已的AllRecord的資料來更新資料行*/
        public void UpdateAllRecord()
        {
            try
            {
                UpdateAllRecord<Schedule_Record>(this.AllRecord());
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*利用物件自已的AllRecord的資料來更新資料行*/
        public void UpdateAllRecord(DB db)
        {
            try
            {
                UpdateAllRecord<Schedule_Record>(this.AllRecord(), db);
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*利用物件自已的AllRecord的資料來新增資料行*/
        public void InsertAllRecord()
        {
            try
            {
                InsertAllRecord<Schedule_Record>(this.AllRecord());
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*利用物件自已的AllRecord的資料來新增資料行*/
        public void InsertAllRecord(DB db)
        {
            try
            {
                InsertAllRecord<Schedule_Record>(this.AllRecord(), db);
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*利用物件自已的AllRecord的資料來刪除資料行*/
        public void DeleteAllRecord()
        {
            try
            {
                DeleteAllRecord<Schedule_Record>(this.AllRecord());
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*利用物件自已的AllRecord的資料來刪除資料行*/
        public void DeleteAllRecord(DB db)
        {
            try
            {
                DeleteAllRecord<Schedule_Record>(this.AllRecord(), db);
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*依照資料表與資料表的關係，產生出來的方法*/
        /*201303180320*/
        public List<VScheduleTime_Record> Link_VScheduleTime_By_ScheduleUuid()
        {
            try
            {
                List<VScheduleTime_Record> ret = new List<VScheduleTime_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                VScheduleTime ___table = new VScheduleTime(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.SCHEDULE_UUID, item.UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<VScheduleTime_Record>)
                        ___table.Where(condition)
                        .FetchAll<VScheduleTime_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180320*/
        public List<ScheduleTime_Record> Link_ScheduleTime_By_ScheduleUuid()
        {
            try
            {
                List<ScheduleTime_Record> ret = new List<ScheduleTime_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                ScheduleTime ___table = new ScheduleTime(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.SCHEDULE_UUID, item.UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<ScheduleTime_Record>)
                        ___table.Where(condition)
                        .FetchAll<ScheduleTime_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180321*/
        public List<VScheduleTime_Record> Link_VScheduleTime_By_ScheduleUuid(OrderLimit limit)
        {
            try
            {
                List<VScheduleTime_Record> ret = new List<VScheduleTime_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                VScheduleTime ___table = new VScheduleTime(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.SCHEDULE_UUID, item.UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<VScheduleTime_Record>)
                        ___table.Where(condition)
                        .Order(limit)
                        .Limit(limit)
                        .FetchAll<VScheduleTime_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180321*/
        public List<ScheduleTime_Record> Link_ScheduleTime_By_ScheduleUuid(OrderLimit limit)
        {
            try
            {
                List<ScheduleTime_Record> ret = new List<ScheduleTime_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                ScheduleTime ___table = new ScheduleTime(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.SCHEDULE_UUID, item.UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<ScheduleTime_Record>)
                        ___table.Where(condition)
                        .Order(limit)
                        .Limit(limit)
                        .FetchAll<ScheduleTime_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180324*/
        public VScheduleTime LinkFill_VScheduleTime_By_ScheduleUuid()
        {
            try
            {
                var data = Link_VScheduleTime_By_ScheduleUuid();
                VScheduleTime ret = new VScheduleTime(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180324*/
        public ScheduleTime LinkFill_ScheduleTime_By_ScheduleUuid()
        {
            try
            {
                var data = Link_ScheduleTime_By_ScheduleUuid();
                ScheduleTime ret = new ScheduleTime(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180325*/
        public VScheduleTime LinkFill_VScheduleTime_By_ScheduleUuid(OrderLimit limit)
        {
            try
            {
                var data = Link_VScheduleTime_By_ScheduleUuid(limit);
                VScheduleTime ret = new VScheduleTime(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180325*/
        public ScheduleTime LinkFill_ScheduleTime_By_ScheduleUuid(OrderLimit limit)
        {
            try
            {
                var data = Link_ScheduleTime_By_ScheduleUuid(limit);
                ScheduleTime ret = new ScheduleTime(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
    }
}
