import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BasicInformationRoutingModule } from './basic-information-routing.module';
import { CategoryComponent } from './components/category/category.component';
import { AdminPanelModule } from '../admin-panel.module';
import { DxDataGridModule } from 'devextreme-angular';


@NgModule({
  declarations: [CategoryComponent],
  imports: [
    CommonModule,
    AdminPanelModule ,
    BasicInformationRoutingModule,
    DxDataGridModule 
  ]
})
export class BasicInformationModule { }
