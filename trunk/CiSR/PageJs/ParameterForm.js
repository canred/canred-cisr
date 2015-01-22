Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('ParameterForm', {
        extend: 'Ext.window.Window',
        title: '係數 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        width: 800,
        height: 660,
        layout: 'fit',
        openerObj: undefined,
        resizable: false,
        draggable: true,
        autoScroll: false,
        y: 0,
        initComponent: function() {
            var me = this;
            me.items = [Ext.create('Ext.form.Panel', {

                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                api: {
                    load: WS.ParameterAction.infoParameterHead,
                    submit: WS.ParameterAction.submitParameterHead
                },
                itemId: 'ParameterForm',
                paramOrder: ['pUuid'],
                border: true,
                autoScroll: false,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'combo',
                            fieldLabel: '公司',
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
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '係數名稱',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'NAME',
                            maxLength: 84,
                            allowBlank: false,
                            width: 750
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
                            width: 750
                        }]

                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 5 0',
                        items: [{
                            xtype: 'numberfield',
                            fieldLabel: '預設值',
                            labelAlign: 'right',
                            name: 'VALUE',
                            allowBlank: false,
                            width: 750
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        margin: '5 0 5 0',
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
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        margin: '5 0 5 0',
                        items: [{
                            fieldLabel: '是否共用',
                            labelAlign: 'right',
                            boxLabel: '是',
                            name: 'IS_PUBLIC',
                            inputValue: 'Y',
                            checked: true
                        }, {
                            boxLabel: '否',
                            name: 'IS_PUBLIC',
                            inputValue: 'N',
                            padding: '0 0 0 60'
                        }]
                    }, {
                        xtype: 'hidden',
                        fieldLabel: 'UUID',
                        name: 'UUID',
                        anchor: '100%',
                        maxLength: 84,
                        itemId: 'UUID'
                    }, {
                        xtype: 'container',
                        width: 750,
                        layout: {
                            type: 'hbox',
                            pack: 'center'
                        },
                        items: [{
                            xtype: 'button',
                            padding: 0,
                            text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                            handler: function() {
                                var main = this.up('window');
                                var form = this.up('window').down("#ParameterForm").getForm();
                                if (form.isValid() == false) {
                                    return;
                                }
                                form.submit({
                                    waitMsg: '更新中...',
                                    success: function(form, action) {
                                        main.uuid = action.result.UUID;
                                        main.down("#UUID").setValue(action.result.UUID);
                                        main.down("#grParameterItem").getStore().getProxy().setExtraParam('pParameterHeadUuid', action.result.UUID);

                                        main.down("#fsRegion").setDisabled(false);
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
                        }]
                    }, {
                        xtype: 'fieldset',
                        border: true,
                        width: 750,
                        title: '依地區分類',
                        itemId: 'fsRegion',
                        items: [{
                            xtype: 'gridpanel',
                            store: Ext.create('Ext.data.Store', {
                                extend: 'Ext.data.Store',
                                autoLoad: false,
                                model: 'VPARAMETERQUERY',
                                pageSize: 10,
                                proxy: {
                                    type: 'direct',
                                    api: {
                                        read: WS.ParameterAction.loadVParameterQueryWithParameter
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['pParameterHeadUuid', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
                                        pParameterHeadUuid: ''
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
                            }),

                            itemId: 'grParameterItem',
                            paramsAsHash: false,
                            autoScroll: true,
                            columns: [{
                                xtype: 'actioncolumn',
                                header: "編輯",
                                width: 50,

                                align: 'center',
                                items: [{
                                    icon: '../../css/custImages/edit.png',
                                    handler: function(grid, rowIndex, colIndex) {
                                        var mainObj = grid.up('window');
                                        if (mainObj.WinParameter == undefined) {
                                            mainObj.WinParameter = Ext.create('ParameterItemForm', {});
                                            mainObj.WinParameter.on('closeEvent', function(obj) {
                                                obj.openerObj.down("#grParameterItem").getStore().reload();
                                            });
                                        }
                                        mainObj.WinParameter.parameterHeadUuid = grid.getStore().getAt(rowIndex).data.PARAMETER_UUID;
                                        mainObj.WinParameter.openerObj = mainObj;
                                        mainObj.WinParameter.setTitle('地區性係數【編輯】');
                                        mainObj.WinParameter.uuid = grid.getStore().getAt(rowIndex).data.PARAMETER_ITEM_UUID;
                                        mainObj.WinParameter.show();
                                    }
                                }],
                                sortable: false,
                                hideable: false
                            }, {
                                text: "地區",
                                dataIndex: 'REGION_NAME',
                                align: 'left',
                                width: 120
                            }, {
                                text: "數值(地區)",
                                dataIndex: 'ITEM_VALUE',
                                align: 'right',
                                width: 100
                            }, {
                                xtype: 'actioncolumn',
                                header: "新增時間",
                                align: 'center',
                                width: 80,
                                items: [{
                                    icon: '../../css/custImages/plus.png',
                                    handler: function(grid, rowIndex, colIndex) {
                                        var mainObj = grid.up('window');
                                        if (mainObj.WinParameterMonth == undefined) {
                                            mainObj.WinParameterMonth = Ext.create('ParameterMonthForm', {});
                                            mainObj.WinParameterMonth.on('closeEvent', function(obj) {
                                                obj.openerObj.down("#grParameterItem").getStore().reload();
                                            });
                                        }
                                        mainObj.WinParameterMonth.parameterItemUuid = grid.getStore().getAt(rowIndex).data.PARAMETER_ITEM_UUID;
                                        mainObj.WinParameterMonth.openerObj = mainObj;
                                        mainObj.WinParameterMonth.setTitle('時間係數【新增】');
                                        mainObj.WinParameterMonth.uuid = undefined; //value;
                                        mainObj.WinParameterMonth.show();
                                    }
                                }],

                                sortable: false,
                                hideable: false
                            }, {
                                header: "編輯",
                                width: 50,
                                align: 'center',
                                xtype: 'actioncolumn',
                                items: [{
                                    icon: '../../css/custImages/edit02.png',
                                    handler: function(grid, rowIndex, colIndex) {
                                        var mainObj = grid.up('window');
                                        if (mainObj.WinParameterMonth == undefined) {
                                            mainObj.WinParameterMonth = Ext.create('ParameterMonthForm', {});
                                            mainObj.WinParameterMonth.on('closeEvent', function(obj) {
                                                obj.openerObj.down("#grParameterItem").getStore().reload();
                                            });
                                        }
                                        mainObj.WinParameterMonth.openerObj = mainObj;
                                        mainObj.WinParameterMonth.setTitle('時間係數【編輯】');
                                        mainObj.WinParameterMonth.uuid = grid.getStore().getAt(rowIndex).data.PARAMETER_MONTH_UUID;
                                        mainObj.WinParameterMonth.show();
                                    }
                                }],
                                sortable: false,
                                hideable: false
                            }, {
                                text: "時間(月份)",
                                dataIndex: 'MONTH_ID',
                                align: 'right',
                                width: 100
                            }, {
                                text: "數值",
                                dataIndex: 'MONTH_VALUE',
                                align: 'right',
                                width: 80
                            }, {
                                text: "說明",
                                dataIndex: 'ITEM_DESCRIPTION',
                                align: 'center'
                            }],
                            height: 310,
                            tbar: [{
                                type: 'button',
                                text: '新增地區',
                                padding: 0,

                                handler: function() {

                                    var myForm = this.up('window').WinParameter;
                                    if (myForm == undefined) {
                                        myForm = Ext.create('ParameterItemForm', {});
                                        myForm.on('closeEvent', function(obj) {
                                            obj.openerObj.down("#grParameterItem").getStore().reload();
                                        });
                                    }
                                    myForm.parameterHeadUuid = this.up('window').uuid;
                                    myForm.openerObj = this.up('window');
                                    myForm.setTitle('地區性係數【新增】');
                                    myForm.uuid = undefined;
                                    myForm.show();
                                }
                            }]
                        }]
                    }
                ],
                fbar: [
                    {
                        type: 'button',
                        text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/leave.png" style="width:20px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '關閉',
                        handler: function() {
                            this.up('window').hide();
                        }
                    }
                ]
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
                if (this.down("#grParameterItem").dockedItems.length == 2) {
                    var pToolbar = new Ext.PagingToolbar({
                        dock: 'bottom',
                        store: this.down("#grParameterItem").getStore(),
                        displayInfo: true,
                        sorters: [{
                            property: 'REGION_NAME',
                            direction: 'ASC'
                        }]
                    });
                    this.down("#grParameterItem").addDocked(pToolbar);
                }

                if (this.uuid != undefined) {
                    /*When 編輯/刪除資料*/
                    this.down("#grParameterItem").getStore().getProxy().setExtraParam('pParameterHeadUuid', this.uuid);
                    this.down("#grParameterItem").getStore().load();
                    this.down("#ParameterForm").getForm().load({
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
                    this.down("#ParameterForm").getForm().reset();
                    this.down("#fsRegion").setDisabled(true);

                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.down("#grParameterItem").getStore().removeAll();
                this.closeEvent();
                this.down("#ParameterForm").getForm().reset();
            }
        }
    });
});