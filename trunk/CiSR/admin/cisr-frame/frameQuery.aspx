<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="frameQuery.aspx.cs" Inherits="Web.admin.cisrFrame.frameQuery" EnableViewState="false" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/FrameHeadForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/FrameItemSetPWG.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/FrameItemBatchSetPWG.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/KpiPackageForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/FrameCategoryForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script language="javascript" type="text/javascript">
            var thisTreeStore = undefined;
            var AppPageQuery = undefined;
            var myForm = undefined;
            var FrameHeadTaskFlag = false;
            var FrameHeadTask = {
                run: function() {
                    if (FrameHeadTaskFlag == true) {
                        //Ext.getCmp('AppMenu_Tree').expandAll();
                        FrameHeadTaskFlag = false;
                    }
                },
                interval: 2000
            }
            Ext.TaskManager.start(FrameHeadTask);


            var PARENTUUID = undefined;
            function openOrgn(uuid, parendUuid) {
                PARENTUUID = parendUuid;
            }
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AppPageAction"));
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".MenuAction"));
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ApplicationAction"));
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FrameAction"));
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AdminCompanyAction"));
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FrameAction"));
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".RegionAction"));
            Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".KpiAction"));

            Ext.onReady(function() {
                /*:::加入Direct:::*/
                Ext.QuickTips.init();
                /*:::設定Compnay Store物件:::*/
                var storeCompany =
                    Ext.create('Ext.data.Store', {
                                successProperty: 'success',
                                autoLoad: true,
                                model: 'COMPANY',
                                pageSize: 10,
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
                                        pKeyword: '',
                                        pIsActive: 'Y'
                                    },
                                    simpleSortMode: true,
                                    listeners: {
                                        
                                        exception: function(proxy, response, operation) {
                                            Ext.MessageBox.show({
                                                title: 'Warning',
                                                msg: response.result.message,
                                                icon: Ext.MessageBox.ERROR,
                                                buttons: Ext.Msg.OK
                                            });
                                        }
                                    }
                                },
                                remoteSort: true,
                                sorters: [{
                                    property: 'C_NAME',
                                    direction: 'ASC'
                                }],
                                listeners:{
                                    load: function( obj, records, successful, eOpts) {
                                          
                                            if(successful){

                                                if(obj.isFirstTime==undefined){
                                                    Ext.getCmp('frame_Query_Company').setValue(records[0].data["UUID"])        
                                                }

                                            }
                                            
                                        },
                                }
                            });

                Ext.define('Model.AppMenu', {
                    extend: 'Ext.data.Model',
                    fields: [{
                        name: 'UUID'
                    }, {
                        name: 'NAME'
                    }, {
                        name: 'C_NAME'
                    }, {
                        name: 'DLEVEL'
                    }, {
                        name: 'ORD'
                    },{
                        name:'REGION_UUID'
                    }]
                });

                Ext.define('AppMenuTree', {
                    extend: 'Ext.data.TreeStore',
                    root: {
                        expanded: false,
                    },
                    autoLoad: false,
                    successProperty: 'success',
                    model: 'Model.AppMenu',
                    nodeParam: 'id',
                    proxy: {
                        paramOrder: ['UUID'],
                        type: 'direct',
                        directFn: WS.FrameAction.loadFrameTree,
                        extraParams: {
                            "UUID": 'aaa'
                        }
                    }
                });



                thisTreeStore = Ext.create('AppMenuTree', {});

                function isActiveRenderer(value, id, r) {
                    if (value == "Y")
                        return "<img src='../../css/custimages/active.gif' style='height:20px;vertical-align:middle'>";
                    else if (value == "N")
                        return "<img src='../../css/custimages/unactive.gif' style='height:20px;vertical-align:middle'>";
                }

                /*設定元件*/
                AppPageQuery = Ext.widget({
                    xtype: 'panel',
                    title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/menu.png" style="height:20px;vertical-align:middle;margin-right:5px;">組織維護',
                    frame: true,
                    openFrameWin:function(uuid){
                       
                                //alert(PARENTUUID);
                                var main = this;
                                /*frameHeadForm 變量保存在 Ext.FrameHeadForm.js當中*/
                                if (main.frameHeadForm == undefined) {
                                    main.frameHeadForm = Ext.create('FrameHeadForm');
                                    main.frameHeadForm.title = '組織維護';
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    /*載入關閉後的事件*/
                                    main.frameHeadForm.on('closeEvent', function(obj) {
                                        /*重新整理畫面的內容*/
                                        var btnQuery = Ext.getCmp('frame_Query_Button');
                                        btnQuery.handler.call(btnQuery.scope);
                                    });
                                    /*設定開啟事內的條件*/
                                    main.frameHeadForm.uuid = uuid;
                                    main.frameHeadForm.openerObj = main;
                                    //main.frameHeadForm.parentFrameHeadUuid = PARENTUUID;
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    main.frameHeadForm.show();
                                } else {
                                    main.frameHeadForm.uuid = uuid;
                                    main.frameHeadForm.openerObj = main;
                                    //main.frameHeadForm.parentFrameHeadUuid = PARENTUUID;
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    main.frameHeadForm.show();
                                }
                            

                            FrameHeadTaskFlag = true;
                    },
                    addChild:function(uuid, parentUuid) {
                                var main = this;
                                /*frameHeadForm 變量保存在 Ext.FrameHeadForm.js當中*/
                                if (main.frameHeadForm == undefined) {
                                    main.frameHeadForm = Ext.create('FrameHeadForm');
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    /*載入關閉後的事件*/
                                    main.frameHeadForm.on('closeEvent', function(obj) {
                                        /*重新整理畫面的內容*/
                                        var btnQuery = Ext.getCmp('frame_Query_Button');
                                        btnQuery.handler.call(btnQuery.scope);
                                    });
                                    /*設定開啟事內的條件*/
                                    main.frameHeadForm.openerObj = main;
                                    main.frameHeadForm.uuid = undefined;
                                    main.frameHeadForm.parentFrameHeadUuid = parentUuid;
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    main.frameHeadForm.show();
                                } else {
                                    main.frameHeadForm.uuid = undefined;
                                    main.frameHeadForm.openerObj = main;
                                    main.frameHeadForm.parentFrameHeadUuid = parentUuid;
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    main.frameHeadForm.show();
                                }
                            

                            FrameHeadTaskFlag = true;

            },

             delMenu:function (uuid) {
                Ext.Msg.show({
                    title: '刪除組織操作',
                    msg: '確定執行刪除動作?',
                    buttons: Ext.Msg.YESNO,
                    fn: function(btn) {
                        if (btn == "yes") {
                            WS.FrameAction.deleteFrameHead(uuid, function(json) {
                                var btnQuery = Ext.getCmp('frame_Query_Button')
                                btnQuery.handler.call(btnQuery.scope)
                                FrameHeadTaskFlag = true;
                            });
                        }
                    }
                });

            },
                    //padding: 10,
                    autoHeight: true,
                    autoWidth: true,
                    items: [{
                        layout: 'column',
                        padding: 10,
                        border: false,
                        items: [{
                            style: 'display:block; padding:2px 0px 0px 0px',
                            xtype: 'label',
                            text: '公司：'
                        }, {
                            xtype: 'combo',
                            editable: false,
                            store: storeCompany,
                            displayField: 'C_NAME',
                            valueField: 'UUID',
                            id: 'frame_Query_Company',
                            enableKeyEvents: true,
                            listeners: {
                                'change': function(obj, value) {
                                    var btnQuery = Ext.getCmp('frame_Query_Button')
                                    btnQuery.handler.call(btnQuery.scope)
                                    FrameHeadTaskFlag = true;
                                },
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
                            xtype: 'label',
                            text: '',
                            style: 'display:block; padding:4px 4px 4px 4px'
                        }, {
                            xtype: 'button',
                            text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                            style: 'display:block; padding:4px 0px 0px 0px',
                            id: 'frame_Query_Button',
                            itemId: 'btnQuery',
                            handler: function() {
                                /*查詢按鈕*/
                                WS.FrameAction.loadTreeRoot(Ext.getCmp('frame_Query_Company').getValue(), function(data) {
                                    if (data.UUID != undefined) {
                                        //alert(data.UUID);
                                        thisTreeStore.getProxy().setExtraParam('UUID', data.UUID);
                                        thisTreeStore.load({
                                            params: {
                                                'UUID': data.UUID
                                            }
                                        });

                                        FrameHeadTaskFlag = true;
                                    }
                                });

                            }
                        }, {
                            xtype: 'label',
                            text: '',
                            style: 'display:block; padding:4px 4px 4px 4px'
                        }]
                    }, {
                        xtype: 'button',
                        text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">新增年度客戶',
                        style: 'margin-left:5px',
                        handler: function() {

                            WS.FrameAction.loadTreeRoot(Ext.getCmp('frame_Query_Company').getValue(), function(data) {
                                PARENTUUID = data.UUID;
                                //alert(PARENTUUID);
                                var main = this.scope.up('panel');
                                /*frameHeadForm 變量保存在 Ext.FrameHeadForm.js當中*/
                                if (main.frameHeadForm == undefined) {
                                    main.frameHeadForm = Ext.create('FrameHeadForm');
                                    main.frameHeadForm.title = '新增年度客戶';
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    /*載入關閉後的事件*/
                                    main.frameHeadForm.on('closeEvent', function(obj) {
                                        /*重新整理畫面的內容*/
                                        var btnQuery = Ext.getCmp('frame_Query_Button');
                                        btnQuery.handler.call(btnQuery.scope);
                                    });
                                    /*設定開啟事內的條件*/
                                    main.frameHeadForm.openerObj = main;
                                    main.frameHeadForm.uuid = undefined;
                                    main.frameHeadForm.parentFrameHeadUuid = PARENTUUID;
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    main.frameHeadForm.show();
                                } else {
                                    main.frameHeadForm.openerObj = main;
                                    main.frameHeadForm.uuid = undefined;
                                    main.frameHeadForm.parentFrameHeadUuid = PARENTUUID;
                                    main.frameHeadForm.companyUuid = Ext.getCmp('frame_Query_Company').getValue();
                                    main.frameHeadForm.show();
                                }
                            },{
                                scope:this
                            });

                            FrameHeadTaskFlag = true;


                        }
                    }, {
                        xtype: 'treepanel',
                        fieldLabel: '組織維護',
                        id: 'AppMenu_Tree',
                        padding: 5,
                        border: true,
                        autoWidth: true,                        
                        height:200,
                        minHeight: 40000,
                        store: thisTreeStore,
                        //multiSelect: true,
                        rootVisible: false,
                        //useArrows: true,
                        columns: [{
                            xtype: 'treecolumn',
                            text: '組織',
                            flex: 2,
                            sortable: true,
                            dataIndex: 'C_NAME'
                        }, {
                            text: '順序',
                            flex: .5,
                            dataIndex: 'ORD',
                            align: 'center',
                            sortable: false,
                            hidden:true
                        }, {
                            text: "維護",
                            dataIndex: 'UUID',
                            align: 'center',
                            flex: 2,
                            renderer: function(value, m, r) {
                                var id = Ext.id();
                                var dom;
                                if (r.getData().leaf == true) {
                                    dom = "<input type='button' class='edit-button' onclick='AppPageQuery.openFrameWin(\"" + value + "\");' value='編輯'/> <input type='button' class='del-button' onclick='AppPageQuery.delMenu(\"" + value + "\");' value='刪除'/>  <input type='button'  class='add-button'   onclick='AppPageQuery.addChild(\"undefined\",\"" + value + "\");' value='新增子組織'/>";
                                } else {
                                    dom = "<input type='button' class='edit-button' onclick='AppPageQuery.openFrameWin(\"" + value + "\");' value='編輯'/> <input type='button' class='del-button-disable' value='刪除'/>  <input type='button'  class='add-button'   onclick='AppPageQuery.addChild(\"undefined\",\"" + value + "\");' value='新增子組織'/>";
                                }
                                return dom;
                            },
                            sortable: false,
                            hideable: false
                        }],
                        listeners: {
                            beforeload: function(tree, node, eOpts) {
                                // var myMask = new Ext.LoadMask(
                                //     Ext.getCmp('AppMenu_Tree'), {
                                //         msg: "資料載入中，請稍等...",
                                //         store: thisTreeStore,
                                //         removeMask: true
                                //     });
                                // myMask.show();
                                /*樹在開始展開前的動作*/
                                // if (node.isComplete() == false) {
                                //     //thisTreeStore.getProxy().setExtraParam('UUID', node.node.raw['UUID']);
                                //     //alert(node.getParams()["UUID"]);
                                //     if (node.getParams()["UUID"] != undefined) {
                                //         thisTreeStore.getProxy().setExtraParam('UUID', node.getParams()["UUID"]);
                                //     } else {
                                //         thisTreeStore.getProxy().setExtraParam('UUID', node.config.node.data["UUID"]);
                                //     }

                                // }
                            }                            
                        }
                    }]
                });
                AppPageQuery.render('divMain');
            });
        </script>

        <div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
        <!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
        <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>
    </asp:Content>
