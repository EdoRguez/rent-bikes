import { Component, Input, OnInit } from '@angular/core';
import { Bike } from '../../shared/interfaces/bike.interface';

@Component({
  selector: 'app-bikes',
  templateUrl: './bikes.component.html',
  styleUrls: ['./bikes.component.scss']
})
export class BikesComponent implements OnInit {

  @Input() listBikes: Bike[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
