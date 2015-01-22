<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="regionQuery.aspx.cs" Inherits="Web.admin.cisrRegion.regionQuery"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/RegionForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var RegionQuery = undefined;
var myForm = undefined;
var myUnit = undefined;

Ext.onReady(function () {
    /*:::加入Direct:::*/    
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".CompanyAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AdminCompanyAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".RegionAction"));

    Ext.QuickTips.init();
    /*:::設定Compnay Store物件:::*/
    var storeRegion =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            /*:::Table設定:::*/
            model: 'REGION',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.RegionAction.loadRegion
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                /*:::Direct Method Parameter Setting:::*/
                paramOrder: ['keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {                    
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function (proxy, response, operation) {
                            if(!response.result.success){
                                Ext.MessageBox.show({
                                    title:'Warning',
                                    icon : Ext.MessageBox.WARNING,
                                    buttons : Ext.Msg.OK,
                                    msg :response.result.message
                                });                                
                            }
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
                property: 'REGION_NAME',
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
    RegionQuery = Ext.widget({
        xtype: 'panel',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">地區/國別維護',
        frame: true,
        height:$(this).height()-140,
        //padding: 5,
        //autoHeight: true,
        //autoWidth: 600,
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
                xtype: 'button',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                style: 'display:block; padding:4px 0px 0px 0px',
                itemId: 'btnQuery',
                handler: function () {
                    //storeRegion.getProxy().setExtraParam('company_uuid', "<%= getUser().COMPANY_UUID %>");
                    storeRegion.getProxy().setExtraParam('keyword', Ext.getCmp('txt_search').getValue());
                    storeRegion.loadPage(1);
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
            store: storeRegion,
            paramOrder: ['C_NAME'],
            idProperty: 'UUID',
            paramsAsHash: false,
            padding: 5,
            border:true,
            //autoHeight:true,
            //height:300,
            height:$(this).height()-240,
            columns: [
            {
                xtype:'actioncolumn',
                width:80,
                header: "編輯",
                //dataIndex: 'UUID',
                align: 'center',
                items:[
                            {
                                 icon: '../../css/custImages/edit.png',
                                        handler: function(grid, rowIndex, colIndex) {    
                                            var openerObj = grid.up('panel');
                                        if (myForm == undefined) {
                                    myForm = Ext.create('RegionForm', {});
                                    myForm.on('closeEvent', function (obj) {
                                        storeRegion.load();
                                    });
                                }
                                myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">地區/國別【維護】');
                                myForm.uuid = grid.getStore().getAt(rowIndex).data.UUID;
                                myForm.openerObj = openerObj;
                                myForm.show(this);
                            }
                        }
                            ],
               
                sortable: false,
                hideable: false
            }
            , {
                header: "地區/國別名稱",
                dataIndex: 'REGION_NAME',
                align: 'center',
                flex: 2
            }, {
                header: "說明",
                dataIndex: 'REGION_DESC',
                align: 'center',
                flex: 2
            }, {
                header: '有效性',
                dataIndex: 'IS_ACTIVE',
                align: 'center',
                flex: 1,
                renderer: isActiveRenderer
            }],
            //height: 450,
            tbarCfg: {
                buttonAlign: 'right'
            },
            bbar: Ext.create('Ext.toolbar.Paging', {
                store: storeRegion,
                displayInfo: true,
                displayMsg: '第{0}~{1}資料/共{2}筆',
                emptyMsg: "無資料顯示"
            }),
            tbar: [
            {
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">新增地區/國別',
                handler: function () {
                    if (myForm == undefined) {
                        myForm = Ext.create('RegionForm', {});
                        myForm.on('closeEvent', function (obj) {
                            storeRegion.load();
                        });
                    }

                    myForm.openerObj = this.up('panel').up('panel');
                    myForm.setTitle('地區/國別【新增】');
                    myForm.uuid = undefined;
                    myForm.show(this.up('panel'));
                }
            }
            ]
        }]
    });
    RegionQuery.render('divMain');
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>