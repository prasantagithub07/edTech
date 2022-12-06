import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { UserLayoutComponent } from './shared/user-layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CoursesComponent } from './courses/courses.component';
import { OrderComponent } from './order/order.component';
import { OrdersComponent } from './orders/orders.component';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    UserLayoutComponent,
    DashboardComponent,
    CoursesComponent,
    OrderComponent,
    OrdersComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
