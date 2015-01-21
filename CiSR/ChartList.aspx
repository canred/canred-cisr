<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="ChartList.aspx.cs" Inherits="CISR.ChartList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")%>'></script>

    <script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/packages/ext-charts/build/ext-charts.js")%>'></script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divPanel" width="100%" height="700"></div>

<style>
.x-tip {
    width: auto !important;
}
.x-tip-body {
    width: auto !important;
}
.x-tip-body span {
    width: auto !important;
}
</style>
<script language="javascript" type="text/javascript">
    var mainPanel = undefined;
    var storeMain = undefined;
    Ext.Loader.setConfig({
        enabled: true
    });

    Ext.direct.Manager.addProvider(eval(SYSTEM_APPLICATION + ".ChartAction"));
    Ext.onReady(function(){
    Ext.QuickTips.init();
    Ext.define('PieChart', {
        extend: 'Ext.panel.Panel',
        title: '',
        KPI: undefined,
        FRAME: undefined,
        TIME: undefined,
        DISPLAY: undefined,
        closeAction: 'destory',
        width: $("#header").width()-50,
        height: 600,
        resizable: false,
        draggable: false,
        initComponent: function() {
            var me = this;
            this.myDataStore = Ext.create('Ext.data.JsonStore', {
                fields: ['ITEMCATEGORY', 'ITEMVALUE'],
            });
            me.items = [
            {
              xtype : 'container',
              layout : 'hbox',
              items : [
                {
                  xtype : 'label',
                  itemId:'labChartGroup',
                  text : '類別：' ,
                  margin:'0 5 0 5'
                  /*
                  ,labelStyle : 'font-weight:bold;',
                  anchor : '100%'
                  */
                },
                {
                  xtype:'tbfill'
                },
                {
                xtype:'button',
                text:'Remove this chart',
                handler:function(handler,scope){
                  //WS.ChartAction.removeMyChart()
                }
              }]
            },
            {
                xtype: 'chart',
                width: 750,
                height: 550,
                margin: '0 0 0 0',
                style: 'background: #fff',
                animate: true,
                shadow: false,
                store: this.myDataStore,
                insetPadding: 80,
                legend: {
                    field: 'ITEMCATEGORY',
                    position: 'bottom',
                    boxStrokeWidth: 0,
                    labelFont: '12px Helvetica'
                },
                items: [
                    {
                        type: 'text',
                        text: '圖表名稱: ' + this.NAME,
                        font: '10px Helvetica',
                        x: 12,
                        y: 490
                    }, {
                        type: 'text',
                        text: '說明: ' + this.DESC,
                        font: '10px Helvetica',
                        x: 12,
                        y: 510
                    }
                ],
                series: [{
                    type: 'pie',
                    angleField: 'ITEMVALUE',
                    label: {
                        field: 'ITEMCATEGORY',
                        display: 'outside',
                        calloutLine: true
                    },
                    showInLegend: true,
                    highlight: true,
                    highlightCfg: {
                        fill: '#000',
                        'stroke-width': 10,
                        stroke: '#fff'
                    },
                    tips: {
                        trackMouse: true,
                        renderer: function(storeItem, item) {
                            // this.setTitle('* '+storeItem.get('ITEMCATEGORY') + ': ' + storeItem.get('ITEMVALUE'));
                            this.setTitle( '*數值：'+storeItem.get('ITEMVALUE'));
                        }
                    }
                }]
            }];
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'afterrender': function() {
                this.down("#labChartGroup").setText('類別：'+this.chartGroup);
                WS.ChartAction.loadPieChartA(this.DISPLAY, this.KPI, this.FRAME, this.TIME, function(obj, jsonObj) {
                    try {
                        if (jsonObj.result.success) {
                            Ext.each(jsonObj.result.data.Item, function(item) {
                                this.myDataStore.add({
                                    "ITEMCATEGORY": item.ITEMCATEGORY,
                                    "ITEMVALUE": item.ITEMVALUE
                                });

                               
                            }, this);



                        } else {
                            Ext.MessageBox.show({
                                title: '設定錯誤',
                                icon: Ext.MessageBox.ERROR,
                                buttons: Ext.Msg.OK,
                                msg: jsonObj.result.message
                            });
                        }
                    } catch (e) {
                        Ext.MessageBox.show({
                            title: '發生異常錯誤',
                            icon: Ext.MessageBox.ERROR,
                            buttons: Ext.Msg.OK,
                            msg: '造成原因可能為資料不齊全'
                        });
                    }

                }, this);
            },
            'close': function() {
                Ext.getBody().unmask();
                this.closeEvent();
            }
        }
    });

      Ext.define('ColumnClusterCharts', {
        extend: 'Ext.panel.Panel',
        title: '',
        KPI: undefined,
        FRAME: undefined,
        TIME: undefined,
        DISPLAY: undefined,
        TIMECOLUMN: undefined,
        closeAction: 'destory',
        width: $("#header").width()-50,
        height: 600,
        resizable: false,
        draggable: false,
        initComponent: function() {
            var me = this;
            var arrTimeColumn = Array();
            var arrTimeColumn2 = Array();
            arrTimeColumn.push('ITEMCATEGORY');
            for (var i = 0; i < this.TIMECOLUMN.split(';').length; i++) {
                if (this.TIMECOLUMN.split(';')[i] != "") {
                    arrTimeColumn.push("D" + (i + 1));
                    
                }
            }

            console.log(arrFrameText);

            var arrFrameText = Array();

            for(var i =0 ;i <this.FRAMETEXT.split(';').length ; i++){
                if( this.FRAMETEXT.split(';')[i] !=""){
                    arrFrameText.push(this.FRAMETEXT.split(';')[i]);
                    arrTimeColumn2.push("D" + (i + 1));
                }
            }

            me.items = [{
                xtype: 'panel',
                width: $("#header").width()-50,
                height: 600,
                items: [
                  {
              xtype : 'container',
              layout : 'hbox',
              items : [
                {
                  xtype:'tbfill'
                },
                {
                xtype:'button',
                text:'Remove this chart',
                handler:function(handler,scope){
                  alert('未完成')
                }
              }]
            },
                  {
                    xtype: 'chart',
                    width: $("#header").width()-50,
                    height: 600,
                    padding: '10 0 0 0',
                    margin: '0 0 0 0',
                    style: 'background: #fff',
                    animate: false,
                    shadow: false,
                    store: this.myDataStore,
                    insetPadding: 60,
                    legend: {
                        disabled: true,
                        position: 'bottom',
                        boxStrokeWidth: 0,
                        labelFont: '12px Helvetica'
                    },
                    items: [
                        // {
                        //     type: 'text',
                        //     text: 'Pie Charts - Basic',
                        //     font: '22px Helvetica',
                        //     width: 100,
                        //     height: 30,
                        //     x: 40, // the sprite x position
                        //     y: 12 // the sprite y position
                        // },

                        {
                            type: 'text',
                            text: '圖表名稱: ' + this.NAME,
                            font: '10px Helvetica',
                            x: 12,
                            y: 500
                        }, {
                            type: 'text',
                            text: '說明: ' + this.DESC,
                            font: '10px Helvetica',
                            x: 12,
                            y: 520
                        }
                    ],
                    axes: [{
                        type: 'Numeric',
                        position: 'left',
                        fields: 'D1',
                        grid: true,
                        //minimum: 0,
                        label: {
                            renderer: function(v) {
                                return v;
                            }
                        }
                    }, {
                        type: 'Category',
                        position: 'bottom',
                        fields: 'ITEMCATEGORY',
                        grid: true,
                        label: {
                            rotate: {
                                degrees: -45
                            }
                        }
                    }],
                    series: [{
                        type: 'column',
                        axis: 'left',
                        title: arrFrameText,
                        xField: 'ITEMCATEGORY',
                        yField: arrTimeColumn2,
                        style: {
                            opacity: 0.80
                        },
                        highlight: {
                            fill: '#000',
                            'stroke-width': 1,
                            stroke: '#000'
                        },
                        tips: {
                            trackMouse: true,
                            style: 'background: #FFF',
                            height: 20,
                            renderer: function(storeItem, item) {
                                var browser = item.series.title[Ext.Array.indexOf(item.series.yField, item.yField)];
                                

                                //this.setTitle('* '+browser + ' 時間:' + storeItem.get('ITEMCATEGORY') + '; 值: ' + storeItem.get(item.yField));

                                this.setTitle('*數值：'+ storeItem.get(item.yField));
                            }
                        }
                    }]
                }]
            }];
            me.callParent(arguments);
        },
        closeEvent: function() {
            this.fireEvent('closeEvent', this);
        },
        listeners: {
            'show': function() {

            },
            'close': function() {
                Ext.getBody().unmask();
                this.closeEvent();
            }
        }
    });

  
       mainPanel= Ext.create('Ext.form.Panel',{
        title:'我的圖表',
        frame:true,
        padding:'10 0 0 0',
        autoHeight:true,
        width: $("#header").width()-15,
        renderTo:'divPanel',
        items:[
            {
                xtype : 'fieldset',
                border : false,
                itemId:'fdContent',
                items : [{                  
                }]
            }
        ]
       }); 

       storeMain = Ext.create('Ext.data.Store', {
           extend : 'Ext.data.Store',
           autoLoad : false,
           model : 'CHART_LIST',
           pageSize : 10,
           remoteSort:true,
           proxy : {
               type : 'direct',
               api : {
                   read : WS.ChartAction.loadMyChart
               },
               reader : {
                   root : 'data'
               },             
               paramsAsHash : true,
               paramOrder : [ 'page', 'limit', 'sort', 'dir'],
               extraParams : {                   
               },
               simpleSortMode : true,
               listeners : {
                   exception : function(proxy, response, operation) {
                       Ext.MessageBox.show({
                           title : 'REMOTE EXCEPTON A',
                           msg : operation.getError(),
                           icon : Ext.MessageBox.ERROR,
                           buttons : Ext.Msg.OK
                       });
                   },
                   beforeload : function() {
                       alert('beforeload proxy');
                   }
               }
           },
           listeners : {
               write : function(proxy, operation) {
               },
               read : function(proxy, operation) {
               },
               beforeload : function() {
               },
               afterload : function() {
               },
               load : function() {
               }
           },
           sorters : [{
               property : 'UUID',
               direction : 'DESC'
           }]
       });

       storeMain.load(function(obj,jsonObj){
            //if(jsonObj.result != undefined && jsonObj.result.success != undefined){
                Ext.each( jsonObj._response.result.data , function(item){
                  
                    if ( item["CHART_TYPE"]=="PieCharts" ){                        
                        var initObj = Ext.decode(item["JOBJECT"]);
                        initObj.UUID = item["UUID"];
                        var genChart = Ext.create('PieChart',initObj);
                        genChart.chartGroup = item["CHART_GROUP"];
                        mainPanel.add(genChart);
                    }else if(item["CHART_TYPE"]=="ColumnClusterCharts"){
                        var initObj = Ext.decode(item["JOBJECT"]);

                        
                        console.log(initObj.KPI);
                        console.log(initObj.FRAME);
                        console.log(initObj.TIMECOLUMN);
                        

                        WS.ChartAction.loadColumnClusterCharts(initObj.KPI, initObj.FRAME, initObj.TIMECOLUMN, function(obj, jsonObj2) {
                          try {
                              if (jsonObj2.result.success) {

                                 
                                  
                                  var arrTimeColumn = Array();
                                  arrTimeColumn.push('ITEMCATEGORY');
                                  for (var i = 0; i < initObj.TIMECOLUMN.split(';').length; i++) {
                                      if (initObj.TIMECOLUMN.split(';')[i] != "") {
                                          arrTimeColumn.push("D" + (i + 1));
                                      }
                                  }

                                  var myDataStore = Ext.create('Ext.data.JsonStore', {
                                      fields: arrTimeColumn
                                  });

                                  Ext.each(jsonObj2.result.data.Item, function(item) {
                                      this.add(item);
                                  }, myDataStore);

                                   mainPanel.add(Ext.create('ColumnClusterCharts',
                                    {
                                      KPI: initObj.KPI ,
                                      FRAME: initObj.FRAME,
                                      FRAMETEXT:initObj.FRAMETEXT,
                                      TIMES: initObj.TIMES,
                                      TIMEE: initObj.TIMEE,
                                      TIMECOLUMN: initObj.TIMECOLUMN,
                                      myDataStore: myDataStore,                                      
                                      NAME: initObj.NAME,
                                      DESC: initObj.DESC
                                  }));

                                  
                              } else {
                                  Ext.MessageBox.show({
                                      title: '設定錯誤',
                                      icon: Ext.MessageBox.ERROR,
                                      buttons: Ext.Msg.OK,
                                      msg: jsonObj2.result.message
                                  });
                              }
                          } catch (e) {
                              Ext.MessageBox.show({
                                  title: '發生異常錯誤',
                                  icon: Ext.MessageBox.ERROR,
                                  buttons: Ext.Msg.OK,
                                  msg: '造成原因可能為資料不齊全'
                              });
                          }
                      });
                    }
                });
            //}
       },mainPanel);

    });

</script>
</asp:Content>
