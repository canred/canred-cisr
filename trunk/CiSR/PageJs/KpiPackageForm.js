Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".KpiAction"));
    Ext.define('KpiPackageForm', {
        extend: 'Ext.window.Window',
        title: 'KPI策略 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        companyUuid: undefined,
        height: 620,
        width: 900,
        layout: 'fit',
        hasChange: false,
        openerObj: undefined,
        resizable: false,
        draggable: true,
        closeEvent: undefined,
        initComponent: function() {
            var me = this;
            me.items = [Ext.create('Ext.form.Panel', {
                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                api: {
                    load: WS.FrameAction.infoKpiPackage,
                    submit: WS.FrameAction.submitKpiPackage
                },
                itemId: 'KpiPackageForm',
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
                        fieldLabel: '策略名稱',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'NAME',
                        maxLength: 84,
                        allowBlank: false,
                        margin: '5 0 0 0'
                    }, {
                        xtype: 'numberfield',
                        fieldLabel: '指定時間屬性',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'SCOPE_MONTH_ID',
                        emptyText: 'ex:201401 or 2014',
                        maxLength: 84,
                        allowBlank: false,
                        margin: '5 0 0 0'
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
                    xtype: 'container',
                    layout: {
                        type: 'hbox',
                        pack: 'center'
                    },
                    items: [{
                        xtype: 'button',
                        margin: '5 0 0 0',
                        text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                        handler: function() {
                            var main = this.up('window');

                            var form = this.up('window').down("#KpiPackageForm").getForm();
                            if (form.isValid() == false) {
                                return;
                            }
                            form.submit({
                                waitMsg: '更新中...',
                                success: function(form, action) {
                                    main.uuid = action.result.UUID;
                                    main.down("#UUID").setValue(action.result.UUID);
                                    main.down("#fsKpiPackageItem").setDisabled(false);
                                    main.setTitle('KPI策略【維護】');
                                    Ext.MessageBox.show({
                                        title: '維護KPI策略',
                                        msg: '操作完成',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK
                                    });

                                    var grdUnSelect = main.down('#grdUnSelectKpi');
                                    var grdSelect = main.down('#grdSelectKpi');
                                    var _kpiPackageUuid = main.uuid;
                                    var _companyUuid = main.companyUuid;

                                    grdUnSelect.getStore().getProxy().setExtraParam('packageUuid', _kpiPackageUuid);
                                    grdUnSelect.getStore().getProxy().setExtraParam('companyUuid', _companyUuid);
                                    grdUnSelect.getStore().load();

                                    grdSelect.getStore().getProxy().setExtraParam('packageUuid', _kpiPackageUuid);
                                    grdSelect.getStore().getProxy().setExtraParam('companyUuid', _companyUuid);
                                    grdSelect.getStore().load();
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
                    title: '策略KPI項目',
                    itemId: 'fsKpiPackageItem',
                    items: [{
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'gridpanel',
                            enableColumnMove: false,
                            itemId: 'grdUnSelectKpi',
                            selModel: new Ext.selection.CheckboxModel({
                                mode: 'MULTI',
                                checkOnly: false
                            }),
                            store: Ext.create('Ext.data.Store', {
                                successProperty: 'success',
                                autoLoad: false,
                                model: 'V_KPI',
                                pageSize: 9999,
                                proxy: {
                                    type: 'direct',
                                    api: {
                                        read: WS.KpiAction.loadVKpiNotIncludePackageUuid
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['companyUuid', 'packageUuid', 'keyword', 'timeType', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
                                        packageUuid: '',
                                        companyUuid: '',
                                        keyword: '',
                                        timeType: ''
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
                                    property: 'KPI_ID',
                                    direction: 'ASC'
                                }]
                            }),
                            paramsAsHash: false,
                            padding: 5,
                            autoScroll: true,
                            columns: [{
                                text: "指標 ID",
                                dataIndex: 'KPI_ID',
                                align: 'left',
                                width: 100,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }

                                }
                            }, {
                                text: "名稱",
                                dataIndex: 'C_DESC',
                                align: 'left',
                                width: 100,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }

                                }
                            }, {
                                text: "時間",
                                dataIndex: "TIME_ID",
                                align: 'left',
                                width: 80,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }

                                }
                            }],
                            height: 380,
                            width: 400
                           
                        }, {
                            xtype: 'container',
                            layout: {
                                type: 'vbox',
                                pack: 'center'
                            },
                            height: 380,
                            items: [{
                                xtype: 'button',
                                text: '>',
                                margin: '10 0 10 0',
                                handler: function(handler, scope) {
                                    var main = this.up('window');
                                    var arrKpiHead = "";
                                    var selectCount = 0;
                                    Ext.each(main.down("#grdUnSelectKpi").getSelectionModel().getSelection(), function(item) {
                                        arrKpiHead += item.data["KPI_HEAD_UUID"] + ';';
                                        selectCount += 1;
                                    });
                                    if (selectCount > 100) {
                                        Ext.MessageBox.show({
                                            title: '係統提供',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '一次最多處理100項資料'
                                        });

                                        return;
                                    }

                                    if (selectCount > 100) {
                                        Ext.MessageBox.show({
                                            title: '係統提供',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '一次最多處理100項資料'
                                        });

                                        return;
                                    }
                                    main.mask('處理中');
                                    WS.KpiAction.KpiPackageAddKpiHead(main.uuid, arrKpiHead, function(obj, jsonObj) {
                                        if (jsonObj.result.success) {
                                            this.scope.down("#grdUnSelectKpi").getStore().reload();
                                            this.scope.down("#grdSelectKpi").getStore().reload();
                                            this.scope.hasChange = true;
                                        } else {
                                            alert(jsonObj.result.message)
                                        }
                                        this.scope.unmask();
                                    }, {
                                        scope: main
                                    });
                                }
                            }, {
                                xtype: 'button',
                                text: '<',
                                handler: function(handler, scope) {
                                    var main = this.up('window');
                                    var arrKpiHeadUuid = "";
                                    var selectCount = 0;
                                    Ext.each(main.down("#grdSelectKpi").getSelectionModel().getSelection(), function(item) {
                                        arrKpiHeadUuid += item.data["KPI_HEAD_UUID"] + ";";
                                        selectCount += 1;
                                    });
                                    main.mask();
                                    WS.KpiAction.KpiPackageRemoveKpiHead(main.uuid, arrKpiHeadUuid, function(obj, jsonObj) {
                                        if (jsonObj.result.success) {
                                            this.scope.down("#grdUnSelectKpi").getStore().reload();
                                            this.scope.down("#grdSelectKpi").getStore().reload();
                                            this.scope.hasChange = true;
                                            this.scope.unmask();
                                        }
                                    }, {
                                        scope: main
                                    });
                                }
                            }]
                        }, {
                            xtype: 'gridpanel',
                            itemId: 'grdSelectKpi',
                            enableColumnMove: false,
                            store: Ext.create('Ext.data.Store', {
                                successProperty: 'success',
                                autoLoad: false,
                                model: 'V_KPI',
                                pageSize: 9999,
                                proxy: {
                                    type: 'direct',
                                    api: {
                                        read: WS.KpiAction.loadVKpiIncludePackageUuid
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['companyUuid', 'packageUuid', 'keyword', 'timeType', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
                                        packageUuid: '',
                                        companyUuid: '',
                                        keyword: '',
                                        timeType: ''
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
                                    property: 'KPI_ID',
                                    direction: 'ASC'
                            }]

                            }),
                            paramsAsHash: false,
                            padding: 5,
                            autoScroll: true,
                            selModel: new Ext.selection.CheckboxModel({
                                mode: 'MULTI',
                                checkOnly: true
                            }),
                            columns: [{
                                text: "指標 ID",
                                dataIndex: 'KPI_ID',
                                align: 'left',
                                flex: 1,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }
                                }
                            }, {
                                text: "名稱",
                                dataIndex: 'C_DESC',
                                align: 'left',
                                flex: 3,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }
                                }
                            }, {
                                text: "時間",
                                dataIndex: "TIME_ID",
                                align: 'left',
                                flex: 1,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }
                                }
                            }],
                            height: 380,
                            width: 450
                        }]
                    }]
                }, {
                    xtype: 'label',
                    text: '字體顏色說明：藍字表「年」資料；黑字表「月」資料'
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
                this.hasChange = false;
                if (this.uuid != undefined) {
                    /*When 編輯/刪除資料*/
                    this.down("#KpiPackageForm").getForm().load({
                        params: {
                            'pUuid': this.uuid
                        },
                        success: function(response, a, b) {
                            if (response.owner.up('window').down("#KpiPackageForm").getForm().isValid() == true) {
                                var grdUnSelect = response.owner.up('window').down('#grdUnSelectKpi');
                                var grdSelect = response.owner.up('window').down('#grdSelectKpi');
                                var _kpiPackageUuid = response.owner.up('window').uuid;
                                var _companyUuid = response.owner.up('window').companyUuid;

                                grdUnSelect.getStore().getProxy().setExtraParam('packageUuid', _kpiPackageUuid);
                                grdUnSelect.getStore().getProxy().setExtraParam('companyUuid', _companyUuid);
                                grdUnSelect.getStore().load();

                                grdSelect.getStore().getProxy().setExtraParam('packageUuid', _kpiPackageUuid);
                                grdSelect.getStore().getProxy().setExtraParam('companyUuid', _companyUuid);
                                grdSelect.getStore().load();
                            }
                        },
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
                    this.down("#KpiPackageForm").getForm().reset();
                    this.down("#fsKpiPackageItem").setDisabled(true);
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent(this);
                this.down("#KpiPackageForm").getForm().reset();
            }
        }
    });
});