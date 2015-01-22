Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FilesAction"));
    Ext.define('UploadJobLogForm', {
        extend: 'Ext.window.Window',
        title: '簽核紀錄',
        uploadJobUuid: undefined,
        openerObj: undefined,
        uploadJobUuid: undefined,
        closeAction: 'hide',
        width: 700,
        height: 500,
        resizable: false,
        draggable: false,
        locked: false,
        initComponent: function() {
            var me = this;
            me.storeUploadJobLog = Ext.create('Ext.data.Store', {
                extend: 'Ext.data.Store',
                autoLoad: false,
                remoteSort: true,
                model: 'FILES',
                pageSize: 10,
                proxy: {
                    type: 'direct',
                    api: {
                        read: WS.UploadJobAction.loadUploadJobLog
                    },
                    reader: {
                        rootProperty: 'data'
                    },
                    paramsAsHash: true,
                    paramOrder: ['pUploadJobUuid', 'page', 'limit', 'sort', 'dir'],
                    extraParams: {
                        'pUploadJobUuid': me.uploadJobUuid
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
                    property: 'CREATE_DATE',
                    direction: 'DESC'
                }]
            });
            me.items = [{
                xtype: 'panel',
                items: [{
                    xtype: 'fieldset',
                    title: '簽核紀錄',
                    margin: 10,
                    height: 380,
                    border: true,
                    items: [{
                        xtype: 'label',
                        html: '連擊內容可查看完整內容。',
                        margin: '0 0 0 160'
                    }, {
                        xtype: 'gridpanel',
                        itemId: 'grdUploadJobLog',
                        store: me.storeUploadJobLog,
                        paramsAsHash: false,
                        padding: 5,
                        autoScroll: true,
                        columns: [{
                                text: "處理時間",
                                dataIndex: 'CREATE_DATE',
                                align: 'center',
                                sortable: false,
                                width: 150
                            }, {
                                text: '內容',
                                dataIndex: 'MSG',
                                align: 'left',
                                flex: 1
                            }

                        ],
                        height: 350,
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: me.storeUploadJobLog,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        }),
                        listeners: {
                            celldblclick: function(iView, td, cellIndex, record, tr, rowIndex, e, eOpts) {
                                Ext.MessageBox.show({
                                    title: '內容',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: record.data.MSG
                                });
                            }
                        }
                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'tbfill'
                    }, {
                        xtype: 'button',
                        text: '關閉',
                        handler: function(handler, scope) {
                            this.up('window').close();
                        }
                    }, {
                        xtype: 'tbfill'
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

                if (this.uploadJobUuid != undefined) {
                    this.down("#grdUploadJobLog").getStore().getProxy().setExtraParam('pUploadJobUuid', this.uploadJobUuid);
                    this.down("#grdUploadJobLog").getStore().load();
                }
                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
            },
            'hide': function() {
                this.closeEvent();

                this.uploadJobUuid = undefined;
                this.openerObj = undefined;
                this.uploadJobUuid = undefined;
            },
            'close': function() {
                this.closeEvent();
                if (this.openerObj != undefined) {
                    this.openerObj.unmask();
                }
            }
        }
    });
});