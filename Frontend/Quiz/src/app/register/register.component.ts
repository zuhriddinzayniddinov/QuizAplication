import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Role } from './Roles';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  roles: Role[] = [
    {value: 1, viewValue: 'User'},
    {value: 2, viewValue: 'Worker'},
    {value: 3, viewValue: 'Maker'},
    {value: 4, viewValue: 'Admin'},
  ];
  registerForm;
  constructor(private fb: FormBuilder,private auth:AuthService) {
    this.registerForm = this.fb.group({
      name: ['',Validators.required],
      email: ['',Validators.required],
      password: ['',Validators.required],
      role:[1,Validators.required]
    });
  }
  register(){
    this.auth.register(this.registerForm.value)
  }
}
