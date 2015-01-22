Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('KpiHeadForm', {
        extend: 'Ext.window.Window',
        title: '指標 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        companyUuid: undefined,
        width: 700,
        height: 620,
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
                    load: WS.KpiAction.infoKpiHead,
                    submit: WS.KpiAction.submitKpiHead
                },
                itemId: 'KpiHeadForm',
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

                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'textfield',
                        width: 275,
                        margin: '5 0 0 0',
                        name: 'KPI_ID',
                        fieldLabel: 'ID',
                        labelAlign: 'right'
                    }, {
                        xtype: 'combo',
                        margin: '5 0 0 0',
                        width: 275,
                        fieldLabel: '單位',
                        labelAlign: 'right',
                        displayField: 'UNIT_NAME',
                        valueField: 'UNIT_NAME',
                        //labelWidth: 70,
                        name: 'UNIT',
                        padding: 5,
                        editable: false,
                        hidden: false,
                        store: Ext.create('Ext.data.Store', {
                            successProperty: 'success',
                            autoLoad: true,
                            model: 'V_UNIT',
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
                },
                {
                    //Aliases
                    xtype : 'container',
                    layout : 'hbox',
                    items : [{
                        xtype: 'textfield',
                        width: 275,
                        margin: '5 0 0 0',
                        name: 'ALIASES',
                        fieldLabel: '類別ID',
                        labelAlign: 'right'
                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    margin: '0 0 0 45',

                    items: [{
                        xtype: 'fieldset',
                        title: '名稱',
                        border: true,
                        width: 215,
                        margin: '0 0 0 15',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '中文',
                            labelAlign: 'right',
                            name: 'C_DESC',
                            labelWidth: 30,
                            width: 160
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '簡中',
                            name: 'ZH_DESC',
                            labelAlign: 'right',
                            labelWidth: 30,
                            width: 160
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '英文',
                            name: 'E_DESC',
                            labelAlign: 'right',
                            labelWidth: 30,
                            width: 160
                        }]
                    }, {
                        xtype: 'fieldset',
                        title: '說明',
                        border: true,
                        width: 215,
                        margin: '0 0 0 60',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '中文',
                            name: 'C_NOTICE',
                            labelAlign: 'right',
                            labelWidth: 30,
                            width: 160
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '簡中',
                            labelAlign: 'right',
                            name: 'ZH_NOTICE',
                            labelWidth: 30,
                            width: 160
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '英文',
                            labelAlign: 'right',
                            name: 'E_NOTICE',
                            labelWidth: 30,
                            width: 160
                        }]
                    }]

                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'combo',
                        width: 270,
                        fieldLabel: '時間屬性',
                        labelAlign: 'right',
                        queryMode: 'local',
                        displayField: 'text',
                        valueField: 'value',
                        name: 'TIME_TYPE',
                        itemId: 'cmbTimeType',
                        padding: 5,
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
                        xtype: 'combo',
                        width: 265,
                        fieldLabel: '小數位',
                        labelAlign: 'right',
                        queryMode: 'local',
                        displayField: 'text',
                        valueField: 'value',
                        name: 'SIGNAL',
                        padding: 5,
                        editable: false,
                        hidden: false,
                        store: new Ext.data.ArrayStore({
                            fields: ['text', 'value'],
                            data: [
                                ['0', '0'],
                                ['1', '1'],
                                ['2', '2'],
                                ['3', '3'],
                                ['4', '4'],
                                ['5', '5'],
                                ['6', '6'],
                            ]
                        }),
                        value: '2'
                    }]

                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        width: 200,
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
                            padding: '0 0 0 20'
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        defaultType: 'radiofield',
                        width: 270,
                        items: [{
                            fieldLabel: '計算方式',
                            labelAlign: 'right',
                            boxLabel: '總合計算',
                            name: 'NEED_SUMMARY',
                            inputValue: 'Y',
                            checked: true
                        }, {
                            boxLabel: '平均計算',
                            name: 'NEED_SUMMARY',
                            inputValue: 'N',
                            padding: '0 0 0 20'
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        hidden: true,
                        defaultType: 'radiofield',
                        width: 200,
                        items: [{
                            fieldLabel: '安全性',
                            labelAlign: 'right',
                            boxLabel: '開啟',
                            name: 'NEED_SECURITY',
                            inputValue: 'Y'
                        }, {
                            boxLabel: '關閉',
                            name: 'NEED_SECURITY',
                            inputValue: 'N',
                            padding: '0 0 0 20',
                            checked: true
                        }]
                    }]
                }, {
                    xtype: 'hidden',
                    fieldLabel: 'UUID',
                    name: 'UUID',
                    padding: 5,

                    maxLength: 84,
                    itemId: 'UUID'
                }, {

                    xtype: 'hidden',
                    fieldLabel: 'DEGREE',
                    name: 'DEGREE',
                    padding: 5,

                    maxLength: 84,
                    itemId: 'DEGREE'
                }, {

                    xtype: 'hidden',
                    fieldLabel: 'INCLUDE_KPI',
                    name: 'INCLUDE_KPI',
                    padding: 5,

                    maxLength: 84,
                    itemId: 'INCLUDE_KPI'
                }, {
                    xtype: 'container',
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
                            var form = this.up('window').down("#KpiHeadForm").getForm();
                            if (form.isValid() == false) {
                                return;
                            }
                            form.submit({
                                waitMsg: '更新中...',
                                success: function(form, action) {
                                    main.uuid = action.result.UUID;
                                    main.down("#UUID").setValue(action.result.UUID);
                                    main.down("#grKpiFormula").getStore().getProxy().setExtraParam('pKpiHeadUuid', action.result.UUID);

                                    main.down("#fsRegion").setDisabled(false);
                                    main.setTitle('指標類別【維護】');
                                    main.down("#fsRegion").setDisabled(false);
                                    main.down("#grKpiFormula").setDisabled(false);
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
                    width: 670,
                    title: '時間性指標',
                    itemId: 'fsRegion',
                    items: [{
                        xtype: 'gridpanel',
                        store: Ext.create('Ext.data.Store', {
                            extend: 'Ext.data.Store',
                            autoLoad: false,
                            model: 'V_KPI_ITEM',
                            pageSize: 10,
                            proxy: {
                                type: 'direct',
                                api: {
                                    read: WS.KpiAction.loadVKpiItem
                                },
                                reader: {
                                    root: 'data'
                                },
                                paramsAsHash: true,
                                paramOrder: ['pKpiHeadUuid', 'page', 'limit', 'sort', 'dir'],
                                extraParams: {
                                    pKpiHeadUuid: ''
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
                                property: 'TIME_ID',
                                direction: 'DESC'
                            }]
                        }),

                        itemId: 'grKpiFormula',
                        paramsAsHash: false,
                        autoScroll: true,
                        //remoteSort:true,
                        columns: [{
                            xtype: 'actioncolumn',
                            header: "編輯",
                            align: 'center',
                            items: [{
                                icon: '../../css/custImages/edit.png',
                                handler: function(grid, rowIndex, colIndex) {
                                    var mainObj = grid.up('window');
                                    if (mainObj.WinKpiHeadFormula == undefined) {
                                        mainObj.WinKpiHeadFormula = Ext.create('KpiFormulaForm', {});
                                        mainObj.WinKpiHeadFormula.on('closeEvent', function(obj) {
                                            obj.openerObj.down("#grKpiFormula").getStore().reload();
                                        });
                                    }
                                    mainObj.WinKpiHeadFormula.openerObj = mainObj;
                                    mainObj.WinKpiHeadFormula.setTitle('時間性指標【編輯】');
                                    mainObj.WinKpiHeadFormula.uuid = grid.getStore().getAt(rowIndex).data.KPI_FORMULA_UUID;
                                    mainObj.WinKpiHeadFormula.companyUuid = mainObj.down("#cmbCompanyUuid").getValue();
                                    mainObj.WinKpiHeadFormula.kpi_head_uuid = mainObj.uuid;
                                    mainObj.WinKpiHeadFormula.timeType = mainObj.down("#cmbTimeType").getValue();
                                    mainObj.WinKpiHeadFormula.show();
                                }
                            }],
                            sortable: false,
                            hideable: false
                        }, {
                            text: "時間(月份)",
                            dataIndex: 'TIME_ID',
                            align: 'center',
                            flex: 1
                        }, {
                            text: "公式",
                            dataIndex: 'ALGORITHM_MAN',
                            align: 'left',
                            flex: 3
                        }, {
                            text: "公式說明",
                            dataIndex: 'KPI_FORMULA_DESC',
                            align: 'left',
                            flex: 1
                        }],
                        autoHeight: true,
                        tbar: [{
                            type: 'button',
                            text: '新增時間性指標',
                            padding: 0,
                            handler: function() {
                                var myForm = this.up('window').WinKpiFormula;
                                if (myForm == undefined) {
                                    myForm = Ext.create('KpiFormulaForm', {});
                                    myForm.on('closeEvent', function(obj) {
                                        obj.openerObj.down("#grKpiFormula").getStore().reload();
                                    });
                                }
                                myForm.kpi_head_uuid = this.up('window').uuid;
                                myForm.companyUuid = this.up('window').down("#cmbCompanyUuid").getValue();
                                myForm.openerObj = this.up('window');
                                myForm.setTitle('時間性指標【新增】');
                                myForm.timeType = this.up('window').down("#cmbTimeType").getValue();
                                myForm.uuid = undefined;
                                myForm.show();
                            }
                        }]
                    }]
                }],
                fbar: [{
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
                if (this.down("#grKpiFormula").dockedItems.length == 2) {
                    var pToolbar = new Ext.PagingToolbar({
                        dock: 'bottom',
                        store: this.down("#grKpiFormula").getStore(),
                        displayInfo: true,
                        sorters: [{
                            property: 'REGION_NAME',
                            direction: 'ASC'
                        }]
                    });
                    this.down("#grKpiFormula").addDocked(pToolbar);
                }
                if (this.uuid != undefined) {
                    this.down("#fsRegion").setDisabled(false);
                    this.down("#grKpiFormula").setDisabled(false);
                    /*When 編輯/刪除資料*/
                    this.down("#grKpiFormula").getStore().getProxy().setExtraParam('pKpiHeadUuid', this.uuid);
                    this.down("#grKpiFormula").getStore().load();
                    this.down("#KpiHeadForm").getForm().load({
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
                    this.down("#KpiHeadForm").getForm().reset();
                    this.down("#fsRegion").setDisabled(true);
                    this.down("#grKpiFormula").setDisabled(true);
                    this.down("#cmbTimeType").setReadOnly(false);
                    this.down("#cmbCompanyUuid").setReadOnly(false);
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.down("#grKpiFormula").getStore().removeAll();
                this.closeEvent();
                this.down("#KpiHeadForm").getForm().reset();
            }
        }
    });
});