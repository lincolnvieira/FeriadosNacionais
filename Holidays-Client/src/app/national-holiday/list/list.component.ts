import { Component, OnInit } from '@angular/core';
import { NationalHoliday } from '../models/national-holiday';
import { NationalHolidayService } from '../national-holiday.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {
  
  public nationalHolidays : NationalHoliday[];

  constructor(private nationalHolidayService: NationalHolidayService) {}

  ngOnInit(): void {
    this.nationalHolidayService.getAllNationalHolidays()
      .subscribe(
        response => this.nationalHolidays = response
      );
  }
}
