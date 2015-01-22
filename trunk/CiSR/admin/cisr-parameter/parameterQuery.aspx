<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="parameterQuery.aspx.cs" Inherits="Web.admin.cisrParameter.parameterQuery"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")  %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.CompanyForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/ParameterForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/ParameterItemForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/ParameterMonthForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var ParameterQuery = undefined;
var myForm = undefined;
Ext.onReady(function() {
    /*:::加入Direct:::*/
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ParameterAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".RegionAction"));

    Ext.QuickTips.init();
    var storeVParameterQuery =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            model: 'VPARAMETERQUERY',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ParameterAction.loadVParameterQuery
                },
                reader: {
                    rootProperty: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['companyUuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    companyUuid: '',
                    keyword: ''
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
                property: 'NAME',
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
    ParameterQuery = Ext.widget({
        xtype: 'panel',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">係數維護',
        frame: true,
        height: $(this).height() - 140,
        items: [

            {
                layout: 'column',
                padding: 10,
                border: false,
                items: [{
                    xtype: 'combo',
                    fieldLabel: '公司',
                    labelAlign: 'right',
                    itemId: 'cmbCompany',
                    displayField: 'C_NAME',
                    valueField: 'UUID',
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
                                rootProperty: 'data'
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
                    style: 'display:block; padding:2px 0px 0px 0px',
                    xtype: 'label',
                    margin: '0 0 0 20',
                    text: '關鍵字：'
                }, {
                    xtype: 'textfield',
                    id: 'txt_search',
                    enableKeyEvents: true,
                    listeners: {
                        keyup: function(e, t, eOpts) {

                            if (t.button == 12) {
                                this.up('panel').down("#btnQuery").handler();
                            }
                        }
                    }
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
                        storeVParameterQuery.getProxy().setExtraParam('company_uuid', "<%= getUser().COMPANY_UUID %>");
                        storeVParameterQuery.getProxy().setExtraParam('keyword', Ext.getCmp('txt_search').getValue());
                        storeVParameterQuery.loadPage(1);
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
                store: storeVParameterQuery,
                paramOrder: ['C_NAME'],
                idProperty: 'UUID',
                paramsAsHash: false,
                padding: 5,
                border: true,
                height: $(this).height() - 240,
                columns: [{
                    xtype: 'actioncolumn',
                    align: 'center',
                    header: '操作',
                    items: [{
                        icon: '../../css/custImages/edit.gif',
                        handler: function(grid, rowIndex, colIndex) {
                            if (myForm == undefined) {
                                myForm = Ext.create('ParameterForm', {});
                                myForm.on('closeEvent', function(obj) {
                                    storeVParameterQuery.load();
                                });
                            }
                            myForm.openerObj = grid;
                            myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">係數【維護】');
                            myForm.uuid = grid.getStore().getAt(rowIndex).data.PARAMETER_UUID;
                            myForm.show();
                        }
                    }]
                }, {
                    header: "係數名稱",
                    dataIndex: 'NAME',
                    align: 'left',
                    width: 200
                }, {
                    header: "說明",
                    dataIndex: 'DESCRIPTION',
                    align: 'left',
                    flex: 1,
                    hidden: true
                }, {
                    header: "值",
                    dataIndex: 'VALUE',
                    align: 'right',
                    flex: 1
                }, {
                    header: "地區",
                    dataIndex: 'REGION_NAME',
                    align: 'left',
                    flex: 1
                }, {
                    header: "值(地區)",
                    dataIndex: 'ITEM_VALUE',
                    align: 'right',
                    flex: 1
                }, {
                    header: "月份",
                    dataIndex: 'MONTH_ID',
                    align: 'right',
                    flex: 1
                }, {
                    header: "值(月份)",
                    dataIndex: 'MONTH_VALUE',
                    align: 'right',
                    flex: 1
                }, {
                    header: '啟用',
                    dataIndex: 'IS_ACTIVE',
                    align: 'center',
                    flex: 1,
                    renderer: isActiveRenderer
                }, {
                    header: '共用',
                    dataIndex: 'IS_PUBLIC',
                    align: 'center',
                    flex: 1,
                    renderer: isActiveRenderer
                }],
                tbarCfg: {
                    buttonAlign: 'right'
                },
                bbar: Ext.create('Ext.toolbar.Paging', {
                    store: storeVParameterQuery,
                    displayInfo: true,
                    displayMsg: '第{0}~{1}資料/共{2}筆',
                    emptyMsg: "無資料顯示"
                }),
                tbar: [{
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">新增係數',
                    handler: function() {
                        if (myForm == undefined) {
                            myForm = Ext.create('ParameterForm', {});
                            myForm.on('closeEvent', function(obj) {
                                storeVParameterQuery.load();
                            });
                        }
                        myForm.openerObj = this.up('panel');
                        myForm.setTitle('係數【新增】');
                        myForm.uuid = undefined;
                        myForm.show();
                    }
                }]
            }
        ]
    });
    ParameterQuery.render('divMain');
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>