<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="Web.admin.basic.mainpage" EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.CompanyForm.js")%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
var CompanyQuery = undefined;
var myForm = undefined;


Ext.onReady(function () {
    /*:::加入Direct:::*/
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AdminCompanyAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ADAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".SyncClientAction"));

    
    Ext.QuickTips.init();
    /*:::設定Compnay Store物件:::*/
    var storeCompany =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            /*:::Table設定:::*/
            model: 'COMPANY',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.AdminCompanyAction.loadCompany
                },
                reader: {
                    rootProperty: 'data'
                },
                paramsAsHash: true,
                /*:::Direct Method Parameter Setting:::*/
                paramOrder: ['pKeyword', 'pIsActive', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: '',
                    pIsActive: 'Y'
                },
                simpleSortMode: true,
                listeners: {
                    exception: function (proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            msg: response.result.message,
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK
                        });
                    },
                    beforeload: function () {
                        alert('beforeload proxy');
                    }
                }
            },
            listeners: {
                write: function (proxy, operation) {},
                read: function (proxy, operation) {},
                beforeload: function () {},
                afterload: function () {},
                load: function () {}
            },
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
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
    CompanyQuery = Ext.widget({
        xtype: 'panel',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/company.png" style="height:20px;vertical-align:middle;margin-right:5px;">公司維護',
        frame: true,
        padding: 5,
        
        height:$(document).height()-140,
        //autoHeight: true,
        autoWidth: true,
        border: true,
        padding: '5 20 5 5',
        items: [{
            layout: 'column',
            padding: 10,
            border: false,
            items: [{
                style: 'display:block; padding:2px 0px 0px 0px',
                xtype: 'label',
                text: '關鍵字：'
            }, {
                xtype: 'textfield',
                id: 'txt_search',
                enableKeyEvents: true,
                listeners: {
                    keyup: function (e, t, eOpts) {
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
                style: 'display:block; padding:2px 0px 0px 20px',
                xtype: 'label',
                text: '是否啟用：'
            }, {
                xtype: 'combobox',
                queryMode: 'local',
                displayField: 'name',
                valueField: 'value',
                id: 'cmb_isActive',
                editable: false,
                width: 80,
                store: {
                    xtype: 'store',
                    fields: ['name', 'value'],
                    data: [{
                        name: "啟用",
                        value: "Y"
                    }, {
                        name: "不啟用",
                        value: "N"
                    }]
                },
                value: 'Y',
                enableKeyEvents: true,
                listeners: {
                    keyup: function (e, t, eOpts) {
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
                handler: function () {
                    storeCompany.getProxy().setExtraParam('pKeyword', Ext.getCmp('txt_search').getValue());
                    storeCompany.getProxy().setExtraParam('pIsActive', Ext.getCmp('cmb_isActive').getValue());
                    storeCompany.load();
                }
            }, {
                xtype: 'label',
                text: '',
                style: 'display:block; padding:4px 4px 4px 4px'
            }, {
                xtype: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/clear.gif" style="height:18px;vertical-align:middle;margin-top:-2px;margin-right:5px;">清除',
                style: 'display:block; padding:4px 0px 0px 0px',
                handler: function () {
                    Ext.getCmp('txt_search').setValue('');
                    Ext.getCmp('cmb_isActive').setValue('Y');
                }
            }]
        }, {
            xtype: 'gridpanel',
            store: storeCompany,
            paramOrder: ['C_NAME'],
            idProperty: 'UUID',
            paramsAsHash: false,   
            border:true,         
            height: $(this).height()-240,
            padding: '5 15 5 5',
            columns: [
                {
                    text: "編輯",
                    xtype: 'actioncolumn',
                    dataIndex: 'UUID',
                    align: 'center',
                    width: 60,
                    items: [{
                        tooltip: '*編輯',
                        icon: '../../css/custImages/edit.gif',
                        handler: function(grid, rowIndex, colIndex) {
                            if (myForm == undefined) {
                                    myForm = Ext.create('CompanyForm', {});
                                    myForm.on('closeEvent', function (obj) {
                                        storeCompany.load();
                                    });
                                }
                                myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/company.png" style="height:20px;vertical-align:middle;margin-right:5px;">公司【維護】');

                                

                                myForm.uuid = grid.getStore().getAt(rowIndex).data.UUID;
                                myForm.show();
                        }
                    }],                            
                    sortable: false,
                    hideable: false
                },
              {
                header: "名稱-繁中",
                dataIndex: 'C_NAME',
                align: 'center',
                flex: 1
            }, {
                header: "名稱-簡中",
                align: 'center',
                dataIndex: 'NAME_ZH_CN',
                flex: 1,
                renderer: function (value) {
                    return '<div align="left">' + value + '</div>';
                }
            }, {

                header: "名稱-英文",
                dataIndex: 'E_NAME',
                align: 'center',
                flex: 1
            }, {
                header: "每週第一天為",
                align: 'center',
                dataIndex: 'WEEK_SHIFT',
                flex: 1,
                renderer: function (value) {
                    return '<div align="left">' + value + '</div>';
                }
            }, {
                header: '啟用',
                dataIndex: 'IS_ACTIVE',
                align: 'center',
                flex: 1,
                renderer: isActiveRenderer
            }],
            
            
            tbarCfg: {
                buttonAlign: 'right'
            },
            bbar: Ext.create('Ext.toolbar.Paging', {
                store: storeCompany,
                displayInfo: true,
                displayMsg: '第{0}~{1}資料/共{2}筆',
                emptyMsg: "無資料顯示"
            }),
            tbar: [
                {
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">新增',
                handler: function () {
                    if (myForm == undefined) {
                        myForm = Ext.create('CompanyForm', {});
                        myForm.on('closeEvent', function (obj) {
                            storeCompany.load();
                        });
                    }
                    myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/company.png" style="height:20px;vertical-align:middle;margin-right:5px;">公司【新增】');
                    myForm.uuid = undefined;
                    myForm.show();
                }
            }
            ,
            {
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/Cloud_Sync.png" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">同步公司(主伺服器)',
                hidden:<%=showSync()%>,
                handler: function () {
                    Ext.getBody().mask("正在處理中…請稍後…");
                    
                    WS.SyncClientAction.SyncCompany(function(obj,jsonObj){
                        Ext.getBody().unmask();
                        if(jsonObj.result.success){
                             
                            Ext.MessageBox.show({
                                title:'同步公司(主伺服器)',
                                icon : Ext.MessageBox.INFO,
                                buttons : Ext.Msg.OK,
                                msg : '已成功完成同步作業。' ,
                                fn:function(){                                   
                                    storeCompany.load();
                                }
                            });
                        }else{

                            Ext.MessageBox.show({
                                                            title:'發生異常',
                                                            icon : Ext.MessageBox.INFO,
                                                            buttons : Ext.Msg.OK,
                                                            msg :  jsonObj.result.message
                                                        });                            
                            
                        }
                    });
                    
                }
            }
            
            ]

        }]
    });
    CompanyQuery.render('divMain');
});
</script>
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>





