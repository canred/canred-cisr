Ext.Loader.setConfig({
    enabled: true
});
Ext.Loader.setPath('Ext.ux', SYSTEM_ROOT_PATH + '/js/ux');

Ext.onReady(function() {
    Ext.define('PopMessage', {
        extend: 'Ext.window.Window',
        title: 'Message',
        closeAction: 'hide',
        width: 800,
        height: 400,
        resizable: false,
        draggable: true,
        msg: 'aaa',
        autoScroll: true,
        initComponent: function() {
            var me = this;
            me.callParent(arguments);
        },
        items: [{
            xtype: 'label',
            itemId: 'txtMsg',
            width: 495,
            minHeight: 350,
            autoHeight: true

        }],
        closeEvent: function() {
            //this.fireEvent('closeEvent', this);
        },
        listeners: {
            'show': function() {
                Ext.getBody().mask();
                var showMsg = this.msg;
                while (showMsg.indexOf('\n') >= 0) {
                    showMsg = showMsg.replace('\n', '<BR>');
                }

                while (showMsg.indexOf('\r') >= 0) {
                    showMsg = showMsg.replace('\r', '<BR>');
                }
                this.down("#txtMsg").setHtml(showMsg, true);
            },
            'beforeshow': function() {

            },
            'afterrender': function() {
            },
            'hide': function() {
                Ext.getBody().unmask();
                // this.closeEvent();
            },
            'close': function() {
                Ext.getBody().unmask();
                //this.closeEvent();
            }
        }
    });
});