import { Component, Inject } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-score-dialog',
  templateUrl: './score-dialog.component.html',
  styleUrls: ['./score-dialog.component.css']
})
export class ScoreDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<ScoreDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any,
    public router:Router
  ) {}

  reyta(){
    this.router.navigate([]);
  }

  play(){
    this.router.navigate(['play']);
  }
}
