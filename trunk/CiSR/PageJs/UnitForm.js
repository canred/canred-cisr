Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('UnitForm', {
        extend: 'Ext.window.Window',
        title: '單位 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        UNIT_CATEGORY_UUID: undefined,
        width: $(window).width() * 0.9,
        height: $(window).height() * 0.9,
        maxHeight: 380,
        maxWidth: 550,
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
                    load: WS.UnitAction.infoUnit,
                    submit: WS.UnitAction.submitUnit
                },
                itemId: 'UnitForm',
                paramOrder: ['pUuid'],
                border: true,
                autoScroll: true,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [
                    {
                        xtype: 'container',
                        layout: 'anchor',
                        defaultType: 'textfield',
                        items: [{
                            xtype: 'combo',
                            fieldLabel: '單位類別',
                            itemId: 'UNIT_CATEGORY_UUID',
                            labelAlign: 'right',
                            displayField: 'NAME',
                            valueField: 'UUID',
                            name: 'UNIT_CATEGORY_UUID',
                            padding: 5,
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
                                        read: WS.UnitAction.loadUnitCategory
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['pKeyword', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
                                        'pKeyword': ''
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
                                    property: 'NAME',
                                    direction: 'ASC'
                                }]
                            })

                        }, {
                            fieldLabel: '單位名稱',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'UNIT_NAME',
                            anchor: '-50 0',
                            maxLength: 84,
                            allowBlank: false
                        }, {
                            fieldLabel: '單位說明',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'UNIT_C_DESC',
                            anchor: '-50 0',
                            maxLength: 84,
                            allowBlank: true
                        }, {
                            fieldLabel: '單位說明(英)',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'UNIT_E_DESC',
                            anchor: '-50 0',
                            maxLength: 84,
                            allowBlank: true
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
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
                    }
                ],
                fbar: [{
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                    handler: function() {
                        var main = this.up('window');
                        var form = this.up('window').down("#UnitForm").getForm();
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
            })]
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
                if (this.UNIT_CATEGORY_UUID != undefined) {
                    this.down("#UNIT_CATEGORY_UUID").store.load({
                        callback: function(obj, jsonObj) {
                            this.down("#UNIT_CATEGORY_UUID").setValue(this.UNIT_CATEGORY_UUID);
                        },
                        scope: this
                    });
                }
                if (this.uuid != undefined) {
                    /*When 編輯/刪除資料*/
                    this.down("#UnitForm").getForm().load({
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
                    this.down("#UnitForm").getForm().reset();
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent();
                this.down("#UnitForm").getForm().reset();
            }
        }
    });
});