Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".FilesAction"));
    Ext.define('FilesForm', {
        extend: 'Ext.window.Window',
        title: '檔案',
        fileGroupId: undefined,
        openerObj: undefined,
        uploadJobUuid: undefined,
        closeAction: 'hide',
        isNew: true,
        width: 600,
        height: 400,
        resizable: false,
        draggable: false,
        locked: false,
        initComponent: function() {
            var me = this;
            me.items = [{
                xtype: 'form',
                itemId: 'frmFiles',
                api: {
                    submit: WS.FilesAction.submitFiles
                },
                items: [{
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        fieldLabel: '上傳檔案',
                        xtype: 'filefield',
                        labelAlign: 'right',
                        itemId: 'ONE_FILE',
                        name: 'ONE_FILE',
                        flex: 1,
                        margin: 5
                    }, {
                        xtype: 'button',
                        text: '確定',
                        itemId: 'btnOK',
                        margin: 5,
                        handler: function(handler, scope) {
                            this.up('window').down("#frmFiles").getForm().submit({
                                waitMsg: '更新中...',
                                success: function(form, action) {

                                    form.owner.up('window').down("#grdFiles").getStore().getProxy().setExtraParam('pFileGroupId', form.owner.up('window').fileGroupId);
                                    form.owner.up('window').down("#grdFiles").getStore().load();
                                },
                                failure: function(form, action) {
                                    Ext.MessageBox.show({
                                        title: 'System Error',
                                        msg: action.result.message,
                                        icon: Ext.MessageBox.ERROR,
                                        buttons: Ext.Msg.OK
                                    });
                                }
                            }, {
                                scope: this.up('window')
                            });
                        }
                    }, {
                        xtype: 'hiddenfield',
                        name: "FILE_GROUP_ID",
                        itemId: "FILE_GROUP_ID"
                    }, {
                        xtype: 'hiddenfield',
                        name: 'UPLOAD_JOB_UUID',
                        itemId: "UPLOAD_JOB_UUID"

                    }]
                }, {
                    xtype: 'fieldset',
                    title: '檔案清單',
                    margin: 10,
                    height: 260,
                    border: true,
                    items: [{
                        xtype: 'gridpanel',
                        itemId: 'grdFiles',
                        store: Ext.create('Ext.data.Store', {
                            extend: 'Ext.data.Store',
                            autoLoad: false,
                            remoteSort: true,
                            model: 'FILES',
                            pageSize: 10,
                            proxy: {
                                type: 'direct',
                                api: {
                                    read: WS.FilesAction.loadFiles
                                },
                                reader: {
                                    rootProperty: 'data'
                                },
                                paramsAsHash: true,
                                paramOrder: ['pFileGroupId', 'page', 'limit', 'sort', 'dir'],
                                extraParams: {
                                    'pFileGroupId': ''
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
                                property: 'FILE_NAME',
                                direction: 'ASC'
                            }]
                        }),
                        paramsAsHash: false,
                        padding: 5,
                        autoScroll: true,
                        columns: [{
                                text: "Action",
                                dataIndex: 'UUID',
                                align: 'center',
                                sortable: false,
                                width: 80,
                                hidden: this.locked,
                                renderer: function(value, m, r) {
                                    var id = Ext.id();
                                    var winMain = this.up('window');
                                    Ext.defer(function() {
                                        Ext.widget('button', {
                                            renderTo: id,
                                            text: '刪',
                                            width: 60,
                                            uuid: value,
                                            winMain: winMain,
                                            handler: function() {
                                                Ext.MessageBox.confirm('檔案刪除操作', '你確定刪除這一個檔案?', function(result) {
                                                    if (result == 'yes') {

                                                        WS.FilesAction.removeFiles(this.uuid);
                                                        this.winMain.down("#grdFiles").getStore().reload();
                                                    }
                                                }, this);

                                            }
                                        });
                                    }, 50);
                                    return Ext.String.format('<div id="{0}"></div>', id);
                                }
                            }, {
                                text: 'File',
                                dataIndex: 'FILE_NAME',
                                align: 'left',
                                flex: 1,
                                renderer: function(value, m, r) {
                                    var html = "";
                                    html = "<a target='_black' href='" + SYSTEM_URL_ROOT + r.data["SYSTEM_PATH"].replace('~', '') + "'>";
                                    html += r.data["FILE_NAME"];
                                    html += "</a>"

                                    return html;

                                }
                            }

                        ],
                        height: 270
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

                if (this.fileGroupId != undefined) {
                    this.down("#FILE_GROUP_ID").setValue(this.fileGroupId);
                    this.down("#UPLOAD_JOB_UUID").setValue(this.uploadJobUuid);
                    this.down("#grdFiles").getStore().getProxy().setExtraParam('pFileGroupId', this.fileGroupId);
                    this.down("#grdFiles").getStore().load();
                }

                if (this.locked == true) {
                    this.down("#ONE_FILE").setDisabled(true);
                    this.down("#btnOK").setDisabled(true);
                }
                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
            },
            'beforeshow': function() {
            },
            'afterrender': function() {
            },
            'hide': function() {
                this.closeEvent();
                this.fileGroupId = undefined;
                this.openerObj = undefined;
                this.uploadJobUuid = undefined;
            },
            'close': function() {
                this.closeEvent();
                if (this.openerObj != undefined) {
                    this.openerObj.unmask();
                }
                isNew = true;
            }
        }
    });
});