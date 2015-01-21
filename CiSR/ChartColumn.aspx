<%@ Page Title="" Language="C#" MasterPageFile="~/mpStand.Master" AutoEventWireup="true" CodeBehind="ChartColumn.aspx.cs" Inherits="CISR.ChartColumn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/js/shared/include-ext.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Proxy.ashx")+ "?cache="+IST.Util.UID.Instance.GetUniqueID() %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/pageJs/AllModel.js")+ "?cache="+IST.Util.UID.Instance.GetUniqueID()%>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<script language="javascript" type="text/javascript">
    var AttendantQuery = undefined;
    var myForm = undefined;
    var myFiles = undefined;
    var store1 = undefined;
    Ext.onReady(function() {
    	store1 = Ext.create('Ext.data.JsonStore', {
        fields: ['name', 'data1', 'data2', 'data3', 'data4', 'data5'],
        data: [{
            'name': 'metric one',
            'data1': 10,
            'data2': 12,
            'data3': 14,
            'data4': 8,
            'data5': 13
        }, {
            'name': 'metric two',
            'data1': 7,
            'data2': 8,
            'data3': 16,
            'data4': 10,
            'data5': 3
        }, {
            'name': 'metric three',
            'data1': 5,
            'data2': 2,
            'data3': 14,
            'data4': 12,
            'data5': 7
        }, {
            'name': 'metric four',
            'data1': 2,
            'data2': 14,
            'data3': 6,
            'data4': 1,
            'data5': 23
        }, {
            'name': 'metric five',
            'data1': 27,
            'data2': 38,
            'data3': 36,
            'data4': 13,
            'data5': 33
        }]



    });

    	Ext.create('Ext.panel.Panel',{
    		title:'Test',
    		width:600,
    		height:600,
    		items:[
    			Ext.create('Ext.chart.CartesianChart', {
        id: 'chartCmp',
        xtype: 'chart',
        style: 'background:#fff',
        //animate: true,
        shadow: true,
        store: store1,
        legend: {
            position: 'bottom'
        },
        axes: [{
            type: 'Numeric',
            position: 'left',
            fields: ['data1', 'data2', ],
            minimum: 0,
            label: {
                renderer: Ext.util.Format.numberRenderer('0,0')
            },
            grid: true,
            title: 'Number of Hits'
        }, {
            type: 'Category',
            position: 'bottom',
            fields: ['name'],
            title: 'Month of the Year'
        }],
        series: [{
            type: 'column',
            axis: 'bottom',
            xField: 'name',
            yField: ['data1', 'data2', 'data3'],
            tips: {
                trackMouse: true,
                width: 110,
                height: 25,
                renderer: function (storeItem, item) {
                    this.setTitle(storeItem.get('data2') + ' visits in ' + storeItem.get('name').substr(0, 3));
                }
            }
        }, {

            type: 'line',
            axis: 'left',
            xField: 'name',
            yField: 'data3',
            tips: {
                trackMouse: true,
                width: 110,
                height: 25,
                renderer: function (storeItem, item) {
                    this.setTitle(storeItem.get('data2') + ' visits in ' + storeItem.get('name').substr(0, 3));
                }
            },
            style: {
                fill: '#18428E',
                stroke: '#18428E',
                'stroke-width': 3
            },
            markerConfig: {
                type: 'circle',
                size: 4,
                radius: 4,
                'stroke-width': 0,
                fill: '#18428E',
                stroke: '#18428E'
            }

        }]

    })
    		],
    		renderTo:Ext.getBody()
    	})
    });
</script>
</asp:Content>
