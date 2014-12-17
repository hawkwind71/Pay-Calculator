"use strict";
var app = angular.module(
    "payslipApp",
    [
        'ngResource'
    ]);

app.constant('Settings', {
    serverBaseUri: "http://localhost:62658/"
});

app.controller('mainController', ['$scope', 'httpService', 'Settings',
    function ($scope, httpService, Settings) {
        $scope.payslip = null;
        $scope.months = [
                    { name: 'January', value: 1 },
                    { name: 'February', value: 2 },
                    { name: 'March', value: 3 },
                    { name: 'April', value: 4 },
                    { name: 'May', value: 5 },
                    { name: 'June', value: 6 },
                    { name: 'July', value: 7 },
                    { name: 'August', value: 8 },
                    { name: 'September', value: 9 },
                    { name: 'October', value: 10 },
                    { name: 'November', value: 11 },
                    { name: 'December', value: 12 }
        ];

        var dt = new Date();
        // year choices start from 2 years ago
        $scope.years = [
            dt.getFullYear() - 2,
            dt.getFullYear() - 1,
            dt.getFullYear()
        ];

            $scope.calc = function () {
            var data = $scope.item;
            var result = httpService.HttpResource(Settings.serverBaseUri + "api/payment/get").query(data , function () {
                $scope.payslip = result;
            });
        };
    }]);