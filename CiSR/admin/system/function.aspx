<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="function.aspx.cs" Inherits="Web.admin.system.function"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.CompanyForm.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/Ext.AppPageForm.js")%>'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var AppPageQuery = undefined;
var myForm = undefined;
// Ext.require([
//     'Ext.grid.*',
//     'Ext.data.*',
//     'Ext.util.*',
//     'Ext.toolbar.Paging',
//     'Ext.ux.PreviewPlugin',
//     'Ext.ModelManager',
//     'Ext.tip.QuickTipManager'
// ]);

Ext.onReady(function () {
    /*:::加入Direct:::*/
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AppPageAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ApplicationAction"));
    Ext.QuickTips.init();
    /*:::設定Compnay Store物件:::*/

    var storeApplication =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            /*:::Table設定:::*/
            model: 'APPLICATION',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ApplicationAction.loadApplication
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                /*:::Direct Method Parameter Setting:::*/
                paramOrder: ['pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pKeyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function (proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTION',
                            msg: operation.getError(),
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
                load: function () {
                    if (storeApplication.getCount() > 0) {
                        Ext.getCmp('function_Query_Application').setValue(storeApplication.data.getAt(0).data['UUID']);
                        storeAppPage.getProxy().setExtraParam('pApplicationHeadUuid', Ext.getCmp('function_Query_Application').getValue());
                        storeAppPage.load();
                    }
                }
            },
            remoteSort: true,
            sorters: [{
                property: 'NAME'
            }]
        });

    var storeAppPage =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            /*:::Table設定:::*/
            model: 'APPPAGE',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.AppPageAction.loadAppPage
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                /*:::Direct Method Parameter Setting:::*/
                paramOrder: ['pApplicationHeadUuid', 'pKeyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    pApplicationHeadUuid: '',
                    pKeyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function (proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'Warning',
                            msg: response.result.message,
                            icon: Ext.MessageBox.WARNING,
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
                property: 'NAME'
            }]
        });

    function isActiveRenderer(value, id, r) {
        if (value == "Y")
            return "<img src='../../css/custimages/active.gif' style='height:20px;vertical-align:middle'>";
        else if (value == "N")
            return "<img src='../../css/custimages/unactive.gif' style='height:20px;vertical-align:middle'>";
    }

    /*設定元件*/
    AppPageQuery = Ext.widget({
        xtype: 'panel',
        /*功能清單*/
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/function_tag.png" style="height:20px;vertical-align:middle;margin-right:5px;">功能清單',
        frame: true,
        //padding: 5,
        height:$(this).height()-140,
        autoWidth: true,
        items: [{
            layout: 'column',
            padding: 5,
            border: false,
            items: [{
                style: 'display:block; padding:2px 0px 0px 0px',
                xtype: 'label',
                text: '系統：'
            }, {
                xtype: 'combo',
                editable: false,
                store: storeApplication,
                enableKeyEvents: true,
                displayField: 'NAME',
                valueField: 'UUID',
                id: 'function_Query_Application',
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
                xtype: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                style: 'display:block; padding:4px 0px 0px 0px',
                itemId: 'btnQuery',
                handler: function () {
                    storeAppPage.getProxy().setExtraParam('pKeyword', Ext.getCmp('txt_search').getValue());
                    storeAppPage.getProxy().setExtraParam('pApplicationHeadUuid', Ext.getCmp('function_Query_Application').getValue());
                    storeAppPage.load();
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
                }
            }]
        }, {
            xtype: 'gridpanel',
            store: storeAppPage,
            paramOrder: ['NAME'],
            idProperty: 'UUID',
            paramsAsHash: false,
            height:$(this).height()-240,
            padding: 5,
            border:true,
            columns: [{
                header: "<center>編輯</center>",
                dataIndex: 'UUID',
                align: 'center',
                renderer: function (value, m, r) {
                    var id = Ext.id();
                    Ext.defer(function () {
                        Ext.widget('button', {
                            renderTo: id,
                            text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/edit.gif" style="height:12px;vertical-align:middle;margin-right:5px;margin-top:-2px;">&nbsp;編輯',
                            width: 75,
                            handler: function () {
                                if (myForm == undefined) {
                                    myForm = Ext.create('AppPageForm', {});
                                    myForm.on('closeEvent', function (obj) {
                                        storeAppPage.load();
                                    });
                                }
                                myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/function_tag.png" style="height:20px;vertical-align:middle;margin-right:5px;">功能【維護】');
                                myForm.uuid = value;
                                myForm.show();
                            }
                        });
                    }, 50);
                    return Ext.String.format('<div id="{0}"></div>', id);
                },
                sortable: false,
                hideable: false
            }, {

                header: "<center>功能代碼</center>",
                dataIndex: 'ID',
                align: 'left',
                flex: 1
            }, {

                header: "功能名稱",
                dataIndex: 'NAME',
                align: 'left',
                flex: 1
            }, {

                header: "<center>功能描述</center>",
                align: 'left',
                dataIndex: 'DESCRIPTION',
                flex: 1,
                renderer: function (value) {
                    return '<div align="left">' + value + '</div>';
                }
            }, {
                header: "<center>路徑</center>",
                dataIndex: 'URL',
                align: 'left',
                flex: 1
            }, {

                header: "<center>行為</center>",
                align: 'center',
                dataIndex: 'P_MODE',
                flex: 1,
                renderer: function (value) {
                    return '<div align="left">' + value + '</div>';
                }

            }, {
                header: '<center>啟用</center>',
                dataIndex: 'IS_ACTIVE',
                align: 'center',
                flex: 1,
                renderer: isActiveRenderer
            }],
            
            tbarCfg: {
                buttonAlign: 'right'
            },
            bbar: Ext.create('Ext.toolbar.Paging', {
                store: storeAppPage,
                displayInfo: true,
                displayMsg: '第{0}~{1}資料/共{2}筆',
                emptyMsg: "無資料顯示"
            }),
            tbar: [{
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">新增',
                handler: function () {

                    if (myForm == undefined) {
                        myForm = Ext.create('AppPageForm', {});
                        myForm.on('closeEvent', function (obj) {
                            storeAppPage.load();
                        });
                    }
                    myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/function_tag.png" style="height:20px;vertical-align:middle;margin-right:5px;">功能【新增】');
                    myForm.uuid = undefined;
                    myForm.show();

                }
            }]

        }]
    });
    AppPageQuery.render('divMain');
});
</script>
			
			<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>

