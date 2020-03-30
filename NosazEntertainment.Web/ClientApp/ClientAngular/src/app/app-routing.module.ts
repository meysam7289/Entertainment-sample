import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';


const routes: Routes = [
{
  path:'admin-panel',
  loadChildren: './modules/admin-panel/admin-panel.module#AdminPanelModule'
},
{
  path:'',
  redirectTo:'admin-panel',
  pathMatch:'full'
},
{
  path:'not-found',
  component:NotFoundComponent
},
{
  path:'**',
  redirectTo:'not-found'
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
