function openDialog(url, name) {
    window.open(url, name, 'height=600,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no');
}

//user/index页面
(function () {
    'use strict';
        var Grid = BUI.Grid,
            Data = BUI.Data;
        var Grid = Grid,
            Store = Data.Store,
            store = new Store({
                url: '/user/GetUserForSelect'
            }),
            grid,
            users = [], //设置用户数据
            columns = []; //设置表格的列
     
    //定义方法区域
    var init = function() {
            setGridColumns();
            //设置表格具体框架信息
            grid = new Grid.Grid({
                render: '#grid',
                width: '100%', //这个属性一定要设置
                columns: columns,
                store: store
            });

            store.load(null, loadDataCallBack);
        },
        //返回数据后进行的callback操作
        loadDataCallBack = function(data) {
            users = data;
            grid.render();
        },
        getRoleInfo = function(role) {
            return role.Name;
        },
        setDateFormat = function(date) {
            return formatDate(date);
        },
        getProjects = function(projects) {
            var tmpStr = "";
            for (var i = 0; i < projects.length; i++) {
                tmpStr += projects[i].Name + ",";
            }
            return tmpStr.substring(0, tmpStr.length - 1);
        },
        setGridColumns = function() {
            columns = [
                {
                    title: 'Name',
                    dataIndex: 'Name',
                    width: '10%'
                },
                {
                    title: 'Role',
                    dataIndex: 'Role',
                    renderer: getRoleInfo,
                    width: '5%'
                },
                {
                    title: 'CreateDate',
                    dataIndex: 'CreateDate',
                    renderer: setDateFormat,
                    width: '10%'
                },
                {
                    title: 'Projects',
                    dataIndex: 'Project',
                    renderer: getProjects,
                    width: '20%'
                },
                {
                    title: 'Operation',
                    dataIndex: 'UserId',
                    renderer: function(userId) {
                        return "<span class='btn btn-success'><i class='icon-zoom-in icon-white'></i>View</span>" +
                            "<span class='btn btn-info' onclick='EditUser('" + userId + "')'><i class='icon-edit icon-white'></i>Edit</span>" +
                            "<span class='btn btn-danger' onclick='DelUser('" + userId + "')'><i class='icon-trash icon-white'></i>Delete</span>";
                    }
                }
            ];
        };

    //调用方法区域
    init();

})(BUI);
