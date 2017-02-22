

var app = angular.module('MyApp', ['toaster','angularMoment', 'ngAnimate']);





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

app.controller('medalsController', function ($scope, crudMedals, toaster, moment) {
  
    
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
                $scope.Medallas = {};
                $scope.Medallas.Stats = {};
                $scope.noencontrado = false;
                toaster.pop('success', result.lastindexgame, result.lastindexgame);
                $scope.Hoy = moment();
                for (var att in result) {
                    if (result.hasOwnProperty(att)) {
                        if (result[att] != null) {
                            if (result[att].toString().substring(0,5) === "/Date") {

                                var fecha = moment(new Date(parseInt(result[att].substr(6))));
                                if (moment(fecha).isBefore(moment()))
                                    {
                                    result[att] = moment();
                                $scope.Medallas.Stats[att] = result[att];
                                }
                                } else {
                                $scope.Medallas[att] = result[att];
                            }
                        } else {
                            $scope.Medallas.Stats[att] = result[att];
                        }
                    }
                }
                
                  
                    //if (result.asesino != null) {
                    //    var fecha = moment(new Date(parseInt(result.asesino.substr(6))));
                    //    if (moment(fecha).isBefore(moment()))
                    //        $scope.Medallas.asesino = moment();
                    //}


                    //if (result.pentakill != null)
                    //{
                    //    var fecha = moment(new Date(parseInt(result.pentakill.substr(6))));
                    //    if (moment(fecha).isBefore(moment()))
                    //        $scope.Medallas.pentakill = moment();
                    //}

              
                $scope.loading = false;
              
            }
           
        }).finally(function () {
            // called no matter success or failure
         
            $scope.loading = false;
        });;
    };

   
     
});
