(function () {
    'use strict';

    angular
        .module('linterestapp')
        .controller('LinsController', LinsController);

    LinsController.$inject = ['$scope', 'linfactory'];

    function LinsController($scope, linfactory) {
        /* jshint validthis:true */
        //var vm = this;
        $scope.title = 'LinsController';

        activate();

        $scope.saveLin = function () {
            console.log('called controller saveLin()');
            var newlin = { ImageUrl: $scope.newLin.ImageUrl, Text: $scope.newLin.Text, PinImageUrl: $scope.newLin.PinImageUrl };
            linfactory.saveLin(newlin).then(function (res) {

                $scope.newLin.ImageUrl = "";
                $scope.newLin.Description = "";
                $scope.newLin.PinImageUrl = "";

                $scope.Lins.push(res.data);
            });
        }



        function activate() {
            linfactory.getAllLins().then(function (res) {
                console.log(res.data);
                $scope.Lins = res.data;
            });
        }
    }
})();
