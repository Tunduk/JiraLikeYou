import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/eventReceiverService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public data: string;
  ngOnInit(): void {

    this.eventService.messageReceived.subscribe(x => { this.data = x.mainMessage; console.log(x) });
    }
  constructor(private eventService:EventService) {

  }
}
