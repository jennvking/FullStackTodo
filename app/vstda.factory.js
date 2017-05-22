(function () {
    'use strict';

    angular
        .module('toDoList')
        .factory('vstdaFactory', vstdaFactory);

    vstdaFactory.$inject = ['$http'];
    function vstdaFactory($http) {
        var service = {
            keepTask: keepTask
        };

        return service;

        ////////////////
        function keepTask(object) {

            return $http({
                method: "POST",
                url: 'http://localhost:49840/api/VstdoModels',
                data: object,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }
            })
                .then(function success (response) {
                    return response;
                }, function err (error) {
                    return error;
                });
        }
    }
})();
