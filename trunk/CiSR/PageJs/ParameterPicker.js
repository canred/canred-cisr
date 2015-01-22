Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ParameterAction"));
    var storeVParameterQuery =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            model: 'VPARAMETERQUERY',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.ParameterAction.loadVParameterQuery
                },
                reader: {
                    root: 'data'
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
    Ext.define('ParameterPicker', {
        extend: 'Ext.window.Window',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:16px;vertical-align:middle;margin-top:-2px;margin-right:5px;">挑選係數資料',
        closeAction: 'hide',
        uuid: undefined,
        iconSelectUrl: SYSTEM_URL_ROOT + '/css/custImages/mouse_select_left.gif',
        companyUuid: undefined,
        openerObj: undefined,
        width: 750,
        height: 450,
        layout: 'fit',
        resizable: false,
        draggable: true,
        initComponent: function() {
            var me = this;
            me.items = [Ext.create('Ext.form.Panel', {
                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                paramOrder: ['pUuid'],
                border: true,
                bodyPadding: 5,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [
                    {
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '關鍵字',
                            itemId: 'txtKeyword',
                            labelAlign: 'right',
                            enableKeyEvents: true,
                            listeners: {
                                keyup: function(e, t, eOpts) {
                                    if (t.button == 12) {
                                        this.up('panel').down('#btnQuery').handler();
                                    }
                                }
                            }
                        }, {
                            xtype: 'label',
                            text: '',
                            style: 'display:block; padding:4px 4px 4px 4px'
                        }, {
                            xtype: 'button',
                            padding: 0,
                            text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:16px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                            itemId: 'btnQuery',
                            handler: function() {
                                storeVParameterQuery.getProxy().setExtraParam('companyUuid', this.up('window').companyUuid);
                                storeVParameterQuery.getProxy().setExtraParam('keyword', this.up('window').down("#txtKeyword").getValue());
                                storeVParameterQuery.loadPage(1);
                            }
                        }]
                    },
                    {
                        xtype: 'gridpanel',
                        store: storeVParameterQuery,
                        idProperty: 'UUID',
                        paramsAsHash: false,
                        padding: 5,
                        height: 375,
                        columns: [{
                            xtype: 'actioncolumn',
                            text: "挑選",
                            dataIndex: 'UUID',
                            align: 'center',
                            items: [{
                                icon: '../../css/custImages/mouse_select_left.gif',
                                handler: function(grid, rowIndex, colIndex) {
                                    grid.up('window').selectedEvent(grid.getStore().getAt(rowIndex));

                                }
                            }],
                            sortable: false,
                            hideable: false
                        }, {
                            header: "係數名稱",
                            dataIndex: 'NAME',
                            align: 'left',
                            width: 150
                        }, {
                            header: "說明",
                            dataIndex: 'DESCRIPTION',
                            align: 'left',
                            width: 200,
                            hidden: true
                        }, {
                            header: "值",
                            dataIndex: 'VALUE',
                            align: 'right',
                            width: 60
                        }, {
                            header: "地區",
                            dataIndex: 'REGION_NAME',
                            align: 'left',
                            width: 80
                        }, {
                            header: "值(地區)",
                            dataIndex: 'ITEM_VALUE',
                            align: 'right',
                            width: 100
                        }, {
                            header: "月份",
                            dataIndex: 'MONTH_ID',
                            align: 'left',
                            width: 80
                        }, {
                            header: "值(月份)",
                            dataIndex: 'MONTH_VALUE',
                            align: 'right',
                            flex: 1
                        }],
                        anchor: '95%',
                        //height: 450,
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: storeVParameterQuery,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        }),
                        listeners: {
                            'beforerender': function() {}
                        },
                        tbarCfg: {
                            buttonAlign: 'right'
                        }
                    }
                ],
                fbar: [{
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/leave.png" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">關閉',
                    handler: function() {
                        this.up('window').hide();

                    }
                }]
            })]
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        selectedEvent: function(result) {
            this.fireEvent('selectedEvent', result, this.openerObj);
            this.hide();
        },
        listeners: {
            'beforeshow': function() {
                /*:::畫面開啟後載入資料:::*/
                //Ext.getBody().mask();
                this.openerObj != undefined ? this.openerObj.mask() : true;
                storeVParameterQuery.getProxy().setExtraParam('company_uuid', this.companyUuid);
                storeVParameterQuery.getProxy().setExtraParam('keyword', '');
                storeVParameterQuery.load();
            },
            'hide': function() {
                //Ext.getBody().unmask();
                this.openerObj != undefined ? this.openerObj.unmask() : true;
                this.down("#txtKeyword").setValue('');
                this.closeEvent();
            }
        }
    });
});