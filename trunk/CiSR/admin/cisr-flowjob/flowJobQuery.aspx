<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="flowJobQuery.aspx.cs" Inherits="Web.admin.cisrFlowJob.flowJobQuery"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.CompanyForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.AttendantForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.CreateUploadJob.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/FilesForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var AttendantQuery = undefined;
var myForm = undefined;
var myFiles = undefined;
Ext.onReady(function() {
    /*:::加入Direct:::*/
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AttendantAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ADAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".SyncClientAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".TimeAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FrameAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UploadJobAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UtilAction"));


    Ext.QuickTips.init();
    var storeVUploadJob =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            /*:::Table設定:::*/
            model: 'V_UPLOAD_JOB',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.UploadJobAction.loadVUploadJob
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['pTimeType', 'pTimeId', 'pAttendantUuid', 'pKeyword', 'pFrameHeadUuid', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pTimeType: 'month',
                    pTimeId: '',
                    pAttendantUuid: '',
                    pKeyword: '',
                    pFrameHeadUuid: '',
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        if (!response.result.success) {
                            Ext.MessageBox.show({
                                title: 'Warning',
                                icon: Ext.MessageBox.WARNING,
                                buttons: Ext.Msg.OK,
                                msg: response.result.message
                            });
                        }
                    },
                    beforeload: function() {
                        alert('beforeload proxy');
                    }
                }
            },
            listeners: {
                write: function(proxy, operation) {},
                read: function(proxy, operation) {},
                beforeload: function() {},
                afterload: function() {},
                load: function() {}
            },
            remoteSort: true,
            sorters: [{
                property: 'RAW_ID',
                direction: 'ASC'
            }]
        });

    function isActiveRenderer(value, id, r) {
        if (value == "Y")
            return "<img src='" + SYSTEM_URL_ROOT + "/css/custimages/active.gif' style='height:20px;vertical-align:middle'>";
        else if (value == "N")
            return "<img src='" + SYSTEM_URL_ROOT + "/css/custimages/unactive.gif' style='height:20px;vertical-align:middle'>";
    }

    AttendantQuery = Ext.widget({
        xtype: 'panel',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">工作',
        frame: true,
        height: 490,
        items: [{
            xtype: 'container',
            layout: 'hbox',
            margin: '5 0 0 0',
            items: [{
                xtype: 'combo',
                fieldLabel: '時間屬性',
                labelAlign: 'right',
                //id: 'id',
                queryMode: 'local',
                itemId: 'cmbTimeType',
                displayField: 'text',
                valueField: 'value',

                editable: false,
                hidden: false,
                value: 'month',
                width: 120,
                labelWidth: 60,
                store: new Ext.data.ArrayStore({
                    fields: ['text', 'value'],
                    data: [
                        ['月', 'month'],
                        ['年', 'year']
                    ]
                }),
                listeners: {
                    'change': function(obj) {
                        var mainPanel = this.up('panel');
                        this.up('panel').down("#cmbTimeId").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                        this.up('panel').down("#cmbTimeId").getStore().reload();
                        this.up('panel').down("#cmbTimeId").setValue('');
                    }
                }
            }, {

                fieldLabel: '時間',
                labelAlign: 'right',
                width: 120,
                labelWidth: 40,
                itemId: 'cmbTimeId',
                xtype: 'combo',
                displayField: 'TIME_ID',
                valueField: 'TIME_ID',
                editable: false,
                hidden: false,
                store: Ext.create('Ext.data.Store', {
                    extend: 'Ext.data.Store',
                    autoLoad: false,
                    remoteSort: true,
                    model: 'TIME',
                    pageSize: 9999,
                    proxy: {
                        type: 'direct',
                        api: {
                            read: WS.TimeAction.loadTime
                        },
                        reader: {
                            root: 'data'
                        },
                        writer: {
                            type: 'json',
                            writeAllFields: true,
                            root: 'updatedata'
                        },
                        paramsAsHash: true,
                        paramOrder: ['pTimeType', 'page', 'limit', 'sort', 'dir'],
                        extraParams: {
                            'pTimeType': ''
                        },
                        simpleSortMode: true,
                        listeners: {
                            exception: function(proxy, response, operation) {
                                Ext.MessageBox.show({
                                    title: 'REMOTE EXCEPTON A',
                                    msg: operation.getError(),
                                    icon: Ext.MessageBox.ERROR,
                                    buttons: Ext.Msg.OK
                                });
                            },
                            beforeload: function() {
                                alert('beforeload proxy');
                            }
                        }
                    },
                    sorters: [{
                        property: 'TIME_ID',
                        direction: 'ASC'
                    }]
                })

            }, {
                xtype: 'combo',
                fieldLabel: '人員',
                //id: 'id',
                //queryMode : 'remote',
                labelAlign: 'right',
                width: 140,
                labelWidth: 40,
                itemId: 'cmbAttend',
                displayField: 'C_NAME',
                valueField: 'UUID',
                name: 'name',

                editable: true,
                hidden: false,
                store: Ext.create('Ext.data.Store', {
                    extend: 'Ext.data.Store',
                    autoLoad: false,
                    remoteSort: true,
                    model: 'ATTENDANT',
                    pageSize: 9999,
                    proxy: {
                        type: 'direct',
                        api: {
                            read: WS.AttendantAction.load
                        },
                        reader: {
                            root: 'data'
                        },
                        writer: {
                            type: 'json',
                            writeAllFields: true,
                            root: 'updatedata'
                        },
                        paramsAsHash: true,
                        paramOrder: ['pCompanyUuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                        extraParams: {
                            'pCompanyUuid': '<%= this.getUser().COMPANY_UUID %>',
                            'keyword': ''
                        },
                        simpleSortMode: true,
                        listeners: {
                            exception: function(proxy, response, operation) {
                                Ext.MessageBox.show({
                                    title: 'REMOTE EXCEPTON A',
                                    msg: operation.getError(),
                                    icon: Ext.MessageBox.ERROR,
                                    buttons: Ext.Msg.OK
                                });
                            },
                            beforeload: function() {
                                alert('beforeload proxy');
                            }
                        }
                    },
                    listeners: {
                        write: function(proxy, operation) {},
                        read: function(proxy, operation) {},
                        beforeload: function() {},
                        afterload: function() {},
                        load: function() {}
                    },
                    sorters: [{
                        property: 'C_NAME',
                        direction: 'ASC'
                    }]
                }),
                //readOnlyCls : 'readOnly',
                listeners: {
                    'select': function(combo, records, eOpts) {

                    },
                    'beforedeselect': function(combo, record, index, eOpts) {

                    },
                    'beforeselect': function(combo, record, index, eOpts) {

                    }
                }
            }, {
                xtype: 'textfield',
                fieldLabel: '關鍵字',
                labelAlign: 'right',
                itemId: 'txt_search',
                width: 150,
                labelWidth: 50
            }, {
                xtype: 'button',
                width: 80,
                margin: '0 10 0 10',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                style: 'display:block; padding:4px 0px 0px 0px',
                itemId: 'btnQuery',
                handler: function() {

                    var _timeType = '';
                    var _timeId = '';
                    var _attendant = '';
                    var _keyword = '';
                    var _frameHead = '';

                    _timeType = this.up('panel').down("#cmbTimeType").getValue();
                    _timeId = this.up('panel').down("#cmbTimeId").getValue();
                    _attendant = this.up('panel').down("#cmbAttend").getValue();
                    _keyword = this.up('panel').down("#txt_search").getValue();
                    _frameHead = this.up('panel').down("#cmbFrameHead").getValue();


                    _timeType = Ext.isEmpty(_timeType) ? "" : _timeType;
                    _timeId = Ext.isEmpty(_timeId) ? "" : _timeId;
                    _attendant = Ext.isEmpty(_attendant) ? "" : _attendant;
                    _keyword = Ext.isEmpty(_keyword) ? "" : _keyword;
                    _frameHead = Ext.isEmpty(_frameHead) ? "" : _frameHead;

                    storeVUploadJob.getProxy().setExtraParam('pTimeType', _timeType);
                    storeVUploadJob.getProxy().setExtraParam('pTimeId', _timeId);
                    storeVUploadJob.getProxy().setExtraParam('pAttendantUuid', _attendant);
                    storeVUploadJob.getProxy().setExtraParam('pKeyword', _keyword);
                    storeVUploadJob.getProxy().setExtraParam('pFrameHeadUuid', _frameHead);

                    storeVUploadJob.loadPage(1);
                }
            }, {
                xtype: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/clear.gif" style="height:18px;vertical-align:middle;margin-top:-2px;margin-right:5px;">清除',
                style: 'display:block; padding:4px 0px 0px 0px',
                handler: function() {
                    Ext.getCmp('txt_search').setValue('');
                }

            }]
        }, {
            xtype: 'container',
            layout: 'hbox',

            padding: 5,
            items: [{
                xtype: 'combo',
                fieldLabel: '組織',
                labelAlign: 'right',
                width: 685,
                labelWidth: 55,
                itemId: 'cmbFrameHead',
                displayField: 'C_NAME',
                valueField: 'UUID',
                tpl: new Ext.XTemplate(
                    '<tpl for=".">',
                    '<li role="option" unselectable="on" class="x-boundlist-item">',
                    '{[this.showName(values.FULL_FRAME_NAME_LIST)]}',
                    '</li>',
                    '</tpl>', {
                        showName: function(fullName) {
                            var arrName = fullName.split(':');
                            var ret = "";
                            if (arrName.length > 1) {
                                for (var i = 1; i < arrName.length; i++) {
                                    if (i == (arrName.length - 2)) {
                                        ret += arrName[i];
                                    } else {
                                        ret += "&nbsp;&nbsp;&nbsp;&nbsp;";
                                    }
                                }
                            }
                            return ret;
                        }
                    }
                ),
                editable: false,
                hidden: false,
                store: Ext.create('Ext.data.Store', {
                    extend: 'Ext.data.Store',
                    remoteSort: false,
                    autoLoad: false,
                    model: 'FRAME_HEAD',
                    pageSize: 9999,
                    proxy: {
                        type: 'direct',
                        api: {
                            read: WS.FrameAction.loadFrameHeadCmb
                        },
                        reader: {
                            root: 'data'
                        },
                        paramsAsHash: true,
                        paramOrder: ['pCompanyUuid', 'pageNo', 'limitNo', 'sort', 'dir'],
                        extraParams: {
                            'pCompanyUuid': '',
                            'pageNo': '',
                            'limitNo': '',
                            'sort': '',
                            'dir': ''

                        },
                        simpleSortMode: true
                    }
                }),
                //readOnlyCls : 'readOnly',
                listeners: {
                    'select': function(combo, records, eOpts) {

                    },
                    'beforedeselect': function(combo, record, index, eOpts) {

                    },
                    'beforeselect': function(combo, record, index, eOpts) {

                    }
                }
            }]
        }, {
            xtype: 'gridpanel',
            store: storeVUploadJob,
            minHeight: 370,
            plugins: Ext.create('Ext.grid.plugin.RowEditing', {
                clicksToMoveEditor: 2,
                autoCancel: true,
                listeners: {
                    edit: function(obj, context, eOpts) {
                        if (obj.grid.getStore().getModifiedRecords().length) {
                            Ext.each(obj.grid.getStore().getModifiedRecords(), function(item) {
                                var value = item.data["VALUE"];
                                var explain = item.data["EXPLAIN"];
                                var uuid = item.data["UUID"];

                                WS.UploadJobAction.setUploadJobValue(uuid, value, explain, function() {

                                });

                            });
                            //obj.grid.getStore().getModifiedRecords()[0].data["VALUE"]
                            //obj.grid.getStore().getModifiedRecords()[0].data["EXPLAIN"]
                            //obj.grid.getStore().getModifiedRecords()[0].data["UUID"]
                            obj.grid.getStore().commitChanges()
                        }
                    }
                }
            }),
            paramOrder: ['C_NAME'],
            idProperty: 'UUID',
            paramsAsHash: false,
            padding: 5,
            border: true,
            //autoHeight:true,
            //height:300,
            //height:$(this).height()-240,
            columns: [{
                header: '時間',
                dataIndex: 'TIME_ID',
                width: 80,
                align: 'right'
            }, {
                xtype: 'actioncolumn',
                header: '流程控制',
                //dataIndex:'UUID',
                sortable: false,
                width: 100,
                align: 'center',
                editor: {
                    xtype: 'label',
                    text: ''
                        /*
                        ,labelStyle : 'font-weight:bold;',
                        anchor : '100%'
                        */
                },
                items: [{
                        icon: '../../css/custImages/first.png',
                        tooltip: '*無條件到第一關卡',
                        handler: function(grid, rowIndex, colIndex) {
                            WS.UploadJobAction.first(grid.getStore().getAt(rowIndex).data.UUID, "", function(obj, objJson) {
                                storeVUploadJob.reload();
                            });
                        }
                    }, {
                        icon: '../../css/custImages/previous02.png',
                        tooltip: '*退一個關卡',
                        handler: function(grid, rowIndex, colIndex) {
                            WS.UploadJobAction.previous(grid.getStore().getAt(rowIndex).data.UUID, "", function(obj, objJson) {
                                storeVUploadJob.reload();
                            });
                        }
                    }, {
                        icon: '../../css/custImages/next02.png',
                        tooltip: '前進一個關卡',
                        handler: function(grid, rowIndex, colIndex) {
                            WS.UploadJobAction.next(grid.getStore().getAt(rowIndex).data.UUID, "", function(obj, objJson) {
                                storeVUploadJob.reload();
                            });
                        }
                    },

                    {
                        icon: '../../css/custImages/last.png',
                        tooltip: '*無條件結束關卡',
                        handler: function(grid, rowIndex, colIndex) {
                            WS.UploadJobAction.last(grid.getStore().getAt(rowIndex).data.UUID, "", function(obj, objJson) {
                                storeVUploadJob.reload();
                            });
                        }
                    }
                ]
            }, {
                header: '組織',
                dataIndex: 'FULL_FRAME_NAME_LIST',
                width: 150,
                renderer: function(value, r) {
                    var arrF = value.split(':');
                    var show = "";
                    for (var i = 1; i < arrF.length; i++) {
                        if (arrF[i] != "")
                            show = arrF[i] + ">";
                    }

                    if (arrF.length > 1) {
                        show = show.substr(0, show.length - 1);
                    }


                    return show;

                }
            }, {
                header: '組織(完整)',
                hidden: true,
                width: 250,
                dataIndex: 'FULL_FRAME_NAME_LIST',
                renderer: function(value, r) {
                    var arrF = value.split(':');
                    var show = "";
                    for (var i = 1; i < arrF.length; i++) {
                        if (arrF[i] != "")
                            show += arrF[i] + ">";
                    }

                    if (arrF.length > 1) {
                        show = show.substr(0, show.length - 1);
                    }


                    return show;

                }
            }, {
                header: '上傳ID',
                dataIndex: 'RAW_ID'
            }, {
                header: '資料名稱',
                dataIndex: 'RAW_C_DESC',
                renderer: function(value, m, r) {

                    var html = "";

                    if (r.data["FINISH"] == 1) {
                        return '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/finish.png" style="height:16px;vertical-align:middle;">' + value;
                    } else {
                        return value;
                    }

                }
            }, {
                header: '值',
                dataIndex: 'VALUE',
                editor: {
                    xtype: 'textfield'
                }
            }, {
                header: '說明',
                dataIndex: 'EXPLAIN',
                editor: {
                    xtype: 'textfield'
                }
            }, {
                header: '附件',
                width: 50,
                align: 'center',
                sortable: false,
                dataIndex: 'FILES_GROUP_ID',
                editor: {
                    xtype: 'label',
                    text: ''
                },
                xtype: 'actioncolumn',
                items: [{
                    icon: '../../css/custImages/upload.png',
                    handler: function(grid, rowIndex, colIndex) {
                        // if(r.data["FILES_COUNT"]>0){
                        //     showText = "修改檔案";
                        // }else{
                        //     showText = "上傳";
                        // }
                        //this.icon: '../../css/custImages/upload02.png';
                        if (myFiles == undefined) {
                            myFiles = Ext.create('FilesForm', {});
                            myFiles.on('closeEvent', function(obj) {

                                storeVUploadJob.load();

                            });
                        }
                        myFiles.openerObj = this.mainPanel;
                        myFiles.uploadJobUuid = grid.getStore().getAt(rowIndex).data.UUID;
                        if (grid.getStore().getAt(rowIndex).data["FILES_GROUP_ID"] == "") {
                            WS.UtilAction.getUid(function(obj, jsonObj) {
                                this.fileGroupId = jsonObj.result.data[0]["uid"];
                                this.isNew = true;
                                this.show();
                            }, myFiles);
                        } else {
                            //alert('bbb');
                            myFiles.fileGroupId = grid.getStore().getAt(rowIndex).data["FILES_GROUP_ID"];
                            myFiles.isNew = false;
                            myFiles.show();
                        }
                        return;
                    }
                }]
            }, {
                header: '第1關',
                dataIndex: 'DWG1_SHOW',
                renderer: function(value, m, r) {

                    var html = "";

                    if (r.data["STATUS"] == 1) {
                        return "<span style='color:blue;font-weight:bold;'>" + value + "</span>";
                    } else {
                        return value;
                    }

                }
            }, {
                header: '第2關',
                dataIndex: 'DWG2_SHOW',
                renderer: function(value, m, r) {

                    var html = "";
                    if (r.data["STATUS"] == 2) {
                        return "<span style='color:blue;font-weight:bold;'>" + value + "</span>";
                    } else {
                        return value;
                    }

                }
            }, {
                header: '第3關',
                dataIndex: 'DWG3_SHOW',
                renderer: function(value, m, r) {

                    var html = "";
                    if (r.data["STATUS"] == 3) {
                        return "<span style='color:blue;font-weight:bold;'>" + value + "</span>";
                    } else {
                        return value;
                    }

                }
            }, {
                header: '第4關',
                dataIndex: 'DWG4_SHOW',
                hidden: true,
                renderer: function(value, m, r) {

                    var html = "";
                    if (r.data["STATUS"] == 4) {
                        return "<span style='color:blue;font-weight:bold;'>" + value + "</span>";
                    } else {
                        return value;
                    }

                }
            }, {
                header: '第5關',
                dataIndex: 'DWG5_SHOW',
                hidden: true,
                renderer: function(value, m, r) {

                    var html = "";
                    if (r.data["STATUS"] == 5) {
                        return "<span style='color:blue;font-weight:bold;'>" + value + "</span>";
                    } else {
                        return value;
                    }

                }
            }],
            //height: 450,
            tbarCfg: {
                buttonAlign: 'right'
            },
            bbar: Ext.create('Ext.toolbar.Paging', {
                store: storeVUploadJob,
                displayInfo: true,
                displayMsg: '第{0}~{1}資料/共{2}筆',
                emptyMsg: "無資料顯示"
            }),
            tbar: [

                {
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">啟動新工作',
                    handler: function() {
                        if (myForm == undefined) {
                            myForm = Ext.create('CreateUploadJobForm', {});
                            myForm.on('closeEvent', function(obj) {
                                storeVUploadJob.reload();
                            });
                        }
                        myForm.setTitle('啟動工作');
                        myForm.uuid = undefined;
                        myForm.companyUuid = '<%= this.getUser().COMPANY_UUID %>';
                        myForm.show();
                    },
                    width: 100
                }

            ],
            listeners: {
                afterrender: function(obj, eOpts) {
                    var mainPanel = this.up('panel');
                    this.up('panel').down("#cmbTimeId").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                    this.up('panel').down("#cmbTimeId").getStore().load({

                    });
                    this.up('panel').down("#cmbFrameHead").getStore().getProxy().setExtraParam('pCompanyUuid', '<%= this.getUser().COMPANY_UUID %>');
                    //this.up('panel').down("#cmbFrameHead").getStore().reload();
                }
            }
        }]
    });
    AttendantQuery.render('divMain');
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>