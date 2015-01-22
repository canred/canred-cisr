Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');
Ext.require(['*', 'Ext.ux.DataTip']);
Ext.MessageBox.buttonText.yes = "確定";
Ext.MessageBox.buttonText.no = "取消";
Ext.onReady(function() {
    Ext.define('FrameCategoryForm', {
        extend: 'Ext.window.Window',
        title: '組織產業別 新增/修改',
        closeAction: 'hide',
        uuid: undefined,
        companyUuid: undefined,
        width: 400,
        height: 200,
        layout: 'fit',
        openerObj: undefined,
        resizable: false,
        draggable: true,
        hasChange:false,
        initComponent: function() {
            var me = this;
            me.items = [Ext.create('Ext.form.Panel', {
                layout: {
                    type: 'form',
                    align: 'stretch'
                },
                api: {
                    load: WS.FrameAction.infoFrameCategory,
                    submit: WS.FrameAction.submitFrameCategory
                },
                itemId: 'FrameCategoryForm',
                paramOrder: ['pUuid'],
                border: true,
                autoScroll: true,
                defaultType: 'textfield',
                buttonAlign: 'center',
                items: [{
                    xtype: 'container',
                    layout: 'hbox',
                    items: [{
                        xtype: 'textfield',
                        fieldLabel: '產業別名稱',
                        labelAlign: 'right',
                        labelWidth: 100,
                        name: 'FRAME_CATEGORY_NAME',
                        margin: 5,
                        maxLength: 84,
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
                }],
                fbar: [{
                    type: 'button',
                    text: '<img src="' + SYSTEM_URL_ROOT + '/css/images/save.gif" style="width:16px;height:16px;vertical-align:middle;margin-right:5px;"/>' + '儲存',
                    handler: function() {
                        var main = this.up('window');
                        var form = this.up('window').down("#FrameCategoryForm").getForm();
                        if (form.isValid() == false) {
                            return;
                        }
                        form.submit({
                            waitMsg: '更新中...',
                            success: function(form, action) {
                                main.uuid = action.result.UUID;
                                main.down("#UUID").setValue(action.result.UUID);
                                main.setTitle('組織產業別【維護】');
                                Ext.MessageBox.show({
                                    title: '組織產業別',
                                    msg: '操作完成',
                                    icon: Ext.MessageBox.INFO,
                                    buttons: Ext.Msg.OK
                                });
                                main.hasChange = true;
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
            if(this.hasChange==true){
                this.fireEvent('closeEvent', this);
            }
        },
        listeners: {
            'show': function() {
                if (this.openerObj != undefined) {
                    this.openerObj.mask();
                }
                if (this.uuid != undefined) {
                    /*When 編輯/刪除資料*/
                    this.down("#FrameCategoryForm").getForm().load({
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
                    this.down("#FrameCategoryForm").getForm().reset();
                }
            },
            'hide': function() {
                if (this.openerObj)
                    this.openerObj.unmask();
                this.closeEvent();
                this.down("#FrameCategoryForm").getForm().reset();
            }
        }
    });
});