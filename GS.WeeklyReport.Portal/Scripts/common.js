
//根据给定的时间字符串以及要转换的格式返回给定格式的时间字符串
    var formatDate = function(date, format) {
        var newDate = new Date(Date.parse(date));
        if (typeof format == "undefined") {
            return newDate.toLocaleDateString();
        }
        switch (format.toUpperCase()) {
        case 'UTC':
            return newDate.toUTCString();
        case 'TIME':
            return newDate.toTimeString();
        case 'LOCAL':
            return newDate.toLocaleDateString();
        default:
            return newDate.toLocaleDateString();
        }
    };
