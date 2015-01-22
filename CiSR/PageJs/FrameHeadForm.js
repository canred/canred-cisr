Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('KpiPackagePicker', {
        extend: 'Ext.window.Window',
        title: '更換 指標版本',
        closeAction: 'destory',
        width: 400,
        height: 200,
        resizable: false,
        draggable: false,

        initComponent: function() {
            var me = this;
            me.callParent(arguments);
        },
        items: [{
            xtype: 'combo',
            fieldLabel: '指標版本',
            labelAlign: 'right',
            displayField: 'NAME',
            valueField: 'UUID',
            itemId: 'cmdKpiPackage',
            padding: 5,
            margin:5,
            editable: false,
            hidden: false,
            store: Ext.create('Ext.data.Store', {
                extend: 'Ext.data.Store',
                autoLoad: false,
                remoteSort: true,
                model: 'KPI_PACKAGE',
                pageSize: 10,
                proxy: {
                    type: 'direct',
                    api: {
                        read: WS.KpiAction.loadKpiPackage
                    },
                    reader: {
                        root: 'data'
                    },
                    paramsAsHash: true,
                    paramOrder: ['page', 'limit', 'sort', 'dir'],
                    extraParams: {
                        'page': '1',
                        'limit': '99999',
                        'sort': 'NAME',
                        'dir': 'ASC'
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
                    property: 'NAME',
                    direction: 'ASC'
                }]
            })
        }],
        fbar: [{
            type: 'button',
            text: '選擇',
            handler: function() {
                var store = this.up('window').down("#cmdKpiPackage").getStore();
                var cmb = this.up('window').down("#cmdKpiPackage");
                var kpiPackageUuid = cmb.getValue();

                var displayValue = store[cmb.getValue()];


                var index = store.find('UUID', cmb.getValue());
                if (index != -1) {
                    var record = store.getAt(index);
                    this.up('window').selectKpiPackageName = record.data["NAME"];
                }

                this.up('window').selectKpiPackageUuid = kpiPackageUuid;
                this.up('window').close();
            }
        }, {
            type: 'button',
            text: '關閉',
            handler: function() {
                this.up('window').close();
            }
        }],
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'show': function() {
                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
            },
            'close': function() {
                if (this.openerObj != undefined) {
                    this.openerObj.unmask();
                }
                this.closeEvent();
            }
        }
    });
    Ext.define('FrameHeadForm', {
        extend: 'Ext.window.Window',
        title: '組織 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        companyUuid: undefined,
        submitNoMessage: false,
        height: 620,
        width: 1000,
        layout: 'fit',
        openerObj: undefined,
        resizable: false,
        draggable: true,
        fnParentFrameHeadInfo:function(uuid,callback){
          if( !this.parentFrameHead ){
            WS.FrameAction.infoFrameHead(this.parentFrameHeadUuid,function(obj,jsonObj){
              this.parentFrameHead = jsonObj.result.data;
              console.log(this.parentFrameHead);
              callback(this);
            },this);
          }else{
            callback(this);
          }           
        },
        fnGetOrder:function(){
          /*自動設定排序*/
          WS.FrameAction.getFrameChildCount(this.parentFrameHeadUuid,function(obj,jsonObj){
            this.down("#ORD").setValue( parseInt( jsonObj.result.COUNT )+1)            
          },this);
        },
        fnCurrency:function(){
          /*自動設定幣別*/
          this.fnParentFrameHeadInfo(this.parentFrameHeadUuid,function(obj){
           obj.down("#CURRENCY").setValue(obj.parentFrameHead.CURRENCY);
          },this);
        },
        fnFrameCategory:function(){
          /*自動設定產業別*/
          this.fnParentFrameHeadInfo(this.parentFrameHeadUuid,function(obj){
            obj.down("#cmbFrameCategory").setValue(obj.parentFrameHead.FRAME_CATEGORY_UUID);
          },this);
        },
        parentFrameHeadUuid: undefined,
        fnCheckRightSelect: function() {
            if (this.down("#grdFrameItem").selModel.getSelection() == 0) {
                return false;
            } else {
                return true;
            }
        },
        initComponent: function() {
            var me = this;
            me.filterDelayTask = Ext.create('Ext.util.DelayedTask', function() {
                this.down("#grdUnselect").getStore().filterBy(function(record) {
                    if (this.down("#txtSearch").getValue() == "") {
                        return true;
                    } else {
                        if (
                            record.get('RAW_ID').indexOf(this.down("#txtSearch").getValue()) >= 0 ||
                            record.get('C_DESC').indexOf(this.down("#txtSearch").getValue()) >= 0
                        ) {
                            return true;
                        }
                    }
                }, this);
            }, me);
            me.items = [Ext.create('Ext.form.Panel', {
                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                api: {
                    load: WS.FrameAction.infoFrameHead,
                    submit: WS.FrameAction.submitFrameHead
                },
                itemId: 'FrameHeadForm',
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
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'combo',
                            fieldLabel: '公司',
                            labelAlign: 'right',
                            displayField: 'C_NAME',
                            valueField: 'UUID',
                            name: 'COMPANY_UUID',
                            itemId: 'cmdCompany',
                            editable: false,
                            hidden: false,
                            labelWidth: 100,
                            width: 300,
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
                            xtype: 'textfield',
                            fieldLabel: '組織名稱(中文)',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'C_NAME',
                            maxLength: 84,
                            allowBlank: false,
                            itemId: 'C_NAME'
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '組織名稱(英文)',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'E_NAME',
                            itemId: 'E_NAME',
                            maxLength: 84,
                            allowBlank: false
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '組織ID',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'FRAME_ID',
                            anchor: '-50 0',
                            maxLength: 84,
                            allowBlank: true,
                            hidden: true
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '組織名稱(簡中)',
                            labelAlign: 'right',
                            labelWidth: 100,
                            width: 300,
                            name: 'ZH_NAME',
                            margin: '5 0 0 0',
                            maxLength: 84,
                            allowBlank: true
                        }, {
                            xtype: 'textfield',
                            fieldLabel: '幣別',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'CURRENCY',
                            itemId:'CURRENCY',
                            margin: '5 0 0 0',
                            maxLength: 84,
                            allowBlank: true
                        }, {
                            xtype: 'hiddenfield',
                            fieldLabel: '排序',
                            labelAlign: 'right',
                            labelWidth: 100,
                            name: 'ORD',
                            itemId: 'ORD',
                            margin: '5 0 0 0',
                            maxLength: 84,
                            minValue: 1,

                            allowBlank: true
                        }]
                    }, {
                        xtype: 'container',
                        layout: 'hbox',
                        margin: '5 0 0 0',
                        items: [{
                            xtype: 'container',
                            layout: 'hbox',
                            items: [{
                                xtype: 'combo',
                                fieldLabel: '國別',
                                labelAlign: 'right',
                                width: 220,
                                itemId: 'cmdRegion',
                                displayField: 'REGION_NAME',
                                valueField: 'UUID',
                                name: 'REGION_UUID',
                                padding: 0,
                                editable: false,
                                hidden: false,
                                store: Ext.create('Ext.data.Store', {
                                    extend: 'Ext.data.Store',
                                    autoLoad: false,
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

                            }, {
                                xtype: 'button',
                                text: '清空',
                                margin: '0 0 0 10',
                                padding: 0,
                                //height: 30,
                                handler: function(handler, scope) {
                                    this.up('window').down("#cmdRegion").setValue("");
                                }
                            }, {
                                xtype: 'container',
                                layout: 'hbox',
                                items: [{
                                    xtype: 'textfield',
                                    fieldLabel: '指標版本',
                                    labelAlign: 'right',
                                    readOnly: true,
                                    itemId: 'txtKpiPackage',
                                    labelWidth: 120,
                                    width: 200
                                }, {
                                    xtype: 'hidden',
                                    name: 'KPI_PACKAGE_UUID',
                                    itemId: 'KPI_PACKAGE_UUID'
                                }, {
                                    xtype: 'button',
                                    text: '設',
                                    tooltip: '*設定 指標版本 內容',
                                    padding: 0,
                                    margin: '0 0 0 5',
                                    itemId: 'btnKpiPackage',
                                    handler: function(handler, scope) {
                                        if (this.up('window').down("#KPI_PACKAGE_UUID").getValue() == "") {
                                            //修改當前的策略
                                            var curUuid = this.up('window').down("#UUID").getValue();
                                            WS.FrameAction.addKPIPackageInFrame(curUuid, function(obj, jsonObj) {
                                                if (obj.success) {
                                                    this.scope.down("#KPI_PACKAGE_UUID").setValue(obj.KpiPackageUuid);
                                                    if (this.scope.winKpiPackageForm == undefined) {
                                                        this.scope.winKpiPackageForm = Ext.create("KpiPackageForm", {});
                                                        this.scope.winKpiPackageForm.on('closeEvent', function(obj) {
                                                            if (obj.openerObj != undefined) {
                                                                if (obj.hasChange == true) {
                                                                    obj.openerObj.down("#grdUnselect").getStore().load();
                                                                    obj.openerObj.down("#grdFrameItem").getStore().load();
                                                                }
                                                            }
                                                        });
                                                    }
                                                    this.scope.winKpiPackageForm.openerObj = this.scope;
                                                    this.scope.winKpiPackageForm.uuid = obj.KpiPackageUuid;
                                                    this.scope.down("#KPI_PACKAGE_UUID").setValue(obj.KpiPackageUuid);
                                                    this.scope.down("#txtKpiPackage").getValue(obj.kpiPackageName);
                                                    this.scope.winKpiPackageForm.companyUuid = this.scope.companyUuid;
                                                    this.scope.winKpiPackageForm.show();
                                                } else {
                                                    Ext.MessageBox.show({
                                                        title: '設定 指標版本 發生異常錯誤',
                                                        icon: Ext.MessageBox.ERROR,
                                                        buttons: Ext.Msg.OK,
                                                        msg: obj.message
                                                    });
                                                }
                                            }, {
                                                scope: this.up('window')
                                            });
                                        } else {
                                            //建立新的策略
                                            if (this.up('window').winKpiPackageForm == undefined) {
                                                this.up('window').winKpiPackageForm = Ext.create("KpiPackageForm", {});

                                                this.up('window').winKpiPackageForm.on('closeEvent', function(obj) {
                                                    if (obj.openerObj != undefined) {
                                                        if (obj.hasChange == true) {
                                                            obj.openerObj.down("#grdUnselect").getStore().load();
                                                            obj.openerObj.down("#grdFrameItem").getStore().load();
                                                        }
                                                    }
                                                });
                                            }
                                            this.up('window').winKpiPackageForm.openerObj = this.up('window');
                                            this.up('window').winKpiPackageForm.uuid = this.up('window').down("#KPI_PACKAGE_UUID").getValue();
                                            this.up('window').winKpiPackageForm.companyUuid = this.up('window').companyUuid;
                                            this.up('window').winKpiPackageForm.show();
                                        }
                                    }
                                }, {
                                    xtype: 'button',
                                    text: '選',
                                    itemId: 'btnChangeKpiPackage',
                                    tooltip: '*更換成現有的指標版本',
                                    margin: '0 0 0 5',
                                    padding: 0,
                                    handler: function(handler, scope) {
                                        if (this.up('window').down("#C_NAME").getValue() == "") {
                                            Ext.MessageBox.show({
                                                title: 'CiSR',
                                                icon: Ext.MessageBox.WARNING,
                                                buttons: Ext.Msg.OK,
                                                msg: '請先填寫組織名稱(中文)、組織名稱(中文)、排序等3個欄位資訊'
                                            });
                                            return;
                                        }

                                        if (this.up('window').down("#E_NAME").getValue() == "") {
                                            Ext.MessageBox.show({
                                                title: 'CiSR',
                                                icon: Ext.MessageBox.WARNING,
                                                buttons: Ext.Msg.OK,
                                                msg: '請先填寫組織名稱(中文)、組織名稱(中文)、排序等3個欄位資訊'
                                            });
                                            return;
                                        }
                                        console.log(this.up('window').down("#ORD").getValue());
                                        if (this.up('window').down("#ORD").getValue() == undefined) {
                                            Ext.MessageBox.show({
                                                title: 'CiSR',
                                                icon: Ext.MessageBox.WARNING,
                                                buttons: Ext.Msg.OK,
                                                msg: '請先填寫組織名稱(中文)、組織名稱(中文)、排序等3個欄位資訊'
                                            });
                                            return;
                                        }

                                        var curUuid = this.up('window').down("#UUID").getValue();
                                        var a = Ext.create('KpiPackagePicker', {});
                                        a.on('closeEvent', function(obj) {
                                            if (obj.selectKpiPackageUuid != undefined) {
                                                if (obj.selectKpiPackageUuid != obj.openerObj.down("#KPI_PACKAGE_UUID").getValue()) {
                                                    obj.openerObj.down("#KPI_PACKAGE_UUID").setValue(obj.selectKpiPackageUuid);
                                                    obj.openerObj.down("#txtKpiPackage").setValue(obj.selectKpiPackageName);
                                                    obj.openerObj.down("#grdUnselect").getStore().getProxy().setExtraParam('pPackageUuid', obj.selectKpiPackageUuid);
                                                    obj.openerObj.down("#grdFrameItem").getStore().getProxy().setExtraParam('pPackageUuid', obj.selectKpiPackageUuid);
                                                    var main = obj.openerObj;
                                                    var form = obj.openerObj.down("#FrameHeadForm").getForm();
                                                    if (form.isValid() == false) {
                                                        return;
                                                    }
                                                    form.submit({
                                                        waitMsg: '更新中...',
                                                        success: function(form, action) {
                                                            main.uuid = action.result.UUID;
                                                            main.down("#UUID").setValue(action.result.UUID);
                                                            main.down("#btnKpiPackage").setDisabled(false);
                                                            main.setTitle('組織【維護】');
                                                            if (main.submitNoMessage == true) {

                                                            } else {
                                                                Ext.MessageBox.show({
                                                                    title: '指標版本變更',
                                                                    msg: '操作完成',
                                                                    icon: Ext.MessageBox.INFO,
                                                                    buttons: Ext.Msg.OK
                                                                });
                                                            }
                                                            main.submitNoMessage = false;
                                                            main.down("#grdUnselect").getStore().load();
                                                            main.down("#grdFrameItem").getStore().load();
                                                            main.unmask();
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
                                            }
                                        });
                                        a.openerObj = this.up('window');
                                        a.show();
                                    }

                                }, {
                                    xtype: 'button',
                                    text: '新',
                                    tooltip: '*建立新 指標版本',
                                    padding: 0,
                                    margin: '0 0 0 5',
                                    itemId: 'btnKpiPackageAdd',
                                    handler: function(handler, scope) {
                                        Ext.MessageBox.confirm('重新設定指標版本', '你確定要重新設定指標版本?', function(result) {
                                            if (result == 'yes') {
                                                //修改當前的策略
                                                var curUuid = this.up('window').down("#UUID").getValue();
                                                WS.FrameAction.addKPIPackageInFrame(curUuid, function(obj, jsonObj) {
                                                    if (obj.success) {
                                                        this.scope.down("#KPI_PACKAGE_UUID").setValue(obj.KpiPackageUuid);
                                                        this.scope.down("#btnKpiPackage").setDisabled(false);
                                                        this.scope.down("#txtKpiPackage").setValue(obj.kpiPackageName);
                                                        this.scope.submitNoMessage = true;
                                                        this.scope.down("#btnSubmit").handler();
                                                        alert('此組織已設定新的指標版本，請點擊『設定』按鈕，並設定此策略之內容指標');
                                                    } else {
                                                        Ext.MessageBox.show({
                                                            title: '設定指標版本發生異常錯誤',
                                                            icon: Ext.MessageBox.ERROR,
                                                            buttons: Ext.Msg.OK,
                                                            msg: obj.message
                                                        });
                                                    }
                                                }, {
                                                    scope: this.up('window')
                                                });
                                            }
                                        }, this);
                                    }
                                }]
                            }, {
                                xtype: 'container',
                                layout: 'hbox',
                                items: [{
                                    xtype: 'combo',
                                    fieldLabel: '產業別',
                                    labelAlign: 'right',
                                    displayField: 'FRAME_CATEGORY_NAME',
                                    itemId: 'cmbFrameCategory',
                                    valueField: 'UUID',
                                    name: 'FRAME_CATEGORY_UUID',
                                    width: 250,
                                    labelWidth: 80,
                                    editable: false,
                                    hidden: false,
                                    store: Ext.create('Ext.data.Store', {
                                        extend: 'Ext.data.Store',
                                        autoLoad: false,
                                        model: 'FRAME_CATEGORY',
                                        pageSize: 9999,
                                        remoteSort: true,
                                        proxy: {
                                            type: 'direct',
                                            api: {
                                                read: WS.FrameAction.loadFrameCategory
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
                                            paramOrder: ['keyword','page', 'limit', 'sort', 'dir'],
                                            extraParams: {
                                              'keyword':''
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
                                            property: 'FRAME_CATEGORY_NAME',
                                            direction: 'ASC'
                                        }]
                                    })
                                }
                                // , {
                                //     xtype: 'button',
                                //     text: '新建',
                                //     padding: 0,
                                //     margin: '0 0 0 10',
                                //     itemId: 'btnKpiPackageAdd',
                                //     handler: function(handler, scope) {
                                //         if (this.up('window').WinFrameCategory == undefined) {
                                //             this.up('window').WinFrameCategory = Ext.create('FrameCategoryForm', {});
                                //             this.up('window').WinFrameCategory.on('closeEvent', function(obj) {
                                //                 obj.openerObj.down("#cmbFrameCategory").getStore().reload();
                                //             });
                                //         }
                                //         this.up('window').WinFrameCategory.openerObj = this.up('window');
                                //         this.up('window').WinFrameCategory.setTitle('<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:20px;vertical-align:middle;margin-right:5px;">組織產業別【新增】');
                                //         this.up('window').WinFrameCategory.uuid = undefined;
                                //         this.up('window').WinFrameCategory.show(this);
                                //     }
                                // }
                                ]
                            }]
                        }]
                    }]
                }, {
                    xtype: 'container',
                    layout: 'hbox',
                    hidden: true,
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
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'fieldset',
                        title: '可選項目',
                        width: 400,
                        height: 390,
                        items: [{
                            xtype: 'gridpanel',
                            itemId: 'grdUnselect',
                            selModel: new Ext.selection.CheckboxModel({
                                mode: 'MULTI',
                                checkOnly: true
                            }),
                            tbar: [{
                                type: 'button',
                                text: 'A',
                                padding: 0,
                                tooltip: '*全部',
                                handler: function() {
                                    this.up('window').down("#grdUnselect").getStore().clearFilter();
                                }
                            }, {
                                type: 'button',
                                text: 'M',
                                padding: 0,
                                tooltip: '*僅顯示月相關資料',
                                handler: function() {
                                    this.up('window').down("#grdUnselect").getStore().clearFilter();
                                    this.up('window').down("#grdUnselect").getStore().filterBy(function(record) {
                                        if (record.get('TIME_TYPE') == 'month') {
                                            if (this.down("#txtSearch").getValue() == "") {
                                                return true;
                                            } else {
                                                if (
                                                    record.get('RAW_ID').indexOf(this.down("#txtSearch").getValue()) >= 0 ||
                                                    record.get('C_DESC').indexOf(this.down("#txtSearch").getValue()) >= 0
                                                ) {
                                                    return true;
                                                }
                                            }
                                        }
                                    }, this.up('window'));
                                }
                            }, {
                                type: 'button',
                                text: 'Y',
                                padding: 0,
                                tooltip: '*僅顯示年相關資料',
                                handler: function() {
                                    this.up('window').down("#grdUnselect").getStore().clearFilter();
                                    this.up('window').down("#grdUnselect").getStore().filterBy(function(record) {
                                        if (record.get('TIME_TYPE') == 'year') {
                                            if (this.down("#txtSearch").getValue() == "") {
                                                return true;
                                            } else {
                                                if (
                                                    record.get('RAW_ID').indexOf(this.down("#txtSearch").getValue()) >= 0 ||
                                                    record.get('C_DESC').indexOf(this.down("#txtSearch").getValue()) >= 0
                                                ) {
                                                    return true;
                                                }
                                            }
                                        }
                                    }, this.up('window'));
                                }
                            }, {
                                xtype: 'textfield',
                                emptyText: 'Search Keyword',
                                width: 140,
                                itemId: 'txtSearch',
                                enableKeyEvents: true,
                                listeners: {
                                    'keyup': function() {
                                        this.up('window').filterDelayTask.delay({
                                            interval: 1000,
                                            scope: this.up('window')
                                        });
                                    }
                                }
                            }],
                            enableColumnMove: false,
                            enableColumnHide: false,
                            store: Ext.create('Ext.data.Store', {
                                extend: 'Ext.data.Store',
                                autoLoad: false,
                                remoteSort: true,
                                model: 'V_KPI_EXP',
                                pageSize: 9999,
                                proxy: {
                                    type: 'direct',
                                    api: {
                                        read: WS.KpiAction.loadVKpiExtNotIncludeFrame
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['pPackageUuid', 'pFrameHeadUuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
                                        'pPackageUuid': '',
                                        'pFrameHeadUuid': '',
                                        'keyword': '',
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
                                    property: 'RAW_ID',
                                    direction: 'ASC'
                                }]
                            }),
                            paramsAsHash: false,
                            autoScroll: true,
                            columns: [{
                                text: "資料ID",
                                dataIndex: 'RAW_ID',
                                align: 'left',

                                width: 100,
                                enableColumnHide: false,
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
                                flex: 1,
                                renderer: function(value, r) {

                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }
                                }
                            }],
                            height: 350
                        }]

                    }, {
                        xtype: 'container',
                        layout: 'vbox',
                        items: [{
                            xtype: 'button',
                            text: '>',
                            margin: '150 5 10 5',
                            handler: function(handler, scope) {
                                var mainWin = this.up('window');
                                mainWin.mask("正在加載資料中…");
                                if (this.up('window').down("#grdUnselect").selModel.getSelection() == 0) {
                                    Ext.MessageBox.show({
                                        title: '操作提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '請先勾選左方資料項目!'
                                    });
                                    return;
                                }

                                mainWin.hasChange = false;
                                var addRow = '';
                                var frameHeadUuid = '';
                                Ext.each(this.up('window').down("#grdUnselect").selModel.getSelection(), function(item) {
                                    var rawHeadUuid = item.data.RAW_HEAD_UUID;
                                    frameHeadUuid = mainWin.uuid;
                                    addRow += rawHeadUuid + ';';
                                });

                                if (addRow !== '') {
                                    WS.FrameAction.addRawToFrameBatch(addRow, frameHeadUuid, function(obj, jsonObj) {
                                        if (jsonObj.result.success != null && jsonObj.result.success) {
                                            this.scope.down("#grdUnselect").getStore().load();
                                            this.scope.down("#grdFrameItem").getStore().load();
                                            this.scope.unmask();
                                        }
                                    }, {
                                        scope: mainWin
                                    });
                                }
                            }
                        }, {
                            xtype: 'button',
                            margin: '5 5 10 5',
                            text: '<',
                            handler: function(handler, scope) {
                                var mainWin = this.up('window');
                                mainWin.mask('正在移除資料中…');
                                if (this.up('window').down("#grdFrameItem").selModel.getSelection() == 0) {
                                    Ext.MessageBox.show({
                                        title: '操作提示',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK,
                                        msg: '請先勾選右方資料項目!'
                                    });
                                    return;
                                }
                                mainWin.hasChange = false;
                                var removeRow = '';
                                var frameHeadUuid = '';
                                Ext.each(this.up('window').down("#grdFrameItem").selModel.getSelection(), function(item) {
                                    var rawHeadUuid = item.data.RAW_HEAD_UUID;
                                    frameHeadUuid = item.data.FRAME_HEAD_UUID;
                                    removeRow += rawHeadUuid + ';';
                                });

                                if (removeRow !== '' && frameHeadUuid !== '') {
                                    WS.FrameAction.removeRawFromFrameBatch(removeRow, frameHeadUuid, function(obj, jsonObj) {
                                        if (jsonObj.result.success != null && jsonObj.result.success) {
                                            this.scope.down("#grdUnselect").getStore().load();
                                            this.scope.down("#grdFrameItem").getStore().load();
                                            this.scope.unmask();
                                        }
                                    }, {
                                        scope: mainWin
                                    });
                                }
                            }
                        }]
                    }, {
                        xtype: 'fieldset',
                        title: '已選項目&工作指派',
                        width: 600,
                        height: 390,
                        items: [{
                            xtype: 'gridpanel',
                            itemId: 'grdFrameItem',
                            enableColumnMove: false,
                            enableColumnHide: false,
                            selModel: new Ext.selection.CheckboxModel({
                                checkOnly: true,
                                mode: 'MULTI'
                            }),
                            store: Ext.create('Ext.data.Store', {
                                extend: 'Ext.data.Store',
                                autoLoad: false,
                                remoteSort: true,
                                model: 'V_FRAMEITEM',
                                pageSize: 9999,
                                proxy: {
                                    type: 'direct',
                                    api: {
                                        read: WS.FrameAction.loadVFrameItem
                                    },
                                    reader: {
                                        root: 'data'
                                    },
                                    paramsAsHash: true,
                                    paramOrder: ['pFrameHeadUuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                                    extraParams: {
                                        'pFrameHeadUuid': '',
                                        'keyword': '',
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
                                    property: 'RAW_ID',
                                    direction: 'ASC'
                                }]
                            }),
                            paramsAsHash: false,
                            autoScroll: true,
                            columns: [{
                                text: "資料ID",
                                dataIndex: 'RAW_ID',
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
                                width: 180,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }

                                }
                            }, {
                                text: "負責人1",
                                dataIndex: 'PWG1_SHOW',
                                align: 'center',
                                width: 70,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }

                                }
                            }, {
                                text: "負責人2",
                                dataIndex: 'PWG2_SHOW',
                                align: 'center',
                                width: 70,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }

                                }
                            }, {
                                text: "負責人3",
                                dataIndex: 'PWG3_SHOW',
                                align: 'center',
                                width: 70,
                                renderer: function(value, r) {
                                    if (r.record.data["TIME_TYPE"] == "year") {
                                        return Ext.String.format('<div style="color:#0000ff" >{0}</div>', value);
                                    } else {
                                        return Ext.String.format('<div >{0}</div>', value);
                                    }

                                }
                            }],
                            listeners: {
                                celldblclick: function(iView, iCellEl, iColIdx, iRecord, iRowEl, iRowIdx, iEvent) {
                                    var uuid = iRecord.data["UUID"];
                                    var seq = iColIdx - 2;
                                    if (this.up('window').winSetPwg == undefined) {
                                        this.up('window').winSetPwg = Ext.create("FrameItemSetPWG", {
                                            closeEvent: function(obj) {
                                                obj.openerObj.down("#grdFrameItem").getStore().reload();
                                            }
                                        });
                                    }
                                    this.up('window').winSetPwg.frameItemUuid = uuid;
                                    this.up('window').winSetPwg.frameHeadUuid = iRecord.data["FRAME_HEAD_UUID"];
                                    this.up('window').winSetPwg.seq = seq;
                                    this.up('window').winSetPwg.companyUuid = this.up('window').companyUuid;
                                    this.up('window').winSetPwg.openerObj = iView.up('window');
                                    this.up('window').winSetPwg.show();
                                }
                            },
                            height: 350,
                            tbar: [{
                                xtype: 'label',
                                text: '批次設定負責人'
                            }, {
                                xtype: 'button',
                                text: '1',
                                padding: 0,
                                handler: function(handler, scope) {
                                    if (this.up('window').fnCheckRightSelect() == false) {
                                        Ext.MessageBox.show({
                                            title: '操作提示',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '請先勾選下方資料項目!'
                                        });
                                        return;
                                    } else {
                                        var arrFrameItem = "";
                                        Ext.each(this.up('window').down("#grdFrameItem").selModel.getSelection(), function(item) {
                                            arrFrameItem += item.data.UUID + ';';

                                        });
                                        if (this.up('window').winBatchSetPwg == undefined) {
                                            this.up('window').winBatchSetPwg = Ext.create("FrameItemBatchSetPWG", {
                                                closeEvent: function(obj) {
                                                    obj.openerObj.down("#grdFrameItem").getStore().reload();
                                                }
                                            });
                                        }
                                        this.up('window').winBatchSetPwg.arrFrameItem = arrFrameItem;
                                        this.up('window').winBatchSetPwg.seq = "1";
                                        this.up('window').winBatchSetPwg.companyUuid = this.up('window').companyUuid
                                        this.up('window').winBatchSetPwg.openerObj = this.up('window');
                                        this.up('window').winBatchSetPwg.show();
                                    }
                                }
                            }, {
                                xtype: 'button',
                                text: '2',
                                padding: 0,
                                handler: function(handler, scope) {
                                    if (this.up('window').fnCheckRightSelect() == false) {
                                        Ext.MessageBox.show({
                                            title: '操作提示',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '請先勾選下方資料項目!'
                                        });
                                        return;
                                    } else {
                                        var arrFrameItem = "";
                                        Ext.each(this.up('window').down("#grdFrameItem").selModel.getSelection(), function(item) {
                                            arrFrameItem += item.data.UUID + ';';

                                        });
                                        if (this.up('window').winBatchSetPwg == undefined) {
                                            this.up('window').winBatchSetPwg = Ext.create("FrameItemBatchSetPWG", {
                                                closeEvent: function(obj) {
                                                    obj.openerObj.down("#grdFrameItem").getStore().reload();
                                                }
                                            });
                                        }
                                        this.up('window').winBatchSetPwg.arrFrameItem = arrFrameItem;
                                        this.up('window').winBatchSetPwg.seq = "2";
                                        this.up('window').winBatchSetPwg.companyUuid = this.up('window').companyUuid
                                        this.up('window').winBatchSetPwg.openerObj = this.up('window');
                                        this.up('window').winBatchSetPwg.show();
                                    }
                                }
                            }, {
                                xtype: 'button',
                                text: '3',
                                padding: 0,
                                handler: function(handler, scope) {
                                    if (this.up('window').fnCheckRightSelect() == false) {
                                        Ext.MessageBox.show({
                                            title: '操作提示',
                                            icon: Ext.MessageBox.INFO,
                                            buttons: Ext.Msg.OK,
                                            msg: '請先勾選下方資料項目!'
                                        });
                                        return;
                                    } else {
                                        var arrFrameItem = "";
                                        Ext.each(this.up('window').down("#grdFrameItem").selModel.getSelection(), function(item) {
                                            arrFrameItem += item.data.UUID + ';';

                                        });
                                        if (this.up('window').winBatchSetPwg == undefined) {
                                            this.up('window').winBatchSetPwg = Ext.create("FrameItemBatchSetPWG", {
                                                closeEvent: function(obj) {
                                                    obj.openerObj.down("#grdFrameItem").getStore().reload();
                                                }
                                            });
                                        }
                                        this.up('window').winBatchSetPwg.arrFrameItem = arrFrameItem;
                                        this.up('window').winBatchSetPwg.seq = "3";
                                        this.up('window').winBatchSetPwg.companyUuid = this.up('window').companyUuid
                                        this.up('window').winBatchSetPwg.openerObj = this.up('window');
                                        this.up('window').winBatchSetPwg.show();
                                    }
                                }
                            }]
                        }]
                    }]
                }, {
                    xtype: 'label',
                    text: '字體顏色說明：藍字表「年」資料；黑字表「月」資料'
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
                    fieldLabel: 'PARENT_FRAME_HEAD_UUID',
                    name: 'PARENT_FRAME_HEAD_UUID',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'PARENT_FRAME_HEAD_UUID'
                }, {

                    xtype: 'hidden',
                    fieldLabel: 'DLEVEL',
                    name: 'DLEVEL',
                    padding: 5,
                    anchor: '100%',
                    maxLength: 84,
                    itemId: 'DLEVEL'
                }],
                fbar: [{
                    type: 'button',
                    itemId: 'btnSubmit',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                    handler: function() {
                        var main = this.up('window');
                        var form = this.up('window').down("#FrameHeadForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        }
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                main.uuid = action.result.UUID;
                                main.down("#UUID").setValue(action.result.UUID);
                                main.setTitle('組織【維護】');
                                if (main.submitNoMessage == true) {

                                } else {
                                    Ext.MessageBox.show({
                                        title: '維護組織',
                                        msg: '操作完成',
                                        icon: Ext.MessageBox.INFO,
                                        buttons: Ext.Msg.OK
                                    });
                                }
                                main.submitNoMessage = false;
                                main.fnShow();
                                main.down("#btnKpiPackageAdd").setDisabled(false);
                                main.down("#btnChangeKpiPackage").setDisabled(false);
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
        fnShow: function() {
            if (this.openerObj != undefined) {
                this.openerObj.mask();
            }
            if (this.companyUuid != undefined) {
                this.down("#cmdRegion").getStore().getProxy().setExtraParam('', '');
                this.down("#cmdRegion").getStore().reload({
                    callback: function() {
                        /*:::畫面開啟後載入資料:::*/
                        /*this.uuid 是 undefined 的話；表示執行新增的動作*/
                        this.down("#cmbFrameCategory").getStore().reload({
                            callback: function() {
                                if (this.uuid != undefined) {
                                    /*When 編輯/刪除資料*/
                                    this.down("#FrameHeadForm").getForm().load({
                                        params: {
                                            'pUuid': this.uuid
                                        },
                                        success: function(response, jsonObj, b) {
                                            if (jsonObj.result.data.KPI_PACKAGE_UUID == undefined) {
                                                return;
                                            }
                                            if (jsonObj.result.data.KPI_PACKAGE_UUID == "")
                                                return;
                                            WS.KpiAction.infoKpiPackage(jsonObj.result.data.KPI_PACKAGE_UUID, function(obj, jsonObj) {
                                                if (jsonObj.result.success == true) {
                                                    this.scope.down("#txtKpiPackage").setValue(jsonObj.result.data["NAME"]);
                                                }
                                            }, {
                                                scope: response.owner.up('window')
                                            });
                                            var _grdUnselect = response.owner.up('window').down("#grdUnselect");
                                            _grdUnselect.getStore().getProxy().setExtraParam('pPackageUuid', jsonObj.result.data.KPI_PACKAGE_UUID);
                                            _grdUnselect.getStore().getProxy().setExtraParam('pFrameHeadUuid', jsonObj.result.data.UUID);
                                            _grdUnselect.getStore().load();
                                            var _grdSelect = response.owner.up('window').down("#grdFrameItem");
                                            _grdSelect.getStore().getProxy().setExtraParam('pFrameHeadUuid', jsonObj.result.data.UUID);
                                            _grdSelect.getStore().load();
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
                                    this.down("#FrameHeadForm").getForm().reset();
                                    this.down("#cmdCompany").setValue(this.companyUuid);
                                    this.down("#PARENT_FRAME_HEAD_UUID").setValue(this.parentFrameHeadUuid);
                                    this.down("#btnKpiPackage").setDisabled(true);
                                    this.down("#btnKpiPackageAdd").setDisabled(true);
                                    this.down("#btnChangeKpiPackage").setDisabled(true);
                                    this.fnGetOrder();

                                    this.fnCurrency();
                                    this.down("#cmbFrameCategory").getStore().load({
                                      callback:function(){
                                        this.fnFrameCategory();
                                      },
                                      scope:this
                                    });
                                    
                                }
                            },
                            scope: this
                        });
                    },
                    scope: this
                });
            }
        },
        listeners: {
            'show': function() {
                this.fnShow();
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent();
                this.down("#grdUnselect").getStore().removeAll();
                this.down("#grdFrameItem").getStore().removeAll();
                this.down("#grdUnselect").getStore().getProxy().setExtraParam('pPackageUuid', '');
                this.down("#grdUnselect").getStore().getProxy().setExtraParam('pFrameHeadUuid', '');
                this.down("#grdFrameItem").getStore().getProxy().setExtraParam('pFrameHeadUuid', '');
                this.down("#FrameHeadForm").getForm().reset();
                this.down("#btnKpiPackage").setDisabled(false);
                this.down("#cmbFrameCategory").setValue('');
                this.down("#CURRENCY").setValue('');
                this.parentFrameHead = undefined;
            }
        }
    });
});
