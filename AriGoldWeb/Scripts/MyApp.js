var app = angular.module('MyApp', ['ui.bootstrap']);

app.factory('crudMedals', function ($http) {
    crudUserObj = {};

    crudUserObj.getAll = function () {
        var Users;

        Users = $http({ method: 'Get', url: '/Home/GetAll' }).
        then(function (response) {
            return response.data;
        });

        return Users;
    };

    crudUserObj.GetDatosInvocador = function (server,nombre) {
        var Users;

        Users = $http({ method: 'Get', url: '/Home/GetDatos/', params: { server: server, nombre: nombre } }).
        then(function (response) {
                if (response.data == "") {
                    return ""; 
                } else {
                 return response.data;
                  
                }
            });
      
        return Users;
    };

   

    return crudUserObj;
});

app.controller('medalsController', function ($scope, crudMedals) {

    //crudMedals.getAll().then(function (result) {
    //    $scope.Users = result;
    //});
    $scope.servers = {};

    $scope.servers = [{
        value: '0',
        label: 'EUW'
    }, {
        value: '1',
        label: 'NA'
    }, {
        value: '2',
        label: 'EUNE'
    }, {
        value: '3',
        label: 'KR'
    }, {
        value: '4',
        label: 'OCE'
    }, {
        value: '5',
        label: 'LAN'
    }, {
    value: '6',
    label: 'LAS'
    }];

    $scope.server = $scope.servers[0] ;
    $scope.GetDatosInvocador = function (server, nombre) {
        $scope.loading = true;
        crudMedals.GetDatosInvocador(server, nombre).then(function (result) {
            $scope.bronze = false;
            $scope.silver = false;
            $scope.gold = false;
            $scope.platinum = false;
            $scope.diamond = false;
            if (result == "") {
                $scope.noencontrado = true;
            } else {
                $scope.noencontrado = false;
               if (result.division == '"BRONZE"') {
                $scope.bronze = true;
                $scope.silver = false;
                $scope.gold = false;
                $scope.platinum = false;
                $scope.diamond = false;

            }
            if (result.division == '"SILVER"') {
                $scope.bronze = false;
                $scope.silver = true;
                $scope.gold = false;
                $scope.platinum = false;
                $scope.diamond = false;
            }
            if (result.division == '"GOLD"') {
                $scope.bronze = false;
                $scope.silver = false;
                $scope.gold = true;
                $scope.platinum = false;
                $scope.diamond = false;
            }
            if (result.division == '"PLATINUM"') {
                $scope.bronze = false;
                $scope.silver = false;
                $scope.gold = false;
                $scope.platinum = true;
                $scope.diamond = false;
            }
            if (result.division == '"DIAMOND"') {
                $scope.bronze = false;
                $scope.silver = false;
                $scope.gold = false;
                $scope.platinum = false;
                $scope.diamond = true;
            }
            $scope.Medallas = result;
            $scope.loading = false;  
            }
           
        }).finally(function () {
            // called no matter success or failure
            $scope.loading = false;
        });;
    };

   
     
});
