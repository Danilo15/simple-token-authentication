(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', main);

    function main($scope, $http) {
        $scope.token = '00000000-0000-0000-0000-000000000000';
        $scope.gerarToken = function () {
            $http.get('http://localhost:49963/TokenService.svc/GenerateToken/').then(function (response) {
                var data = response.data;
                $scope.token = data.Token.toUpperCase();
                $scope.expire = 'O token expira em: ' + data.TokenExpire;
            })
        }

        var getProdutcsURL = 'http://localhost:60861/api/Product/GetProducts';

        var errorFunc = function (data) {
            var texto = data.statusText;
            alert(texto);
        }

        var montarGrid = function (data) {
            $('.grid').css('display', 'block');
            $scope.products = data;
        }

        $scope.buscarProdutosAJAX = function () {
            $.ajax({
                url: getProdutcsURL,
                headers: {
                    'token': $scope.token
                },
                method: 'GET',
                crossDomain: true,
                success: function (data) {
                    montarGrid(data);
                },
                error: function (data) {
                    errorFunc(data);
                }
            })
        }

        $scope.buscarProdutosMVC = function () {
            $http({
                method: 'GET',
                url: getProdutcsURL,
                headers: {
                    'token': $scope.token
                }
            }).then(function successCallback(data) {
                montarGrid(data.data);
            }, function errorCallback(data) {
                errorFunc(data);
            });
        }
    }

})();