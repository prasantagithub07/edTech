import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    {path: 'admin' , loadChildren: () => import('./admin/admin.module').then(m=> m.AdminModule)},
    {path: 'user', loadChildren:() => import('./user/user.module').then(m=> m.UserModule)},
    {path: '', loadChildren:() => import('./public/public.module').then(m=> m.PublicModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
