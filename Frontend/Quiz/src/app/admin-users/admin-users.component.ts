import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent {


  roles = ['User','Test ishlovchi','Test tuzuvchi','Admin'];

  users: any;

  constructor(private apiSvc: ApiService,private router :Router){}


  ngOnInit(){
    this.apiSvc.getAllUsers().subscribe(result=>{
      this.users = result;
    });
  }

  navigateToEditUser(userid:Number){
    this.router.navigate(['/admin/edituser/'+userid]);
  }
}
