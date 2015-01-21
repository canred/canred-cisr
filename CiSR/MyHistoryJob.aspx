<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="MyHistoryJob.aspx.cs" Inherits="CISR.MyHistoryJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>

    <script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/FilesForm.js")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/UploadJobLogForm.js")%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divDownload" style="position:absolute;top:-100px;" width="100%" height="20"></div>
    <div id="divSetting" width="100%" height="700"></div>

<script language="javascript" type="text/javascript">
 Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');

Ext.require(['*', 'Ext.ux.DataTip']);
var panelWin = undefined;
var winFile = undefined;
var winLog = undefined;
var flagTask = false;

var objName = {
    run: function() {
        if (flagTask == true) {
            panelWin.down("#grdUploadJob").getStore().load();
            flagTask = false;
        } else {
            //your code
        }
    },
    interval: 1000
};
Ext.TaskManager.start(objName);
Ext.onReady(function() {

    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ADAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".TimeAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FrameAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UploadJobAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UtilAction"));


    Ext.define('UploadExcel', {
        extend: 'Ext.window.Window',
        title: '上傳Excel',
        closeAction: 'destory',
        width: 700,
        height: 530,
        resizable: false,
        hasChange: false,
        draggable: false,
        initComponent: function() {
            var me = this;
            me.callParent(arguments);
        },
        items: [{
            xtype: 'form',
            padding: 5,
            api: {
                submit: WS.UploadJobAction.submitExcel
            },
            items: [{
                xtype: 'filefield',
                fieldLabel: '檔案',
                itemId: 'file',
                labelWidth: 40,
                width: 380,
                name: 'file',
                emptyText: '請選擇要上傳的Excel檔案',
                listeners: {
                    'change': function(obj, ePots) {
                        this.up('panel').getForm().submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                if (action.result.excelLog) {
                                    if (this.memLogStore == undefined) {
                                        this.memLogStore = Ext.create('Ext.data.Store', {
                                            autoLoad: false,
                                            fields: [{
                                                name: 'LOG',
                                                type: 'string'
                                            }]
                                        });
                                    }

                                    Ext.each(action.result.excelLog.split('|'), function(item) {
                                        this.memLogStore.add({
                                            LOG: item
                                        });
                                    }, this);

                                    this.down("#grdLog").reconfigure(this.memLogStore);
                                    this.hasChange = true;
                                }
                            },
                            failure: function(form, action) {
                                Ext.MessageBox.show({
                                    title: 'System Error',
                                    msg: action.result.message,
                                    icon: Ext.MessageBox.ERROR,
                                    buttons: Ext.Msg.OK
                                });
                            },
                            scope: this.up('window')
                        });
                    }
                }
            }, {
                xtype: 'label',
                html: '上傳細詳資訊'
            }, {
                xtype: 'gridpanel',
                itemId: 'grdLog',
                queryMode: 'loccl',
                paramsAsHash: false,
                padding: 5,
                autoScroll: true,
                border: true,
                columns: [{
                    text: "訊息",
                    dataIndex: 'LOG',
                    align: 'left',
                    flex: 3
                }],
                height: 400
            }]
        }],
        fbar: [{
            type: 'button',
            text: '關閉',
            handler: function() {
                this.up('window').close();
            }
        }],
        closeEvent: function() {
            if (this.hasChange) {
                this.fireEvent('closeEvent', this);
            }

            if (this.openerObj != undefined) {
                this.openerObj.unmask();
            }
        },
        listeners: {
            'show': function() {
                this.hasChange = false;
                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
            },
            'close': function() {

                this.closeEvent();
                this.hasChange = false;
            }
        }
    });

    panelWin = Ext.create('Ext.form.Panel', {
        width: $(this).width() * .95,
        renderTo: 'divSetting',
        showCount: function(month, year) {
            //alert(month);
            //alert(year);
            if (month == 0) {
                this.down("#labMonth").setText('<h1 style="margin-right:10px;" >' + month + '筆</h1>', false);
            } else {
                this.down("#labMonth").setText('<h1 style="margin-right:10px;color:red" >' + month + '筆</h1>', false);
            }

            if (year == 0) {
                this.down("#labYear").setText('<h1 style="margin-right:10px;" >' + year + '筆</h1>', false);
            } else {
                this.down("#labYear").setText('<h1 style="margin-right:10px;color:red" >' + year + '筆</h1>', false);
            }

        },
        fnOpenFiles: function(obj, r) {
            if (winFile == undefined) {
                winFile = Ext.create('FilesForm', {locked
                    :true});                
                winFile.on('closeEvent', function(obj) {
                    try {
                        flagTask = true;
                    } catch (e) {}
                }, this);
            }
            winFile.openerObj = this;
            winFile.uploadJobUuid = r.data["UUID"];
            if (r.data["FILES_GROUP_ID"] == "") {
                WS.UtilAction.getUid(function(obj, jsonObj) {
                    this.fileGroupId = jsonObj.result.data[0]["uid"];
                    this.isNew = true;
                    this.show();
                }, winFile);
            } else {
                winFile.fileGroupId = r.data["FILES_GROUP_ID"];
                winFile.isNew = false;
                winFile.show();
            }
        },
        fnOpenLog:function(obj,r){
           
                winLog = Ext.create('UploadJobLogForm', {uploadJobUuid:r.data["UUID"]});                
                winLog.on('closeEvent', function(obj) {
                    
                }, this);
           
            winLog.openerObj = this;
            
            
            
            
            winLog.show();
            
        },
        padding: 10,
        items: [{
            xtype: 'container',

            layout: {
                type: 'table',
                // The total column count must be specified here
                columns: 6
            },
            border: true,
            defaults: {
                // applied to each contained panel
                bodyStyle: 'background:red'
            },
            height: 60,
            defaults: {
                height: 50,
                width: 50
            },
            items: [{
                    xtype: 'label',
                    html: '<h1 style="color:#A69E9C;" >已處理工作</h1>',
                    rowspan: 2
                }, {
                    xtype: 'label',
                    html: '<h1 style="margin-left:10px">年:</h1>',
                    rowspan: 2
                }, {
                    xtype: 'label',
                    html: '<h1 style="margin-right:10px;" >0筆</h1>',
                    rowspan: 2,
                    itemId: 'labYear'

                }, {
                    xtype: 'label',
                    html: '<h1 margin-right:10px>,月:</h1>',
                    rowspan: 2
                }, {
                    xtype: 'label',
                    html: '<h1 style="margin-right:10px;" >0筆</h1>',
                    rowspan: 2,
                    itemId: 'labMonth'
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    width: 600,
                    height: 25,
                    items: [{
                        xtype: 'combo',
                        fieldLabel: '時間屬性',
                        labelAlign: 'right',
                        queryMode: 'local',
                        itemId: 'cmbTimeType',
                        displayField: 'text',
                        valueField: 'value',
                        width: 120,
                        labelWidth: 60,

                        editable: false,
                        hidden: false,
                        value: 'month',
                        store: new Ext.data.ArrayStore({
                            fields: ['text', 'value'],
                            data: [
                                ['月', 'month'],
                                ['年', 'year']
                            ]
                        }),
                        listeners: {
                            'change': function(combo, records, eOpts) {
                                combo.up('panel').down('#grdUploadJob').getStore().getProxy().setExtraParam('pTimeType', combo.getValue());
                                combo.up('panel').down('#grdUploadJob').getStore().loadPage(1);
                            }
                        }
                    }, {
                        xtype: 'combo',
                        fieldLabel: '顯示筆數',
                        labelAlign: 'right',
                        queryMode: 'local',
                        width: 130,
                        labelWidth: 60,
                        displayField: 'text',
                        valueField: 'value',
                        value: 100,
                        editable: false,
                        hidden: false,
                        store: new Ext.data.ArrayStore({
                            fields: ['text', 'value'],
                            data: [
                                ['100', 100],
                                ['200', 200],
                                ['300', 300],
                                ['全部', 9999]
                            ]
                        }),
                        listeners: {
                            'select': function(combo, records, eOpts) {
                                combo.up('panel').down('#grdUploadJob').getStore().getProxy().setExtraParam('limit', combo.getValue());
                                combo.up('panel').down('#grdUploadJob').getStore().loadPage(1);
                            }
                        }
                    },  {
                        xtype: 'button',
                        text: '匯出',
                        margin: '0 5 0 5',
                        handler: function() {
                                var timeType = this.up('panel').down("#cmbTimeType").getValue();
                                var url = "myHistoryJobExport.ashx?timeType=" + timeType;
                                if (timeType == 'month') {
                                    Ext.Ajax.request({
                                        url: url,
                                        success: function(response, opts) {
                                            var obj = response.responseText;
                                            $("#divDownload").html('');
                                            obj = obj.replace('~', SYSTEM_URL_ROOT);
                                            var createA = document.createElement('a');
                                            var createAText = document.createTextNode("Download");
                                            var id = Ext.id();
                                            createA.setAttribute('id', id);
                                            createA.setAttribute('href', obj);
                                            createA.appendChild(createAText);
                                            $("#divDownload").append(createA);
                                            var evt = document.createEvent("MouseEvents");
                                            evt.initMouseEvent("click", true, true, window,
                                                0, 0, 0, 0, 0, false, false, false, false, 0, null);
                                            var allowDefault = createA.dispatchEvent(evt);
                                        },
                                        failure: function(response, opts) {
                                            console.log('server-side failure with status code ' + response.status);
                                        }
                                    });
                                } else if (timeType == 'year') {
                                    Ext.Ajax.request({
                                        url: url,
                                        success: function(response, opts) {
                                            var obj = response.responseText;
                                            $("#divDownload").html('');
                                            obj = obj.replace('~', SYSTEM_URL_ROOT);
                                            var createA = document.createElement('a');
                                            var createAText = document.createTextNode("Download");
                                            var id = Ext.id();
                                            createA.setAttribute('id', id);
                                            createA.setAttribute('href', obj);
                                            createA.appendChild(createAText);
                                            $("#divDownload").append(createA);
                                            var evt = document.createEvent("MouseEvents");
                                            evt.initMouseEvent("click", true, true, window,
                                                0, 0, 0, 0, 0, false, false, false, false, 0, null);
                                            var allowDefault = createA.dispatchEvent(evt);
                                        },
                                        failure: function(response, opts) {
                                            console.log('server-side failure with status code ' + response.status);
                                        }
                                    });
                                } else {
                                    Ext.MessageBox.show({
                                        title: '系統提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '發現未知的錯誤!'
                                    });
                                }
                            }
                    }]
                }, {
                    width: 600,
                    height: 25,
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype:'label',
                        margin:'5 0 0 0',                        
                        html:'底色說明:<span style="color:#FFD303 ;" >「黃」</span>:必須項目；<span style="color:green ;" >「綠」</span>:內含附件'

                    }]
                },

            ]

        }, {
            xtype: 'gridpanel',
            itemId: 'grdUploadJob',
            enableColumnMove: false,
            store: Ext.create('Ext.data.Store', {
                successProperty: 'success',
                autoLoad: true,
                model: 'V_UPLOAD_JOB',
                pageSize: 100,
                proxy: {
                    type: 'direct',
                    api: {
                        read: WS.UploadJobAction.loadMyHistoryVUploadJob
                    },
                    reader: {
                        rootProperty: 'data'
                    },
                    paramsAsHash: true,
                    paramOrder: ['pTimeType', 'pTimeId', 'pKeyword', 'pFrameHeadUuid', 'page', 'limit', 'sort', 'dir'],
                    extraParams: {
                        pTimeType: 'month',
                        pTimeId: '',
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
                    load: function(obj, records, successful, eOpts) {
                        for (var i = 0; i < records.length; i++) {
                            if (records[i].data["RAW_NEED_FILS"] == "Y") {
                                Ext.get(panelWin.down("#grdUploadJob").getView().getCellByPosition({
                                    row: i,
                                    column: 6
                                })).dom.style.background = "#FFD303";
                            }

                            if (records[i].data["RAW_CAN_NULL"] == "N") {
                                Ext.get(panelWin.down("#grdUploadJob").getView().getCellByPosition({
                                    row: i,
                                    column: 4
                                })).dom.style.background = "#FFD303";
                            }

                            if (records[i].data["RAW_NEED_DESC"] == "Y") {
                                Ext.get(panelWin.down("#grdUploadJob").getView().getCellByPosition({
                                    row: i,
                                    column: 5
                                })).dom.style.background = "#FFD303";
                            }

                            if (records[i].data["FILES_COUNT"] > 0) {
                                Ext.get(panelWin.down("#grdUploadJob").getView().getCellByPosition({
                                    row: i,
                                    column: 6
                                })).dom.style.background = "#63B120";
                            }
                        }
                    }
                },
                remoteSort: true,
                sorters: [{
                    property: 'RAW_ID',
                    direction: 'ASC'
                }]
            }),
            minHeight: 5000,
            autoWidth: true,
            // selModel: new Ext.selection.CheckboxModel({
            //     mode: 'SIMPLE',
            //     checkOnly: true,
            //     showHeaderCheckbox: false
            // }),
            paramsAsHash: false,
            padding: 5,
            autoScroll: true,
            columns: [{
                text: "時間",
                dataIndex: 'TIME_ID',
                align: 'left',
                width: 60
            }, {
                text: "Raw Id",
                dataIndex: 'RAW_ID',
                align: 'left',
                width: 90
            }, {
                text: "組織",
                dataIndex: 'FULL_FRAME_NAME_LIST',
                align: 'left',
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
                text: "組織(完整)",
                dataIndex: 'FULL_FRAME_NAME_LIST',
                align: 'left',
                hidden: true,
                width: 200,
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
                text: "名稱",
                dataIndex: 'RAW_C_DESC',
                align: 'left',
                width: 300
            }, {
                text: "數值",
                dataIndex: 'VALUE',
                align: 'right',
                width: 90
            }, {
                text: "說明",
                dataIndex: 'EXPLAIN',
                align: 'left',
                width: 120                
            }, {
                xtype: 'actioncolumn',
                text: "附件",
                align: 'center',
                width: 80,
                items: [{
                    icon: './css/custImages/upload.png',
                    tooltip:'*查看附件內容',
                    handler: function(grid, rowIndex, colIndex) {
                        var mainPanel = grid.up('panel').up('panel');
                        mainPanel.fnOpenFiles(undefined, grid.getStore().getAt(rowIndex));
                    }
                }]
            }, {
                xtype: 'actioncolumn',
                text: "簽核記錄",
                tooltip:'*查看詳細簽核記錄',
                align: 'center',
                width: 80,
                items: [{
                    icon: './css/custImages/tabs.gif',
                    tooltip:'*查看詳細簽核記錄',
                    handler: function(grid, rowIndex, colIndex) {
                        var mainPanel = grid.up('panel').up('panel');
                        mainPanel.fnOpenLog(undefined, grid.getStore().getAt(rowIndex));
                    }
                }]
            }]
        }],
        listeners: {
            'afterrender': function(obj, eOpts) {
                WS.UploadJobAction.loadVUploadJobHistoryCount(function(obj, jsonObj) {
                    if (jsonObj.result.success) {
                        var monthCount = jsonObj.result.month;
                        var yearCount = jsonObj.result.year;
                        this.showCount(monthCount, yearCount);
                    }
                }, this);
            }
        }
    });
});
</script>
</asp:Content>
