Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('FrameItemSetPWG', {
        extend: 'Ext.window.Window',
        title: '設定資料收集人員',
        closeAction: 'hide',
        uuid: undefined,
        companyUuid: undefined,
        frameItemUuid: undefined,
        frameHeadUuid: undefined,
        seq: undefined,
        height: 430,
        width: 800,
        layout: 'fit',
        openerObj: undefined,
        resizable: false,
        draggable: true,
        parentFrameHeadUuid: undefined,
        closeEvent: function() {

        },
        loadUnSelectFn: function() {
            this.down("#grdUnselect").getStore().reload();
        },
        loadSelectFn: function() {
            this.down("#grdSelect").getStore().reload();
        },
        initComponent: function() {
            var me = this;
            me.items = [
                Ext.create('Ext.panel.Panel', {
                    plain: true,
                    padding: 10,
                    buttons: [
                        '->', {

                            xtype: 'button',
                            text: '關閉',
                            handler: function(handler, scope) {
                                this.up('window').hide();
                            }
                        },
                        '->'
                    ],
                    items: [{
                            xtype: 'combo',
                            fieldLabel: '公司',
                            itemId: 'cmbCompany',
                            displayField: 'C_NAME',
                            valueField: 'UUID',
                            padding: 5,
                            editable: false,
                            hidden: false,
                            store: Ext.create('Ext.data.Store', {
                                successProperty: 'success',
                                autoLoad: false,
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
                                        if (successful) {
                                            if (obj.isFirstTime == undefined) {}
                                        }
                                    },
                                }
                            })
                        }, {
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                    xtype: 'fieldset',
                                    border: true,
                                    width: 350,
                                    height: 300,
                                    title: '可選擇人員',
                                    items: [{
                                        xtype: 'gridpanel',
                                        itemId: 'grdUnselect',
                                        selModel: new Ext.selection.CheckboxModel({
                                            checkOnly: true
                                        }),
                                        store: Ext.create('Ext.data.Store', {
                                            extend: 'Ext.data.Store',
                                            autoLoad: false,
                                            model: 'ATTENDANT',
                                            remoteSort: true,
                                            pageSize: 999,
                                            proxy: {
                                                type: 'direct',
                                                api: {
                                                    read: WS.FrameAction.loadAttendantNotIncludePwg
                                                },
                                                reader: {
                                                    root: 'data'
                                                },
                                                paramsAsHash: true,
                                                paramOrder: ['pPwgUuid', 'frameHeadUuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                                                extraParams: {
                                                    'pPwgUuid': '',
                                                    'frameHeadUuid': '',
                                                    'keyword': ''
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
                                                    }
                                                }
                                            },
                                            sorters: [{
                                                property: 'C_NAME',
                                                direction: 'ASC'
                                            }]
                                        }),
                                        paramsAsHash: false,
                                        padding: 5,
                                        autoScroll: true,
                                        columns: [{
                                            text: "名稱",
                                            dataIndex: 'C_NAME',
                                            align: 'center',
                                            flex: 3
                                        }],
                                        height: 270
                                    }]
                                }, {
                                    xtype: 'container',
                                    layout: 'vbox',
                                    margin: '120 5 0 5',
                                    items: [{
                                        xtype: 'button',
                                        text: '>',
                                        handler: function(handler, scope) {
                                            var gid = this.up('window').gid;
                                            var mainWin = this.up('window');
                                            if (this.up('window').down("#grdUnselect").selModel.getSelection().length > 0) {
                                                Ext.each(this.up('window').down("#grdUnselect").selModel.getSelection(), function(item) {

                                                    WS.FrameAction.addAttendToPwg(item.data["UUID"], gid, mainWin.frameItemUuid, mainWin.seq, function(obj, jsonObj) {
                                                        this.loadUnSelectFn();
                                                        this.loadSelectFn();

                                                    }, mainWin);
                                                });
                                            }
                                        }
                                    }, {
                                        xtype: 'button',
                                        margin: '10 0 0 0',
                                        text: '<',
                                        handler: function(handler, scope) {
                                            var gid = this.up('window').gid;
                                            var mainWin = this.up('window');
                                            if (this.up('window').down("#grdSelect").selModel.getSelection().length > 0) {
                                                Ext.each(this.up('window').down("#grdSelect").selModel.getSelection(), function(item) {

                                                    WS.FrameAction.removeAttendFromPwg(item.data["ATTENDANT_UUID"], gid, mainWin.frameItemUuid, mainWin.seq, function(obj, jsonObj) {
                                                        this.loadUnSelectFn();
                                                        this.loadSelectFn();
                                                    }, mainWin);
                                                });
                                            }
                                        }
                                    }]
                                },

                                {
                                    xtype: 'fieldset',
                                    title: '已選擇人員',
                                    border: true,
                                    width: 350,
                                    height: 300,
                                    items: [{
                                        xtype: 'gridpanel',
                                        itemId: 'grdSelect',
                                        selModel: new Ext.selection.CheckboxModel({
                                            checkOnly: true
                                        }),
                                        store: Ext.create('Ext.data.Store', {
                                            extend: 'Ext.data.Store',
                                            autoLoad: false,
                                            model: 'V_PWG',
                                            remoteSort: true,
                                            pageSize: 999,
                                            proxy: {
                                                type: 'direct',
                                                api: {
                                                    read: WS.FrameAction.loadPwg
                                                },
                                                reader: {
                                                    root: 'data'
                                                },
                                                paramsAsHash: true,
                                                paramOrder: ['pPwgUuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                                                extraParams: {
                                                    'pPwgUuid': '',
                                                    'keyword': ''
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
                                                    }
                                                }
                                            },
                                            sorters: [{
                                                property: 'C_NAME',
                                                direction: 'ASC'
                                            }]
                                        }),
                                        paramsAsHash: false,
                                        padding: 5,
                                        autoScroll: true,
                                        columns: [{
                                            text: "名稱",
                                            dataIndex: 'C_NAME',
                                            align: 'center',
                                            flex: 3
                                        }],
                                        height: 270
                                    }]
                                }
                            ]
                        }
                    ]
                })
            ];
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'show': function() {
                var thisMainWin = this;
                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
                if (this.companyUuid != undefined) {

                    this.down("#cmbCompany").getStore().load(function(obj, jsonObj) {
                        if (obj.length == 1) {
                            if (obj[0].data != undefined) {
                                if (obj[0].data["UUID"] != undefined) {
                                    thisMainWin.down("#cmbCompany").setValue(obj[0].data["UUID"]);

                                    WS.FrameAction.checkFramwPWG(thisMainWin.frameItemUuid, thisMainWin.seq, function(obj, jsonObj) {
                                        //console.log(jsonObj);
                                        if (jsonObj.result.success) {
                                            //jsonObj.result.GID
                                            thisMainWin.down("#grdUnselect").getStore().getProxy().setExtraParam('pPwgUuid', jsonObj.result.GID);
                                            thisMainWin.down("#grdUnselect").getStore().getProxy().setExtraParam('frameHeadUuid', thisMainWin.frameHeadUuid);
                                            thisMainWin.down("#grdUnselect").getStore().getProxy().setExtraParam('keyword', '');
                                            thisMainWin.down("#grdUnselect").getStore().load();

                                            thisMainWin.down("#grdSelect").getStore().getProxy().setExtraParam('pPwgUuid', jsonObj.result.GID);
                                            thisMainWin.down("#grdSelect").getStore().load();
                                            thisMainWin.gid = jsonObj.result.GID;
                                        } else {
                                            alert(jsonObj.result.message);
                                        }
                                    });
                                }
                            }
                        }
                    });                 
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent(this);

                this.uuid = undefined;
                this.companyUuid = undefined;
                this.frameItemUuid = undefined;
                this.frameHeadUuid = undefined;
                this.seq = undefined;
               
            }
        }
    });
});