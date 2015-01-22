Ext.onReady(function() {
    /*Basic*/


    Ext.define('COMPANY', {
        extend: 'Ext.data.Model',
        fields: ['UUID', 'ID', 'C_NAME', 'E_NAME', 'WEEK_SHIFT', 'NAME_ZH_CN', 'IS_ACTIVE']
    });


    Ext.define('ATTENDANT', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'CREATE_DATE',
            'UPDATE_DATE',
            'IS_ACTIVE',
            'COMPANY_UUID',
            'ACCOUNT',
            'C_NAME',
            'E_NAME',
            'EMAIL',
            'PASSWORD',
            'IS_SUPPER',
            'IS_ADMIN',
            'CODE_PAGE',
            'DEPARTMENT_UUID',
            'PHONE',
            'SITE_UUID',
            'GENDER',
            'BIRTHDAY',
            'HIRE_DATE',
            'QUIT_DATE',
            'IS_MANAGER',
            'IS_DIRECT',
            'GRADE',
            'ID',
            'SRC_UUID',
            'IS_DEFAULT_PASS'
        ]
    });

    Ext.define('ATTEDNANTV', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'COMPANY_ID',
            'COMPANY_C_NAME',
            'COMPANY_E_NAME',
            'DEPARTMENT_ID',
            'DEPARTMENT_C_NAME',
            'DEPARTMENT_E_NAME',
            'SITE_ID',
            'SITE_C_NAME',
            'SITE_E_NAME',
            'UUID',
            'CREATE_DATE',
            'UPDATE_DATE',
            'IS_ACTIVE',
            'COMPANY_UUID',
            'ACCOUNT',
            'C_NAME',
            'E_NAME',
            'EMAIL',
            'PASSWORD',
            'IS_SUPPER',
            'IS_ADMIN',
            'CODE_PAGE',
            'DEPARTMENT_UUID',
            'PHONE',
            'SITE_UUID',
            'GENDER',
            'BIRTHDAY',
            'HIRE_DATE',
            'QUIT_DATE',
            'IS_MANAGER',
            'IS_DIRECT',
            'GRADE',
            'ID',
            'IS_DEFAULT_PASS'
        ]
    });

    Ext.define('APPLICATION', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'CREATE_DATE',
            'UPDATE_DATE',
            'IS_ACTIVE',
            'NAME',
            'DESCRIPTION',
            'ID',
            'CREATE_USER',
            'UPDATE_USER',
            'WEB_SITE',
            'UUID'
        ]
    });



    Ext.define('APPPAGE', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'IS_ACTIVE',
            'CREATE_DATE',
            'CREATE_USER',
            'UPDATE_DATE',
            'UPDATE_USER',
            'ID',
            'NAME',
            'DESCRIPTION',
            'URL',
            'PARAMETER_CLASS',
            'APPLICATION_HEAD_UUID',
            'P_MODE'
        ]
    });


    Ext.define('Model.SiteMap', {
        extend: 'Ext.data.Model',
        fields: [{
            name: 'UUID'
        }, {
            name: 'NAME'
        }, {
            name: 'DESCRIPTION'
        }]
    });

    Ext.define('AppMenu', {
        extend: 'Ext.data.Model',
        fields: [{
            name: 'UUID'
        }, {
            name: 'NAME'
        }, {
            name: 'NAME_ZH_TW'
        }, {
            name: 'DESCRIPTION'
        }, {
            name: 'ORD'
        }]
    });

    Ext.define('PROXY', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'PROXY_ACTION',
            'PROXY_METHOD',
            'DESCRIPTION',
            'PROXY_TYPE',
            'NEED_REDIRECT',
            'REDIRECT_PROXY_ACTION',
            'REDIRECT_PROXY_METHOD',
            'APPLICATION_HEAD_UUID',
            'REDIRECT_SRC'
        ]
    });


    Ext.define('GROUPHEAD', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'CREATE_DATE',
            'UPDATE_DATE',
            'IS_ACTIVE',
            'NAME_ZH_TW',
            'NAME_ZH_CN',
            'NAME_EN_US',
            'COMPANY_UUID',
            'ID',
            'APPLICATION_HEAD_UUID',
            'APPLICATION_HEAD_ID',
            'APPLICATION_HEAD_NAME'
        ]
    });

    Ext.define('AppMenu2', {
        extend: 'Ext.data.Model',
        fields: [{
            name: 'UUID'
        }, {
            name: 'NAME_ZH_TW'
        }, {
            name: 'ACTION_MODE'
        }, {
            name: 'DESCRIPTION'
        }, {
            name: 'URL'
        }, {
            name: 'PARAMETER_CLASS'
        }, {
            name: 'DEFAULT_PAGE_CHECKED',
            type: 'bool',
            convert: function(v) {
                return (v === "Y" || v === true) ? true : false;
            }
        }, {
            name: 'IS_DEFAULT_PAGE',
            type: 'bool',
            convert: function(v) {
                return (v === "Y" || v === true) ? true : false;
            }
        }]
    });


    Ext.define('SCHEDULE', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'SCHEDULE_NAME',
            'SCHEDULE_END_DATE',
            'LAST_RUN_TIME',
            'LAST_RUN_STATUS',
            'IS_CYCLE',
            'SINGLE_DATE',
            'HOUR',
            'MINUTE',
            'CYCLE_TYPE',
            'C_MINUTE',
            'C_HOUR',
            'C_DAY',
            'C_WEEK',
            'C_DAY_OF_WEEK',
            'C_MONTH',
            'C_DAY_OF_MONTH',
            'C_WEEK_OF_MONTH',
            'C_YEAR',
            'C_WEEK_OF_YEAR',
            'RUN_URL',
            'RUN_URL_PARAMETER',
            'RUN_ATTENDANT_UUID',
            'IS_ACTIVE',
            'START_DATE',
            'RUN_SECURITY'
        ]
    });
    /*Cisr*/

    Ext.define('VPARAMETERQUERY', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
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
    });



    Ext.define('REGION', {
        extend: 'Ext.data.Model',
        fields: ['UUID', 'REGION_NAME']
    });




    Ext.define('TIME', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: ['TIME_ID', 'TIME_TYPE']
    })

    Ext.define('V_RAW_HEAD', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'COMPANY_ID',
            'COMPANY_C_NAME',
            'COMPANY_E_NAME',
            'COMPANY_ZH_CN',
            'UUID',
            'CREATE_DATE',
            'UPDATE_DATE',
            'IS_ACTIVE',
            'COMPANY_UUID',
            'RAW_ID',
            'RAW_CATEGORY_UUID',
            'C_DESC',
            'E_DESC',
            'C_DEFINE',
            'E_DEFINE',
            'UNIT',
            'CAN_NULL',
            'TIME_TYPE',
            'NEED_DESC',
            'NEED_FILE',
            'VALUEDISPLAY',

            'RAW_HEAD_CATEGORY_NAME',
            'RAW_HEAD_CATEGORY_DESCRIPTION'
        ]
    });

    Ext.define('V_KPI', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'KPI_HEAD_UUID',
            'IS_ACTIVE',
            'COMPANY_UUID',
            'KPI_ID',
            'C_DESC',
            'E_DESC',
            'UNIT',
            'DEGREE',
            'C_NOTICE',
            'SIGNAL',
            'TIME_TYPE',
            'C_DESC_GROUP',
            'E_DESC_GROUP',
            'INCLUDE_KPI',
            'CALCULTE_ORD',
            'NEED_SUMMARY',
            'NEED_SECURITY',
            'ZH_DESC',
            'KPI_FORMULA_UUID',
            'TIME_ID',
            'ALGORITHM',
            'KPI_FORMULA_DESC',
            'ALGORITHM_MAN'

        ]
    });

    Ext.define('V_UNIT', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
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
    });

    Ext.define('V_KPI_ITEM', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: ['KPI_HEAD_UUID',
            'IS_ACTIVE',
            'COMPANY_UUID',
            'KPI_ID',
            'C_DESC',
            'E_DESC',
            'UNIT',
            'DEGREE',
            'C_NOTICE',
            'SIGNAL',
            'TIME_TYPE',
            'C_DESC_GROUP',
            'E_DESC_GROUP',
            'INCLUDE_KPI',
            'CALCULTE_ORD',
            'NEED_SUMMARY',
            'NEED_SECURITY',
            'ZH_DESC',
            'KPI_FORMULA_UUID',
            'TIME_ID',
            'ALGORITHM',
            'KPI_FORMULA_DESC',
            'ALGORITHM_MAN'
        ]
    });

    Ext.define('V_KPI_EXP', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: ['KPI_PACKAGE_EXPEND_UUID',
            'KPI_PACKAGE_UUID',
            'KPI_PACKAGE_ITEM_UUID',
            'RAW_HEAD_UUID',
            'RAW_ID',
            'RAW_HEAD_IS_ACTIVE',
            'RAW_CATEGORY_UUID',
            'C_DESC',
            'E_DESC',
            'C_DEFINE',
            'E_DEFINE',
            'UNIT',
            'CAN_NULL',
            'TIME_TYPE',
            'NEED_DESC',
            'NEED_FILE',
            'VALUEDISPLAY',

        ]
    });

    Ext.define('V_FRAMEITEM', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: ['UUID',
            'FRAME_ITEM_IS_ACTIVE',
            'FRAME_HEAD_UUID',
            'RAW_HEAD_UUID',
            'FRAME_ITEM_ORD',
            'PWG1_UUID',
            'PWG2_UUID',
            'PWG3_UUID',
            'PWG4_UUID',
            'PWG5_UUID',
            'PWG1_SHOW',
            'PWG2_SHOW',
            'PWG3_SHOW',
            'PWG4_SHOW',
            'PWG5_SHOW',
            'RAW_ID',
            'RAW_CATEGORY_UUID',
            'C_DESC',
            'E_DESC',
            'UNIT',
            'CAN_NULL',
            'TIME_TYPE',
            'NEED_DESC',
            'NEED_FILE',
            'VALUEDISPLAY',

            'SKIP',
            'SKIP_RESULT'
        ]
    });
    Ext.define('V_PWG', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: ['ATTENDANT_UUID', 'C_NAME']
    });

    Ext.define('V_UPLOAD_JOB', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'RAW_CAN_NULL',
            'RAW_TIME_TYPE',
            'RAW_NEED_DESC',
            'RAW_NEED_FILS',
            'RAW_VALUEDISPLAY',
            'UUID',
            'FRAME_HEAD_UUID',
            'RAW_HEAD_UUID',
            'TIME_ID',
            'COMPANY_UUID',
            'FILES_GROUP_ID',
            'VALUE',
            'EXPLAIN',
            'DWG1_GID',
            'DWG2_GID',
            'DWG3_GID',
            'DWG4_GID',
            'DWG5_GID',
            'UPDATE_DATE',
            'STATUS',
            'SKIP',
            'SKIP_RESULT',
            'DWG1_SHOW',
            'DWG2_SHOW',
            'DWG3_SHOW',
            'DWG4_SHOW',
            'DWG5_SHOW',
            'FRAME_HEAD_IS_ACTIVE',
            'REGION_UUID',
            'REGION_NAME',
            'DLEVEL',
            'FULL_FRAME_NAME_LIST',
            'FULL_FRAME_UUID_LIST',
            'FULL_FRAME_ID_LIST',
            'RAW_ID',
            'RAW_C_DESC',
            'RAW_E_DESC',
            'RAW_UNIT',
            'FINISH',
            'FILES_COUNT'
        ]
    });


    Ext.define('FRAME_HEAD', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: ['DLEVEL',
            'ZH_NAME',
            'FULL_FRAME_NAME_LIST',
            'FRAME_ID',
            'FULL_FRAME_ID_LIST',
            'KPI_PACKAGE_UUID',
            'FULL_FRAME_UUID_LIST',
            'HASCHILD',
            'UUID',
            'CREATE_DATE',
            'UPDATE_DATE',
            'IS_ACTIVE',
            'COMPANY_UUID',
            'C_NAME',
            'E_NAME',
            'PARENT_FRAME_HEAD_UUID',
            'ORD',
            'REGION_UUID',
            'CURRENCY',
            'FRAME_CATEGORY_UUID'
        ]
    });
    Ext.define('V_CAL', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'FRAME_HEAD_UUID',
            'TIME_ID',
            'KPI_HEAD_UUID',
            'ORD',
            'STATUS',
            'ERROR_MSG',
            'VALUE',
            'FORMULA',
            'CAL_LOG',
            'FRAME_LEVEL',
            'C_NAME',
            'FULL_FRAME_UUID_LIST',
            'FULL_FRAME_NAME_LIST',
            'KPI_ID',
            'C_DESC',
            'UNIT',
            'HASCHILD'

        ]
    });

    Ext.define('FILES', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'FILES_GROUP_ID',
            'FILE_NAME',
            'SYSTEM_PATH'

        ]
    });

    Ext.define('FRAME_CATEGORY', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: ['UUID',
            'FRAME_CATEGORY_NAME'
        ]
    });

    Ext.define('KPI_PACKAGE', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'COMPANY_UUID',
            'NAME',
            'SCOPE_MONTH_ID'
        ]
    });

    Ext.define('CHART_LIST', {
        extend: 'Ext.data.Model',
        /*:::欄位設定:::*/
        fields: [
            'UUID',
            'CHART_NAME',
            'CHART_DESC',
            'CHART_TITLE',
            'CHART_TYPE',
            'CHART_X',
            'CHART_Y',
            'CHART_TIME',
            'ATTENDANT_UUID',
            'DISPLAY',
            'JOBJECT',
            'COMPANY_UUID'
        ]
    });

});
