import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import {  Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  userForm: FormGroup;
  constructor(public fb: FormBuilder, private authService: AuthService, private router: Router) { 
    this.userForm = this.fb.group({
      name: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]],
      confirmPassword: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  userSignUp(){
    console.log(this.userForm);
    if(this.userForm.valid){
      this.authService.UserSignUp(this.userForm.value).subscribe(res => {
        if(res.status == 201){
          this.router.navigate(['/login']);
        }
      });
    }
  }
}
