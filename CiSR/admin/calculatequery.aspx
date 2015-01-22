<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="calculatequery.aspx.cs" Inherits="CISR.admin.calculatequery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.Cal.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/PopMessage.js")%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var VCalQuery = undefined;
var myForm = undefined;
var myFiles = undefined;
var popMessage = undefined;
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AttendantAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ADAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".TimeAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FrameAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UploadJobAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".CalAction"));
    Ext.QuickTips.init();
     
    
    var storeVCal =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_CAL',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.CalAction.loadVCal
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                /*:::Direct Method Parameter Setting:::*/                
                paramOrder: ['pTimeId','pTimeId2', 'pKeyword', 'pFullFrameHeadUuid', 'pStatus','pKpiType','page', 'limit', 'sort', 'dir'],                                      
                extraParams: {
                    pTimeId: '',
                    pTimeId2:'',
                    pKeyword: '',
                    pFullFrameHeadUuid: '',
                    pStatus: '',
                    pKpiType:''
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
                    }
                }
            },
            listeners: {               
                load: function(obj, records, successful, eOpts) {
                    for (var i = 0; i < records.length; i++) {
                        if (records[i].data["STATUS"] == "W") {
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 0
                            })).dom.style.background = "#80ACE5";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 1
                            })).dom.style.background = "#80ACE5";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 2
                            })).dom.style.background = "#80ACE5";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 3
                            })).dom.style.background = "#80ACE5";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 4
                            })).dom.style.background = "#80ACE5";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 5
                            })).dom.style.background = "#80ACE5";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 6
                            })).dom.style.background = "#80ACE5";
                        } else if (records[i].data["STATUS"] == "E") {
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 0
                            })).dom.style.background = "#FA9D87";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 1
                            })).dom.style.background = "#FA9D87";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 2
                            })).dom.style.background = "#FA9D87";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 3
                            })).dom.style.background = "#FA9D87";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 4
                            })).dom.style.background = "#FA9D87";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 5
                            })).dom.style.background = "#FA9D87";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 6
                            })).dom.style.background = "#FA9D87";
                        } else if (records[i].data["STATUS"] == "D") {
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 0
                            })).dom.style.background = "#F6C6C3";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 1
                            })).dom.style.background = "#F6C6C3";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 2
                            })).dom.style.background = "#F6C6C3";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 3
                            })).dom.style.background = "#F6C6C3";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 4
                            })).dom.style.background = "#F6C6C3";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 5
                            })).dom.style.background = "#F6C6C3";
                            Ext.get(VCalQuery.down("#grdVCal").getView().getCellByPosition({
                                row: i,
                                column: 6
                            })).dom.style.background = "#F6C6C3";
                        }
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'KPI_ID',
                direction: 'ASC'
            }]
        });

    function isActiveRenderer(value, id, r) {
        if (value == "Y")
            return "<img src='" + SYSTEM_URL_ROOT + "/css/custimages/active.gif' style='height:20px;vertical-align:middle'>";
        else if (value == "N")
            return "<img src='" + SYSTEM_URL_ROOT + "/css/custimages/unactive.gif' style='height:20px;vertical-align:middle'>";
    }

    /*設定元件*/
    VCalQuery = Ext.widget({
        xtype: 'panel',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">KPI計算',
        frame: true,
        height: $(this).height() - 140,     
        items: [{
            xtype: 'container',
            layout: 'hbox',
            margin: '5 0 0 0',
            items: [{
                xtype: 'combo',
                fieldLabel: '時間屬性',
                labelAlign: 'right',
                queryMode: 'local',
                itemId: 'cmbTimeType',
                displayField: 'text',
                valueField: 'value',
                editable: false,
                hidden: false,
                value: 'month',
                width: 140,
                labelWidth: 80,
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
                    }
                }
            }, {
                fieldLabel: '時間',
                labelAlign: 'right',
                width: 140,
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
                            }
                        }
                    },
                    sorters: [{
                        property: 'TIME_ID',
                        direction: 'ASC'
                    }]
                })
            }, {
                xtype: 'textfield',
                fieldLabel: '關鍵字',
                labelAlign: 'right',
                itemId: 'txt_search',
                width: 160,
                labelWidth: 60
            }, 
            {
                xtype: 'combo',
                fieldLabel: '組織',
                labelAlign: 'right',
                width: 130,
                margin: '0 5 0 0',
                labelWidth: 40,
                itemId: 'cmbFrameHead1',
                displayField: 'C_NAME',
                valueField: 'UUID',
                emptyText:'年份',
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
                                        //ret += "&nbsp;&nbsp;&nbsp;&nbsp;";
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
                            read: WS.FrameAction.loadFrameHeadCmb1
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
                listeners: {
                    'select': function(combo, records, eOpts) {
                        combo.up('panel').down('#cmbFrameCategory').getStore().getProxy().setExtraParam('pFrameHeadUuid', combo.getValue());

                        combo.up('panel').down('#cmbFrameCategory').getStore().reload({
                            callback : function() {
                                 this.down('#cmbFrameCategory').setValue('');

                                 this.down('#cmbFrameCategory').fireEvent('select', this.down('#cmbFrameCategory'));

                            },
                            scope:combo.up('panel')
                        });                       
                    }
                }
            }, 
            {
                xtype: 'combo',                
                emptyText:'產業別',
                itemId:'cmbFrameCategory',
                displayField: 'FRAME_CATEGORY_NAME',
                valueField: 'UUID',                
                margin: '0 5 0 0',
                width:80,
                editable: false,
                hidden: false,
                autoLoad:false,
                store: Ext.create('Ext.data.Store', {
                    extend : 'Ext.data.Store',
                    autoLoad : false,
                    model : 'FRAME_CATEGORY',
                    pageSize : 10,                    
                    remoteSort:true,
                    proxy : {
                        type : 'direct',
                        api : {
                            read : WS.FrameAction.loadFrameCategory2AddAll
                        },
                        reader : {
                            root : 'data'
                        },
                        paramsAsHash : true,
                        paramOrder : [ 'pFrameHeadUuid','page', 'limit', 'sort', 'dir'],
                        extraParams : {               
                            'pFrameHeadUuid':''             
                        },
                        simpleSortMode : true,
                        listeners : {
                            exception : function(proxy, response, operation) {
                                Ext.MessageBox.show({
                                    title : 'REMOTE EXCEPTON A',
                                    msg : '無法取得資料，造成原因可能是『年份』未選擇',
                                    icon : Ext.MessageBox.ERROR,
                                    buttons : Ext.Msg.OK
                                });
                            }
                        }
                    },                   
                    sorters : [{
                        property : 'FRAME_CATEGORY_NAME',
                        direction : 'ASC'
                    }]
                }),
                listeners : {
                    'select' : function(combo,records,eOpts){
                        combo.up('panel').down('#cmbFrameHead2').getStore().getProxy().setExtraParam('frame_category_uuid', combo.getValue());
                        combo.up('panel').down('#cmbFrameHead2').getStore().getProxy().setExtraParam('parent_frame_head_uuid', combo.up('panel').down("#cmbFrameHead1").getValue());
                        //alert(getValue);
                        combo.up('panel').down('#cmbFrameHead2').getStore().reload({
                            callback: function() {
                                if (this.getStore().getCount() > 0) {
                                    this.setValue(this.getStore().getAt(0).data['UUID']);
                                    this.fireEvent('select', this);
                                } else {
                                    this.setValue('');
                                }
                            },
                            scope: combo.up('panel').down('#cmbFrameHead2')
                        });
                    },
                    'beforedeselect' : function(combo, record, index, eOpts ){
                
                    },
                    'beforeselect' : function(combo, record, index, eOpts ){
                
                    }
                }
            },
            {
                xtype: 'combo',
                labelAlign: 'right',
                width: 160,
                //labelWidth: 40,
                margin: '0 5 0 0',
                emptyText:'公司',
                autoLoad:false,
                itemId: 'cmbFrameHead2',
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
                                        //ret += "&nbsp;&nbsp;&nbsp;&nbsp;";
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
                            read: WS.FrameAction.loadFrameHeadCmb2
                        },
                        reader: {
                            root: 'data'
                        },
                        paramsAsHash: true,
                        paramOrder: ['parent_frame_head_uuid','frame_category_uuid', 'pageNo', 'limitNo', 'sort', 'dir'],
                        extraParams: {
                            'parent_frame_head_uuid': '',
                            'frame_category_uuid':'',
                            'pageNo': '',
                            'limitNo': '',
                            'sort': '',
                            'dir': ''
                        },
                        simpleSortMode: true
                    }
                }),
                listeners: {
                    'select': function(combo, records, eOpts) {
                        combo.up('panel').down('#cmbFrameHead').getStore().getProxy().setExtraParam('pFrameHeadUuid', combo.getValue())
                        combo.up('panel').down('#cmbFrameHead').getStore().reload({
                            callback: function() {
                                console.log('herr...');
                                if (this.getStore().getCount() > 0) {
                                    this.setValue(this.getStore().getAt(0).data['FULL_FRAME_UUID_LIST']);
                                } else {
                                    this.setValue('');
                                }
                            },
                            scope: combo.up('panel').down('#cmbFrameHead')
                        });
                    }
                }
            }, {
                xtype: 'combo',
                labelAlign: 'right',
                margin: '0 5 0 0',
                width: 200,
                itemId: 'cmbFrameHead',
                displayField: 'C_NAME',
                valueField: 'FULL_FRAME_UUID_LIST',
                tpl: new Ext.XTemplate(
                    '<tpl for=".">',
                    '<li role="option" unselectable="on" class="x-boundlist-item">',
                    '{[this.showName(values.FULL_FRAME_NAME_LIST)]}',
                    '</li>',
                    '</tpl>',
                    {
                        showName: function(fullName) {
                            var arrName = fullName.split(':');
                            var ret = "";
                            if (arrName.length > 1) {
                                for (var i = 1; i < arrName.length; i++) {
                                    if (i == (arrName.length - 2)) {
                                        ret += arrName[i];
                                    } else {
                                        if (i > 3)
                                            ret += "&nbsp;&nbsp;&nbsp;&nbsp;";
                                    }
                                }
                            }
                            return ret;
                        }
                    }
                ),
                autoLoad:false,
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
                            read: WS.FrameAction.loadFrameHeadCmbParentFrameHeadAddAll
                        },
                        reader: {
                            root: 'data'
                        },
                        paramsAsHash: true,
                        paramOrder: ['pFrameHeadUuid', 'pageNo', 'limitNo', 'sort', 'dir'],
                        extraParams: {
                            'pFrameHeadUuid': '',
                            'pageNo': '',
                            'limitNo': '',
                            'sort': '',
                            'dir': ''
                        },
                        simpleSortMode: true
                    }
                })
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
                    var _keyword = '';
                    var _frameHead = '';
                    var _type = 'Complete';
                    _type = this.up('panel').down("#rdgType").getValue().rdgType;
                    _timeType = this.up('panel').down("#cmbTimeType").getValue();
                    _timeId = this.up('panel').down("#cmbTimeId").getValue();
                    _keyword = this.up('panel').down("#txt_search").getValue();
                    _frameHead = this.up('panel').down("#cmbFrameHead").getValue();
                    _timeType = Ext.isEmpty(_timeType) ? "" : _timeType;
                    _timeId = Ext.isEmpty(_timeId) ? "" : _timeId;
                    _keyword = Ext.isEmpty(_keyword) ? "" : _keyword;
                    _frameHead = Ext.isEmpty(_frameHead) ? "" : _frameHead;
                    storeVCal.getProxy().setExtraParam('pTimeType', _timeType);
                    storeVCal.getProxy().setExtraParam('pTimeId', _timeId);
                    storeVCal.getProxy().setExtraParam('pKeyword', _keyword);
                    storeVCal.getProxy().setExtraParam('pFullFrameHeadUuid', _frameHead);
                    storeVCal.getProxy().setExtraParam('pStatus', _type);
                    storeVCal.loadPage(1);
                }
            }, {
                xtype: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/clear.gif" style="height:18px;vertical-align:middle;margin-top:-2px;margin-right:5px;">清除',
                style: 'display:block; padding:4px 0px 0px 0px',
                handler: function() {
                    VCalQuery.down("#txt_search").setValue('');
                    VCalQuery.down("#cmbTimeId").setValue('');
                    VCalQuery.down("#cmbFrameHead").setValue('');
                }
            }]
        }, {
            xtype: 'container',
            layout: 'hbox',
            items: [{
                xtype: 'radiogroup',
                fieldLabel: '顯示方式',
                labelWidth: 80,
                labelAlign: 'right',
                itemId: 'rdgType',
                items: [{
                    boxLabel: '完成計算',
                    inputValue: 'Complete',
                    width: 100,
                    checked: true,
                    name: 'rdgType'

                }, {
                    boxLabel: '錯誤',
                    inputValue: 'Error',
                    name: 'rdgType'
                }, {
                    boxLabel: '待計算',
                    inputValue: 'Wait',
                    name: 'rdgType'
                }, {
                    boxLabel: '全部',
                    inputValue: 'All',
                    name: 'rdgType'
                }]
            }]
        }, {
            xtype: 'gridpanel',
            store: storeVCal,
            itemId: 'grdVCal',
            idProperty: 'UUID',
            paramsAsHash: false,
            padding: 5,
            border: true,
            height: $(this).height() - 240,
            columns: [{
                header: '時間',
                dataIndex: 'TIME_ID'
            }, {
                header: 'KPI ID',
                dataIndex: 'KPI_ID',
                width: 100
            }, {
                header: '說明',
                dataIndex: 'C_DESC',
                width: 300
            }, {
                header: '組織',
                dataIndex: 'C_NAME',
                width: 200
            }, {
                header: '計算值',
                dataIndex: 'VALUE',
                width: 100,
                align: 'right'
            }, {
                header: '資訊',
                xtype: 'actioncolumn',
                align: 'center',
                dataIndex: 'CAL_LOG',
                width: 60,
                items: [{
                    icon: '../css/custImages/info.png',
                    handler: function(grid, rowIndex, colIndex) {
                        if (popMessage == undefined) {
                            popMessage = Ext.create('PopMessage', {

                            });
                        }
                        var showMessage = "";
                        if (grid.getStore().getAt(rowIndex).data.STATUS == "Y") {
                            showMessage = grid.getStore().getAt(rowIndex).data.CAL_LOG;
                            popMessage.title = "計算資訊";
                        } else if (grid.getStore().getAt(rowIndex).data.STATUS == "E" || grid.getStore().getAt(rowIndex).data.STATUS == "D") {
                            showMessage = grid.getStore().getAt(rowIndex).data.ERROR_MSG;
                            popMessage.title = "錯誤資料";
                        };

                        popMessage.msg = showMessage;
                        popMessage.show();
                    }
                }],

            }, {
                header: '層級',
                dataIndex: 'FRAME_LEVEL',
                width: 60
            }],
            tbarCfg: {
                buttonAlign: 'right'
            },
            bbar: Ext.create('Ext.toolbar.Paging', {
                store: storeVCal,
                displayInfo: true,
                displayMsg: '第{0}~{1}資料/共{2}筆',
                emptyMsg: "無資料顯示"
            }),
            tbar: [
                {
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">執行計算',
                    handler: function() {
                        if (myForm == undefined) {
                            myForm = Ext.create('Cal', {});
                            myForm.on('closeEvent', function(obj) {
                                storeVCal.reload();
                            });
                        }
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
                    this.up('panel').down("#cmbFrameHead1").getStore().getProxy().setExtraParam('pCompanyUuid', '<%= this.getUser().COMPANY_UUID %>');
                }
            }
        }]
    });
    VCalQuery.render('divMain');
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>
