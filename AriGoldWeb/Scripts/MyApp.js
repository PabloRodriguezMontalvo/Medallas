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
    crudUserObj.GetDatosBD = function (num_invocador) {
        var notificaciones;

        notificaciones = $http({ method: 'Get', url: '/Home/GetUserInBD/', params: { num_invocador: num_invocador } }).
        then(function (response) {
            if (response.data === "") {
               
                return ""; 

            } else {
                 
                return response.data;
               
            }
        });
      
        return notificaciones;
    };
    crudUserObj.GetNews = function (server, nombre) {
        var Users;

        Users = $http({ method: 'Get', url: '/Home/GetNews/', params: { server: server, nombre: nombre } }).
        then(function (response) {
                if (response.data === "") {
               
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
        crudMedals.GetNews(server, nombre).then(function (result) {

            if (result === "") {
                toaster.pop('error', "No se ha encontrado", "ni una puta mierda");
                $scope.noencontrado = true;
            } else {
                $scope.Medallas = result;
                $scope.noencontrado = false;
                toaster.pop('success', $scope.Medallas.lastindexgame, $scope.Medallas.lastindexgame);

            
          
            $scope.loading = false;  
            }
           
        }).finally(function () {
            // called no matter success or failure
         
            $scope.loading = false;
        });;
    };

   
     
});
