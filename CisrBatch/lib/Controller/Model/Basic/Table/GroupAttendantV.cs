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
    [ISTTableView("GROUP_ATTENDANT_V", false)]
    public partial class GroupAttendantV : TableBase
    {
        /*固定物件*/
        //IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
        /*固定物件但名稱需更新*/
        private GroupAttendantV_Record _currentRecord = null;
        private IList<GroupAttendantV_Record> _All_Record = new List<GroupAttendantV_Record>();
        /*建構子*/
        public GroupAttendantV() { }
        public GroupAttendantV(IDataBaseConfigInfo dbc, string db) : base(dbc, db) { }
        public GroupAttendantV(IDataBaseConfigInfo dbc) : base(dbc) { }
        public GroupAttendantV(IDataBaseConfigInfo dbc, GroupAttendantV_Record currenData)
        {
            this.setDataBaseConfigInfo(dbc);
            this._currentRecord = currenData;
        }
        public GroupAttendantV(IList<GroupAttendantV_Record> currenData)
        {
            this._All_Record = currenData;
        }
        /*欄位資訊 Start*/
        public string GROUP_NAME_ZH_TW { get { return "GROUP_NAME_ZH_TW"; } }
        public string GROUP_NAME_ZH_CN { get { return "GROUP_NAME_ZH_CN"; } }
        public string GROUP_NAME_EN_US { get { return "GROUP_NAME_EN_US"; } }
        public string IS_GROUP_ACTIVE { get { return "IS_GROUP_ACTIVE"; } }
        public string COMPANY_UUID { get { return "COMPANY_UUID"; } }
        public string COMPANY_ID { get { return "COMPANY_ID"; } }
        public string COMPANY_C_NAME { get { return "COMPANY_C_NAME"; } }
        public string COMPANY_E_NAME { get { return "COMPANY_E_NAME"; } }
        public string GROUP_ID { get { return "GROUP_ID"; } }
        public string APPLICATION_HEAD_UUID { get { return "APPLICATION_HEAD_UUID"; } }
        public string ATTENDANT_C_NAME { get { return "ATTENDANT_C_NAME"; } }
        public string ATTENDANT_E_NAME { get { return "ATTENDANT_E_NAME"; } }
        public string ACCOUNT { get { return "ACCOUNT"; } }
        public string EMAIL { get { return "EMAIL"; } }
        public string IS_ATTENDANT_ACTIVE { get { return "IS_ATTENDANT_ACTIVE"; } }
        public string UUID { get { return "UUID"; } }
        public string CREATE_DATE { get { return "CREATE_DATE"; } }
        public string UPDATE_DATE { get { return "UPDATE_DATE"; } }
        public string IS_ACTIVE { get { return "IS_ACTIVE"; } }
        public string GROUP_HEAD_UUID { get { return "GROUP_HEAD_UUID"; } }
        public string ATTENDANT_UUID { get { return "ATTENDANT_UUID"; } }
        public string DEPARTMENT_UUID { get { return "DEPARTMENT_UUID"; } }
        /*欄位資訊 End*/
        /*固定的方法，但名稱需變更 Start*/
        public GroupAttendantV_Record CurrentRecord()
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
        public GroupAttendantV_Record CreateNew()
        {
            try
            {
                GroupAttendantV_Record newData = new GroupAttendantV_Record();
                return newData;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<GroupAttendantV_Record> AllRecord()
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
                _All_Record = new List<GroupAttendantV_Record>();
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
        public GroupAttendantV Fill_By_PK(string pUUID)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>();
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
        public GroupAttendantV Fill_By_PK(string pUUID, DB db)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>(db);
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
        public GroupAttendantV_Record Fetch_By_PK(string pUUID)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319044
        public GroupAttendantV_Record Fetch_By_PK(string pUUID, DB db)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>(db);
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319045
        public GroupAttendantV Fill_By_Uuid(string pUUID)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>();
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
        public GroupAttendantV Fill_By_Uuid(string pUUID, DB db)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>(db);
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
        public GroupAttendantV_Record Fetch_By_Uuid(string pUUID)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.ErrorNoThrowException(this, ex);
                return null;
            }
        }
        //TEMPLATE TABLE 20130319048
        public GroupAttendantV_Record Fetch_By_Uuid(string pUUID, DB db)
        {
            try
            {
                IList<GroupAttendantV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, pUUID)
                ).FetchAll<GroupAttendantV_Record>(db);
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*依照資料表與資料表的關係，產生出來的方法*/
        public List<Attendant_Record> Link_Attendant_By_Uuid()
        {
            try
            {
                List<Attendant_Record> ret = new List<Attendant_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                Attendant ___table = new Attendant(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.ATTENDANT_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<Attendant_Record>)
                        ___table.Where(condition)
                        .FetchAll<Attendant_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public List<Company_Record> Link_Company_By_Uuid()
        {
            try
            {
                List<Company_Record> ret = new List<Company_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                Company ___table = new Company(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.COMPANY_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<Company_Record>)
                        ___table.Where(condition)
                        .FetchAll<Company_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public List<GroupHead_Record> Link_GroupHead_By_Uuid()
        {
            try
            {
                List<GroupHead_Record> ret = new List<GroupHead_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                GroupHead ___table = new GroupHead(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.GROUP_HEAD_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<GroupHead_Record>)
                        ___table.Where(condition)
                        .FetchAll<GroupHead_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180340*/
        public List<Attendant_Record> Link_Attendant_By_Uuid(OrderLimit limit)
        {
            try
            {
                List<Attendant_Record> ret = new List<Attendant_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                Attendant ___table = new Attendant(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.ATTENDANT_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<Attendant_Record>)
                        ___table.Where(condition)
                        .Order(limit)
                        .Limit(limit)
                        .FetchAll<Attendant_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180340*/
        public List<Company_Record> Link_Company_By_Uuid(OrderLimit limit)
        {
            try
            {
                List<Company_Record> ret = new List<Company_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                Company ___table = new Company(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.COMPANY_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<Company_Record>)
                        ___table.Where(condition)
                        .Order(limit)
                        .Limit(limit)
                        .FetchAll<Company_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180340*/
        public List<GroupHead_Record> Link_GroupHead_By_Uuid(OrderLimit limit)
        {
            try
            {
                List<GroupHead_Record> ret = new List<GroupHead_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                GroupHead ___table = new GroupHead(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.GROUP_HEAD_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<GroupHead_Record>)
                        ___table.Where(condition)
                        .Order(limit)
                        .Limit(limit)
                        .FetchAll<GroupHead_Record>();
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180336*/
        public Attendant LinkFill_Attendant_By_Uuid()
        {
            try
            {
                var data = Link_Attendant_By_Uuid();
                Attendant ret = new Attendant(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180336*/
        public Company LinkFill_Company_By_Uuid()
        {
            try
            {
                var data = Link_Company_By_Uuid();
                Company ret = new Company(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180336*/
        public GroupHead LinkFill_GroupHead_By_Uuid()
        {
            try
            {
                var data = Link_GroupHead_By_Uuid();
                GroupHead ret = new GroupHead(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180337*/
        public Attendant LinkFill_Attendant_By_Uuid(OrderLimit limit)
        {
            try
            {
                var data = Link_Attendant_By_Uuid(limit);
                Attendant ret = new Attendant(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180337*/
        public Company LinkFill_Company_By_Uuid(OrderLimit limit)
        {
            try
            {
                var data = Link_Company_By_Uuid(limit);
                Company ret = new Company(data);
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*201303180337*/
        public GroupHead LinkFill_GroupHead_By_Uuid(OrderLimit limit)
        {
            try
            {
                var data = Link_GroupHead_By_Uuid(limit);
                GroupHead ret = new GroupHead(data);
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
