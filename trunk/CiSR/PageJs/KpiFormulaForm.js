Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".TimeAction"));
    Ext.define('KpiFormulaForm', {
        extend: 'Ext.window.Window',
        title: '時間性指標 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        kpi_head_uuid: undefined,
        timeType: undefined,
        width: 900,
        height: 600,
        layout: 'fit',
        openerObj: undefined,
        resizable: false,
        draggable: true,
        arrCalculate: Array(),
        removeCalculate: function(btnId) {
            console.log(this.arrCalculate);
            if (this.arrCalculate.length > 0) {
                for (var i = 0; i < this.arrCalculate.length; i++) {
                    if (this.arrCalculate[i].btnId == btnId) {
                        this.arrCalculate.splice(i, 1);
                    }
                }
                this.down("#fsCalculate").remove(this.down("#" + btnId));
                this.showAlgorithm();
            }
        },
        addCalculate: function(btnId, jumpAction) {

            var text = this.down("#" + btnId).getText();
            var btnType = this.down("#" + btnId).btnType;
            var itemName = this.down("#" + btnId).itemName;
            var keyId = this.down("#" + btnId).keyId;
            this.arrCalculate.push({
                btnId: btnId,
                text: text,
                keyId: keyId,
                btnType: btnType,
                itemName: itemName
            });
            console.log(this.arrCalculate);
            if (jumpAction == true) {

            } else {
                this.showAlgorithm();
            }
        },

        showAlgorithm: function() {
            var showText = '';
            for (var i = 0; i < this.arrCalculate.length; i++) {
                console.log(this.arrCalculate[i].btnType);
                if (this.arrCalculate[i].btnType != '') {
                    showText += this.arrCalculate[i].btnType + "!" + this.arrCalculate[i].keyId;
                } else {
                    showText += this.arrCalculate[i].text;
                }
            }
            this.down("#ALGORITHM").setValue(showText);
            this.showAlgorithmMan();
        },
        showAlgorithmMan: function() {
            var showText = '';
            for (var i = 0; i < this.arrCalculate.length; i++) {
                if (this.arrCalculate[i].btnType != '') {
                    showText += this.arrCalculate[i].btnType + "!" + this.arrCalculate[i].text;
                } else {
                    showText += this.arrCalculate[i].text;
                }
            }
            this.down("#ALGORITHM_MAN").setValue(showText);
        },

        initComponent: function() {
            var me = this;
            me.items = [Ext.create('Ext.form.Panel', {
                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                api: {
                    load: WS.KpiAction.infoKpiFormula,
                    submit: WS.KpiAction.submitKpiFormula
                },
                itemId: 'KpiFormulaForm',
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
                        fieldLabel: '時間屬性',
                        labelAlign: 'right',
                        itemId: 'txtTimeId',
                        displayField: 'TIME_ID',
                        valueField: 'TIME_ID',
                        name: 'TIME_ID',
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
                            sorters: [{
                                property: 'TIME_ID',
                                direction: 'ASC'
                            }]
                        }),
                        allowBlank: false
                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    width: 850,
                    margin: '5 0 0 0',
                    items: [{
                        xtype: 'textfield',
                        flex: 1,
                        name: 'DESCRIPTION',
                        fieldLabel: '說明',
                        labelAlign: 'right'
                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    width: 850,
                    items: [{
                        xtype: 'hiddenfield',
                        flex: 1,
                        name: 'ALGORITHM',
                        fieldLabel: 'ALGORITHM',
                        labelAlign: 'right',
                        itemId: 'ALGORITHM'
                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    width: 850,
                    items: [{
                        xtype: 'hiddenfield',
                        flex: 1,
                        name: 'ALGORITHM_MAN',
                        fieldLabel: 'ALGORITHM_MAN',
                        labelAlign: 'right',
                        itemId: 'ALGORITHM_MAN'
                    }]
                }, {
                    xtype: 'hiddenfield',
                    fieldLabel: 'UUID',
                    name: 'UUID',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'UUID'
                }, {

                    xtype: 'hiddenfield',
                    fieldLabel: 'KPI_HEAD_UUID',
                    name: 'KPI_HEAD_UUID',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'KPI_HEAD_UUID'
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{

                        xtype: 'hiddenfield',
                        fieldLabel: 'JSS',
                        name: 'JSS',
                        padding: 5,
                        anchor: '100%',
                        itemId: 'JSS'
                    }]
                }, {
                    xtype: 'fieldset',
                    border: true,
                    title: '指標計算機',
                    width: 850,
                    height: 400,
                    items: [{
                        xtype: 'fieldset',
                        border: true,
                        height: 250,
                        itemId: 'fsCalculate',
                        width: 820,
                        autoScroll: true,
                        items: []
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        width: 820,
                        height: 150,
                        items: [{
                            xtype: 'fieldset',
                            border: true,
                            height: 80,
                            margin: 5,
                            title: '符號',
                            defaults: {
                                margin: 3,
                                width: 38,
                                height: 38
                            },
                            items: [{
                                xtype: 'button',
                                text: '(',
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '(',
                                        width: 50,
                                        height: 36,
                                        margin: 5,
                                        itemId: tmpId,
                                        btnType: '',
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }

                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: ')',
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();

                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: ')',
                                        width: 50,
                                        itemId: tmpId,
                                        height: 36,
                                        margin: 5,
                                        btnType: '',
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));

                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '[',
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '[',
                                        width: 50,
                                        height: 36,
                                        itemId: tmpId,
                                        btnType: '',
                                        margin: 5,
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: ']',
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: ']',
                                        width: 50,
                                        itemId: tmpId,
                                        btnType: '',
                                        height: 36,
                                        margin: 5,
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '{',
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '{',
                                        width: 50,
                                        itemId: tmpId,
                                        btnType: '',
                                        height: 36,
                                        margin: 5,
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '}',
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '}',
                                        width: 50,
                                        itemId: tmpId,
                                        btnType: '',
                                        height: 36,
                                        margin: 5,
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }]
                        }, {
                            xtype: 'fieldset',
                            border: true,
                            flex: 1,
                            margin: 5,
                            title: '元素',
                            height: 80,
                            defaults: {
                                margin: 3,
                                width: 78,
                                height: 38
                            },
                            items: [{
                                xtype: 'button',
                                text: '資料',
                                width: 60,
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    var mainWin = this.up('window');
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '資料',
                                        width: 200,
                                        height: 36,
                                        itemId: tmpId,
                                        margin: 5,
                                        btnType: 'R',
                                        menu: [{
                                                text: '選擇資料',
                                                handler: function() {

                                                    if (this.up('window').RawHeadPicker == undefined) {
                                                        this.up('window').RawHeadPicker = Ext.create('RawHeadPicker', {

                                                        });
                                                        this.up('window').RawHeadPicker.on('selectedEvent', function(record, openerObj) {
                                                            var cId = openerObj.controlledItemId;
                                                            openerObj.down("#" + cId).setText(record.data["C_DESC"]);
                                                            openerObj.down("#" + cId).itemName = record.data["C_DESC"];
                                                            openerObj.down("#" + cId).keyId = record.data["UUID"];
                                                            for (var i = 0; i < openerObj.arrCalculate.length; i++) {
                                                                if (openerObj.arrCalculate[i].btnId == cId) {
                                                                    openerObj.arrCalculate[i].text = record.data.C_DESC;
                                                                    //openerObj.arrCalculate[i].itemName = record.data.C_DESC;
                                                                    openerObj.arrCalculate[i].keyId = record.data.UUID;
                                                                }
                                                            }
                                                            openerObj.showAlgorithm();
                                                        });

                                                    }
                                                    this.up('window').RawHeadPicker.companyUuid = this.up('window').companyUuid;

                                                    this.up('window').RawHeadPicker.timeType = this.up('window').timeType;

                                                    this.up('window').RawHeadPicker.openerObj = this.up('window');
                                                    this.up('window').controlledItemId = this.up('button').itemId;
                                                    this.up('window').RawHeadPicker.show();
                                                }
                                            }
                                            , {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '指標',
                                width: 60,
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '指標',
                                        width: 200,
                                        height: 36,
                                        itemId: tmpId,
                                        margin: 5,
                                        btnType: 'K',
                                        menu: [{
                                                text: '選擇指標',
                                                handler: function() {
                                                    if (this.up('window').KpiPicker == undefined) {
                                                        this.up('window').KpiPicker = Ext.create('KpiPicker', {

                                                        });
                                                        this.up('window').KpiPicker.on('selectedEvent', function(record, openerObj) {
                                                            var cId = openerObj.controlledItemId;
                                                            openerObj.down("#" + cId).setText(record.data["C_DESC"]);
                                                            openerObj.down("#" + cId).itemName = record.data["C_DESC"];
                                                            openerObj.down("#" + cId).keyId = record.data["KPI_HEAD_UUID"];
                                                            for (var i = 0; i < openerObj.arrCalculate.length; i++) {
                                                                if (openerObj.arrCalculate[i].btnId == cId) {
                                                                    openerObj.arrCalculate[i].text = record.data.C_DESC;
                                                                    openerObj.arrCalculate[i].itemName = record.data.C_DESC;
                                                                    openerObj.arrCalculate[i].keyId = record.data.KPI_HEAD_UUID;
                                                                }
                                                            }
                                                            openerObj.showAlgorithm();
                                                        });

                                                    }
                                                    this.up('window').KpiPicker.companyUuid = this.up('window').companyUuid;
                                                    this.up('window').KpiPicker.openerObj = this.up('window');
                                                    this.up('window').controlledItemId = this.up('button').itemId;
                                                    this.up('window').KpiPicker.keyword = "";
                                                    this.up('window').KpiPicker.timeType = this.up('window').timeType;
                                                    this.up('window').KpiPicker.show();
                                                }
                                            },
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '係數',
                                width: 60,
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '係數',
                                        btnType: 'P',
                                        width: 200,
                                        height: 36,
                                        itemId: tmpId,
                                        margin: 5,
                                        menu: [{
                                                text: '選擇係數',
                                                handler: function() {
                                                    if (this.up('window').ParameterPicker == undefined) {
                                                        this.up('window').ParameterPicker = Ext.create('ParameterPicker', {

                                                        });
                                                        this.up('window').ParameterPicker.on('selectedEvent', function(record, openerObj) {
                                                            var cId = openerObj.controlledItemId;
                                                            openerObj.down("#" + cId).setText(record.data["NAME"]);
                                                            openerObj.down("#" + cId).itemName = record.data["NAME"];
                                                            openerObj.down("#" + cId).keyId = record.data["PARAMETER_UUID"];
                                                            for (var i = 0; i < openerObj.arrCalculate.length; i++) {
                                                                if (openerObj.arrCalculate[i].btnId == cId) {
                                                                    openerObj.arrCalculate[i].text = record.data.NAME;
                                                                    openerObj.arrCalculate[i].itemName = record.data.NAME;
                                                                    openerObj.arrCalculate[i].keyId = record.data.PARAMETER_UUID;
                                                                }
                                                            }
                                                            openerObj.showAlgorithm();
                                                        });

                                                    }
                                                    this.up('window').ParameterPicker.companyUuid = this.up('window').companyUuid;
                                                    this.up('window').ParameterPicker.openerObj = this.up('window');
                                                    this.up('window').controlledItemId = this.up('button').itemId;
                                                    this.up('window').ParameterPicker.keyword = "";
                                                    this.up('window').ParameterPicker.show();
                                                }
                                            },
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }]
                        }, {
                            xtype: 'fieldset',
                            border: true,
                            height: 80,
                            flex: 1,
                            margin: 5,
                            title: '運算符號',
                            defaults: {
                                margin: 3,
                                width: 58,
                                height: 38
                            },
                            items: [{
                                xtype: 'button',
                                text: '+',
                                width: 40,
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '+',
                                        height: 36,
                                        itemId: tmpId,
                                        btnType: '',
                                        margin: 5,
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '-',
                                width: 40,
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '-',
                                        width: 50,
                                        height: 36,
                                        itemId: tmpId,
                                        btnType: '',
                                        margin: 5,
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '*',
                                width: 40,
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '*',
                                        width: 50,
                                        height: 36,
                                        margin: 5,
                                        itemId: tmpId,
                                        btnType: '',
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }, {
                                xtype: 'button',
                                text: '/',
                                width: 40,
                                handler: function(handler, scope) {
                                    var cal = this.up('window').down("#fsCalculate");
                                    var tmpId = Ext.id();
                                    cal.add(Ext.create('Ext.button.Button', {
                                        text: '/',
                                        width: 50,
                                        height: 36,
                                        itemId: tmpId,
                                        btnType: '',
                                        margin: 5,
                                        menu: [
                                            {
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }
                                        ],
                                        handler: function() {
                                        }
                                    }));
                                    this.up('window').addCalculate(tmpId);
                                }
                            }]
                        }]
                    }]
                }],
                fbar: [{
                    xtype: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                    handler: function() {
                        var main = this.up('window');
                        this.up('window').down("#JSS").setValue(Ext.encode(this.up('window').arrCalculate));
                        var form = this.up('window').down("#KpiFormulaForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        }
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                main.uuid = action.result.UUID;
                                main.down("#UUID").setValue(action.result.UUID);
                                Ext.MessageBox.show({
                                    title: '儲存操作',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK,
                                    msg: '完成操作!'
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
                    xtype: 'button',
                    text: '刪除',
                    handler: function(handler, scope) {
                        var main = this.up('window');
                        Ext.MessageBox.confirm('你確定要刪除此筆資料', '確定後將永久刪除!', function(result) {
                            if (result == 'yes') {
                                WS.KpiAction.destoryKpiFormula(this.uuid, function(obj, json) {
                                    main.hide();
                                });
                            }
                        }, main);
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
                WS.KpiAction.infoKpiHead(this.kpi_head_uuid, function(obj, jsonObj) {
                    if (jsonObj.result.data["TIME_TYPE"] == "year") {
                        this.down("#txtTimeId").getStore().getProxy().setExtraParam('pTimeType', jsonObj.result.data["TIME_TYPE"]);
                        this.down("#txtTimeId").getStore().reload();
                    }

                    if (this.uuid != undefined) {
                        /*When 編輯/刪除資料*/
                        this.down("#KpiFormulaForm").getForm().load({
                            params: {
                                'pUuid': this.uuid
                            },
                            success: function(response, a, b) {
                                var cal = response.owner.up('window').down("#fsCalculate");
                                cal.removeAll();
                                response.owner.up('window').arrCalculate = Array();
                                Ext.each(Ext.decode(a.result.data.JSS), function(item) {

                                    if (item.keyId != undefined) {
                                        cal.add(Ext.create('Ext.button.Button', {
                                            text: item.text,
                                            width: 200,
                                            height: 36,
                                            margin: 5,
                                            keyId: item.keyId,
                                            itemId: item.btnId,
                                            btnType: item.btnType,
                                            menu: [{
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }

                                            }],
                                            handler: function() {
                                            }
                                        }));
                                    } else {
                                        cal.add(Ext.create('Ext.button.Button', {
                                            text: item.text,
                                            width: 50,
                                            height: 36,
                                            margin: 5,
                                            itemId: item.btnId,
                                            btnType: '',
                                            menu: [{
                                                text: '刪除',
                                                handler: function() {
                                                    var btnId = this.up('button').getItemId();
                                                    this.up('window').removeCalculate(btnId);
                                                }
                                            }],
                                            handler: function() {
                                            }
                                        }));
                                    }
                                    response.owner.up('window').addCalculate(item.btnId);
                                });
                                console.log(response.owner.up('window').arrCalculate);
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
                        }, {
                            scope: this
                        });
                    } else {
                        /*When 新增資料*/
                        this.arrCalculate = Array();
                        this.down("#KpiFormulaForm").getForm().reset();
                        this.down("#KPI_HEAD_UUID").setValue(this.kpi_head_uuid);
                    }
                }, this);
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();

                var cal = this.down("#fsCalculate");
                cal.removeAll();
                this.arrCalculate = [];
                this.closeEvent();
            }
        }
    });
});