Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('RawHeadCategorForm', {
        extend: 'Ext.window.Window',
        title: '收集資料類別 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        companyUuid: undefined,
        width: 600,
        height: 600,
        layout: 'fit',
        openerObj: undefined,
        resizable: false,
        draggable: true,
        initComponent: function() {
            var me = this;
            me.items = [Ext.create('Ext.form.Panel', {
                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                api: {
                    load: WS.RawAction.infoRawHeadCategory,
                    submit: WS.RawAction.submitRawHeadCategory
                },
                itemId: 'RawHeadCategorForm',
                paramOrder: ['pUuid'],
                border: true,
                autoScroll: true,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [{
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'combo',
                        fieldLabel: '公司',
                        margin: 5,
                        labelAlign: 'right',
                        displayField: 'C_NAME',
                        valueField: 'UUID',
                        name: 'COMPANY_UUID',

                        editable: false,
                        hidden: false,
                        store: Ext.create('Ext.data.Store', {
                            extend: 'Ext.data.Store',
                            autoLoad: true,
                            model: 'COMPANY',
                            pageSize: 9999,
                            remoteSort: true,
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
                                    'pKeyword': '',
                                    'pIsActive': 'Y'
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
                        })

                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '類別名稱',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'NAME',
                        margin: 5,
                        maxLength: 84,
                        allowBlank: false,
                        flex: 1
                    }]

                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'textfield',

                        fieldLabel: '類別說明',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'DESCRIPTION',
                        margin: 5,
                        maxLength: 84,
                        allowBlank: true,
                        flex: 1
                    }]

                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'textfield',

                        fieldLabel: '語言屬性',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'LAN_NO',
                        margin: 5,
                        maxLength: 84,
                        allowBlank: true,
                        flex: 1,
                        value: '0',
                        hidden: true
                    }]
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'UUID',
                    name: 'UUID',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'UUID'
                }],
                fbar: [{
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                    handler: function() {
                        var main = this.up('window');
                        var form = this.up('window').down("#RawHeadCategorForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        }
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                main.uuid = action.result.UUID;
                                main.down("#UUID").setValue(action.result.UUID);
                                main.setTitle('單位【維護】');
                                Ext.MessageBox.show({
                                    title: '維護單位',
                                    msg: '操作完成',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK
                                });
                            },
                            failure: function(form, action) {
                                Ext.MessageBox.show({
                                    title: 'Warning',
                                    msg: action.result.message,
                                    icon: Ext.MessageBox.ERROR,
                                    buttons: Ext.Msg.OK
                                });
                            }
                        });
                    }
                }, {
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/leave.png" style="width:20px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '關閉',
                    handler: function() {
                        this.up('window').hide();
                    }
                }]
            })];
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'show': function() {
                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
                if (this.uuid != undefined) {
                    /*When 編輯/刪除資料*/
                    this.down("#RawHeadCategorForm").getForm().load({
                        params: {
                            'pUuid': this.uuid
                        },
                        success: function(response, a, b) {},
                        failure: function(response, jsonObj, b) {
                            if (!jsonObj.result.success) {
                                Ext.MessageBox.show({
                                    title: 'Warning',
                                    icon: Ext.MessageBox.WARNING,
                                    buttons: Ext.Msg.OK,
                                    msg: jsonObj.result.message
                                });
                            }

                        }
                    });
                } else {
                    /*When 新增資料*/
                    this.down("#RawHeadCategorForm").getForm().reset();
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent();
                this.down("#RawHeadCategorForm").getForm().reset();
            }
        }
    });
});