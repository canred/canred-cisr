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
    [ISTTableView("GROUP_APPMENU", true)]
    public partial class GroupAppmenu : TableBase
    {
        /*固定物件*/
        //IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
        /*固定物件但名稱需更新*/
        private GroupAppmenu_Record _currentRecord = null;
        private IList<GroupAppmenu_Record> _All_Record = new List<GroupAppmenu_Record>();
        /*建構子*/
        public GroupAppmenu() { }
        public GroupAppmenu(IDataBaseConfigInfo dbc, string db) : base(dbc, db) { }
        public GroupAppmenu(IDataBaseConfigInfo dbc) : base(dbc) { }
        public GroupAppmenu(IDataBaseConfigInfo dbc, GroupAppmenu_Record currenData)
        {
            this.setDataBaseConfigInfo(dbc);
            this._currentRecord = currenData;
        }
        public GroupAppmenu(IList<GroupAppmenu_Record> currenData)
        {
            this._All_Record = currenData;
        }
        /*欄位資訊 Start*/
        public string UUID { get { return "UUID"; } }
        public string IS_ACTIVE { get { return "IS_ACTIVE"; } }
        public string CREATE_DATE { get { return "CREATE_DATE"; } }
        public string CREATE_USER { get { return "CREATE_USER"; } }
        public string UPDATE_DATE { get { return "UPDATE_DATE"; } }
        public string UPDATE_USER { get { return "UPDATE_USER"; } }
        public string APPMENU_UUID { get { return "APPMENU_UUID"; } }
        public string GROUP_HEAD_UUID { get { return "GROUP_HEAD_UUID"; } }
        public string IS_DEFAULT_PAGE { get { return "IS_DEFAULT_PAGE"; } }
        /*欄位資訊 End*/
        /*固定的方法，但名稱需變更 Start*/
        public GroupAppmenu_Record CurrentRecord()
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
        public GroupAppmenu_Record CreateNew()
        {
            try
            {
                GroupAppmenu_Record newData = new GroupAppmenu_Record();
                return newData;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<GroupAppmenu_Record> AllRecord()
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
                _All_Record = new List<GroupAppmenu_Record>();
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
        public GroupAppmenu Fill_By_PK(string puuid)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>();
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
        public GroupAppmenu Fill_By_PK(string puuid, DB db)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>(db);
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
        public GroupAppmenu_Record Fetch_By_PK(string puuid)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319044
        public GroupAppmenu_Record Fetch_By_PK(string puuid, DB db)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>(db);
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319045
        public GroupAppmenu Fill_By_Uuid(string puuid)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>();
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
        public GroupAppmenu Fill_By_Uuid(string puuid, DB db)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>(db);
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
        public GroupAppmenu_Record Fetch_By_Uuid(string puuid)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.ErrorNoThrowException(this, ex);
                return null;
            }
        }
        //TEMPLATE TABLE 20130319048
        public GroupAppmenu_Record Fetch_By_Uuid(string puuid, DB db)
        {
            try
            {
                IList<GroupAppmenu_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<GroupAppmenu_Record>(db);
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
                UpdateAllRecord<GroupAppmenu_Record>(this.AllRecord());
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
                UpdateAllRecord<GroupAppmenu_Record>(this.AllRecord(), db);
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
                InsertAllRecord<GroupAppmenu_Record>(this.AllRecord());
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
                InsertAllRecord<GroupAppmenu_Record>(this.AllRecord(), db);
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
                DeleteAllRecord<GroupAppmenu_Record>(this.AllRecord());
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
                DeleteAllRecord<GroupAppmenu_Record>(this.AllRecord(), db);
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*依照資料表與資料表的關系，產生出來的方法*/
        public List<Appmenu_Record> Link_Appmenu_By_Uuid()
        {
            try
            {
                List<Appmenu_Record> ret = new List<Appmenu_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                Appmenu ___table = new Appmenu(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.APPMENU_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<Appmenu_Record>)
                        ___table.Where(condition)
                        .FetchAll<Appmenu_Record>();
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
        public List<Appmenu_Record> Link_Appmenu_By_Uuid(OrderLimit limit)
        {
            try
            {
                List<Appmenu_Record> ret = new List<Appmenu_Record>();
                var dbc = IST.Config.DataBase.Factory.getInfo();
                Appmenu ___table = new Appmenu(dbc);
                SQLCondition condition = new SQLCondition(___table);
                foreach (var item in AllRecord())
                {
                    condition
                    .L().Equal(___table.UUID, item.APPMENU_UUID).R().Or();
                }
                condition.CheckSQL();
                ret = (List<Appmenu_Record>)
                        ___table.Where(condition)
                        .Order(limit)
                        .Limit(limit)
                        .FetchAll<Appmenu_Record>();
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
        public Appmenu LinkFill_Appmenu_By_Uuid()
        {
            try
            {
                var data = Link_Appmenu_By_Uuid();
                Appmenu ret = new Appmenu(data);
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
        public Appmenu LinkFill_Appmenu_By_Uuid(OrderLimit limit)
        {
            try
            {
                var data = Link_Appmenu_By_Uuid(limit);
                Appmenu ret = new Appmenu(data);
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
