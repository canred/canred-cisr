Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".RawAction"));
    var storeRawHead =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: false,
            model: 'V_RAW_HEAD',
            pageSize: 9999,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.RawAction.loadVRawHead
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['company_uuid', 'timeType', 'keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    company_uuid: '',
                    timeType: 'month',
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTION',
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
            remoteSort: true,
            sorters: [{
                property: 'RAW_ID',
                direction: 'ASC'
            }]
        });

    Ext.define('RawHeadPicker', {
        extend: 'Ext.window.Window',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:16px;vertical-align:middle;margin-top:-2px;margin-right:5px;">挑選上傳資料',
        closeAction: 'hide',
        uuid: undefined,
        iconSelectUrl: SYSTEM_URL_ROOT + '/css/custImages/mouse_select_left.gif',
        companyUuid: undefined,
        openerObj: undefined,
        width: 750,
        height: 620,
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
                items: [{
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '關鍵字',
                        itemId: 'WsRawHeadPickerKeyword',
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
                            storeRawHead.getProxy().setExtraParam('timeType', this.up('window').timeType);
                            storeRawHead.getProxy().setExtraParam('company_uuid', this.up('window').companyUuid);
                            storeRawHead.getProxy().setExtraParam('keyword', this.up('window').down("#WsRawHeadPickerKeyword").getValue());
                            storeRawHead.loadPage(1);
                        }
                    }]
                }, {
                    xtype: 'gridpanel',
                    store: storeRawHead,
                    idProperty: 'UUID',
                    paramsAsHash: false,
                    itemId: 'grdRawHead',
                    padding: 5,
                    columns: [{
                        text: "挑選",
                        xtype: 'actioncolumn',
                        dataIndex: 'UUID',
                        align: 'center',
                        width: 60,
                        items: [{
                            tooltip: '*選擇',
                            icon: '../../css/custImages/mouse_select_left.gif',
                            handler: function(grid, rowIndex, colIndex) {
                                grid.up('window').selectedEvent(grid.getStore().getAt(rowIndex));
                            }
                        }],
                        sortable: false,
                        hideable: false
                    }, {
                        text: "上傳資料ID",
                        dataIndex: 'RAW_ID',
                        align: 'left',
                        width: 100
                    }, {
                        text: "名稱",
                        dataIndex: 'C_DESC',
                        align: 'left',
                        width: 200
                    }, {
                        text: "名稱",
                        dataIndex: 'E_DESC',
                        align: 'left',
                        width: 200
                    }, {
                        text: "單位",
                        dataIndex: 'UNIT',
                        align: 'right',
                        width: 80
                    }],
                    height: 450,
                    bbar: Ext.create('Ext.toolbar.Paging', {
                        store: storeRawHead,
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
                }],
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
                this.openerObj != undefined ? this.openerObj.mask() : true;
                storeRawHead.getProxy().setExtraParam('company_uuid', this.companyUuid);
                storeRawHead.getProxy().setExtraParam('keyword', '');
                storeRawHead.getProxy().setExtraParam('timeType', 'month');
                storeRawHead.load();
            },
            'hide': function() {
                this.openerObj != undefined ? this.openerObj.unmask() : true;
                this.down("#WsRawHeadPickerKeyword").setValue('');
                this.closeEvent();
            }
        }
    });
});