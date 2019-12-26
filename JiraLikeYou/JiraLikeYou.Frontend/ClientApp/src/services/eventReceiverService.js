"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var signalr_1 = require("@microsoft/signalr");
var EventService = /** @class */ (function () {
    function EventService() {
        this.messageReceived = new core_1.EventEmitter();
        this.connectionEstablished = new core_1.EventEmitter();
        this.connectionIsEstablished = false;
        this.createConnection();
        this.registerOnServerEvents();
        this.startConnection();
    }
    EventService.prototype.createConnection = function () {
        this._hubConnection = new signalr_1.HubConnectionBuilder()
            .configureLogging(signalr_1.LogLevel.Debug)
            .withUrl('http://localhost:52000/occasionHub')
            .build();
    };
    EventService.prototype.startConnection = function () {
        var _this = this;
        this._hubConnection
            .start()
            .then(function () {
            _this.connectionIsEstablished = true;
            console.log('Hub connection started');
            _this.connectionEstablished.emit(true);
        })
            .catch(function (err) {
            console.log('Error while establishing connection, retrying...');
            setTimeout(function () { this.startConnection(); }, 5000);
        });
    };
    EventService.prototype.registerOnServerEvents = function () {
        var _this = this;
        this._hubConnection.on('Send', function (data) {
            _this.messageReceived.emit(data);
        });
    };
    return EventService;
}());
exports.EventService = EventService;
//# sourceMappingURL=eventReceiverService.js.map