<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="kpiQuery.aspx.cs" Inherits="Web.admin.cisrKpi.kpiQuery"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'</script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>

<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/KpiHeadForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/KpiFormulaForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/UnitForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/RawHeadPicker.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/KpiPicker.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/ParameterPicker.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var KpiQuery = undefined;
var myKpiHead = undefined;
var myKpiFormula = undefined;

Ext.onReady(function() {
    Ext.Loader.setConfig({
        enabled: true
    });

    /*:::加入Direct:::*/
    //Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".CompanyAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AdminCompanyAction"));


    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".KpiAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UnitAction"));
    Ext.QuickTips.init();
    /*:::設定Compnay Store物件:::*/
    var storeVKpi =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            /*:::Table設定:::*/
            model: 'V_KPI',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.KpiAction.loadVKpi
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                /*:::Direct Method Parameter Setting:::*/
                paramOrder: ['companyUuid', 'keyword', 'timeType', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    companyUuid: '',
                    keyword: '',
                    timeType: ''
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
            remoteSort: true,
            sorters: [{
                property: 'KPI_ID',
                direction: 'ASC'
            }]
        });

    function isActiveRenderer(value, id, r) {
        if (value == "Y")
            return "<img src='" + SYSTEM_URL_ROOT + "/css/custimages/active.gif' style='height:15px;vertical-align:middle'>";
        else if (value == "N")
            return "<img src='" + SYSTEM_URL_ROOT + "/css/custimages/unactive.gif' style='height:15px;vertical-align:middle'>";
    }

    /*設定元件*/
    KpiQuery = Ext.widget({
        xtype: 'panel',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">指標維護',
        frame: true,
        height: 480,
        //padding: 5,
        //autoHeight: true,
        //autoWidth: 600,
        items: [{
            layout: 'column',
            padding: 10,
            border: false,
            items: [{
                xtype: 'combo',
                fieldLabel: '公司',
                labelAlign: 'right',
                //id: 'id',
                //queryMode : 'remote',
                itemId: 'cmbCompany',
                displayField: 'C_NAME',
                valueField: 'UUID',
                //name: 'name',

                editable: false,
                hidden: false,
                store: Ext.create('Ext.data.Store', {
                    extend: 'Ext.data.Store',
                    autoLoad: true,
                    model: 'COMPANY',
                    pageSize: 10,
                    remoteSort: true,
                    proxy: {
                        type: 'direct',
                        api: {
                            read: WS.AdminCompanyAction.loadCompany
                        },
                        reader: {
                            root: 'data'
                        },
                        paramsAsHash: true,
                        paramOrder: ['pKeyword', 'pIsActive', 'page', 'limit', 'sort', 'dir'],
                        extraParams: {
                            'pKeyword': '',
                            'pIsActive': 'Y'
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
                        property: 'C_NAME',
                        direction: 'ASC'
                    }]
                }),
                listeners: {
                    'select': function(combo, records, eOpts) {

                    }
                }
            }, {
                fieldLabel: '關鍵字',
                xtype: 'textfield',
                id: 'txt_search',
                labelAlign: 'right',
                width: 200,
                enableKeyEvents: true,
                listeners: {
                    keyup: function(e, t, eOpts) {

                        if (t.button == 12) {
                            this.up('panel').down("#btnQuery").handler();
                        }
                    }
                }
            }, {
                xtype: 'combo',
                fieldLabel: '時間屬性',
                //id: 'id',
                labelAlign: 'right',
                queryMode: 'local',
                itemId: 'cmbTimeType',
                displayField: 'text',
                valueField: 'value',
                width: 200,
                //name: 'name',

                editable: false,
                hidden: false,
                store: new Ext.data.ArrayStore({
                    fields: ['text', 'value'],
                    data: [
                        ['月', 'month'],
                        ['年', 'year']
                    ]
                }),
                value: 'month'

            }, {
                xtype: 'label',
                text: '',
                style: 'display:block; padding:4px 4px 4px 4px'
            }, {
                xtype: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                style: 'display:block; padding:4px 0px 0px 0px',
                itemId: 'btnQuery',
                handler: function() {
                    storeVKpi.getProxy().setExtraParam('companyUuid', this.up('panel').down('#cmbCompany').getValue());
                    storeVKpi.getProxy().setExtraParam('keyword', Ext.getCmp('txt_search').getValue());
                    storeVKpi.getProxy().setExtraParam('timeType', this.up('panel').down('#cmbTimeType').getValue());
                    //  companyUuid:'',                    
                    // keyword: '',cmbCompany
                    // timeType:''
                    storeVKpi.loadPage(1);
                }
            }, {
                xtype: 'label',
                text: '',
                style: 'display:block; padding:4px 4px 4px 4px'
            }, {
                xtype: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/clear.gif" style="height:18px;vertical-align:middle;margin-top:-2px;margin-right:5px;">清除',
                style: 'display:block; padding:4px 0px 0px 0px',
                handler: function() {
                    Ext.getCmp('txt_search').setValue('');
                }
            }]
        }, {
            xtype: 'gridpanel',
            store: storeVKpi,
            //paramOrder: ['C_NAME'],
            idProperty: 'UUID',
            paramsAsHash: false,
            padding: 5,
            border: true,
            autoHeight: true,
            //autoHeight:true,
            //height:400,
            //height:$(this).height()-240,
            columns: [{
                    xtype: 'actioncolumn',
                    align: 'center',
                    header: '操作',
                    items: [{
                        icon: '../../css/custImages/edit.gif',
                        handler: function(grid, rowIndex, colIndex) {
                            if (myKpiHead == undefined) {
                                myKpiHead = Ext.create('KpiHeadForm', {});
                                myKpiHead.on('closeEvent', function(obj) {
                                    storeVKpi.load();
                                });
                            }
                            myKpiHead.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">指標類別【維護】');
                            myKpiHead.uuid = grid.getStore().getAt(rowIndex).data.KPI_HEAD_UUID;
                            myKpiHead.companyUuid = grid.getStore().getAt(rowIndex).data.COMPANY_UUID

                            //console.log(r);
                            myKpiHead.openerObj = grid;
                            myKpiHead.show(this);
                        }
                    }]
                }, {
                    header: "KPI_ID",
                    dataIndex: 'KPI_ID',
                    align: 'left',
                    wieth: 150
                }, {
                    header: "指標名稱",
                    dataIndex: 'C_DESC',
                    align: 'left',
                    width: 200
                }, {
                    header: "時間ID",
                    dataIndex: 'TIME_ID',
                    align: 'right',
                    width: 100
                }, {
                    xtype: 'actioncolumn',
                    align: 'center',
                    header: '新增時間指標',
                    hideable: false,
                    sortable: false,
                    items: [{
                        icon: '../../css/custImages/plus.png',
                        handler: function(grid, rowIndex, colIndex) {
                            if (myKpiFormula == undefined) {
                                myKpiFormula = Ext.create('KpiFormulaForm', {});
                                myKpiFormula.on('closeEvent', function(obj) {
                                    storeVKpi.load();
                                });
                            }
                            myKpiFormula.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">時間性指標【新增】');
                            myKpiFormula.openerObj = grid.up('panel');
                            myKpiFormula.kpi_head_uuid = grid.getStore().getAt(rowIndex).data.KPI_HEAD_UUID
                            myKpiFormula.timeType = grid.getStore().getAt(rowIndex).data.TIME_TYPE;
                            myKpiFormula.uuid = undefined;
                            //alert(this.up('panel').down("#cmbCompany").getValue());



                            myKpiFormula.companyUuid = grid.up('panel').up('panel').down("#cmbCompany").getValue();
                            myKpiFormula.show(this);
                        }
                    }]
                },

                {
                    xtype: 'actioncolumn',
                    header: "編輯時間指標",
                    //dataIndex: 'KPI_FORMULA_UUID',
                    align: 'center',
                    items: [{
                        icon: '../../css/custImages/edit02.png',
                        handler: function(grid, rowIndex, colIndex) {
                            if (myKpiFormula == undefined) {
                                myKpiFormula = Ext.create('KpiFormulaForm', {});
                                myKpiFormula.on('closeEvent', function(obj) {
                                    storeVKpi.load();
                                });
                            }
                            myKpiFormula.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">時間性指標【編輯】');
                            myKpiFormula.openerObj = grid.up('panel');
                            myKpiFormula.timeType = grid.getStore().getAt(rowIndex).data.TIME_TYPE;
                            myKpiFormula.kpi_head_uuid = grid.getStore().getAt(rowIndex).data.KPI_HEAD_UUID;
                            //myKpiFormula.kpi_head_uuid = value;
                            myKpiFormula.uuid = grid.getStore().getAt(rowIndex).data.KPI_FORMULA_UUID;

                            if (grid.getStore().getAt(rowIndex).data.KPI_FORMULA_UUID == "") {
                                Ext.MessageBox.show({
                                    title: '操作提示',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '請先設定/新增時間指標!'
                                });
                            } else {
                                myKpiFormula.companyUuid = grid.up('panel').up('panel').down("#cmbCompany").getValue();
                                myKpiFormula.show(this);
                            }
                            //alert(this.up('panel').down("#cmbCompany").getValue());




                        }
                    }],
                    sortable: false,
                    hideable: false
                }, {
                    header: "公式",
                    dataIndex: 'ALGORITHM_MAN',
                    align: 'left',
                    flex: 1
                }, {
                    header: '有效性',
                    dataIndex: 'IS_ACTIVE',
                    align: 'center',
                    width: 80,
                    renderer: isActiveRenderer
                }
            ],
            //height: 450,
            tbarCfg: {
                buttonAlign: 'right'
            },
            bbar: Ext.create('Ext.toolbar.Paging', {
                store: storeVKpi,
                displayInfo: true,
                displayMsg: '第{0}~{1}資料/共{2}筆',
                emptyMsg: "無資料顯示"
            }),
            tbar: [{
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">新增指標',
                handler: function() {
                    if (myKpiHead == undefined) {
                        myKpiHead = Ext.create('KpiHeadForm', {});
                        myKpiHead.on('closeEvent', function(obj) {
                            storeVKpi.load();
                        });
                    }

                    myKpiHead.openerObj = this.up('panel').up('panel');
                    myKpiHead.setTitle('指標【新增】');
                    myKpiHead.uuid = undefined;
                    myKpiHead.show(this.up('panel'));
                }
            }]
        }],
        listeners: {
            'afterrender': function(obj, eOpts) {
                var main = this;
                this.down("#cmbCompany").getStore().load(function(obj, a) {
                    main.down("#cmbCompany").setValue(obj[0].data.UUID);
                    main.down("#btnQuery").handler();
                    // main.down("#btnQuery").handler();
                });
            }
        }
    });
    KpiQuery.render('divMain');
});
</script>           
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>