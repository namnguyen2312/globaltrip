(function (app) {
    app.filter('filterBoolText', function () {
        return function (input) {
            if (input == true)
                return 'Mở';
            else
                return 'Đóng';
        }
    });

    app.filter('filterBoolClass', function () {
        return function (input) {
            if (input == true)
                return 'badge bg-green';
            else
                return 'badge bg-yellow';
        }
    });

    app.filter('showOrderStatus', function () {
        return function (input) {
            var textClass = "";
            switch (input) {
                case 1:
                    textClass = "badge bg-green";
                    break;
                case 2:
                    textClass = "badge bg-yellow";
                    break;
                case 3:
                    textClass = "badge bg-light-blue";
                    break;
                case 4:
                    textClass = "badge bg-red";
                    break;
                default:
                    textClass = "badge bg-red";
            }
            return textClass;
        }
    });

    app.filter('showPurchaseOrderStatus', function () {
        return function (input) {
            var textClass = "";
            switch (input) {
                case 1:
                    textClass = "badge bg-green";
                    break;
                case 2:
                    textClass = "badge bg-green";
                    break;
                case 3:
                    textClass = "badge bg-yellow";
                    break;
                case 4:
                    textClass = "badge bg-light-blue";
                    break;
                case 7:
                    textClass = "badge bg-light-blue";
                    break;
                default:
                    textClass = "badge bg-red";
            }
            return textClass;
        }
    });

    app.filter('numberFixedLen', function () {
        return function (n, len) {
            var num = parseInt(n, 10);
            len = parseInt(len, 10);
            if (isNaN(num) || isNaN(len)) {
                return n;
            }
            num = '' + num;
            while (num.length < len) {
                num = '0' + num;
            }
            return num;
        };
    });

})(angular.module('nbtapp.common'));