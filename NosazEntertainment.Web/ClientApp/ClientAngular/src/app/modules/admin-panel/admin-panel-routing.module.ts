import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';


const routes: Routes = [
  {
    path: '',
    component: AdminPanelComponent,
    children:[
      {
        path:'basic-information',
        loadChildren: './basic-information/basic-information.module#BasicInformationModule'
      },
      {
        path:'dashboard',
        component:DashboardComponent
      },
    ]
  },
{
  path:'**',
  redirectTo:'not-found'

}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminPanelRoutingModule { }
