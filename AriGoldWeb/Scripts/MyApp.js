var app = angular.module('MyApp', ['toaster', 'ngAnimate']);

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
    crudUserObj.GetNotificacions = function (num_invocador) {
        var notificaciones;

        notificaciones = $http({ method: 'Get', url: '/Home/LeerNotificaciones/', params: { num_invocador: num_invocador } }).
        then(function (response) {
            if (response.data == "") {
               
                return ""; 

            } else {
                 
                return response.data;
               
            }
        });
      
        return notificaciones;
    };
    crudUserObj.GetDatosInvocador = function (server, nombre) {
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

app.controller('medalsController', function ($scope, crudMedals, toaster) {
  
    
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

    $scope.server = $scope.servers[0];

  
    $scope.GetDatosInvocador = function (server, nombre) {
        $scope.loading = true;
        crudMedals.GetDatosInvocador(server, nombre).then(function (result) {
            crudMedals.GetNotificacions(result.num_invocador).then(function (result) {
                $scope.notificaciones = result;
            });
            $scope.bronze = false;
            $scope.silver = false;
            $scope.gold = false;
            $scope.platinum = false;
            $scope.diamond = false;
            if (result == "") {
                toaster.pop('error', "No se ha encontrado", "ni una puta mierda");
                $scope.noencontrado = true;
            } else {
                $scope.noencontrado = false;
                toaster.pop('success', "OH YEAH", "BABY");
                if (result.doble_doble == true) {
                    $scope.doble_doble = true;
                }
                if (result.pentakill == true) {
                    $scope.doble_doble = true;
                }
               if (result.division == 'Bronze') {
                $scope.bronze = true;
                $scope.silver = false;
                $scope.gold = false;
                $scope.platinum = false;
                $scope.diamond = false;

            }
            if (result.division == 'Silver') {
                $scope.bronze = false;
                $scope.silver = true;
                $scope.gold = false;
                $scope.platinum = false;
                $scope.diamond = false;
            }
            if (result.division == 'Gold') {
                $scope.bronze = false;
                $scope.silver = false;
                $scope.gold = true;
                $scope.platinum = false;
                $scope.diamond = false;
            }
            if (result.division == 'Platinum') {
                $scope.bronze = false;
                $scope.silver = false;
                $scope.gold = false;
                $scope.platinum = true;
                $scope.diamond = false;
            }
            if (result.division == 'Diamond') {
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
