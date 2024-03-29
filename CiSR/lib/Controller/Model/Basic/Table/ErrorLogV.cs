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
    [ISTTableView("ERROR_LOG_V", false)]
    public partial class ErrorLogV : TableBase
    {
        /*固定物件*/
        //IST.DB.SQLCreater.ASQLCreater sqlCreater = null;
        /*固定物件但名稱需更新*/
        private ErrorLogV_Record _currentRecord = null;
        private IList<ErrorLogV_Record> _All_Record = new List<ErrorLogV_Record>();
        /*建構子*/
        public ErrorLogV() { }
        public ErrorLogV(IDataBaseConfigInfo dbc, string db) : base(dbc, db) { }
        public ErrorLogV(IDataBaseConfigInfo dbc) : base(dbc) { }
        public ErrorLogV(IDataBaseConfigInfo dbc, ErrorLogV_Record currenData)
        {
            this.setDataBaseConfigInfo(dbc);
            this._currentRecord = currenData;
        }
        public ErrorLogV(IList<ErrorLogV_Record> currenData)
        {
            this._All_Record = currenData;
        }
        /*欄位資訊 Start*/
        public string UUID { get { return "UUID"; } }
        public string CREATE_DATE { get { return "CREATE_DATE"; } }
        public string UPDATE_DATE { get { return "UPDATE_DATE"; } }
        public string IS_ACTIVE { get { return "IS_ACTIVE"; } }
        public string ERROR_CODE { get { return "ERROR_CODE"; } }
        public string ERROR_TIME { get { return "ERROR_TIME"; } }
        public string ERROR_MESSAGE { get { return "ERROR_MESSAGE"; } }
        public string APPLICATION_NAME { get { return "APPLICATION_NAME"; } }
        public string ATTENDANT_UUID { get { return "ATTENDANT_UUID"; } }
        public string ERROR_TYPE { get { return "ERROR_TYPE"; } }
        public string IS_READ { get { return "IS_READ"; } }
        public string C_NAME { get { return "C_NAME"; } }
        public string E_NAME { get { return "E_NAME"; } }
        public string ID { get { return "ID"; } }
        /*欄位資訊 End*/
        /*固定的方法，但名稱需變更 Start*/
        public ErrorLogV_Record CurrentRecord()
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
        public ErrorLogV_Record CreateNew()
        {
            try
            {
                ErrorLogV_Record newData = new ErrorLogV_Record();
                return newData;
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        public IList<ErrorLogV_Record> AllRecord()
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
                _All_Record = new List<ErrorLogV_Record>();
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
        public ErrorLogV Fill_By_PK(string puuid)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>();
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
        public ErrorLogV Fill_By_PK(string puuid, DB db)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>(db);
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
        public ErrorLogV_Record Fetch_By_PK(string puuid)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319044
        public ErrorLogV_Record Fetch_By_PK(string puuid, DB db)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>(db);
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        //TEMPLATE TABLE 20130319045
        public ErrorLogV Fill_By_Uuid(string puuid)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>();
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
        public ErrorLogV Fill_By_Uuid(string puuid, DB db)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>(db);
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
        public ErrorLogV_Record Fetch_By_Uuid(string puuid)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>();
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.ErrorNoThrowException(this, ex);
                return null;
            }
        }
        //TEMPLATE TABLE 20130319048
        public ErrorLogV_Record Fetch_By_Uuid(string puuid, DB db)
        {
            try
            {
                IList<ErrorLogV_Record> ret = null;
                ret = this.Where(
                new SQLCondition(this)
                                    .Equal(this.UUID, puuid)
                ).FetchAll<ErrorLogV_Record>(db);
                return ret.First();
            }
            catch (Exception ex)
            {
                log.Error(ex); IST.MyException.MyException.Error(this, ex);
                throw ex;
            }
        }
        /*依照資料表與資料表的關系，產生出來的方法*/
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
    }
}
