<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="rawQuery.aspx.cs" Inherits="Web.admin.cisrRaw.rawQuery"  EnableViewState="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>

<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/RawHeadForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/RawHeadCategoryForm.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
var RawHeadQuery = undefined;
var myForm = undefined;
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AdminCompanyAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".RawAction"));
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".UnitAction"));
    Ext.QuickTips.init();
    var storeRawHead =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            /*:::Table設定:::*/
            model: 'V_RAW_HEAD',
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.RawAction.loadVRawHead
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['company_uuid', 'time_type', 'keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    company_uuid: '<%= getUser().COMPANY_UUID %>',
                    time_type: 'month',
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
            remoteSort: true,
            sorters: [{
                property: 'RAW_ID',
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
    RawHeadQuery = Ext.widget({
        xtype: 'panel',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">收集資料維護',
        frame: true,
        height: $(this).height() - 150,
        items: [{
            layout: 'column',
            padding: 10,
            border: false,
            items: [{
                xtype: 'combo',
                fieldLabel: '公司',
                labelAlign: 'right',
                displayField: 'C_NAME',
                valueField: 'UUID',
                itemId: 'cmbCompany',
                id: 'cmbCompany',
                margin: '0 10 0 0',
                editable: false,
                hidden: false,
                store: Ext.create('Ext.data.Store', {
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
                    listeners: {
                        load: function(obj, records, successful, eOpts) {
                            if (records.length > 0) {
                                RawHeadQuery.down("#cmbCompany").setValue(records[0].data["UUID"]);
                            } else {
                                Ext.MessageBox.show({
                                    title: '提示',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '無法讀取公司資訊。'
                                });
                            }
                        }
                    }
                })
            }, {
                xtype: 'combo',
                fieldLabel: '時間屬性',
                labelAlign: 'right',
                value: 'month',
                queryMode: 'local',
                itemId: 'cmbTimeType',
                displayField: 'text',
                valueField: 'value',
                margin: '0 10 0 0',
                editable: false,
                hidden: false,
                width:160,
                store: new Ext.data.ArrayStore({
                    fields: ['text', 'value'],
                    data: [
                        ['月', 'month'],
                        ['年', 'year']
                    ]
                })
            }, {
                xtype: 'textfield',
                id: 'txt_search',
                fieldLabel: '關鍵字',
                labelAlign: 'right',
                margin: '0 10 0 0',
                width:200,
                enableKeyEvents: true,
                listeners: {
                    keyup: function(e, t, eOpts) {
                        if (t.button == 12) {
                            this.up('panel').down("#btnQuery").handler();
                        }
                    }
                }
            }, {
                xtype: 'button',
                margin: '0 10 0 0',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                style: 'display:block; padding:4px 0px 0px 0px',
                itemId: 'btnQuery',
                handler: function() {
                    storeRawHead.getProxy().setExtraParam('company_uuid', "<%= getUser().COMPANY_UUID %>");
                    storeRawHead.getProxy().setExtraParam('keyword', Ext.getCmp('txt_search').getValue());
                    storeRawHead.getProxy().setExtraParam('time_type', this.up('panel').down("#cmbTimeType").getValue());
                    storeRawHead.loadPage(1);
                }
            }, {
                xtype: 'button',
                margin: '0 10 0 0',
                text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/clear.gif" style="height:18px;vertical-align:middle;margin-top:-2px;margin-right:5px;">清除',
                style: 'display:block; padding:4px 0px 0px 0px',
                handler: function() {
                    Ext.getCmp('txt_search').setValue('');
                }
            }]
        }, {
            xtype: 'gridpanel',
            store: storeRawHead,
            paramsAsHash: false,
            padding: 5,
            border: true,
            //autoHeight:true,
            height: $(this).height() - 240,
            columns: [
            		{
            			xtype:'actioncolumn',
            			width:40,
            			align:'center',
            			items:[{
            				icon:SYSTEM_URL_ROOT + '/css/custimages/edit.gif',
            				handler:function(grid,rowIndex,colIndex){
            					if (myForm == undefined) {
                                        myForm = Ext.create('RawHeadForm', {});
                                        myForm.on('closeEvent', function(obj) {
                                            storeRawHead.load();
                                        });
                                    }
                                    myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">收集資料【維護】');
                                    myForm.uuid = grid.getStore().getAt(rowIndex).get('UUID');
                                    //alert(this.up('panel').up('panel'));
                                    myForm.openerObj = grid;
                                    myForm.companyUuid = '<%= getUser().COMPANY_UUID %>';
                                    myForm.show(grid);
            				}
            			}]
            		}
            		// ,
            		// {
              //       header: "編輯",
              //       dataIndex: 'UUID',
              //       align: 'center',
              //       renderer: function(value, m, r) {
              //           var id = Ext.id();
              //           var mainObj = this.up('panel');
              //           Ext.defer(function() {
              //               Ext.widget('button', {
              //                   renderTo: id,
              //                   text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/edit.gif" style="height:12px;vertical-align:middle;margin-right:5px;margin-top:-2px;">&nbsp;編輯',
              //                   width: 75,
              //                   mainObj: mainObj,
              //                   handler: function() {
              //                       if (myForm == undefined) {
              //                           myForm = Ext.create('RawHeadForm', {});
              //                           myForm.on('closeEvent', function(obj) {
              //                               storeRawHead.load();
              //                           });
              //                       }
              //                       myForm.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">收集資料【維護】');
              //                       myForm.uuid = value;
              //                       //alert(this.up('panel').up('panel'));
              //                       myForm.openerObj = this.mainObj;
              //                       myForm.companyUuid = '<%= getUser().COMPANY_UUID %>';
              //                       myForm.show(this);
              //                   }
              //               });
              //           }, 50);
              //           return Ext.String.format('<div id="{0}"></div>', id);
              //       },
              //       sortable: false,
              //       hideable: false
              //   }
                , {
                    header: "ID",
                    dataIndex: 'RAW_ID',
                    align: 'left',
                    width:100
                }, {
                    header: "類別",
                    dataIndex: 'RAW_HEAD_CATEGORY_NAME',
                    align: 'center',
                    width:80
                }, {
                    header: "名稱(中文)",
                    dataIndex: 'C_DESC',
                    align: 'left',
                    width:100
                }, {
                    header: "名稱(英文)",
                    dataIndex: 'E_DESC',
                    align: 'left',
                    width:100,
                    hidden: true
                }, {
                    header: "定義(中文)",
                    dataIndex: 'C_DEFINE',
                    align: 'left',
                    width:100
                }, {
                    header: "定義(英文)",
                    dataIndex: 'E_DEFINE',
                    align: 'left',
                    width:100,
                    hidden: true
                }, {
                    header: "單位",
                    dataIndex: 'UNIT',
                    align: 'center',
                    width:60
                }, {
                    header: "時間屬性",
                    dataIndex: 'TIME_TYPE',
                    align: 'left',
                    width:80,
                    renderer: function(value, r) {
                        return value == "month" ? "月" : "年";
                    }
                }, {
                    header: '允許空值',
                    dataIndex: 'CAN_NULL',
                    align: 'center',
                    width:80,
                    renderer: isActiveRenderer
                }, {
                    header: '說明',
                    dataIndex: 'NEED_DESC',
                    align: 'center',
                    width:50,
                    renderer: isActiveRenderer
                }, {
                    header: '檔案',
                    dataIndex: 'NEED_FILE',
                    align: 'center',
                    width:50,
                    renderer: isActiveRenderer
                }
                , {
                    header: '啟用',
                    dataIndex: 'IS_ACTIVE',
                    align: 'center',
                    width:50,
                    renderer: isActiveRenderer
                }
            ],
            tbarCfg: {
                buttonAlign: 'right'
            },
            bbar: Ext.create('Ext.toolbar.Paging', {
                store: storeRawHead,
                displayInfo: true,
                displayMsg: '第{0}~{1}資料/共{2}筆',
                emptyMsg: "無資料顯示"
            }),
            tbar: [{
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/add.gif" style="height:12px;vertical-align:middle;margin-top:-2px;margin-right:5px;">新增',
                    handler: function() {
                        if (myForm == undefined) {
                            myForm = Ext.create('RawHeadForm', {});
                            myForm.on('closeEvent', function(obj) {
                                storeRawHead.load();
                            });
                        }
                        myForm.openerObj = this.up('panel').up('panel');
                        myForm.setTitle('收集資料【新增】');
                        myForm.companyUuid = '<%= getUser().COMPANY_UUID %>';
                        myForm.uuid = undefined;
                        myForm.show(this);
                    }
                }

            ]
        }]
    });
    RawHeadQuery.render('divMain');
});
</script>			
<div id="divMain" style="margin-bottom:5px;margin-top:35px;"></div>
<!-- 使用者session的檢查操作，當逾期時自動轉頁至登入頁面 -->
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/keeySession.js")%>'></script>           
</asp:Content>