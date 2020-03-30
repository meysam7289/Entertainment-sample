import { Component, OnInit } from '@angular/core';
import { faBars , faThumbtack } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  faBars = faBars;
  faThumbtack = faThumbtack;
  pinActive=true;
  constructor() { }

  ngOnInit() {
  }
  sidebarToggle(wrapper:HTMLDivElement){
    if(!this.pinActive){
      wrapper.classList.toggle("toggled");
    }
  }

  pinSidebar(){
    this.pinActive=!this.pinActive;
  }
}
