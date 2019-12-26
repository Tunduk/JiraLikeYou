import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/eventReceiverService';
import { JiraEventDto } from '../../services/hubModels/jiraEventDto';
import { HistoryApiDto } from '../../services/api/historyApiDto';
import { HistoryService } from '../../services/api/history.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent implements OnInit {
  public jiraEvent: JiraEventDto;
  public historyInfo: HistoryApiDto[];
  ngOnInit(): void {
    this.eventService.messageReceived.subscribe(x => {
    this.jiraEvent = x as JiraEventDto;
      console.log(x);
      let audio = new Audio();
      audio.src = 'https://pro-sound.org/uploads/tracks/icq/Sound_05952.mp3';
      audio.load();
      audio.play();
      this.historyService.getLastHistory().subscribe(x => { x.reverse();this.historyInfo =x ; console.log(x); });
    });
  }
  constructor(private eventService: EventService, private historyService: HistoryService) {

  }
}
