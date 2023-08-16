import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { IEmployee } from 'src/app/models/employeeModel';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-management',
  templateUrl: './employee-management.component.html',
  styleUrls: ['./employee-management.component.scss']
})
export class EmployeeManagementComponent implements OnInit {
  public employees : IEmployee[] =[];
  employeeForm!: FormGroup;

  constructor(private employeeService: EmployeeService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getEmployees()
    this.employeeForm = this.fb.group({
      name: ['', Validators.required],
      firstName: ['', Validators.required],
      email: ['', Validators.required],
      birthDate: ['', [Validators.required]],
      clientId: ['', Validators.required],
    });
  }

  onSubmit() {
    this.employeeForm.value.clientId = +this.employeeForm.value.clientId;
    if (this.employeeForm.valid) {
      this.employeeService
      .addEmployee(this.employeeForm.value)
      .subscribe((response) => {
      })
    }
  }

  deleteItem(employeeId: number): void {
    console.log(employeeId, "ffffffffffffff")
    this.employeeService
    .deleteEmployee(employeeId)
    .subscribe((response) => {
    })
  }

  getEmployees() {
    this.employeeService
      .getEmployees()
      .subscribe((data) => {
        this.employees = data;
      })
  }

}
