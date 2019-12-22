import { EventEmitter, Injectable } from '@angular/core';  
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';  
import { JiraEventDto } from './hubModels/jiraEventDto';

  

export class EventService {
  messageReceived = new EventEmitter<JiraEventDto>();  
  connectionEstablished = new EventEmitter<Boolean>();  
  
  private connectionIsEstablished = false;  
  private _hubConnection: HubConnection;  
  
  constructor() {  
    this.createConnection();  
    this.registerOnServerEvents();  
    this.startConnection();  
  }  
  
  private createConnection() {  
    this._hubConnection = new HubConnectionBuilder()
      .configureLogging(LogLevel.Debug)
    
      .withUrl('http://localhost:52000/jiraHub')  
      .build();  
  }  
  
  private startConnection(): void {  
    this._hubConnection  
      .start()  
      .then(() => {  
        this.connectionIsEstablished = true;  
        console.log('Hub connection started');  
        this.connectionEstablished.emit(true);  
      })  
      .catch(err => {  
        console.log('Error while establishing connection, retrying...');  
        setTimeout(function () { this.startConnection(); }, 5000);  
      });  
  }  
  
  private registerOnServerEvents(): void {  
    this._hubConnection.on('NewJiraEvent', (data: any) => {  
      this.messageReceived.emit(data);  
    });  
  }  
}    
