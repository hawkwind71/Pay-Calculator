"use strict";
app.service('httpService', ['$q', '$resource',
function ($q, $resource) {
    this.HttpResource = function (route) {
        return $resource(route, { id: '@id' }, { update: { method: 'PUT' }, query: { method: 'POST'} });
    }
}]);
