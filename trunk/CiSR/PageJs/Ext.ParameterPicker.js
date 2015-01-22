Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".AttendantAction"));
    var storeParameterPicker =
        Ext.create('Ext.data.Store', {
            successProperty: 'success',
            autoLoad: true,
            model: Ext.define('vparameterquery', {
                extend: 'Ext.data.Model',
                fields: [
                    'COMPANY_ID',
                    'COMPANY_C_NAME',
                    'COMPANY_E_NAME',
                    'COMPANY_UUID',
                    'PARAMETER_UUID',
                    'PARAMETER_ITEM_UUID',
                    'IS_ACTIVE',
                    'NAME',
                    'DESCRIPTION',
                    'VALUE',
                    'ITEM_IS_ACTIVE',
                    'IS_PUBLIC',
                    'ITEM_DESCRIPTION',
                    'ITEM_VALUE',
                    'REGION_NAME',
                    'MONTH_ID',
                    'MONTH_VALUE',
                    'PARAMETER_MONTH_UUID'
                ]
            }),
            pageSize: 10,
            proxy: {
                type: 'direct',
                api: {
                    read: WS.AttendantAction.load
                },
                reader: {
                    root: 'data'
                },
                paramsAsHash: true,
                paramOrder: ['company_uuid', 'keyword', 'page', 'limit', 'sort', 'dir'],
                extraParams: {
                    company_uuid: '',
                    keyword: ''
                },
                simpleSortMode: true,
                listeners: {
                    exception: function(proxy, response, operation) {
                        Ext.MessageBox.show({
                            title: 'REMOTE EXCEPTION',
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
            remoteSort: true,
            sorters: [{
                property: 'C_NAME',
                direction: 'ASC'
            }]
        });

    Ext.define('AttendantPicker', {
        extend: 'Ext.window.Window',
        title: '<img src="' + SYSTEM_URL_ROOT + '/css/images/man.png" style="height:16px;vertical-align:middle;margin-top:-2px;margin-right:5px;">挑選人員',
        closeAction: 'hide',
        uuid: undefined,
        id: 'ExtAttendantPicker',
        iconSelectUrl: SYSTEM_URL_ROOT + '/css/custImages/mouse_select_left.gif',
        companyUuid: undefined,
        width: 750,
        height: 450,
        layout: 'fit',
        resizable: false,
        draggable: true,
        initComponent: function() {
            this.addEvents('closeEvent');
            this.addEvents('selectedEvent');
            var me = this;
            me.items = [Ext.create('Ext.form.Panel', {
                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                id: 'Ext.AttendantPicker.Form',
                paramOrder: ['pUuid'],
                border: true,
                bodyPadding: 5,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [
                    {
                        xtype: 'container',
                        layout: 'hbox',
                        items: [{
                            xtype: 'textfield',
                            fieldLabel: '關鍵字',
                            id: 'Ext.AttendantPicker.keyWord',
                            labelAlign: 'right',
                            enableKeyEvents: true,
                            listeners: {
                                keyup: function(e, t, eOpts) {
                                    if (t.button == 12) {
                                        this.up('panel').down('#btnQuery').handler();
                                    }
                                }
                            }
                        }, {
                            xtype: 'label',
                            text: '',
                            style: 'display:block; padding:4px 4px 4px 4px'
                        }, {
                            xtype: 'button',
                            text: '<img src="' + SYSTEM_URL_ROOT + '/css/custimages/search.gif" style="height:16px;vertical-align:middle;margin-top:-2px;margin-right:5px;">查詢',
                            itemId: 'btnQuery',
                            handler: function() {
                                storeParameterPicker.getProxy().setExtraParam('company_uuid', Ext.getCmp('ExtAttendantPicker').companyUuid);
                                storeParameterPicker.getProxy().setExtraParam('keyword', Ext.getCmp('Ext.AttendantPicker.keyWord').getValue());
                                storeParameterPicker.load();
                            }
                        }]
                    },

                    {
                        xtype: 'gridpanel',
                        store: storeParameterPicker,
                        idProperty: 'UUID',
                        paramsAsHash: false,
                        padding: 5,
                        columns: [{
                            text: "挑選",
                            dataIndex: 'UUID',
                            align: 'center',
                            renderer: function(value, m, r) {
                                var id = Ext.id();
                                Ext.defer(function() {
                                    Ext.widget('button', {
                                        renderTo: id,
                                        text: '<img src="' + Ext.getCmp('ExtAttendantPicker').iconSelectUrl + '" style="height:16px;vertical-align:middle">&nbsp;選擇',
                                        record: r,
                                        width: 75,
                                        handler: function() {


                                            Ext.getCmp('ExtAttendantPicker').selectedEvent(this.record);

                                        }
                                    });
                                }, 50);
                                return Ext.String.format('<div id="{0}"></div>', id);
                            },
                            sortable: false,
                            hideable: false
                        }, {
                            text: "中文姓名",
                            dataIndex: 'C_NAME',
                            align: 'center',
                            flex: 1
                        }, {
                            text: "英文姓名",
                            dataIndex: 'E_NAME',
                            align: 'center',
                            flex: 1
                        }, {
                            text: "帳號",
                            dataIndex: 'ACCOUNT',
                            align: 'center',
                            flex: 2
                        }, {
                            text: "E-Mail",
                            dataIndex: 'EMAIL',
                            align: 'center',
                            flex: 2
                        }],
                        anchor: '95%',
                        height: 450,
                        bbar: Ext.create('Ext.toolbar.Paging', {
                            store: storeParameterPicker,
                            displayInfo: true,
                            displayMsg: '第{0}~{1}資料/共{2}筆',
                            emptyMsg: "無資料顯示"
                        }),
                        listeners: {
                            'beforerender': function() {}
                        },
                        tbarCfg: {
                            buttonAlign: 'right'
                        }
                    }
                ],
                fbar: [{
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/leave.png" style="height:20px;vertical-align:middle;margin-top:-2px;margin-right:5px;">關閉',
                    handler: function() {
                        Ext.getCmp('ExtAttendantPicker').hide();
                    }
                }]
            })]
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        selectedEvent: function(result) {
            this.fireEvent('selectedEvent', result);
        },
        listeners: {
            'beforeshow': function() {
                /*:::畫面開啟後載入資料:::*/
                Ext.getBody().mask();
                storeParameterPicker.getProxy().setExtraParam('company_uuid', Ext.getCmp('ExtAttendantPicker').companyUuid);
                storeParameterPicker.getProxy().setExtraParam('keyword', Ext.getCmp('Ext.AttendantPicker.keyWord').getValue());
                storeParameterPicker.load();
            },
            'hide': function() {
                Ext.getBody().unmask();
                Ext.getCmp('Ext.AttendantPicker.keyWord').setValue('');
                this.closeEvent();
            }
        }
    });
});