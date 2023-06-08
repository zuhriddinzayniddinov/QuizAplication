import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { UserMorify } from './user';

@Component({
  selector: 'app-admin-edit-user',
  templateUrl: './admin-edit-user.component.html',
  styleUrls: ['./admin-edit-user.component.css']
})
export class AdminEditUserComponent {
  user = new UserMorify();
  temp: any;
  subscription: Subscription = Subscription.EMPTY;
    constructor(private apiSvc: ApiService,private router : ActivatedRoute){ }

    ngOnInit(){
      this.user.id = Number(this.router.snapshot.paramMap.get('userid'));
      
        this.subscription = this.apiSvc.getByIdUser(this.user.id).subscribe( u => {
            this.temp = u;
        });        
    }

    refresh() {
      this.user.role = this.temp.role;
    }

    Save() {
      this.apiSvc.putUser(this.user);
    }
}
