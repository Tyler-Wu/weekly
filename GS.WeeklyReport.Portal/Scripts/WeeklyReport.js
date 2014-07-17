/// <reference path="../Views/Shared/_CalendarDialogViewPage.cshtml" />
$(document).ready(function() {
    initProjectList();
    

    var settings = {
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        events: [],
        firstDay: 1,
        editable: true,
        droppable: true, // this allows things to be dropped onto the calendar !!!,
        monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
        monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
        dayNames: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
        dayNamesShort: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
        allDaySlot: false, //all-day��Ϣɾ��
        slotMinutes: 30,
        minTime: 7,
        maxTime: 19,
        firstHour: 7,
        axisFormat: 'h(:mm)tt',
        //把calendar拖进时间表事件
        drop: function(date, allDay, ui) { // this function is called when something is dropped
            var bgcolor;
            if ($.browser.msie) {
                bgcolor = this.currentStyle.backgroundColor;
            } else if ($.browser.safari) {
                bgcolor = getComputedStyle(this, false).backgroundColor;
            } else if ($.browser.mozilla) {
                bgcolor = this.currentStyle.backgroundColor;
            } else if ($.browser.opera) {
                bgcolor = this.currentStyle.backgroundColor;
            } else {
                alert("i don't konw this browser!");
            }
            //var bgcolor = this.currentStyle.backgroundColor;
            // retrieve the dropped element's stored Event Object
            var originalEventObject = $(this).data('eventObject');
            var tempDate = new Date(date);
            // we need to copy it, so that multiple events don't have a reference to the same object
            var copiedEventObject = $.extend({}, originalEventObject);
            copiedEventObject.workItemId = '00000000-0000-0000-0000-000000000000';
            copiedEventObject.title = this.outerText;
            // assign it the date that was reported 
            copiedEventObject.id = guid();
            copiedEventObject.start = date;
            copiedEventObject.end = new Date(tempDate.setHours(tempDate.getHours() + 1));
            copiedEventObject.allDay = allDay;
            copiedEventObject.color = bgcolor;

            // render the event on the calendar
            // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
            $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);


            console.log("data:{"
                + "start :" + copiedEventObject.start + ",End:" + copiedEventObject.end + "}"
            );


            //当项目被拖进时间表的时候应该先添加进数据库
            var durationTime = (copiedEventObject.end - copiedEventObject.start) / (3600 * 1000);
            var workItem = getWorkItemFromEvent(copiedEventObject) //通过event得到workItem
            var addWorkItemCallBack = function(response) {
                if (response && response != "fail") {
                    copiedEventObject.workItemId = response; //成功的话会返回一个workItemId
                } else {
                    alert("fail to add the workItem");
                }
            };
            addWorkItem(workItem, addWorkItemCallBack);
            // is the "remove after drop" checkbox checked?
            if ($('#drop-remove').is(':checked')) {
                // if so, remove the element from the "Draggable Events" list
                $(this).remove();
            }

        },
        //event: function (event, element) {
        //    $('#deleteThisShedule').click(function () {
        //        $('#calendar').fullCalendar('removeEvents', event.id);
        //        $.fancybox.close();
        //    });
        //},
        //上下拖动calendar事件
        eventDrop: function(event) {
            var a = $('#calendar').fullCalendar('formatDate', event.start, "yyyy-MM-dd HH:mm:ss");
            var b;
            if (event.end != null || event.end != undefined) {
                b = $('#calendar').fullCalendar('formatDate', event.end, "yyyy-MM-dd HH:mm:ss");
            }
            console.log("data:{"
                + "start :" + a + ",End:" + b + "}"
            );
            var workItem = getWorkItemFromEvent(event);
            updateWorkItem(workItem, function(data) {
                if (data == "fail") {
                    alert("fail to update this WorkItem!!");
                }
            });
        },
        //calendar下拉事件
        eventResize: function(event, dayDelta, minuteDelta, allDay, revertFunc, jsEvent, ui, view) {
            var workItem = getWorkItemFromEvent(event) //通过event得到workItem
            console.log('Start: ' + event.start.getTime() / 1000);
            console.log('End: ' + event.end.getTime() / 1000);
            updateWorkItem(workItem, function(data) {
                if (data == "fail") {
                    alert("fail to update this WorkItem!!");
                }
            });
        },
        eventClick: function(event, element) {
            var startTime = event.start.getTime() / 1000,
                endTime = event.end.getTime() / 1000,
                durationTime = (event.end - event.start) / (3600 * 1000);

            $.fancybox({
                width: 520,
                height: 300,
                autoScale: false,
                scrolling: 'no',
                autoDimensions: false,
                href: '../CalendarDialog/CalendarDialog?id=' + event.workItemId+'&backgroundColor=' + event.color+'&dtStamp='+new Date().getTime()//加个时间戳防止浏览器缓存问题
            });
            console.log(typeof event);
        },
        eventMouseover: function(event) {

        }
    };
    initWorkItemList(function (workItems) {
        //初始化颜色
        for (var index in workItems) {
            workItems[index].color = workItems[index].color.getColor();
        }
        settings.events = workItems;
        $('#calendar').fullCalendar(settings);
    });
});
function getLocalTime(nS) {
    return new Date(parseInt(nS) * 1000).toLocaleString().replace(/:\d{1,2}$/, ' ');
}
//通过event得到workItem
function getWorkItemFromEvent(event) {
    var durationTime = (event.end - event.start) / (3600 * 1000);
    return {
        'calendarId': event.id, //event.id,
        'title': event.title,
        'itemId': event.workItemId,
        'projectName': event.title,
        'start': (event.start.getTime() / 1000),
        'end': (event.end.getTime() / 1000),
        'duration': durationTime,
        'color': event.backgroundColor,
        'allDay': event.allDay,
        'projectId': event.project.ProjectId //?allDay是什么东西？
    };
}
//更新workItem的函数
function updateWorkItem(workItem, callback) {
    $.ajax({
        url: '/Calendar/UpdateWorkItem',
        type: 'Post',
        data: workItem,
        success: function (response) {
            callback(response);
        },
        error: function (msg) {
            //  revertFunc();
        },
    });
}
//添加workItem的函数
function addWorkItem(workItem, callback) {
    $.ajax({
        url: '/Calendar/AddWorkItem',
        type: 'Post',
        data: workItem,
        success: function (response) {
            callback(response);
        },
        error: function (msg) {
            //  revertFunc();
        },
    });
}
//初始化项目列表
function initProjectList() {
    $.get("/Calendar/GetProjectList", function (result) {
        if (result) {
            var eventObj = [];
            console.log(result);
            for (var i = 0; i < result.length; i++) {
                $("#external-events ul#example").append('<li><div class="external-event badge badge-inverse ui-draggable" style="position: relative;background:' + result[i].Color.getColor() + '">' + result[i].Name + '</div></li>');
                eventObj.push(result[i]);
            }
            $('#external-events div.external-event').each(function (index) {

                // it doesn't need to have a start or end
                var eventObject = {
                    title: $.trim($(this).text()), // use the element's text as the event title
                    project: eventObj[index],//把项目对象加入eventObject中
                };

                // store the Event Object in the DOM element so we can get to it later
                $(this).data('eventObject', eventObject);

                // make the event draggable using jQuery UI
                $(this).draggable({
                    zIndex: 999,
                    revert: true,      // will cause the event to go back to its
                    revertDuration: 0  //  original position after the drag
                });

            });
        }
    });
}
//找到workItem列表
function initWorkItemList(callback) {
    $.get("/Calendar/GetWorkItemList", function (result) {
        if (result) {
            callback(result);
        }
    });
}
function guid() {
    var temp = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        temp += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
            temp += "-";
    }
    return temp;
};
// by zhangxinxu welcome to visit my personal website http://www.zhangxinxu.com/
// 2010-03-12 v1.0.0
//十六进制颜色值域RGB格式颜色值之间的相互转换

//-------------------------------------
//十六进制颜色值的正则表达式
var reg = /^#([0-9a-fA-f]{3}|[0-9a-fA-f]{6})$/;
/*RGB颜色转换为16进制*/
String.prototype.colorHex = function () {
    var that = this;
    if (/^(rgb|RGB)/.test(that)) {
        var aColor = that.replace(/(?:\(|\)|rgb|RGB)*/g, "").split(",");
        var strHex = "#";
        for (var i = 0; i < aColor.length; i++) {
            var hex = Number(aColor[i]).toString(16);
            if (hex === "0") {
                hex += hex;
            }
            strHex += hex;
        }
        if (strHex.length !== 7) {
            strHex = that;
        }
        return strHex;
    } else if (reg.test(that)) {
        var aNum = that.replace(/#/, "").split("");
        if (aNum.length === 6) {
            return that;
        } else if (aNum.length === 3) {
            var numHex = "#";
            for (var i = 0; i < aNum.length; i += 1) {
                numHex += (aNum[i] + aNum[i]);
            }
            return numHex;
        }
    } else {
        return that;
    }
};

//-------------------------------------------------

/*16进制颜色转为RGB格式*/
String.prototype.colorRgb = function () {
    var sColor = this.toLowerCase();
    if (sColor && reg.test(sColor)) {
        if (sColor.length === 4) {
            var sColorNew = "#";
            for (var i = 1; i < 4; i += 1) {
                sColorNew += sColor.slice(i, i + 1).concat(sColor.slice(i, i + 1));
            }
            sColor = sColorNew;
        }
        //处理六位的颜色值
        var sColorChange = [];
        for (var i = 1; i < 7; i += 2) {
            sColorChange.push(parseInt("0x" + sColor.slice(i, i + 2)));
        }
        return "RGB(" + sColorChange.join(",") + ")";
    } else {
        return sColor;
    }
};
//initialize the calendar

String.prototype.getColor = function () {
    var colorNum = parseInt(this,10);
    switch(colorNum){
        case 1: return 'red';
        case 2: return 'green';
        case 3: return 'yellow';
        case 4: return 'blue';
        case 5: return 'purple';
        case 6: return 'pink';
        case 7: return 'orange';
        case 8: return 'grey';
        case 9: return 'brown';
        default: return 'black';
    };
}
