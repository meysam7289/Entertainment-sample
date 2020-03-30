import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'sidebar-menu',
  templateUrl: './sidebar-menu.component.html',
  styleUrls: ['./sidebar-menu.component.css']
})
export class SidebarMenuComponent implements OnInit {
  isCollapsed=false;
  constructor() { }

  ngOnInit() {
  }

  sidebarToggle(){
    
  }
}
