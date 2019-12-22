"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var environment_1 = require("../../environments/environment");
var HttpService = /** @class */ (function () {
    function HttpService(http, baseMethod) {
        this.http = http;
        this.baseUrl = environment_1.environment.apiUrl + baseMethod;
    }
    HttpService.prototype.getText = function (path) {
        if (path === void 0) { path = ''; }
        return this.http
            .get(this.baseUrl + path, { 'responseType': "text" });
    };
    HttpService.prototype.get = function (path, shared) {
        if (path === void 0) { path = ''; }
        if (shared === void 0) { shared = false; }
        return this.http.get(this.baseUrl + path);
    };
    HttpService.prototype.getById = function (id, path) {
        if (path === void 0) { path = ''; }
        return this.http.get(this.baseUrl + path + id);
    };
    HttpService.prototype.delete = function (id) {
        var request = this.http.delete(this.baseUrl + id);
        return request;
    };
    HttpService.prototype.put = function (id, payload) {
        return this.http
            .put(this.baseUrl + id, payload);
    };
    HttpService.prototype.putWithPath = function (id, path) {
        if (path === void 0) { path = ''; }
        return this.http
            .put(this.baseUrl + path + id, null);
    };
    HttpService.prototype.putWithPathAndPayload = function (id, path, payload) {
        if (path === void 0) { path = ''; }
        return this.http
            .put(this.baseUrl + path + id, payload);
    };
    HttpService.prototype.post = function (payload, path) {
        if (path === void 0) { path = ''; }
        return this.http
            .post(this.baseUrl + path, payload);
    };
    return HttpService;
}());
exports.HttpService = HttpService;
//# sourceMappingURL=httpService.js.map