// project import
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../../../services/auth.service';
import Swal from 'sweetalert2';
import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-auth-login',
  standalone: true,
  imports: [RouterModule,ReactiveFormsModule,CommonModule],
  templateUrl: './auth-login.component.html',
  styleUrl: './auth-login.component.scss'
})
export class AuthLoginComponent {
  isLoading = false;
  loginForm: FormGroup;

  constructor(private authService: AuthService) {
    this.loginForm= new FormGroup({
      userNameV: new FormControl('',[Validators.required]),
      PasswordV: new FormControl('',[Validators.required]),
    })
  }
  
  username: string = '';
  password: string = '';

  login() {
    this.isLoading = true;  
    console.log(this.loginForm.controls);
    console.log('Form Value:', this.loginForm.value);
    if (this.loginForm.valid) {
      const { userNameV, PasswordV } = this.loginForm.value;
      this.authService.login(userNameV, PasswordV).subscribe(
        (response) => {
          this.isLoading = false;
          Swal.fire({
            title: 'Welcome!',
            text: `${response.username}`,
            icon: 'success',
          });
        },
        (error) => {
          this.isLoading = false;
          Swal.fire({
            title: 'Error',
            text: `${error.error}`,
            icon: 'error',
          });
        }
      );
    }else{
      this.isLoading = false;
      const { userNameV, PasswordV } = this.loginForm.value;
      console.log("1111111111111111111111111111111111111111111111111111111111111"+userNameV.value);
    }
  }
}
