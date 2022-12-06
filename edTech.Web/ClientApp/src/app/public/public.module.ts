import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing.module';
import { FullsizeLayoutComponent } from './shared/fullsize-layout.component';
import { LayoutComponent } from './shared/layout.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { CourselistComponent } from './shared/courselist/courselist.component';
import { CartComponent } from './cart/cart.component';
import { CourseComponent } from './course/course.component';
import { CoursesComponent } from './courses/courses.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { PaymentComponent } from './payment/payment.component';
import { ReceiptComponent } from './receipt/receipt.component';
import { SignupComponent } from './signup/signup.component';
import { UnauthorizeComponent } from './unauthorize/unauthorize.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    FullsizeLayoutComponent,
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    CourselistComponent,
    CartComponent,
    CourseComponent,
    CoursesComponent,
    HomeComponent,
    LoginComponent,
    NotfoundComponent,
    PaymentComponent,
    ReceiptComponent,
    SignupComponent,
    UnauthorizeComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    ReactiveFormsModule
  ]
})
export class PublicModule { }
