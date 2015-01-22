Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('RawHeadForm', {
        extend: 'Ext.window.Window',
        title: '收集資料 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        companyUuid: undefined,
        width: 600,
        height: 600,
        maxHeight: 500,
        maxWidth: 650,
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
                    load: WS.RawAction.infoRawHead,
                    submit: WS.RawAction.submitRawHead
                },
                itemId: 'RawHeadForm',
                paramOrder: ['pUuid'],
                border: true,
                autoScroll: true,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [{
                    xtype: 'container',
                    layout: 'anchor',
                    defaultType: 'textfield',
                    items: [{
                        xtype: 'combo',
                        fieldLabel: '公司',
                        labelAlign: 'right',
                        displayField: 'C_NAME',
                        valueField: 'UUID',
                        name: 'COMPANY_UUID',
                        itemId: 'cmbCompanyUuid',
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

                    }, {
                        fieldLabel: 'ID',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'RAW_ID',
                        anchor: '-50 0',
                        maxLength: 84,
                        allowBlank: false
                    }, {
                        fieldLabel: '名稱(中文)',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'C_DESC',
                        anchor: '-50 0',
                        maxLength: 84,
                        allowBlank: false
                    }, {
                        fieldLabel: '名稱(英文)',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'E_DESC',
                        anchor: '-50 0',
                        maxLength: 84,
                        allowBlank: false
                    }, {
                        fieldLabel: '定義(中文)',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'C_DEFINE',
                        anchor: '-50 0',
                        maxLength: 84,
                        allowBlank: true
                    }, {
                        fieldLabel: '定義(英文)',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'E_DEFINE',
                        anchor: '-50 0',
                        maxLength: 84,
                        allowBlank: true
                    }, {
                        xtype: 'combo',
                        fieldLabel: '時間屬性',
                        labelAlign: 'right',
                        queryMode: 'local',
                        displayField: 'text',
                        valueField: 'value',
                        name: 'TIME_TYPE',
                        itemId: 'cmbTimeType',

                        editable: false,
                        hidden: false,
                        store: new Ext.data.ArrayStore({
                            fields: ['text', 'value'],
                            data: [
                                ['月', 'month'],
                                ['年', 'year']
                            ]
                        }),
                        value: 'month'
                    }, {
                        xtype: 'container',
                        layout: 'hbox',

                        items: [{
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: 'combo',
                                fieldLabel: '類別',
                                labelAlign: 'right',
                                itemId: 'cmbRawCategoryUuid',
                                displayField: 'NAME',
                                valueField: 'UUID',
                                name: 'RAW_CATEGORY_UUID',
                                editable: false,
                                hidden: false,
                                store: Ext.create('Ext.data.Store', {
                                    extend: 'Ext.data.Store',
                                    autoLoad: false,
                                    model: Ext.define('vrawheadcategory', {
                                        extend: 'Ext.data.Model',
                                        /*:::欄位設定:::*/
                                        fields: [' UUID',
                                            ' NAME',
                                            ' DESCRIPTION',
                                            ' LAN_NO',
                                            ' COMPANY_UUID'
                                        ]
                                    }),
                                    pageSize: 999,
                                    proxy: {
                                        type: 'direct',
                                        api: {
                                            read: WS.RawAction.loadRawHeadCategory
                                        },
                                        reader: {
                                            root: 'data'
                                        },
                                        paramsAsHash: true,
                                        paramOrder: ['pCompanyUuid', 'page', 'limit', 'sort', 'dir'],
                                        extraParams: {
                                            'pCompanyUuid': ''
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
                                        property: 'NAME',
                                        direction: 'ASC'
                                    }]
                                }),
                            }, {
                                xtype: 'button',
                                text: '新增',
                                padding: 0,
                                margin: '0 0 0 10',
                                handler: function(handler, scope) {
                                    if (this.up('window').WinRawHeadCategory == undefined) {
                                        this.up('window').WinRawHeadCategory = Ext.create('RawHeadCategorForm', {});
                                        this.up('window').WinRawHeadCategory.on('closeEvent', function(obj) {
                                            console.log('debug');
                                            obj.openerObj.down("#cmbRawCategoryUuid").getStore().reload();
                                        });
                                    }
                                    this.up('window').WinRawHeadCategory.companyUuid = this.up('window').companyUuid;
                                    this.up('window').WinRawHeadCategory.openerObj = this.up('window');
                                    this.up('window').WinRawHeadCategory.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">收集資料類別【新增】');
                                    this.up('window').WinRawHeadCategory.uuid = undefined;
                                    this.up('window').WinRawHeadCategory.show(this);
                                }
                            }]
                        }, {
                            xtype: 'combo',
                            fieldLabel: '單位',
                            labelAlign: 'right',
                            displayField: 'UNIT_NAME',
                            valueField: 'UNIT_NAME',
                            labelWidth: 70,
                            name: 'UNIT',
                            width: 195,
                            editable: false,
                            hidden: false,
                            store: Ext.create('Ext.data.Store', {
                                successProperty: 'success',
                                autoLoad: true,
                                model: Ext.define('ATTEDNANTVV', {
                                    extend: 'Ext.data.Model',
                                    fields: [
                                        ' UNIT_CATEGORY_UUID',
                                        ' COMPANY_UUID',
                                        ' UNIT_CATEGORY_NAME',
                                        ' UNIT_CATEGORY_DESCRIPTION',
                                        ' UNIT_CATEGORY_IS_PUBLIC',
                                        ' UNIT_CATEGORY_IS_ACTIVE',
                                        ' UNIT_UUID',
                                        ' UNIT_NAME',
                                        ' UNIT_C_DESC',
                                        ' UNIT_IS_ACTIVE',
                                        ' UNIT_E_DESC'
                                    ]
                                }),
                                pageSize: 999,
                                proxy: {
                                    type: 'direct',
                                    api: {
                                        read: WS.UnitAction.loadVUnit
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['keyword', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
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
                                        }
                                    }
                                },
                                remoteSort: true,
                                sorters: [{
                                    property: 'UNIT_CATEGORY_NAME',
                                    direction: 'ASC'
                                }]
                            })
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'fieldset',
                            title: '條件&顯示',
                            border: true,
                            width: 500,
                            margin: '0 0 0 30',
                            items: [{
                                xtype: 'container',
                                layout: 'hbox',
                                items: [{
                                    xtype: 'combo',
                                    fieldLabel: '允許為空',
                                    labelAlign: 'right',
                                    width: 200,
                                    queryMode: 'local',
                                    displayField: 'text',
                                    valueField: 'value',
                                    name: 'CAN_NULL',
                                    margin: 5,
                                    editable: false,
                                    hidden: false,
                                    store: new Ext.data.ArrayStore({
                                        fields: ['text', 'value'],
                                        data: [
                                            ['是', 'Y'],
                                            ['否', 'N']
                                        ]
                                    }),
                                    value: 'Y'
                                }, {
                                    xtype: 'combo',
                                    fieldLabel: '需要說明',
                                    labelAlign: 'right',
                                    width: 200,
                                    queryMode: 'local',
                                    displayField: 'text',
                                    valueField: 'value',
                                    name: 'NEED_DESC',
                                    margin: 5,
                                    editable: false,
                                    hidden: false,
                                    store: new Ext.data.ArrayStore({
                                        fields: ['text', 'value'],
                                        data: [
                                            ['是', 'Y'],
                                            ['否', 'N']
                                        ]
                                    }),
                                    value: 'N'
                                }]
                            }, {
                                xtype: 'container',
                                layout: 'hbox',
                                items: [{
                                    xtype: 'combo',
                                    fieldLabel: '需要檔案',
                                    labelAlign: 'right',
                                    width: 200,
                                    queryMode: 'local',
                                    displayField: 'text',
                                    valueField: 'value',
                                    name: 'NEED_FILE',
                                    margin: 5,
                                    editable: false,
                                    hidden: false,
                                    store: new Ext.data.ArrayStore({
                                        fields: ['text', 'value'],
                                        data: [
                                            ['是', 'Y'],
                                            ['否', 'N']
                                        ]
                                    }),
                                    value: 'N'
                                }, {
                                    xtype: 'combo',
                                    fieldLabel: '顯示方式',
                                    labelAlign: 'right',
                                    width: 200,
                                    queryMode: 'local',
                                    displayField: 'text',
                                    valueField: 'value',
                                    name: 'VALUEDISPLAY',
                                    margin: 5,
                                    editable: false,
                                    hidden: false,
                                    store: new Ext.data.ArrayStore({
                                        fields: ['text', 'value'],
                                        data: [
                                            ['一般', 'normal']
                                        ]
                                    }),
                                    value: 'normal'
                                }]
                            }]
                        }]
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
                        margin: '0 0 0 20'
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
                        var form = this.up('window').down("#RawHeadForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        }
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                main.uuid = action.result.UUID;
                                main.down("#UUID").setValue(action.result.UUID);
                                main.setTitle('收集資料【維護】');
                                Ext.MessageBox.show({
                                    title: '維護收集資料',
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
                var mainWin = this;

                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
                this.down("#cmbRawCategoryUuid").getStore().load({
                    callback: function() {
                        if (this.companyUuid != undefined) {
                            this.down("#cmbRawCategoryUuid").getStore().getProxy().setExtraParam('pCompanyUuid', this.companyUuid);
                            this.down("#cmbRawCategoryUuid").getStore().reload({
                                callback: function() {
                                    if (this.uuid != undefined) {
                                        /*When 編輯/刪除資料*/
                                        this.down("#RawHeadForm").getForm().load({
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

                                        this.down("#cmbTimeType").setReadOnly(true);
                                        this.down("#cmbCompanyUuid").setReadOnly(true);
                                    } else {
                                        /*When 新增資料*/
                                        this.down("#cmbTimeType").setReadOnly(false);
                                        this.down("#cmbCompanyUuid").setReadOnly(false);
                                        this.down("#RawHeadForm").getForm().reset();
                                    }
                                },
                                scope: this
                            });
                        }
                    },
                    scope: this
                });


            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent();
                this.down("#RawHeadForm").getForm().reset();
            }
        }
    });
});