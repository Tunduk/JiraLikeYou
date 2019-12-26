"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var httpService_1 = require("./httpService");
var HistoryService = /** @class */ (function (_super) {
    __extends(HistoryService, _super);
    function HistoryService(http) {
        return _super.call(this, http, "Occasion") || this;
    }
    HistoryService.prototype.getLastHistory = function () {
        return this.get();
    };
    return HistoryService;
}(httpService_1.HttpService));
exports.HistoryService = HistoryService;
//# sourceMappingURL=history.service.js.map