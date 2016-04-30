(function () {
    'use strict';

    angular
        .module('linterestapp')
        .factory('linfactory', factory);

    factory.$inject = ['$http'];

    function factory($http) {
        var service = {
            getAllLins: getAllLins,
            saveLin: saveLin
        };

        return service;

        function getAllLins() {
            return $http.get('/lins/ShowAllUserPins');

        }

        function saveLin(newlin) {
            console.log('factory saved lin')
            return $http.post('/lins/SaveLin', newlin);

        }
    }
})();