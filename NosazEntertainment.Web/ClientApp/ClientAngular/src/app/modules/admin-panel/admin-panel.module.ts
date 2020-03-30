import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminPanelRoutingModule } from './admin-panel-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { SidebarMenuComponent } from './components/sidebar-menu/sidebar-menu.component';
import { NavbarMenuComponent } from './components/navbar-menu/navbar-menu.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [DashboardComponent, AdminPanelComponent, SidebarMenuComponent, NavbarMenuComponent],
  imports: [
    CommonModule,
    FontAwesomeModule ,
    AdminPanelRoutingModule
  ]
})
export class AdminPanelModule { }
