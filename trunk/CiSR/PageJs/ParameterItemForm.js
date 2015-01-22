Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('ParameterItemForm', {
        extend: 'Ext.window.Window',
        title: '地區性係數 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        parameterHeadUuid: undefined,
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
                    load: WS.ParameterAction.infoParameterItem,
                    submit: WS.ParameterAction.submitParameterItem
                },
                itemId: 'ParameterItemForm',
                paramOrder: ['pUuid'],
                border: true,
                autoScroll: true,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [

                    {
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'combo',
                            fieldLabel: '地區',
                            labelAlign: 'right',
                            displayField: 'REGION_NAME',
                            valueField: 'UUID',
                            name: 'REGION_UUID',
                            flex: 1,
                            editable: false,
                            hidden: false,
                            store: Ext.create('Ext.data.Store', {
                                extend: 'Ext.data.Store',
                                autoLoad: true,
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
                                    writer: {
                                        type: 'json',
                                        writeAllFields: true,
                                        root: 'updatedata'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['keyword', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
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
                                remoteSort: true,
                                sorters: [{
                                    property: 'REGION_NAME',
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
                            fieldLabel: '係數說明',
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
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        defaultType: 'radiofield',
                        flex: 1,
                        items: [{
                            fieldLabel: '是否啟用',
                            labelAlign: 'right',
                            boxLabel: '是',
                            name: 'IS_ACTIVE',
                            inputValue: 'Y',
                            checked: true
                        }, {
                            boxLabel: '否',
                            name: 'IS_ACTIVE',
                            inputValue: 'N',
                            padding: '0 0 0 60'
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
                        name: 'PARAMETER_HEAD_UUID',
                        padding: 5,
                        anchor: '100%',
                        maxLength: 84,
                        itemId: 'PARAMETER_HEAD_UUID'
                    }
                ],
                fbar: [{
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                    handler: function() {
                        var main = this.up('window');
                        var form = this.up('window').down("#ParameterItemForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        }
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                main.uuid = action.result.UUID;
                                main.down("#UUID").setValue(action.result.UUID);
                                main.setTitle('地區性係數【維護】');
                                Ext.MessageBox.show({
                                    title: '維護地區性係數',
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
                    this.down("#ParameterItemForm").getForm().load({
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
                    this.down("#ParameterItemForm").getForm().reset();
                    this.down("#PARAMETER_HEAD_UUID").setValue(this.parameterHeadUuid);
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent();
                this.down("#ParameterItemForm").getForm().reset();
            }
        }
    });
});