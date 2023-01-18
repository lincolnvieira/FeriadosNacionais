import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NationalHoliday } from '../models/national-holiday';
import { NationalHolidayService } from '../national-holiday.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html'
})

export class EditComponent implements OnInit {
  id: number;
  public nationalHoliday : NationalHoliday;

  editNationalHolidayFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute, private nationalHolidayService: NationalHolidayService) {}
  
  ngOnInit(): void {
    this.editNationalHolidayFormGroup = this.formBuilder.group({
      title: [''],
      date: [''],
      description: [''],
      legislation: [''],
      type: [''],
      startTime: [''],
      endTime: ['']
    });

    this.route.params.subscribe(params => {
      this.id = params['id'];
   });

    this.nationalHolidayService.getNationalHoliday(this.id)
      .subscribe((response) => {
        this.fillForm(response);   
      }
    ); 
  }

  fillForm(response: NationalHoliday){
    this.editNationalHolidayFormGroup.patchValue({
      date: response.date,
      title: response.title,
      description: response.description,
      legislation: response.legislation,
      type: response.type,
      startTime : response.startTime,
      endTime : response.endTime
    });
  }
}