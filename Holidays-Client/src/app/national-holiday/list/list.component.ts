import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NationalHoliday } from '../models/national-holiday';
import { NationalHolidayService } from '../national-holiday.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {
  
  public nationalHolidays : NationalHoliday[];

  constructor(private nationalHolidayService: NationalHolidayService,
    private router: Router,
    private toastr: ToastrService) {}

  ngOnInit(): void {
    this.loadList();
  }

  loadList(){
    this.nationalHolidayService.getAllNationalHolidays()
      .subscribe(
        response => this.nationalHolidays = response
      );
  }

  resetList(){
    this.nationalHolidayService.resetNationalHoliday()
    .subscribe({
      next: () => { this.processResetSuccess() },
      error: () => { this.processError() }
    });
  }

  deleteItem(id: string){
    if(confirm("Deseja realmente deletar este feriado?")) {
      this.nationalHolidayService.deleteNationalHoliday(id)
      .subscribe({
        next: () => { this.processSuccess() },
        error: () => { this.processError() }
      });
    }
  }

  processSuccess() {
    this.loadList();
    this.toastr.success('Feriado excluido com sucesso!', 'Sucesso!');
  }

  processResetSuccess() {
    this.loadList();
    this.toastr.success('Lista resetada', 'Sucesso!');
  }

  processError(){
    this.toastr.error('Aconteceu um erro interno', 'Erro!');
  }

}
