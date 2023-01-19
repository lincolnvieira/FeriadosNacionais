import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NationalHoliday } from '../models/national-holiday';
import { NationalHolidayService } from '../national-holiday.service';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html'
})

export class EditComponent implements OnInit {
  id: number;
  isDisabled: boolean = true;
  public nationalHoliday : NationalHoliday;

  editNationalHolidayFormGroup: FormGroup;

  constructor(
    private formBuilder: FormBuilder, 
    private route: ActivatedRoute, 
    private nationalHolidayService: NationalHolidayService,
    private router: Router,
    private toastr: ToastrService) {}
  
  ngOnInit(): void {
    this.editNationalHolidayFormGroup = this.formBuilder.group({
      title: [{ value: '', disabled: true}],
      date: [{ value: '', disabled: true}],
      description: [{ value: ''}],
      legislation: [{ value: '', disabled: true}],
      type: [{ value: '', disabled: true}],
      startTime: [{ value: '', disabled: true}],
      endTime: [{ value: '', disabled: true}]
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

  updateNationalHoliday(){
    this.nationalHoliday = Object.assign({}, this.nationalHoliday, this.editNationalHolidayFormGroup.value);
    this.nationalHoliday.nationalHolidayId = this.id.toString();
    this.nationalHolidayService.updateNationalHoliday(this.nationalHoliday)
      .subscribe({
        next: () => { this.processSuccess() },
        error: error => { this.processError(error) }
      });
  }

  processSuccess() {
    let toast = this.toastr.success('Feriado atualizado com sucesso!', 'Sucesso!', { timeOut: 2500 });
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/list']);
      });
    }
  }
  processError(error: HttpErrorResponse){
    this.toastr.error(error.message, 'Erro!');
  }
}