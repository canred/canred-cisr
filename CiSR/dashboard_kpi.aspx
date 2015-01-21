<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="dashboard_kpi.aspx.cs" Inherits="CISR.dashboard_kpi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>

<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/packages/ext-charts/build/ext-charts.js")%>'></script>

<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.Cal.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/PopMessage.js")%>'></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var VCalQuery = undefined;
var myForm = undefined;
var myFiles = undefined;
var popMessage = undefined;
var activeChart = undefined;
Ext.onReady(function() {
    /*:::加入Direct:::*/
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AttendantAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ADAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".TimeAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FrameAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UploadJobAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".CalAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ChartAction"));
    
    Ext.QuickTips.init();
    Ext.define('PreviewPieChart', {
        extend: 'Ext.window.Window',
        title: '',
        KPI: undefined,
        FRAME: undefined,
        TIME: undefined,
        DISPLAY: undefined,
        closeAction: 'destory',
        width: 800,
        height: 600,
        resizable: false,
        draggable: true,
        initComponent: function() {
            var me = this;
            this.myDataStore = Ext.create('Ext.data.JsonStore', {
                fields: ['ITEMCATEGORY', 'ITEMVALUE'],
            });
            me.items = [{
                xtype: 'chart',
                width: 750,
                height: 550,
                margin: '0 0 0 0',
                style: 'background: #fff',
                animate: true,
                shadow: false,
                store: this.myDataStore,
                insetPadding: 80,
                legend: {
                    field: 'ITEMCATEGORY',
                    position: 'bottom',
                    boxStrokeWidth: 0,
                    labelFont: '12px Helvetica'
                },
                items: [
                    {
                        type: 'text',
                        text: '圖表名稱: ' + this.NAME,
                        font: '10px Helvetica',
                        labelWidth:80,
                        x: 12,
                        y: 490
                    }, {
                        type: 'text',
                        text: '說明: ' + this.DESC,
                        font: '10px Helvetica',
                        labelWidth:80,
                        x: 12,
                        y: 510
                    }
                ],
                series: [{
                    type: 'pie',
                    angleField: 'ITEMVALUE',
                    label: {
                        field: 'ITEMCATEGORY',
                        display: 'outside',
                        calloutLine: true
                    },
                    showInLegend: true,
                    highlight: true,
                    highlightCfg: {
                        fill: '#000',
                        'stroke-width': 10,
                        stroke: '#fff'
                    },
                    tips: {
                        trackMouse: true,
                        renderer: function(storeItem, item) {
                            this.setTitle('* '+storeItem.get('ITEMCATEGORY') + ': ' + storeItem.get('ITEMVALUE'));
                        }
                    }
                }]
            }];
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'show': function() {
                WS.ChartAction.loadPieChartA(this.DISPLAY, this.KPI, this.FRAME, this.TIME, function(obj, jsonObj) {
                    try {
                        if (jsonObj.result.success) {
                            Ext.each(jsonObj.result.data.Item, function(item) {
                                this.myDataStore.add({
                                    "ITEMCATEGORY": item.ITEMCATEGORY,
                                    "ITEMVALUE": item.ITEMVALUE
                                });
                            }, this);


                        } else {
                            Ext.MessageBox.show({
                                title: '設定錯誤',
                                icon: Ext.MessageBox.ERROR,
                                buttons: Ext.Msg.OK,
                                msg: jsonObj.result.message
                            });
                        }
                    } catch (e) {
                        Ext.MessageBox.show({
                            title: '發生異常錯誤',
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK,
                            msg: '造成原因可能為資料不齊全'
                        });
                    }

                }, this);
            },
            'close': function() {
                Ext.getBody().unmask();
                this.closeEvent();
            }
        }
    });


    Ext.define('PreviewColumnClusterCharts', {
        extend: 'Ext.window.Window',
        title: '',
        KPI: undefined,
        FRAME: undefined,
        TIME: undefined,
        DISPLAY: undefined,
        TIMECOLUMN: undefined,
        closeAction: 'destory',
        width: 800,
        height: 600,
        resizable: false,
        draggable: false,
        initComponent: function() {
            var me = this;
            var arrTimeColumn = Array();
            var arrTimeColumn2 = Array();
            arrTimeColumn.push('ITEMCATEGORY');
            for (var i = 0; i < this.TIMECOLUMN.split(';').length; i++) {
                if (this.TIMECOLUMN.split(';')[i] != "") {
                    arrTimeColumn.push("D" + (i + 1));
                    
                }
            }

            console.log(arrFrameText);

            var arrFrameText = Array();

            for(var i =0 ;i <this.FRAMETEXT.split(';').length ; i++){
                if( this.FRAMETEXT.split(';')[i] !=""){
                    arrFrameText.push(this.FRAMETEXT.split(';')[i]);
                    arrTimeColumn2.push("D" + (i + 1));
                }
            }

            me.items = [{
                xtype: 'panel',
                width: 750,
                height: 550,
                items: [{
                    xtype: 'chart',
                    width: 750,
                    height: 550,
                    padding: '10 0 0 0',
                    margin: '0 0 0 0',
                    style: 'background: #fff',
                    animate: false,
                    shadow: false,
                    store: this.myDataStore,
                    insetPadding: 60,
                    legend: {
                        disabled: true,
                        position: 'bottom',
                        boxStrokeWidth: 0,
                        labelFont: '12px Helvetica'
                    },
                    items: [
                        // {
                        //     type: 'text',
                        //     text: 'Pie Charts - Basic',
                        //     font: '22px Helvetica',
                        //     width: 100,
                        //     height: 30,
                        //     x: 40, // the sprite x position
                        //     y: 12 // the sprite y position
                        // },

                        {
                            type: 'text',
                            text: '圖表名稱: ' + this.NAME,
                            font: '10px Helvetica',
                            labelWidth:80,
                            x: 12,
                            y: 500
                        }, {
                            type: 'text',
                            text: '說明: ' + this.DESC,
                            font: '10px Helvetica',
                            labelWidth:80,
                            x: 12,
                            y: 520
                        }
                    ],
                    axes: [{
                        type: 'Numeric',
                        position: 'left',
                        fields: 'D1',
                        grid: true,
                        //minimum: 0,
                        label: {
                            renderer: function(v) {
                                return v;
                            }
                        }
                    }, {
                        type: 'Category',
                        position: 'bottom',
                        fields: 'ITEMCATEGORY',
                        grid: true,
                        label: {
                            rotate: {
                                degrees: -45
                            }
                        }
                    }],
                    series: [{
                        type: 'column',
                        axis: 'left',
                        title: arrFrameText,
                        xField: 'ITEMCATEGORY',
                        yField: arrTimeColumn2,
                        style: {
                            opacity: 0.80
                        },
                        highlight: {
                            fill: '#000',
                            'stroke-width': 1,
                            stroke: '#000'
                        },
                        tips: {
                            trackMouse: true,
                            style: 'background: #FFF',
                            height: 20,
                            renderer: function(storeItem, item) {
                                var browser = item.series.title[Ext.Array.indexOf(item.series.yField, item.yField)];
                                this.setTitle('* '+browser + ' 時間:' + storeItem.get('ITEMCATEGORY') + '; 值: ' + storeItem.get(item.yField));
                            }
                        }
                    }]
                }]
            }];
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'show': function() {

            },
            'close': function() {
                Ext.getBody().unmask();
                this.closeEvent();
            }
        }
    });




    Ext.define('PieCharts', {
        extend: 'Ext.window.Window',
        title: '製作圓餅圖',
        closeAction: 'destory',
        width: 300,
        height: 600,
        resizable: false,
        draggable: true,
        initComponent: function() {
            var me = this;
            me.items = [
                {
                    xtype: 'combo',
                    fieldLabel: '圖表類型',
                    queryMode : 'local',
                    labelAlign:'left',
                    itemId:'cmbChartGroup',
                    displayField: 'text',
                    valueField: 'value',
                    padding: 5,
                    margin:'5 0 5 5',
                    labelWidth:60,
                    width: 280,
                    editable: false,
                    hidden: false,
                    value:'EC',
                    store : new Ext.data.ArrayStore({
                        fields: ['text', 'value'],
                        data : [ ['EC', 'EC'],
                        ['EN', 'EN'],
                        ['G4', 'G4'],
                        ['HR', 'HR'],
                        ['LA', 'LA'],
                        ['SO', 'SO'],
                        ['PR', 'PR']] 
                    }),
                    readOnlyCls : 'readOnly'
                },
                {
                    xtype: 'label',
                    html: '指標',
                    padding: 5
                }, {
                    xtype: 'fieldset',
                    margin: 5,
                    border: true,
                    minHeight: 50,
                    autoHeight: true,
                    itemId: 'fsKPI',
                    items: [{
                    }]
                }, {
                    xtype: 'combo',
                    fieldLabel: '顯示方式',
                    itemId: 'cmbDisplay',
                    labelWidth: 60,
                    width: 280,
                    queryMode: 'local',
                    displayField: 'text',
                    valueField: 'value',
                    value: 'NAME',
                    padding: 5,
                    editable: false,
                    hidden: false,
                    store: new Ext.data.ArrayStore({
                        fields: ['text', 'value'],
                        data: [
                            ['代碼', 'CODE'],
                            ['名稱', 'NAME']
                        ]
                    })
                },
                {
                    xtype: 'container',
                    layout: 'hbox',
                    padding: 5,
                    items: [{
                        xtype: 'combo',
                        fieldLabel: '時間',
                        labelAlign: 'right',
                        queryMode: 'local',
                        itemId: 'cmbTimeType',
                        displayField: 'text',
                        valueField: 'value',
                        editable: false,
                        hidden: false,
                        value: 'month',
                        labelWidth: 60,
                        width: 120,
                        store: new Ext.data.ArrayStore({
                            fields: ['text', 'value'],
                            data: [
                                ['月', 'month'],
                                ['年', 'year']
                            ]
                        }),
                        listeners: {
                            'change': function(obj) {
                                var mainPanel = this.up('window');
                                this.up('panel').down("#cmbTimeIdStart").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                                this.up('panel').down("#cmbTimeIdStart").getStore().reload();

                            }
                        }
                    }, {
                        labelAlign: 'right',
                        width: 160,
                        itemId: 'cmbTimeIdStart',
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
                                    'pTimeType': 'month'
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
                    }]
                }, {
                    xtype: 'label',
                    text: '組織',
                    padding: 5
                }, {
                    xtype: 'fieldset',
                    margin: 5,
                    itemId: 'fsFrame',
                    border: true,
                    minHeight: 50,
                    autoHeight: true,
                    items: [{

                    }]
                }, {
                    xtype: 'textfield',
                    fieldLabel: '圖表名稱',
                    padding: 5,
                    labelWidth: 40,
                    width: 280,
                    labelWidth:80,
                    itemId: "txtChartTitle",
                    allowBlank: false
                }, {
                    xtype: 'textarea',
                    fieldLabel: '說明',
                    padding: 5,
                    labelWidth: 40,
                    width: 280,
                    labelWidth:80,
                    itemId: "txtChartDesc",
                    allowBlank: true
                }
            ];
            me.callParent(arguments);
        },
        fbar: [{
            type: 'button',
            text: '預覽',
            handler: function() {
                var kpi = "";
                var frame = "";
                var kpiCount = 0;
                var frameCount = 0;
                for (var i = 0; i < this.up('window').down("#fsKPI").items.items.length; i++) {
                    var item = this.up('window').down("#fsKPI").items.items[i];
                    if (item.xtype == 'button') {
                        kpi += item.KPI_HEAD_UUID + ";";
                        kpiCount++;
                    }
                }

                for (var i = 0; i < this.up('window').down("#fsFrame").items.items.length; i++) {
                    var item = this.up('window').down("#fsFrame").items.items[i];
                    if (item.xtype == 'button') {
                        frame += item.FRAME_HEAD_UUID + ";";
                        frameCount++;
                    }
                }

                if (kpiCount == 0) {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '指標必須選擇一個或多個'
                    });
                    return;
                }

                if (frameCount == 0) {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '組織必須選擇一個或多個'
                    });
                    return;
                }


                if (kpiCount > 1 && frameCount > 1) {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '組織與指標只有一項可以為多個'
                    });
                    return;
                }
                var timeId = this.up('window').down("#cmbTimeIdStart").getValue();
                if (timeId == undefined || timeId == '') {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '請先選擇一個有效的時間'
                    });
                    return;
                }
                var a = Ext.create('PreviewPieChart', {
                    KPI: kpi,
                    FRAME: frame,
                    TIME: timeId,
                    DISPLAY: this.up('window').down('#cmbDisplay').getValue(),
                    NAME: this.up('window').down('#txtChartTitle').getValue(),
                    DESC: this.up('window').down('#txtChartDesc').getValue(),
                });

                a.show();
            }
        }, {
            type: 'button',
            text: '儲存',
            handler: function() {
                var kpi = "";
                var frame = "";
                var kpiCount = 0;
                var frameCount = 0;
                for (var i = 0; i < this.up('window').down("#fsKPI").items.items.length; i++) {
                    var item = this.up('window').down("#fsKPI").items.items[i];
                    if (item.xtype == 'button') {
                        kpi += item.KPI_HEAD_UUID + ";";
                        kpiCount++;
                    }
                }

                for (var i = 0; i < this.up('window').down("#fsFrame").items.items.length; i++) {
                    var item = this.up('window').down("#fsFrame").items.items[i];
                    if (item.xtype == 'button') {
                        frame += item.FRAME_HEAD_UUID + ";";
                        frameCount++;
                    }
                }

                if (kpiCount == 0) {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '指標必須選擇一個或多個'
                    });
                    return;
                }

                if (frameCount == 0) {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '組織必須選擇一個或多個'
                    });
                    return;
                }


                if (kpiCount > 1 && frameCount > 1) {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '組織與指標只有一項可以為多個'
                    });
                    return;
                }

                var timeId = this.up('window').down("#cmbTimeIdStart").getValue();

                if (timeId == undefined || timeId == '') {
                    Ext.MessageBox.show({
                        title: '製作圓餅圖提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '請先選擇一個有效的時間'
                    });
                    return;
                }
                var chartTitle = this.up('window').down('#txtChartTitle').getValue();
                var chartDesc = this.up('window').down('#txtChartDesc').getValue();
                var display = this.up('window').down('#cmbDisplay').getValue();
                var saveJObject = {
                    'KPI': kpi,
                    'FRAME': frame,
                    'TIME': timeId,
                    'DISPLAY': this.up('window').down('#cmbDisplay').getValue(),
                    'NAME': this.up('window').down('#txtChartTitle').getValue(),
                    'DESC': this.up('window').down('#txtChartDesc').getValue(),
                };

                saveJObject = Ext.encode(saveJObject);
                var pChartGroup = this.up('window').down('#cmbChartGroup').getValue();

                WS.ChartAction.saveChartList("","",pChartGroup,chartDesc,chartTitle,"PieCharts",kpi,frame,timeId,display,saveJObject,function(obj,jsonObj){
                    if(jsonObj.result != undefined && jsonObj.result.success){
                        alert('儲存完成');
                    }
                });               
            }
        }],
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'close': function() {
                this.closeEvent();
            }
        }
    });


    Ext.define('ColumnClusterCharts', {
        extend: 'Ext.window.Window',
        title: '製作長方圓',
        closeAction: 'destory',
        width: 300,
        height: 600,
        resizable: false,
        draggable: true,
        initComponent: function() {
            var me = this;
            me.items = [
                {
                    xtype: 'combo',
                    fieldLabel: '圖表類型',
                    queryMode : 'local',
                    labelAlign:'left',
                    itemId:'cmbChartGroup',
                    displayField: 'text',
                    valueField: 'value',
                    padding: 5,
                    margin:'5 0 5 5',
                    labelWidth:60,
                    width: 280,
                    editable: false,
                    hidden: false,
                    value:'EC',
                    store : new Ext.data.ArrayStore({
                        fields: ['text', 'value'],
                        data : [ ['EC', 'EC'],
                        ['EN', 'EN'],
                        ['G4', 'G4'],
                        ['HR', 'HR'],
                        ['LA', 'LA'],
                        ['SO', 'SO'],
                        ['PR', 'PR']] 
                    }),
                    readOnlyCls : 'readOnly'
                },
                {
                    xtype: 'label',
                    html: '指標',
                    padding: 5
                }, {
                    xtype: 'fieldset',
                    margin: 5,
                    border: true,
                    minHeight: 50,
                    autoHeight: true,
                    itemId: 'fsKPI',
                    items: [{

                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    padding: 5,
                    items: [{
                        xtype: 'combo',
                        labelAlign: 'right',
                        queryMode: 'local',
                        itemId: 'cmbTimeType',
                        displayField: 'text',
                        valueField: 'value',
                        editable: false,
                        hidden: false,
                        value: 'month',
                        width: 50,
                        store: new Ext.data.ArrayStore({
                            fields: ['text', 'value'],
                            data: [
                                ['月', 'month'],
                                ['年', 'year']
                            ]
                        }),
                        listeners: {
                            'change': function(obj) {
                                var mainPanel = this.up('window');
                                this.up('panel').down("#cmbTimeIdStart").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                                this.up('panel').down("#cmbTimeIdStart").getStore().reload();

                                this.up('panel').down("#cmbTimeIdEnd").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                                this.up('panel').down("#cmbTimeIdEnd").getStore().reload();

                            }
                        }
                    }, {


                        labelAlign: 'right',
                        width: 110,
                        itemId: 'cmbTimeIdStart',
                        xtype: 'combo',
                        displayField: 'TIME_ID',
                        valueField: 'TIME_ID',
                        editable: false,
                        hidden: false,
                        emptyText: '開始時間',
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
                                    'pTimeType': 'month'
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


                        labelAlign: 'right',
                        width: 110,
                        itemId: 'cmbTimeIdEnd',
                        emptyText: '結束時間',
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
                                    'pTimeType': 'month'
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
                    }]
                }, {
                    xtype: 'label',
                    text: '組織',
                    padding: 5
                }, {
                    xtype: 'fieldset',
                    margin: 5,
                    itemId: 'fsFrame',
                    border: true,
                    minHeight: 50,
                    autoHeight: true,
                    items: [{

                    }]
                }, {
                    xtype: 'textfield',
                    fieldLabel: '圖表名稱',
                    padding: 5,
                    labelWidth: 40,
                    width: 280,
                    labelWidth:80,
                    itemId: "txtChartTitle",
                    allowBlank: false
                }, {
                    xtype: 'textarea',
                    fieldLabel: '說明',
                    padding: 5,
                    labelWidth: 40,
                    width: 280,
                    labelWidth:80,
                    itemId: "txtChartDesc",
                    allowBlank: true
                }


            ];
            me.callParent(arguments);
        },
        fbar: [{
            type: 'button',
            text: '預覽',
            handler: function() {
                var kpi = "";
                var frameText = "";
                var frame = "";
                var kpiCount = 0;
                var frameCount = 0;
                for (var i = 0; i < this.up('window').down("#fsKPI").items.items.length; i++) {
                    var item = this.up('window').down("#fsKPI").items.items[i];
                    if (item.xtype == 'button') {
                        kpi += item.KPI_HEAD_UUID + ";";
                        
                        kpiCount++;
                    }
                }

                //alert(kpiText);

                if (kpiCount == 0) {
                    Ext.MessageBox.show({
                        title: '系統提示',
                        icon: Ext.MessageBox.INFO,
                        buttons: Ext.Msg.OK,
                        msg: '請先選擇一個指標'
                    });
                    return;
                }

                if (kpiCount > 1) {
                    Ext.MessageBox.show({
                        title: '系統提示',
                        icon: Ext.MessageBox.INFO,
                        buttons: Ext.Msg.OK,
                        msg: '只可以有一個指標'
                    });
                    return;
                }

                for (var i = 0; i < this.up('window').down("#fsFrame").items.items.length; i++) {
                    var item = this.up('window').down("#fsFrame").items.items[i];
                    if (item.xtype == 'button') {
                        frame += item.FRAME_HEAD_UUID + ";";
                        frameText+=item.getText()+";";
                        frameCount++;
                    }
                }

                //alert(frameText);

                if (frameCount == 0 || frameCount == 1) {
                    Ext.MessageBox.show({
                        title: '系統提示',
                        icon: Ext.MessageBox.INFO,
                        buttons: Ext.Msg.OK,
                        msg: '請先選擇一個以上或多個組織'
                    });
                    return;
                }

                var timeIds = this.up('window').down("#cmbTimeIdStart").getValue();
                var timeIde = this.up('window').down("#cmbTimeIdEnd").getValue();
                var timeColumn = "";


                if (timeIds == undefined || timeIds == '') {
                    Ext.MessageBox.show({
                        title: '製作長方圓提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '開始時間必須選擇'
                    });
                    return;
                }

                if (timeIde == undefined || timeIde == '') {
                    Ext.MessageBox.show({
                        title: '製作長方圓提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '結束時間必須選擇'
                    });
                    return;
                }

                if (this.up('window').down('#cmbTimeType').getValue() == "month") {
                    var s = new Date(timeIds.substring(0, 4) + "/" + timeIds.substring(4, 6) + "/01");
                    var e = new Date(timeIde.substring(0, 4) + "/" + timeIde.substring(4, 6) + "/01");
                    while (e >= s) {
                        var tmp = "";
                        tmp = (s.getMonth() + 1).toString();
                        if (tmp.length == 1) {
                            tmp = "0" + tmp;
                        }
                        timeColumn += s.getFullYear().toString() + tmp + ";";
                        s = new Date(new Date(s).setMonth(s.getMonth() + 1));
                    }

                } else {
                    var s = new Date(timeIds.substring(0, 4) + "/01/01");
                    var e = new Date(timeIde.substring(0, 4) + "/01/01");
                    while (e >= s) {
                        timeColumn += s.getFullYear().toString() + ";";
                        s = new Date(new Date(s).setMonth(s.getMonth() + 12));
                    }
                }

                var NAME = this.up('window').down('#txtChartTitle').getValue();
                var DESC = this.up('window').down('#txtChartDesc').getValue();

                WS.ChartAction.loadColumnClusterCharts(kpi, frame, timeColumn, function(obj, jsonObj) {
                    try {
                        if (jsonObj.result.success) {


                            console.log("here");
                            var arrTimeColumn = Array();

                            arrTimeColumn.push('ITEMCATEGORY');
                            for (var i = 0; i < timeColumn.split(';').length; i++) {
                                if (timeColumn.split(';')[i] != "") {
                                    arrTimeColumn.push("D" + (i + 1));
                                }
                            }

                            var myDataStore = Ext.create('Ext.data.JsonStore', {
                                fields: arrTimeColumn
                            });

                            Ext.each(jsonObj.result.data.Item, function(item) {
                                this.add(item);
                            }, myDataStore);

                            var a = Ext.create('PreviewColumnClusterCharts', {
                                KPI: kpi,
                                FRAME: frame,
                                FRAMETEXT:frameText,
                                TIMES: timeIds,
                                TIMEE: timeIde,
                                TIMECOLUMN: timeColumn,
                                myDataStore: myDataStore,
                                //DISPLAY:DISPLAY,
                                NAME: NAME,
                                DESC: DESC

                            });
                            a.show();
                        } else {
                            Ext.MessageBox.show({
                                title: '設定錯誤',
                                icon: Ext.MessageBox.ERROR,
                                buttons: Ext.Msg.OK,
                                msg: jsonObj.result.message
                            });
                        }
                    } catch (e) {
                        Ext.MessageBox.show({
                            title: '發生異常錯誤',
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK,
                            msg: '造成原因可能為資料不齊全'
                        });
                    }
                });
            }
        }, {
            type: 'button',
            text: '儲存',
            handler: function() {
                var kpi = "";
                var frameText = "";
                var frame = "";
                var kpiCount = 0;
                var frameCount = 0;
                for (var i = 0; i < this.up('window').down("#fsKPI").items.items.length; i++) {
                    var item = this.up('window').down("#fsKPI").items.items[i];
                    if (item.xtype == 'button') {
                        kpi += item.KPI_HEAD_UUID + ";";
                        
                        kpiCount++;
                    }
                }

                //alert(kpiText);

                if (kpiCount == 0) {
                    Ext.MessageBox.show({
                        title: '系統提示',
                        icon: Ext.MessageBox.INFO,
                        buttons: Ext.Msg.OK,
                        msg: '請先選擇一個指標'
                    });
                    return;
                }

                if (kpiCount > 1) {
                    Ext.MessageBox.show({
                        title: '系統提示',
                        icon: Ext.MessageBox.INFO,
                        buttons: Ext.Msg.OK,
                        msg: '只可以有一個指標'
                    });
                    return;
                }

                for (var i = 0; i < this.up('window').down("#fsFrame").items.items.length; i++) {
                    var item = this.up('window').down("#fsFrame").items.items[i];
                    if (item.xtype == 'button') {
                        frame += item.FRAME_HEAD_UUID + ";";
                        frameText+=item.getText()+";";
                        frameCount++;
                    }
                }

                //alert(frameText);

                if (frameCount == 0 || frameCount == 1) {
                    Ext.MessageBox.show({
                        title: '系統提示',
                        icon: Ext.MessageBox.INFO,
                        buttons: Ext.Msg.OK,
                        msg: '請先選擇一個以上或多個組織'
                    });
                    return;
                }

                var timeIds = this.up('window').down("#cmbTimeIdStart").getValue();
                var timeIde = this.up('window').down("#cmbTimeIdEnd").getValue();
                var timeColumn = "";


                if (timeIds == undefined || timeIds == '') {
                    Ext.MessageBox.show({
                        title: '製作長方圓提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '開始時間必須選擇'
                    });
                    return;
                }

                if (timeIde == undefined || timeIde == '') {
                    Ext.MessageBox.show({
                        title: '製作長方圓提示',
                        icon: Ext.MessageBox.WARNING,
                        buttons: Ext.Msg.OK,
                        msg: '結束時間必須選擇'
                    });
                    return;
                }

                if (this.up('window').down('#cmbTimeType').getValue() == "month") {
                    var s = new Date(timeIds.substring(0, 4) + "/" + timeIds.substring(4, 6) + "/01");
                    var e = new Date(timeIde.substring(0, 4) + "/" + timeIde.substring(4, 6) + "/01");
                    while (e >= s) {
                        var tmp = "";
                        tmp = (s.getMonth() + 1).toString();
                        if (tmp.length == 1) {
                            tmp = "0" + tmp;
                        }
                        timeColumn += s.getFullYear().toString() + tmp + ";";
                        s = new Date(new Date(s).setMonth(s.getMonth() + 1));
                    }

                } else {
                    var s = new Date(timeIds.substring(0, 4) + "/01/01");
                    var e = new Date(timeIde.substring(0, 4) + "/01/01");
                    while (e >= s) {
                        timeColumn += s.getFullYear().toString() + ";";
                        s = new Date(new Date(s).setMonth(s.getMonth() + 12));
                    }
                }

                var chartTitle = this.up('window').down('#txtChartTitle').getValue();
                var chartDesc = this.up('window').down('#txtChartDesc').getValue();


                //var display = this.up('window').down('#cmbDisplay').getValue();
                var saveJObject = {
                    'KPI': kpi,
                    'FRAME': frame,
                    'FRAMETEXT':frameText,
                    'TIMES': timeIds,
                    'TIMEE': timeIde,
                    'TIMECOLUMN': timeColumn,
                    //'myDataStore': myDataStore,
                    //DISPLAY:DISPLAY,
                    'NAME': chartTitle,
                    'DESC': chartDesc
                };

                saveJObject = Ext.encode(saveJObject);
                var pChartGroup = this.up('window').down("#cmbChartGroup").getValue();

                WS.ChartAction.saveChartList("","",pChartGroup,chartDesc,chartTitle,"ColumnClusterCharts",kpi,frame,timeIds+"-"+timeIde,"",saveJObject,function(obj,jsonObj){
                    if(jsonObj.result != undefined && jsonObj.result.success){
                        alert('儲存完成');
                    }
                });
            }
        }],
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'close': function() {
                this.closeEvent();
            }
        }
    });

    
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
                paramOrder: ['pTimeId','pTimeId2', 'pKeyword', 'pFullFrameHeadUuid', 'pStatus', 'pKpiType','page', 'limit', 'sort', 'dir'],
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
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">View KPI',
        frame: true,
        height: 560,
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
                labelWidth: 70,
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

                        this.up('panel').down("#cmbTimeId2").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                        this.up('panel').down("#cmbTimeId2").getStore().reload();
                    }
                }
            }, {

                fieldLabel: '時間',
                labelAlign: 'right',
                emptyText:'開始時間',
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
            },  
            {
                text:'~'
            }
            ,
            {

                //fieldLabel: '時間',
                labelAlign: 'right',
                width: 100,
                emptyText:'結束時間',
                //labelWidth: 60,
                itemId: 'cmbTimeId2',
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
            },          
            {
                xtype: 'combo',
                fieldLabel: '指標類別',
                queryMode : 'local',
                itemId:'cmbKpiType',
                displayField: 'text',
                valueField: 'value',
                labelAlign:'right',
                padding: 5,
                width:200,
                labelWidth:80,
                editable: false,
                hidden: false,
                value:'',
                store : new Ext.data.ArrayStore({
                    fields: ['text', 'value'],
                    data : [
                        ['All', ''],
                        ['EC', 'EC'],
                        ['EN', 'EN'],
                        ['G4', 'G4'],
                        ['HR', 'HR'],
                        ['LA', 'LA'],
                        ['SO', 'SO'],
                        ['PR', 'PR'],
                        ] 
                })
            },
             {
                xtype: 'textfield',
                fieldLabel: '關鍵字',
                labelAlign: 'right',
                itemId: 'txt_search',
                width: 200,
                labelWidth: 60
            },
            {
                xtype:'tbfill'
            },
             {
                xtype: 'button',
                text: '製作圓餅圖',
                margin: '0 0 0 10',
                handler: function(handler, scope) {
                    activeChart = Ext.create('PieCharts', {
                        x: ($(document).width() - 300)
                    });
                    activeChart.show();
                }
            }, {
                xtype: 'button',
                text: '製作長條圖',
                margin: '0 10 0 10',
                handler: function(handler, scope) {
                    activeChart = Ext.create('ColumnClusterCharts', {
                        x: ($(document).width() - 300)
                    });
                    activeChart.show();
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
                            'pCompanyUuid': '<%= this.getUser().COMPANY_UUID %>',
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
                    }
                }
            },
            {
                xtype: 'combo',
                labelAlign: 'right',
                width: 177,
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
                margin: '0 10 0 0',
                width: 375,
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
                    var _timeId2 = '';

                    var _keyword = '';
                    var _frameHead = '';
                    var _type = 'Complete';
                    var _kpiType = '';



                    _type = this.up('panel').down("#rdgType").getValue().rdgType;

                    _timeType = this.up('panel').down("#cmbTimeType").getValue();
                    _timeId = this.up('panel').down("#cmbTimeId").getValue();
                    _timeId2 = this.up('panel').down("#cmbTimeId2").getValue();

                    _keyword = this.up('panel').down("#txt_search").getValue();
                    _frameHead = this.up('panel').down("#cmbFrameHead").getValue();
                    _kpiType = this.up('panel').down("#cmbKpiType").getValue();

                    _timeType = Ext.isEmpty(_timeType) ? "" : _timeType;
                    _timeId = Ext.isEmpty(_timeId) ? "" : _timeId;
                    _timeId2 = Ext.isEmpty(_timeId2) ? "" : _timeId2;

                    _keyword = Ext.isEmpty(_keyword) ? "" : _keyword;
                    _frameHead = Ext.isEmpty(_frameHead) ? "" : _frameHead;
                    _kpiType = Ext.isEmpty(_kpiType) ? "" : _kpiType;


                    storeVCal.getProxy().setExtraParam('pTimeType', _timeType);
                    storeVCal.getProxy().setExtraParam('pTimeId', _timeId);
                    storeVCal.getProxy().setExtraParam('pTimeId2', _timeId2);

                    storeVCal.getProxy().setExtraParam('pKeyword', _keyword);
                    storeVCal.getProxy().setExtraParam('pFullFrameHeadUuid', _frameHead);
                    storeVCal.getProxy().setExtraParam('pKpiType',_kpiType)
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
                    VCalQuery.down("#cmbTimeId2").setValue('');
                    VCalQuery.down("#cmbFrameHead").setValue('');
                }
            }]
        }, {
            xtype: 'container',
            layout: 'hbox',
            hidden: true,
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
                    name: 'rdgType',
                    checked: true
                }],
                listeners: {
                    change: function() {

                    }
                }
            }]
        }, {
            xtype: 'gridpanel',
            store: storeVCal,
            itemId: 'grdVCal',
            idProperty: 'UUID',
            paramsAsHash: false,
            padding: 5,
            border: true,
            height: 450,
            columns: [{
                header: '時間',
                dataIndex: 'TIME_ID',
                width: 80
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
                header: '層級',
                dataIndex: 'FRAME_LEVEL',
                width: 60
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
                    icon: './css/custImages/info.png',
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
            listeners: {
                afterrender: function(obj, eOpts) {
                    var mainPanel = this.up('panel');
                    this.up('panel').down("#cmbTimeId").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                    this.up('panel').down("#cmbTimeId").getStore().load({

                    });

                    this.up('panel').down("#cmbTimeId2").getStore().getProxy().setExtraParam('pTimeType', this.up('panel').down('#cmbTimeType').getValue());
                    this.up('panel').down("#cmbTimeId2").getStore().load({

                    });
                    this.up('panel').down("#cmbFrameHead").getStore().getProxy().setExtraParam('pCompanyUuid', '<%= this.getUser().COMPANY_UUID %>');

                },
                'celldblclick': function(obj, td, cellIndex, record, tr, rowIndex, e, eOpts) {
                    if (activeChart == undefined) {
                        return;
                    }
                    if (cellIndex == 0) {
                        /*是時間*/
                    } else if (cellIndex == 1) {
                        /*是KPI ID*/
                        var isExist = false;
                        for (var i = 0; i < activeChart.down("#fsKPI").items.items.length; i++) {
                            var item = activeChart.down("#fsKPI").items.items[i];
                            if (item.xtype == 'button') {
                                if (item.getText() == record.data["KPI_ID"]) {
                                    isExist = true;
                                }
                            }
                        }

                        if (isExist == false) {                          
                            activeChart.down("#fsKPI").add(Ext.create('Ext.button.Button', {
                                text: record.data["KPI_ID"],
                                KPI_HEAD_UUID: record.data["KPI_HEAD_UUID"],
                                iconAlign: 'right',
                                icon: './css/custimages/1415276541_f-cross_256-16.png',
                                margin: '5 5 0 5',
                                handler: function(obj, b, c) {
                                    if (b.target.className.indexOf('x-btn-icon-el') >= 0) {
                                        obj.up('fieldset').remove(obj);                                       
                                    }
                                }
                            }));
                        }



                    } else if (cellIndex == 3) {
                        /*是組織*/
                        var isExist = false;
                        for (var i = 0; i < activeChart.down("#fsFrame").items.items.length; i++) {
                            var item = activeChart.down("#fsFrame").items.items[i];
                            if (item.xtype == 'button') {
                                if (item.getText() == record.data["C_NAME"]) {
                                    isExist = true;
                                }
                            }
                        }

                        if (isExist == false) {
                            activeChart.down("#fsFrame").add(Ext.create('Ext.button.Button', {
                                text: record.data["C_NAME"],
                                iconAlign: 'right',
                                icon: './css/custimages/1415276541_f-cross_256-16.png',
                                FRAME_HEAD_UUID: record.data["FRAME_HEAD_UUID"],
                                margin: '5 5 0 5',
                                handler: function(obj, b, c) {
                                    if (b.target.className.indexOf('x-btn-icon-el') >= 0) {
                                        obj.up('fieldset').remove(obj);                                      
                                    }
                                }
                            }));
                        }

                    }
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
