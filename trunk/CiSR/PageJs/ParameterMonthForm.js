Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".TimeAction"));
    Ext.define('ParameterMonthForm', {
        extend: 'Ext.window.Window',
        title: '時間係數 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        parameterItemUuid: undefined,
        width: 450,
        height: 300,
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
                    load: WS.ParameterAction.infoParameterMonth,
                    submit: WS.ParameterAction.submitParameterMonth
                },
                itemId: 'ParameterMonthForm',
                paramOrder: ['pUuid'],
                border: true,
                autoScroll: true,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [
                    {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'combo',
                            fieldLabel: '時間屬性',
                            labelAlign: 'right',
                            displayField: 'TIME_ID',
                            valueField: 'TIME_ID',
                            name: 'MONTH_ID',
                            editable: false,
                            hidden: false,
                            store: Ext.create('Ext.data.Store', {
                                extend: 'Ext.data.Store',
                                autoLoad: false,
                                remoteSort: true,
                                model: 'TIME',
                                pageSize: 9999,
                                proxy: {
                                    type: 'direct',
                                    api: {
                                        read: WS.TimeAction.loadTime
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    writer: {
                                        type: 'json',
                                        writeAllFields: true,
                                        root: 'updatedata'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['pTimeType', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
                                        'pTimeType': 'month'
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
                                listeners: {
                                    write: function(proxy, operation) {},
                                    read: function(proxy, operation) {},
                                    beforeload: function() {},
                                    afterload: function() {},
                                    load: function() {}
                                },
                                sorters: [{
                                    property: 'TIME_ID',
                                    direction: 'ASC'
                                }]
                            })
                        }]

                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '時間說明',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'DESCRIPTION',
                            maxLength: 84,
                            allowBlank: true,
                            flex: 1
                        }]

                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'numberfield',
                            fieldLabel: '係數值',
                            labelAlign: 'right',
                            name: 'VALUE',
                            allowBlank: false,
                            flex: 1
                        }]
                    }, {
                        xtype: 'hidden',
                        fieldLabel: 'UUID',
                        name: 'UUID',
                        padding: 5,
                        anchor: '100%',
                        maxLength: 84,
                        itemId: 'UUID'
                    }, {
                        xtype: 'hidden',
                        fieldLabel: 'UUID',
                        name: 'PARAMETER_ITEM_UUID',
                        padding: 5,
                        anchor: '100%',
                        maxLength: 84,
                        itemId: 'PARAMETER_ITEM_UUID'
                    }, {
                        xtype: 'hidden',
                        fieldLabel: 'UUID',
                        name: 'IS_ACTIVE',
                        padding: 5,
                        anchor: '100%',
                        maxLength: 84,
                        value: 'Y'
                    }
                ],
                fbar: [{
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                    handler: function() {
                        var main = this.up('window');
                        var form = this.up('window').down("#ParameterMonthForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        }
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                main.uuid = action.result.UUID;
                                main.down("#UUID").setValue(action.result.UUID);
                                main.setTitle('時間性係數【維護】');
                                Ext.MessageBox.show({
                                    title: '維護時間性係數',
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
                    this.down("#ParameterMonthForm").getForm().load({
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
                    this.down("#ParameterMonthForm").getForm().reset();
                    this.down("#PARAMETER_ITEM_UUID").setValue(this.parameterItemUuid);
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent();
                this.down("#ParameterMonthForm").getForm().reset();
            }
        }
    });
});