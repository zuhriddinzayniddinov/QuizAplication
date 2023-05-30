import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import { User } from '../user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  chek = false;
  registerForm;
  user: any;
  constructor(private fb: FormBuilder,private auth:AuthService,private router:Router) {
    this.registerForm = this.fb.group({
      name: ['',Validators.required],
      email: ['',Validators.required],
      password: ['',Validators.required]
    });
  }

  register() {
    this.chek = true;
    this.auth.register(this.registerForm.value as User);
    this.auth.getNewUser().subscribe(us => {
      this.user = us;
    });
    if (this.user) {
      this.router.navigate(['login']);
    }
  }
}
